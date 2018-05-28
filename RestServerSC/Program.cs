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
                    FldStr = "Sener"
                };

            });
            TblaRec a = ReflectionExample.ToProxy<TblaRec, M2DB.TblB>(tb);
            a.RowPk = tb.GetObjectNo();
            a.RowErr = "";
            a.RowState = "X";

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

            Scheduling.RunTask(() =>
            {
                // RowState: Added, Modified, Deletede, Unchanged
                Db.TransactAsync(() =>
                {
                    if (request.RowState == "A")
                    {
                        var rec = new M2DB.TblA
                        {
                            FldStr = request.FldStr,
                            FldInt = request.FldInt,
                            FldDate = new DateTime(request.FldDate)
                        };
                        //RecToObject<M2DB.TblA>();

                        RecToObject<TblaRec>(request);////////////////////

                        result.RowPk = rec.GetObjectNo();
                    }
                    else if (request.RowState == "M")
                    {
                        result.RowPk = request.RowPk;
                        var rec = Db.FromId(request.RowPk) as M2DB.TblA;
                        if (rec == null)
                        {
                            result.RowErr = "TblA Rec not found";
                        }
                        else
                        {
                            rec.FldStr = request.FldStr;
                            rec.FldInt = request.FldInt;
                            rec.FldDate = new DateTime(request.FldDate);
                        }
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

            return Task.FromResult(result);

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
            M2DB.TblA ta;

            for (int i = 0; i < 1; i++)
            {
                await Scheduling.RunTask(() =>
                {
                    foreach (var r in Db.SQL<M2DB.TblA>("select r from TblA r"))
                    {
                        ta = r;
                        hr.RowPk = r.GetObjectNo();
                        hr.FldStr = r.FldStr;
                        hr.FldInt = r.FldInt;
                        hr.FldDate = r.FldDate.Ticks;
                        //RecToObject<TblaRec>(ta);//////////////////////////////

                        Task.Run(async () =>
                        {
                            await responseStream.WriteAsync(hr);
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
            PropertyInfo[] databaseProperties = databaseType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            // proxy can be subset of database
            // proxy can have own properties
            // only take if proxyProperty in databaseProperty 
            foreach (PropertyInfo proxyProperty in proxyProperties)
            {
                PropertyInfo databaseProperty = databaseProperties.FirstOrDefault(x => x.Name == proxyProperty.Name);

                if (databaseProperty != null)
                {
                    object value = databaseProperty.GetValue(row);

                    value = ConvertToProxyValue(databaseProperty.PropertyType, value);
                    proxyProperty.SetValue(proxy, value);
                }
            }
            
            PropertyInfo proxyRowPk = proxyProperties.FirstOrDefault(x => x.Name == "RowPk");
            if (proxyRowPk != null)
                proxyRowPk.SetValue(proxy,row.GetObjectNo());
            
            // Should every proxy hase rowPk property? Maybe not, use above
            // proxy.GetType().GetProperty("RowPk").SetValue(proxy, row.GetObjectNo());

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
            /*
            if (proxy.ObjectNo > 0)
            {
                row = Db.FromId<TDatabase>(proxy.ObjectNo);
            }
            else
            {
                row = new TDatabase();
            }
            */
            foreach (PropertyInfo databaseProperty in databaseProperties)
            {
                PropertyInfo proxyProperty = proxyProperties.FirstOrDefault(x => x.Name == databaseProperty.Name);

                if (databaseProperty == null)
                {
                    throw new KeyNotFoundException($"There is no property {databaseProperty.Name} in {proxyType}!");
                }

                object value = proxyProperty.GetValue(proxy);

                value = ConvertToDatabaseValue(databaseProperty.PropertyType, value);
                databaseProperty.SetValue(row, value);
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