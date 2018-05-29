using System;
using System.Threading.Tasks;
using Starcounter;
using Grpc.Core;
using Rest;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RestServerSC
{
    class Program
    {
        const int Port = 50051;

        static void Main()
        {
            M2DB.TblB tb = null;

            Db.Transact(() =>
            {
                tb = new M2DB.TblB
                {
                    FldStr = "Sener",
                    FldDate = DateTime.Now
                };

            });
            TblaRec a = ReflectionExample.ToProxy<TblaRec, M2DB.TblB>(tb);
            a.RowErr = "";

            Console.WriteLine("Deneme");

            a.FldStr = a.FldStr.ToUpper();
            //a.RowPk = 0;

            Db.Transact(() =>
            {
                // Converting the proxy object into the database object.
                // This will set the database object property values.
                // Those the changes made to the proxy object will be saved to the database.
                M2DB.TblB tblb = ReflectionExample.FromProxy<TblaRec, M2DB.TblB>(a);
            });

            Console.WriteLine("Deneme");


            Server server = new Server
            {
                Services = { CRUDs.BindService(new CRUDsImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                //Ports = { new ServerPort("217.160.13.102", Port, ServerCredentials.Insecure) }
                //Ports = { new ServerPort("192.168.1.20", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Rest server listening on port " + Port);

        }

        // Reflection yerine fastMember kullanilabilir, hizli ama gerekli mi?
        // https://github.com/mgravell/fast-member

    }

    class CRUDsImpl : Rest.CRUDs.CRUDsBase
    {
        public static void RecToObject<T>(object obj)
        {

            var propList = typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Type typ;
            object objVal;
            foreach (MemberInfo info in propList)
            {
                if (info is PropertyInfo)
                {
                    typ = (info as PropertyInfo).PropertyType;
                    objVal = obj.GetType().GetProperty(info.Name).GetValue(obj);

                }
                else if (info is FieldInfo)
                    typ = (info as FieldInfo).FieldType;

                //dt.Columns.Add(new DataColumn(info.Name, (info as PropertyInfo).PropertyType));
                //else if (info is FieldInfo)
                //    dt.Columns.Add(new DataColumn(info.Name, (info as FieldInfo).FieldType));
            }

        }

        public override Task<TblaRec> TblaUpdate(TblaRec request, ServerCallContext context)
        {
            var result = new TblaRec
            {
                RowPk = request.RowPk,
                FldStr = request.FldStr,
                FldDbl = request.FldDbl,
                FldDcm = request.FldDcm,
                FldDate = request.FldDate,
                FldInt = request.FldInt
            };

            TblaRec proxy = null;
            Scheduling.RunTask(() =>
            {
                // RowState: Added, Modified, Deletede, Unchanged
                Db.TransactAsync(() =>
                {
                    if (request.RowState == "A" || request.RowState == "M")
                    {
                        //var rec = new M2DB.TblA
                        //{
                        //    FldStr = request.FldStr,
                        //    FldInt = request.FldInt,
                        //    FldDate = new DateTime(request.FldDate)
                        //};
                        //RecToObject<M2DB.TblA>();

                        //RecToObject<TblaRec>(request);////////////////////
                        M2DB.TblB row = ReflectionExample.FromProxy<TblaRec, M2DB.TblB>(request);
                        proxy = ReflectionExample.ToProxy<TblaRec, M2DB.TblB>(row);

                        //result.RowPk = row.GetObjectNo();
                    }
                    else if (request.RowState == "D")
                    {
                        result.RowPk = request.RowPk;
                        var rec = Db.FromId(request.RowPk) as M2DB.TblA;
                        if (rec == null)
                        {
                            result.RowErr = "TblA Rec not found";
                        }
                        else
                        {
                            rec.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(proxy);

        }

        public override async Task TblaFill(QryStr request, IServerStreamWriter<TblaRec> responseStream, ServerCallContext context)
        {
            var hr = new TblaRec
            {
                RowPk = 1,
                FldStr = "Bir",
                FldDbl = 1.23,
                FldDcm = 2.34,
                FldDate = DateTime.Now.Ticks,
                FldInt = 1
            };


            for (int i = 0; i < 1; i++)
            {
                await Scheduling.RunTask(() =>
                {
                    foreach (var row in Db.SQL<M2DB.TblB>("select r from TblB r"))
                    {
                        //hr.RowPk = r.GetObjectNo();
                        //hr.FldStr = r.FldStr;
                        //hr.FldInt = r.FldInt;
                        //hr.FldDate = r.FldDate.Ticks;

                        TblaRec proxy = ReflectionExample.ToProxy<TblaRec, M2DB.TblB>(row);

                        Task.Run(async () =>
                        {
                            await responseStream.WriteAsync(proxy);
                        }).Wait();
                    }
                });
            }
            /*
            for (int i = 0; i < 10000; i++)
            {
                hr.Ono = (ulong)i;
                await responseStream.WriteAsync(hr);
            }*/
        }
    }


    public static class ReflectionExample
    {

        public static TProxy ToProxy<TProxy, TDatabase>(TDatabase row)
            where TProxy : class, new()
        {
            TProxy proxy = new TProxy();
            Type proxyType = typeof(TProxy);
            Type databaseType = typeof(TDatabase);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();
            PropertyInfo[] databaseProperties = databaseType.GetProperties().Where(x => x.CanRead).ToArray();
            //PropertyInfo[] databaseProperties = databaseType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            // only take if proxyProperty exists in databaseProperties 
            // proxy can be subset of database
            // proxy can have own properties
            // database can have computed/ReadOnly properties, copy also
            foreach (PropertyInfo proxyProperty in proxyProperties)
            {
                PropertyInfo databaseProperty = databaseProperties.FirstOrDefault(x => x.Name == proxyProperty.Name);
                // Which one is efficient?
                var dbP = row.GetType().GetProperty(proxyProperty.Name)?.GetValue(row);

                if (databaseProperty != null)
                {
                    object value = databaseProperty.GetValue(row);

                    value = ConvertToProxyValue(databaseProperty.PropertyType, value);
                    proxyProperty.SetValue(proxy, value);
                }
            }
            
            //PropertyInfo proxyRowPk = proxyProperties.FirstOrDefault(x => x.Name == "RowPk");
            //if (proxyRowPk != null)
            //    proxyRowPk.SetValue(proxy,row.GetObjectNo());
            
            // Should every proxy hase rowPk property? Maybe not
            proxy.GetType().GetProperty("RowPk")?.SetValue(proxy, row.GetObjectNo());

            return proxy;
        }

        public static TDatabase FromProxy<TProxy, TDatabase>(TProxy proxy)
            where TDatabase : class, new()
        {
            TDatabase row = null;
            Type proxyType = typeof(TProxy);
            Type databaseType = typeof(TDatabase);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();
            PropertyInfo[] databaseProperties = databaseType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            ulong pk = (ulong)proxy.GetType().GetProperty("RowPk")?.GetValue(proxy);

            if (pk > 0)
                row = Db.FromId<TDatabase>(pk);
            else
                row = new TDatabase();

            foreach (PropertyInfo databaseProperty in databaseProperties)
            {
                PropertyInfo proxyProperty = proxyProperties.FirstOrDefault(x => x.Name == databaseProperty.Name);

                if (proxyProperty != null)
                {
                    object value = proxyProperty.GetValue(proxy);

                    value = ConvertToDatabaseValue(databaseProperty.PropertyType, value);
                    databaseProperty.SetValue(row, value);
                }
            }

            return row;
        }

        public static object ConvertToProxyValue(Type databaseType, object value)
        {
            if (value == null)
            {
                return value;
            }

            if (databaseType == typeof(decimal))
            {
                return Convert.ToDouble(value);
            }
            else if (databaseType == typeof(decimal?))
            {
                decimal? v = value as decimal?;
                return (double?)Convert.ToDouble(v.Value);
            }
            else if (databaseType == typeof(DateTime))
            {
                DateTime v = (DateTime)value;
                return v.Ticks;
            }
            else if (databaseType == typeof(DateTime?))
            {
                DateTime? v = value as DateTime?;
                return (long?)(v.Value.Ticks);
            }

            return value;
        }

        public static object ConvertToDatabaseValue(Type databaseType, object value)
        {
            if (value == null)
            {
                return value;
            }

            if (databaseType == typeof(decimal))
            {
                return Convert.ToDecimal(value);
            }
            else if (databaseType == typeof(decimal?))
            {
                double? v = value as double?;
                return (decimal?)Convert.ToDecimal(v.Value);
            }
            else if (databaseType == typeof(DateTime))
            {
                long v = (long)value;
                return new DateTime(v);
            }
            else if (databaseType == typeof(DateTime?))
            {
                long? v = value as long?;
                return (DateTime?)(new DateTime(v.Value));
            }

            return value;
        }

    }
}