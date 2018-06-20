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
                            HspNo = row.HspNo,
                            HasH = row.HasH,
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
                        //else if (request.RowState == "A" && Db.SQL<AHP>("select r from AHP r where r.ObjP.ObjectNo = ? and r.No = ?", request.ObjP, request.No).FirstOrDefault() != null)
                        else if (request.RowState == "A" && Db.SQL<AHP>($"select r from {typeof(AHP)} r where {nameof(AHP.ObjP)}.ObjectNo = ? and r.No = ?", request.ObjP, request.No).FirstOrDefault() != null)
                            request.RowErr = $"{rec.Ad} altında No: {request.No} kullanılmış";
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
                            if (Db.SQL<AHP>("select r from AHP r where r.ObjP.ObjectNo = ?", request.RowPk).FirstOrDefault() != null)
                                request.RowErr = $"Alt hesabı var silemezsiniz";
                            else
                                rec.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task AFBfill(QryProxy request, IServerStreamWriter<AFBproxy> responseStream, ServerCallContext context)
        {
            AFBproxy proxy = new AFBproxy();
            List<AFBproxy> proxyList = new List<AFBproxy>();

            Type proxyType = typeof(AFBproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<AFB>("select r from AFB r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new AFBproxy
                        {
                            RowPk = row.GetObjectNo(),
                            Trh = ((DateTime)row.Trh).Ticks,
                            ObjTur = row.ObjTur == null ? 0 : row.ObjTur.GetObjectNo(),
                            AoK = row.AoK,
                            Info = row.Info ?? "",
                            BrcTop = row.BrcTop,
                            AlcTop = row.AlcTop,
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

        public override Task<AFBproxy> AFBupdate(AFBproxy request, ServerCallContext context)
        {
            var proxy = new AFBproxy
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
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            AFB row = CRUDsHelper.FromProxy<AFBproxy, AFB>(request);
                            request = CRUDsHelper.ToProxy<AFBproxy, AFB>(row);
                        }

                    }
                    else if (request.RowState == "D")
                    {
                        var rec = (AFB)Db.FromId(request.RowPk);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<AFD>("select r from AFD r where r.ObjAFB.ObjectNo = ?", request.RowPk).FirstOrDefault() != null)
                                request.RowErr = $"Detayı var silemezsiniz.";
                            else
                                rec.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task AFDfill(QryProxy request, IServerStreamWriter<AFDproxy> responseStream, ServerCallContext context)
        {
            AFDproxy proxy = new AFDproxy();
            List<AFDproxy> proxyList = new List<AFDproxy>();
            string sel = $"SELECT r FROM AFD r WHERE r.{request.Query}";

            Type proxyType = typeof(AFDproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<AFD>(sel, ulong.Parse(request.Param)))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new AFDproxy
                    {
                        RowPk = row.GetObjectNo(),
                        ObjAFB = row.ObjAFB == null ? 0 : row.ObjAFB.GetObjectNo(),
                        ObjAHP = row.ObjAHP == null ? 0 : row.ObjAHP.GetObjectNo(),
                        Info = row.Info,
                        Tut = row.Tut,
                        ObjDvz = row.ObjDvz == null ? 0 : row.ObjDvz.GetObjectNo(),
                        Kur = row.Kur,
                        TutTL = row.TutTL,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }

        public override Task<AFDproxy> AFDupdate(AFDproxy request, ServerCallContext context)
        {
            var proxy = new AFDproxy
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
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            AFD row = CRUDsHelper.FromProxy<AFDproxy, AFD>(request);
                            request = CRUDsHelper.ToProxy<AFDproxy, AFD>(row);
                        }

                    }
                    else if (request.RowState == "D")
                    {
                        var rec = (AFD)Db.FromId(request.RowPk);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task XGTfill(QryProxy request, IServerStreamWriter<XGTproxy> responseStream, ServerCallContext context)
        {
            XGTproxy proxy = new XGTproxy();
            List<XGTproxy> proxyList = new List<XGTproxy>();

            Type proxyType = typeof(XGTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<XGT>("select r from XGT r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new XGTproxy
                        {
                            RowPk = row.GetObjectNo(),
                            ObjP = row.ObjP == null ? 0 : row.ObjP.GetObjectNo(),
                            Kd = row.Kd,
                            Ad = row.Ad,
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

        public override Task<XGTproxy> XGTupdate(XGTproxy request, ServerCallContext context)
        {
            var proxy = new XGTproxy
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
                        var rec = (XGT)Db.FromId(request.ObjP);

                        if (request.RowErr == string.Empty)
                        {
                            XGT row = CRUDsHelper.FromProxy<XGTproxy, XGT>(request);
                            request = CRUDsHelper.ToProxy<XGTproxy, XGT>(row);
                        }

                    }
                    else if (request.RowState == "D")
                    {
                        var rec = (XGT)Db.FromId(request.RowPk);
                        if (rec == null)
                        {
                            request.RowErr = "AHP Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<XGT>("select r from XGT r where r.ObjP.ObjectNo = ?", request.RowPk).FirstOrDefault() != null)
                                request.RowErr = $"Alt hesabı var silemezsiniz";
                            else
                                rec.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task XDKfill(QryProxy request, IServerStreamWriter<XDKproxy> responseStream, ServerCallContext context)
        {
            XDKproxy proxy;// = new XDKproxy();
            List<XDKproxy> proxyList = new List<XDKproxy>();
            Type proxyType = typeof(XGTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();
            long dtt = 0;
            DateTime dt;
            if (request.Query == "Trh")
            {
                dtt = long.Parse(request.Param);
                dt = new DateTime(dtt);
                //var rows = Db.SQL<XDK>("select r from XDK r");

                var aaa = dt;
                await Scheduling.RunTask(() =>
                {
                    var dvzP = Db.SQL<XGT>("SELECT r FROM XGT r WHERE r.ObjP IS NULL and r.Kd = ?", "Dvz").FirstOrDefault();
                    var dvzs = Db.SQL<XGT>("SELECT r FROM XGT r WHERE r.ObjP = ?", dvzP);

                    foreach (var dvz in dvzs)
                    {
                        var row = Db.SQL<XDK>("select r from XDK r WHERE r.Trh = ? and r.ObjDvz = ?", dt, dvz).FirstOrDefault();
                        if(row == null)
                        {
                            proxy = new XDKproxy
                            {
                                RowPk = 0,
                                ObjDvz = dvz.GetObjectNo(),
                                Trh = dt.Ticks,
                                Kur = dvz.Kd == "TRL" ? 1 : 0,
                                Dvz = dvz.Kd,
                            };
                        }
                        else
                            proxy = CRUDsHelper.ToProxy<XDKproxy, XDK>(row);

                        proxyList.Add(proxy);
                    }
                });

            }
            else
            {
                await Scheduling.RunTask(() =>
                {
                    var rows = Db.SQL<XDK>("select r from XDK r");
                    foreach (var row in rows)
                    {
                        proxy = CRUDsHelper.ToProxy<XDKproxy, XDK>(row);

                        proxyList.Add(proxy);
                    }
                });
            }
            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }

        public override Task<XDKproxy> XDKupdate(XDKproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowState: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowState == "A" || request.RowState == "M")
                    {
                        if (request.RowErr == string.Empty)
                        {
                            XDK row = CRUDsHelper.FromProxy<XDKproxy, XDK>(request);
                            request = CRUDsHelper.ToProxy<XDKproxy, XDK>(row);
                        }

                    }
                    else if (request.RowState == "D")
                    {
                        var rec = (XDK)Db.FromId(request.RowPk);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

    }

}
