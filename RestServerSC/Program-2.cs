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
            /*
            M2DB.TblB tb = null;

            Db.Transact(() =>
            {
                tb = new M2DB.TblB
                {
                    FldStr = "Sener",
                    FldDate = DateTime.Now
                };

            });
            TblaProxy a = ReflectionExample.ToProxy<TblaProxy, M2DB.TblB>(tb);
            a.RowErr = "";

            Console.WriteLine("Deneme");

            a.FldStr = a.FldStr.ToUpper();
            //a.RowPk = 0;

            Db.Transact(() =>
            {
                // Converting the proxy object into the database object.
                // This will set the database object property values.
                // Those the changes made to the proxy object will be saved to the database.
                M2DB.TblB tblb = ReflectionExample.FromProxy<TblaProxy, M2DB.TblB>(a);
            });
*/
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

        public override Task<TblaProxy> TblaUpdate(TblaProxy request, ServerCallContext context)
        {
            var result = new TblaProxy
            {
                RowPk = request.RowPk,
                FldStr = request.FldStr,
                FldDbl = request.FldDbl,
                FldDcm = request.FldDcm,
                FldDate = request.FldDate,
                FldInt = request.FldInt
            };

            TblaProxy proxy = null;
            Scheduling.RunTask(() =>
            {
                // RowState: Added, Modified, Deletede, Unchanged
                Db.TransactAsync(() =>
                {
                    if (request.RowState == "A" || request.RowState == "M")
                    {
                        M2DB.TblB row = ReflectionExample.FromProxy<TblaProxy, M2DB.TblB>(request);
                        proxy = ReflectionExample.ToProxy<TblaProxy, M2DB.TblB>(row);
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

        public  async Task TblaFill2(QryProxy request, IServerStreamWriter<TblaProxy> responseStream, ServerCallContext context)
        {
            var proxy = new TblaProxy();
            proxy.RowPk = 1;

            await Scheduling.RunTask( () =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Task.Run(async () =>
                    {
                        foreach (var row in Db.SQL<M2DB.TblB>("select r from TblB r"))
                        {
                            proxy = ReflectionExample.ToProxy<TblaProxy, M2DB.TblB>(row);
                        
                            await responseStream.WriteAsync(proxy);
                        }
                    }).Wait();

                    //await responseStream.WriteAsync(proxy);
                }
            });

        }

        public  async Task TblaFill3(QryProxy request, IServerStreamWriter<TblaProxy> responseStream, ServerCallContext context)
        {
            var proxy = new TblaProxy();
            proxy.RowPk = 1;
            List<TblaProxy> pl = new List<TblaProxy>();

            // Transfer 14K proxy/sec
            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    foreach (var row in Db.SQL<M2DB.TblB>("select r from TblB r"))
                    {
                        //proxy = ReflectionExample.ToProxy<TblaProxy, M2DB.TblB>(row);
                        proxy.FldStr = row.FldStr;
                        proxy.FldInt = row.FldInt;
                        proxy.FldDbl = row.FldDbl;
                        proxy.FldDcm = Convert.ToDouble(row.FldDcm);
                        pl.Add(proxy);

                        //Task.Run(async () =>
                        //{
                        //    await responseStream.WriteAsync(proxy);
                        //}).Wait();
                    }
                }
            });
            
            foreach(var p in pl)
            {
                await responseStream.WriteAsync(p);
            }

            /*
            // Transfer 9K proxy/sec
            for (int i = 0; i < 1000; i++)
            {
                await Scheduling.RunTask(() =>
                {
                    foreach (var row in Db.SQL<M2DB.TblB>("select r from TblB r"))
                    {
                        proxy = ReflectionExample.ToProxy<TblaProxy, M2DB.TblB>(row);

                        Task.Run(async () =>
                        {
                            await responseStream.WriteAsync(proxy);
                        }).Wait();
                    }
                });
            }
            */
            /*
            // Transfer 20K proxy/sec
            for (int i = 0; i < 100000; i++)
            {
                await responseStream.WriteAsync(proxy);
            }*/
        }

        public override async Task TblaFill(QryProxy request, IServerStreamWriter<TblaProxy> responseStream, ServerCallContext context)
        {
            int kxx = 1;
            var proxy = new TblaProxy();
            proxy.RowPk = 1;
            List<TblaProxy> pl = new List<TblaProxy>();

            Type proxyType = typeof(TblaProxy);
            Type senert = typeof(M2DB.TblB);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();
            PropertyInfo[] sener = senert.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();
            /*
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int j = 0; j < proxyProperties.Length; j++)
            {
                Console.WriteLine(kxx.ToString());
                for (int k = 0; k < sener.Length; k++)
                {
                    Console.WriteLine($"{j},{k} : {proxyProperties[j].Name} {sener[k].Name}");
                    if (proxyProperties[j].Name == sener[k].Name)
                    {
                        dic[j] = k;
                        break;
                    }
                }
            }
            Console.WriteLine(kxx.ToString());
            */
            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    foreach (var row in Db.SQL<M2DB.TblB>("select r from TblB r"))
                    {
                        //proxy = ReflectionExample.ToProxy<TblaProxy, M2DB.TblB>(row);
                        
                        proxy = new TblaProxy
                        {
                            RowPk = row.GetObjectNo(),
                            FldStr = row.FldStr,
                            FldInt = row.FldInt,
                            FldDbl = row.FldDbl,
                            FldDcm = Convert.ToDouble(row.FldDcm),
                            FldDate = ((DateTime)row.FldDate).Ticks,
                        };

                        /*
                        foreach(var d in dic)
                        {
                            object value = sener[d.Value].GetValue(row);
                            value = ReflectionExample.ConvertToProxyValue(sener[d.Value].PropertyType, value);
                            proxyProperties[d.Key].SetValue(proxy, value);
                        }
                        /*
                        foreach (PropertyInfo proxyProperty in proxyProperties)
                        {
                            //PropertyInfo databaseProperty = databaseProperties.FirstOrDefault(x => x.Name == proxyProperty.Name);
                            // Which one is efficient? Both are same
                            var dbP = row.GetType().GetProperty(proxyProperty.Name); //?.GetValue(row);
                            var sss = sener[0].GetValue(row);
                            if (dbP != null)
                            {
                                object value = dbP.GetValue(row);

                                value = ReflectionExample.ConvertToProxyValue(dbP.PropertyType, value);
                                proxyProperty.SetValue(proxy, value);
                            }
                        }
                        */


                        pl.Add(proxy);

                        //Task.Run(async () =>
                        //{
                        //    await responseStream.WriteAsync(proxy);
                        //}).Wait();
                    }
                }
            });
            
            foreach (var p in pl)
            {
                await responseStream.WriteAsync(p);
            }
            
            /*
            // Transfer 9K proxy/sec
            for (int i = 0; i < 1000; i++)
            {
                await Scheduling.RunTask(() =>
                {
                    foreach (var row in Db.SQL<M2DB.TblB>("select r from TblB r"))
                    {
                        proxy = ReflectionExample.ToProxy<TblaProxy, M2DB.TblB>(row);

                        Task.Run(async () =>
                        {
                            await responseStream.WriteAsync(proxy);
                        }).Wait();
                    }
                });
            }
            */
            /*
            // Transfer 20K proxy/sec
            for (int i = 0; i < 100000; i++)
            {
                await responseStream.WriteAsync(proxy);
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
            //Type databaseType = typeof(TDatabase);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();
            //PropertyInfo[] databaseProperties = databaseType.GetProperties().Where(x => x.CanRead).ToArray();
            //PropertyInfo[] databaseProperties = databaseType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            // only take if proxyProperty exists in databaseProperties 
            // proxy can be subset of database
            // proxy can have own properties
            // database can have computed/ReadOnly properties, copy also
            foreach (PropertyInfo proxyProperty in proxyProperties)
            {
                //PropertyInfo databaseProperty = databaseProperties.FirstOrDefault(x => x.Name == proxyProperty.Name);
                // Which one is efficient? Both are same
                var dbP = row.GetType().GetProperty(proxyProperty.Name); //?.GetValue(row);

                if (dbP != null)
                {
                    object value = dbP.GetValue(row);

                    value = ConvertToProxyValue(dbP.PropertyType, value);
                    proxyProperty.SetValue(proxy, value);
                }
                //if (databaseProperty != null)
                //{
                //    object value = databaseProperty.GetValue(row);
                //
                //    value = ConvertToProxyValue(databaseProperty.PropertyType, value);
                //    proxyProperty.SetValue(proxy, value);
                //}
            }

            //PropertyInfo proxyRowPk = proxyProperties.FirstOrDefault(x => x.Name == "RowPk");
            //if (proxyRowPk != null)
            //    proxyRowPk.SetValue(proxy,row.GetObjectNo());

            // Should every proxy hase rowPk property? Maybe not
            //proxy.GetType().GetProperty("RowPk")?.SetValue(proxy, row.GetObjectNo());

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