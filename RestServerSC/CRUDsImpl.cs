using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Rest;
using System.Reflection;
using Starcounter;

namespace RestServerSC
{
    class CRUDsImpl : Rest.CRUDs.CRUDsBase
    {
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

        public override async Task TblaFill(QryProxy request, IServerStreamWriter<TblaProxy> responseStream, ServerCallContext context)
        {
            TblaProxy proxy = new TblaProxy();
            List<TblaProxy> proxyList = new List<TblaProxy>();

            Type proxyType = typeof(TblaProxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

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

                        proxyList.Add(proxy);

                        //Task.Run(async () =>
                        //{
                        //    await responseStream.WriteAsync(proxy);
                        //}).Wait();
                    }
                }
            });

            foreach (var p in proxyList)
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
            // Transfer 22K proxy/sec
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
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            // only take if proxyProperty exists in databaseProperties 
            // proxy can be subset of database
            // proxy can have own properties
            // database can have computed/ReadOnly properties, copy also
            foreach (PropertyInfo proxyProperty in proxyProperties)
            {
                var dbP = row.GetType().GetProperty(proxyProperty.Name); //?.GetValue(row);

                if (dbP != null)
                {
                    object value = dbP.GetValue(row);

                    value = ConvertToProxyValue(dbP.PropertyType, value);
                    proxyProperty.SetValue(proxy, value);
                }
            }

            return proxy;
        }

        public static TDatabase deneme<TDatabase>(ulong? v)
            where TDatabase : class, new()
        {
            TDatabase row = null;
            Type databaseType = typeof(TDatabase);
            PropertyInfo[] databaseProperties = databaseType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            PropertyInfo dbProperty = databaseProperties.FirstOrDefault(x => x.Name == "P");    // ObjectReference AHT P
            Type aaa = dbProperty.GetType();
            //typeof(dbProperty.GetType());

            object result = Convert.ChangeType((decimal)2.12345, typeof(double));//dbProperty.GetType());

            row = Db.FromId<TDatabase>(4);

            if (v != null && dbProperty.PropertyType.GetTypeInfo().IsClass && dbProperty.PropertyType != typeof(string))
                dbProperty.SetValue(row, Db.FromId((ulong)v)); //v.GetObjectNo());  //Db.FromId(2));
            else
                dbProperty.SetValue(row, v);
            /*
            if (dbProperty.PropertyType.IsSerializable)
                dbProperty.SetValue(row, v);
            else
                dbProperty.SetValue(row, Db.FromId(v));// v.GetObjectNo());  //Db.FromId(2));
            */
            return row;
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
