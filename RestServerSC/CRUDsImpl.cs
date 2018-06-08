using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Rest;
using System.Reflection;
using Starcounter;
using M2DB;

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
                        M2DB.TblB row = CRUDsHelper.FromProxy<TblaProxy, M2DB.TblB>(request);
                        proxy = CRUDsHelper.ToProxy<TblaProxy, M2DB.TblB>(row);
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

        public override async Task AHPfill(QryProxy request, IServerStreamWriter<AHPproxy> responseStream, ServerCallContext context)
        {
            AHPproxy proxy = new AHPproxy();
            List<AHPproxy> proxyList = new List<AHPproxy>();

            Type proxyType = typeof(AHPproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<AHP>("select r from AHP r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);
                        
                        proxy = new AHPproxy
                        {
                            RowPk = row.GetObjectNo(),
                            ObjP = row.ObjP == null ? 0 : row.ObjP.GetObjectNo(),
                            No = row.No,
                            Ad = row.Ad,
                            HspNo = row.HspNo
                        };
                        
                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }

        public override Task<AHPproxy> AHPupdate(AHPproxy request, ServerCallContext context)
        {
            var proxy = new AHPproxy
            {
                RowPk = request.RowPk,
            };

            Scheduling.RunTask(() =>
            {
                // RowState: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowState == "A" || request.RowState == "M")
                    {
                        // Hata deneme
                        //request.RowErr = "HATA";

                        // Add Control
                        // Parent Hesabi olmali
                        // Parent Hesap altinada No uniqe olmali 
                        // Parent Hareketleri olmamali
                        var rec = (AHP)Db.FromId(request.ObjP);
                        if (request.ObjP > 0 &&  rec == null)
                            request.RowErr = "Üst Hesabı tanımsız";
                        else if (request.RowState == "A" && Db.SQL<AHP>("select r from AHP r where r.ObjP.ObjectNo = ? and r.No = ?", request.ObjP, request.No).FirstOrDefault() != null)
                            request.RowErr = $"{rec.HspNo} altında No: {request.No} kullanılmış";
                        else if (Db.SlowSQL<AFD>("select r from AFD r where r.ObjectNo = ?", request.ObjP).FirstOrDefault() != null)
                            request.RowErr = "Çalışan hesaba alt hesap açamazsınız";

                        if (request.RowErr == string.Empty)
                        {
                            AHP row = CRUDsHelper.FromProxy<AHPproxy, AHP>(request);
                            request = CRUDsHelper.ToProxy<AHPproxy, AHP>(row);
                        }

                    }
                    else if (request.RowState == "D")
                    {
                        var rec = (AHP)Db.FromId(request.RowPk);
                        if (rec == null)
                        {
                            request.RowErr = "AHP Rec not found";
                        }
                        else
                        {
                            rec.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }
    }

}
