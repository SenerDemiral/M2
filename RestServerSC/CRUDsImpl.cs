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
using System.Data;

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
                // RowSte: Added, Modified, Deletede, Unchanged
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


        // HesapPlani
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
                            RowKey = row.GetObjectNo(),
                            P = row.P == null ? 0 : row.P.GetObjectNo(),
                            No = row.No,
                            Ad = row.Ad,
                            HspNo = row.HspNo,
                            IsW = row.IsW,
                            HasH = row.HasH,
                            Brc = row.Brc,
                            Alc = row.Alc,
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
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Hata deneme
                        //request.RowErr = "HATA";

                        // Add Control
                        // Parent Hesabi olmali
                        // Parent Hesap altinada No uniqe olmali 
                        // Parent Hareketleri olmamali

                        AHP pAhp = (AHP)Db.FromId(request.P);
                        if (request.RowSte == "A")
                        {
                            if (request.P > 0 && pAhp == null)
                                request.RowErr = "Üst Hesabı tanımsız";
                            else if (pAhp.IsW || pAhp.HasH)
                                request.RowErr = "Çalışan hesaba alt hesap açamazsınız";
                            else if (!AHP.IsAhpNoUnique(pAhp, request.No))
                                request.RowErr = $"No: {request.No} kullanılmış";
                        }
                        else if (request.RowSte == "M")
                        {
                            AHP oldRec = Db.FromId<AHP>(request.RowKey);
                            if (request.IsW && oldRec.HasK)
                                request.RowErr = "Üst hesap çalışamaz.";
                            else if (!request.IsW && oldRec.HasH)
                                request.RowErr = "Çalışan hesap, Hareketleri var.";
                            else if (oldRec.No != request.No && !AHP.IsAhpNoUnique(pAhp, request.No))
                                request.RowErr = $"No: {request.No} kullanılmış";
                        }

                        if (request.RowErr == string.Empty)
                        {
                            AHP row = CRUDsHelper.FromProxy<AHPproxy, AHP>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<AHPproxy, AHP>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        var row = (AHP)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "AHP Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<AHP>("select r from AHP r where r.P.ObjectNo = ?", request.RowKey).FirstOrDefault() != null)
                                request.RowErr = $"Alt hesabı var silemezsiniz";
                            else
                            {
                                UHT.Append(request.RowUsr, request.RowKey, request.RowSte);
                                row.Delete();
                            }
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override Task<AFBproxy> AFBgetByPK(PKproxy request, ServerCallContext context)
        {
            AFBproxy prxy = new AFBproxy();
            Scheduling.RunTask(() =>
            {
                AFB afb = Db.FromId(request.PK) as AFB;
                prxy = CRUDsHelper.ToProxy<AFBproxy, AFB>(afb);
            }).Wait();

            return Task.FromResult(prxy);
        }

        
        // Fis
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
                            RowKey = row.GetObjectNo(),
                            Trh = ((DateTime)row.Trh).Ticks,
                            TUR = row.TUR == null ? 0 : row.TUR.GetObjectNo(),
                            Drm = row.Drm,
                            Info = row.Info, //row.Info ?? "",
                            Brc = row.Brc,
                            Alc = row.Alc,
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
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    request.RowErr = "";
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        if(request.RowSte == "M")
                        {
                            AFB sonAFB = Db.FromId<AFB>(request.RowKey);
                            if (request.Drm == "P")
                            {
                                if (sonAFB.Drm == "P")
                                {
                                    request = CRUDsHelper.ToProxy<AFBproxy, AFB>(sonAFB);   // Recent Row gonder, baskasi tarafindan degistirilmis
                                    request.RowErr = "LOCKED Already";
                                }
                                else
                                {
                                    request = CRUDsHelper.ToProxy<AFBproxy, AFB>(sonAFB);   // Recent Row gonder, baskasi tarafindan degistirilmis
                                    request.Drm = "P";
                                }
                            }
                            else if (request.Drm == "K")
                            {
                                if (sonAFB.Brc != sonAFB.Alc)
                                    request.RowErr = "Brc = Alc olmalı.";
                            }
                        }
                        if (request.RowErr == string.Empty)
                        {
                            if (request.TUR == 0)
                                request.TUR = GnlOps.XGTfind("AFB.TUR", "MHS").GetObjectNo();

                            AFB row = CRUDsHelper.FromProxy<AFBproxy, AFB>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<AFBproxy, AFB>(row);
                        }

                    }
                    else if (request.RowSte == "D" && request.Drm == "A")
                    {
                        var row = (AFB)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<AFD>("select r from AFD r where r.AFB.ObjectNo = ?", request.RowKey).FirstOrDefault() != null)
                                request.RowErr = $"Detayı var silemezsiniz.";
                            else
                            {
                                UHT.Append(request.RowUsr, request.RowKey, request.RowSte);
                                row.Delete();
                            }
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
                        RowKey = row.GetObjectNo(),
                        AFB = row.AFB == null ? 0 : row.AFB.GetObjectNo(),
                        AHP = row.AHP == null ? 0 : row.AHP.GetObjectNo(),
                        Info = row.Info,
                        Tut = row.Tut,
                        DVT = row.DVT == null ? 0 : row.DVT.GetObjectNo(),
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
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            AFD row = CRUDsHelper.FromProxy<AFDproxy, AFD>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<AFDproxy, AFD>(row);
                        }
                    }
                    else if (request.RowSte == "D")
                    {
                        var row = (AFD)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            UHT.Append(request.RowUsr, request.RowKey, request.RowSte);
                            row.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }


        // Bill/Fatura
        public override async Task ABBfill(QryProxy request, IServerStreamWriter<ABBproxy> responseStream, ServerCallContext context)
        {
            ABBproxy proxy = new ABBproxy();
            List<ABBproxy> proxyList = new List<ABBproxy>();

            Type proxyType = typeof(ABBproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<ABB>("select r from ABB r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new ABBproxy
                        {
                            RowKey = row.GetObjectNo(),
                            Trh = ((DateTime)row.Trh).Ticks,
                            TUR = row.TUR == null ? 0 : row.TUR.GetObjectNo(),
                            KFT = row.KFT == null ? 0 : row.KFT.GetObjectNo(),
                            DVT = row.DVT == null ? 0 : row.DVT.GetObjectNo(),
                            BA = row.BA,
                            Kur = row.Kur,
                            Drm = row.Drm,
                            Info = row.Info, //row.Info ?? "",
                            Tut = row.Tut,
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

        public override Task<ABBproxy> ABBupdate(ABBproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    request.RowErr = "";
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        if (request.RowSte == "M")
                        {
                            ABB latestRec = Db.FromId<ABB>(request.RowKey);  // Record'un enSon/enYeni/Guncel hali
                            if (request.Drm == "P")
                            {
                                request = CRUDsHelper.ToProxy<ABBproxy, ABB>(latestRec);   // Latest Row gonder, baskasi tarafindan degistirilmis
                                if (latestRec.Drm == "P")
                                    request.RowErr = "LOCKED Already";
                                else
                                    request.Drm = "P";
                            }
                            else if (request.Drm == "K")    // Kapama istegi
                            {
                                request.RowErr = "Not implemented yet.";
                            }
                        }
                        if (request.RowErr == string.Empty)
                        {
                            if (request.TUR == 0)
                                request.TUR = GnlOps.XGTfind("ABB.TUR", "BS").GetObjectNo();

                            ABB row = CRUDsHelper.FromProxy<ABBproxy, ABB>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<ABBproxy, ABB>(row);
                        }

                    }
                    else if (request.RowSte == "D" && request.Drm == "A")
                    {
                        var row = (AFB)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<ABD>("select r from ABD r where r.ABB.ObjectNo = ?", request.RowKey).FirstOrDefault() != null)
                                request.RowErr = $"Detayı var silemezsiniz.";
                            else
                            {
                                UHT.Append(request.RowUsr, request.RowKey, request.RowSte);
                                row.Delete();
                            }
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task ABDfill(QryProxy request, IServerStreamWriter<ABDproxy> responseStream, ServerCallContext context)
        {
            ABDproxy proxy = new ABDproxy();
            List<ABDproxy> proxyList = new List<ABDproxy>();
            string sel = $"SELECT r FROM ABD r WHERE r.{request.Query}";

            Type proxyType = typeof(ABDproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<ABD>(sel, ulong.Parse(request.Param)))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new ABDproxy
                    {
                        RowKey = row.GetObjectNo(),
                        ABB = row.ABB == null ? 0 : row.ABB.GetObjectNo(),
                        NNN = row.NNN == null ? 0 : row.NNN.GetObjectNo(),
                        AHP = row.AHP == null ? 0 : row.AHP.GetObjectNo(),
                        DVT = row.DVT == null ? 0 : row.DVT.GetObjectNo(),
                        Fyt = row.Fyt,
                        Mik = row.Mik,
                        KDY = row.KDY,
                        Kur = row.Kur,
                        Info = row.Info,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }

        public override Task<ABDproxy> ABDupdate(ABDproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            ABD row = CRUDsHelper.FromProxy<ABDproxy, ABD>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<ABDproxy, ABD>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        var row = (ABD)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            UHT.Append(request.RowUsr, request.RowKey, request.RowSte);
                            row.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        // GenelTanim
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
                            RowKey = row.GetObjectNo(),
                            P = row.P == null ? 0 : row.P.GetObjectNo(),
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
                RowKey = request.RowKey,
            };

            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Hata deneme
                        //request.RowErr = "HATA";

                        // Add Control
                        // Parent Hesabi olmali
                        // Parent Hesap altinada No uniqe olmali 
                        // Parent Hareketleri olmamali
                        var rec = (XGT)Db.FromId(request.P);

                        if (request.RowErr == string.Empty)
                        {
                            XGT row = CRUDsHelper.FromProxy<XGTproxy, XGT>(request);
                            request = CRUDsHelper.ToProxy<XGTproxy, XGT>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        var rec = (XGT)Db.FromId(request.RowKey);
                        if (rec == null)
                        {
                            request.RowErr = "AHP Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<XGT>("select r from XGT r where r.P.ObjectNo = ?", request.RowKey).FirstOrDefault() != null)
                                request.RowErr = $"Alt hesabı var silemezsiniz";
                            else
                                rec.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }


        // DovizKur
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
                    var dvzP = Db.SQL<XGT>("SELECT r FROM XGT r WHERE r.P IS NULL and r.Kd = ?", "DVZ").FirstOrDefault();
                    var dvts = Db.SQL<XGT>("SELECT r FROM XGT r WHERE r.P = ?", dvzP);

                    foreach (var dvt in dvts)
                    {
                        var row = Db.SQL<XDK>("select r from XDK r WHERE r.Trh = ? and r.DVT = ?", dt, dvt).FirstOrDefault();
                        if(row == null)
                        {
                            proxy = new XDKproxy
                            {
                                RowKey = 0,
                                DVT = dvt.GetObjectNo(),
                                Trh = dt.Ticks,
                                Kur = dvt.Kd == "TRL" ? 1 : 0,
                                Dvz = dvt.Kd,
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
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        if (request.RowErr == string.Empty)
                        {
                            XDK row = CRUDsHelper.FromProxy<XDKproxy, XDK>(request);
                            request = CRUDsHelper.ToProxy<XDKproxy, XDK>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        var rec = (XDK)Db.FromId(request.RowKey);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }


        // User
        public override async Task UUUfill(QryProxy request, IServerStreamWriter<UUUproxy> responseStream, ServerCallContext context)
        {
            UUUproxy proxy = new UUUproxy();
            List<UUUproxy> proxyList = new List<UUUproxy>();
            string sel = $"SELECT r FROM UUU r";

            Type proxyType = typeof(AFDproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<UUU>("SELECT r FROM UUU r"))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new UUUproxy
                    {
                        RowKey = row.GetObjectNo(),
                        UYT = row.UYT == null ? 0 : row.UYT.GetObjectNo(),
                        Ad = row.Ad,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }

        public override Task<UUUproxy> UUUupdate(UUUproxy request, ServerCallContext context)
        {
            var proxy = new UUUproxy
            {
                RowKey = request.RowKey,
            };

            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            UUU row = CRUDsHelper.FromProxy<UUUproxy, UUU>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<UUUproxy, UUU>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task UYTfill(QryProxy request, IServerStreamWriter<UYTproxy> responseStream, ServerCallContext context)
        {
            UYTproxy proxy = new UYTproxy();
            List<UYTproxy> proxyList = new List<UYTproxy>();
            string sel = $"SELECT r FROM UYT r";

            Type proxyType = typeof(UYTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<UYT>("SELECT r FROM UYT r"))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new UYTproxy
                    {
                        RowKey = row.GetObjectNo(),
                        Ad = row.Ad,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }

        public override Task<UYTproxy> UYTupdate(UYTproxy request, ServerCallContext context)
        {
            var proxy = new UYTproxy
            {
                RowKey = request.RowKey,
            };

            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            UYT row = CRUDsHelper.FromProxy<UYTproxy, UYT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<UYTproxy, UYT>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task UYHfill(QryProxy request, IServerStreamWriter<UYHproxy> responseStream, ServerCallContext context)
        {
            UYHproxy proxy = new UYHproxy();
            List<UYHproxy> proxyList = new List<UYHproxy>();
            string sel = $"SELECT r FROM UYH r";

            Type proxyType = typeof(UYHproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<UYH>("SELECT r FROM UYH r WHERE r.P.ObjectNo = ? or r.K.ObjectNo = ?", 248, 248))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new UYHproxy
                    {
                        RowKey = row.GetObjectNo(),
                        P = row.P == null ? 0 : row.P.GetObjectNo(),
                        K = row.K == null ? 0 : row.K.GetObjectNo(),
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }

        public override Task<UYHproxy> UYHupdate(UYHproxy request, ServerCallContext context)
        {
            var proxy = new UYHproxy
            {
                RowKey = request.RowKey,
            };

            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            UYH row = CRUDsHelper.FromProxy<UYHproxy, UYH>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<UYHproxy, UYH>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }


        // NeTanim
        public override async Task NNNfill(QryProxy request, IServerStreamWriter<NNNproxy> responseStream, ServerCallContext context)
        {
            NNNproxy proxy = new NNNproxy();
            List<NNNproxy> proxyList = new List<NNNproxy>();
            string sel = $"SELECT r FROM KMT r";

            Type proxyType = typeof(NNNproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<NNN>("SELECT r FROM NNN r"))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new NNNproxy
                    {
                        RowKey = row.GetObjectNo(),
                        Kd = row.Kd,
                        Ad = row.Ad,
                        BRM = row.BRM == null ? 0 : row.BRM.GetObjectNo(),
                        Fyt = row.Fyt,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }
        public override Task<NNNproxy> NNNupdate(NNNproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            NNN row = CRUDsHelper.FromProxy<NNNproxy, NNN>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<NNNproxy, NNN>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Firma Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task NeUpFill(QryProxy request, IServerStreamWriter<NeTreeProxy> responseStream, ServerCallContext context)
        {
            NeTreeProxy proxy;
            DataTable table = null;

            await Scheduling.RunTask(() =>
            {
                table = M2DB.NNR.DenemeUp();
            });


            foreach (DataRow r in table.Rows)
            {
                proxy = new NeTreeProxy
                {
                    L = (int)r["L"],
                    P = (int)r["P"],
                    K = (int)r["K"],
                    A = (string)r["A"],
                    N = (ulong)r["N"],
                    M = (double)r["M"],
                    F = (double)r["F"],
                    MT = 1,
                };

                await responseStream.WriteAsync(proxy);

            }
        }

        public override async Task NeDownFill(QryProxy request, IServerStreamWriter<NeTreeProxy> responseStream, ServerCallContext context)
        {
            NeTreeProxy proxy;
            DataTable table = null;

            await Scheduling.RunTask(() =>
            {
                table = M2DB.NNR.DenemeDown();
            });


            foreach (DataRow r in table.Rows)
            {
                proxy = new NeTreeProxy
                {
                    L = (int)r["L"],
                    P = (int)r["P"],
                    K = (int)r["K"],
                    A = (string)r["A"],
                    N = (ulong)r["N"],
                    M = (double)r["M"],
                    F = (double)r["F"],
                    HasKid = (bool)r["HasKid"],
                    MT = 1,
                };

                await responseStream.WriteAsync(proxy);

            }
        }

        public override async Task KidsInParentsFill(QryProxy request, IServerStreamWriter<KidsInParentsProxy> responseStream, ServerCallContext context)
        {
            KidsInParentsProxy proxy;
            DataTable table = null;

            await Scheduling.RunTask(() =>
            {
                table = M2DB.NNR.KidsInParentsMik();
            });


            foreach (DataRow r in table.Rows)
            {
                proxy = new KidsInParentsProxy
                {
                    KNo = (ulong)r["KNo"],
                    PNo = (ulong)r["PNo"],
                    KAd = (string)r["KAd"],
                    PAd = (string)r["PAd"],
                    M = (double)r["M"],
                };

                await responseStream.WriteAsync(proxy);
            }
        }

        public override async Task NodesInParentsFill(QryProxy request, IServerStreamWriter<NodesInParentsProxy> responseStream, ServerCallContext context)
        {
            NodesInParentsProxy proxy;
            DataTable table = null;

            await Scheduling.RunTask(() =>
            {
                table = M2DB.NNR.NodesInParents();
            });


            foreach (DataRow r in table.Rows)
            {
                proxy = new NodesInParentsProxy
                {
                    KNo = (ulong)r["KNo"],
                    PNo = (ulong)r["PNo"],
                    KAd = (string)r["KAd"],
                    PAd = (string)r["PAd"],
                    M = (double)r["M"],
                };

                await responseStream.WriteAsync(proxy);
            }
        }

        // KimFirmaTanim
        public override async Task KFTfill(QryProxy request, IServerStreamWriter<KFTproxy> responseStream, ServerCallContext context)
        {
            KFTproxy proxy = new KFTproxy();
            List<KFTproxy> proxyList = new List<KFTproxy>();
            string sel = $"SELECT r FROM KMT r";

            Type proxyType = typeof(KFTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<KFT>("SELECT r FROM KFT r"))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new KFTproxy
                    {
                        RowKey = row.GetObjectNo(),
                        Ad = row.Ad,
                        VrgDN = row.VrgDN,
                        AHPbrc = row.AHPbrc == null ? 0 : row.AHPbrc.GetObjectNo(),
                        AHPalc = row.AHPalc == null ? 0 : row.AHPalc.GetObjectNo(),
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }
        public override Task<KFTproxy> KFTupdate(KFTproxy request, ServerCallContext context)
        {
            var proxy = new KFTproxy
            {
                RowKey = request.RowKey,
            };

            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            KFT row = CRUDsHelper.FromProxy<KFTproxy, KFT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<KFTproxy, KFT>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Firma Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        // KimPersonelTanim
        public override async Task KPTfill(QryProxy request, IServerStreamWriter<KPTproxy> responseStream, ServerCallContext context)
        {
            KPTproxy proxy = new KPTproxy();
            List<KPTproxy> proxyList = new List<KPTproxy>();

            Type proxyType = typeof(KPTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<KPT>("SELECT r FROM KPT r"))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new KPTproxy
                    {
                        RowKey = row.GetObjectNo(),
                        Kd = row.Kd,
                        Ad = row.Ad,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }
        public override Task<KPTproxy> KPTupdate(KPTproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            KPT row = CRUDsHelper.FromProxy<KPTproxy, KPT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<KPTproxy, KPT>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Firma Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        // KimDepartmanTanim
        public override async Task KDTfill(QryProxy request, IServerStreamWriter<KDTproxy> responseStream, ServerCallContext context)
        {
            KDTproxy proxy = new KDTproxy();
            List<KDTproxy> proxyList = new List<KDTproxy>();

            Type proxyType = typeof(KDTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<KDT>("SELECT r FROM KDT r"))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new KDTproxy
                    {
                        RowKey = row.GetObjectNo(),
                        Kd = row.Kd,
                        Ad = row.Ad,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }
        public override Task<KDTproxy> KDTupdate(KDTproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Add Control
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            KDT row = CRUDsHelper.FromProxy<KDTproxy, KDT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<KDTproxy, KDT>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Firma Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }


        public override async Task ToKPTfill(QryPproxy request, IServerStreamWriter<ToKPTproxy> responseStream, ServerCallContext context)
        {
            ToKPTproxy proxy = new ToKPTproxy();
            List<ToKPTproxy> proxyList = new List<ToKPTproxy>();

            Type proxyType = typeof(ToKPTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var r in Db.SQL<BR>("SELECT r FROM BR r WHERE r.P.ObjectNo = ?", request.P))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);
                    //KPT row = r.C as KPT;   //Db.FromId(r.C)

                    if (r.C is KPT row)
                    {
                        proxy = new ToKPTproxy
                        {
                            RowKey = row.GetObjectNo(),
                            P = r.P.GetObjectNo(),
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
        public override Task<ToKPTproxy> ToKPTupdate(ToKPTproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    var P = request.P;
                    if (request.RowSte == "A")
                    {
                        KPT row = CRUDsHelper.FromProxy<ToKPTproxy, KPT>(request);
                        //var p = Db.FromId(request.P);
                        
                        new BR
                        {
                            P = Db.FromId(request.P) as BB,
                            C = row,
                        };
                        UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                        request = CRUDsHelper.ToProxy<ToKPTproxy, KPT>(row);
                        request.P = P;
                    }

                    if (request.RowSte == "M")
                    {
                        if (request.RowErr == string.Empty)
                        {
                            KPT row = CRUDsHelper.FromProxy<ToKPTproxy, KPT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<ToKPTproxy, KPT>(row);
                            request.P = P;
                        }
                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task ToKDTfill(QryPproxy request, IServerStreamWriter<ToKDTproxy> responseStream, ServerCallContext context)
        {
            ToKDTproxy proxy = new ToKDTproxy();
            List<ToKDTproxy> proxyList = new List<ToKDTproxy>();

            Type proxyType = typeof(ToKDTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var r in Db.SQL<BR>("SELECT r FROM BR r WHERE r.P.ObjectNo = ?", request.P))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);
                    //KPT row = r.C as KPT;   //Db.FromId(r.C)

                    if (r.C is KDT row)
                    {
                        proxy = new ToKDTproxy
                        {
                            RowKey = row.GetObjectNo(),
                            P = r.P.GetObjectNo(),
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
        public override Task<ToKDTproxy> ToKDTupdate(ToKDTproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    var P = request.P;
                    if (request.RowSte == "A")
                    {
                        KDT row = CRUDsHelper.FromProxy<ToKDTproxy, KDT>(request);

                        new BR
                        {
                            P = Db.FromId(P) as BB,
                            C = row,
                        };
                        UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                        request = CRUDsHelper.ToProxy<ToKDTproxy, KDT>(row);
                        request.P = P;
                    }

                    if (request.RowSte == "M")
                    {
                        if (request.RowErr == string.Empty)
                        {
                            KDT row = CRUDsHelper.FromProxy<ToKDTproxy, KDT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<ToKDTproxy, KDT>(row);
                            request.P = P;
                        }
                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        public override async Task BRfill(QryBRproxy request, IServerStreamWriter<BRproxy> responseStream, ServerCallContext context)
        {
            BRproxy proxy = new BRproxy();
            List<BRproxy> proxyList = new List<BRproxy>();

            Type proxyType = typeof(ToKDTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                IEnumerable<BR> brs;
                bool isP2C = false;
                if (string.Compare(request.Mtyp, request.Dtyp) < 0)  // P is Master
                {
                    brs = Db.SQL<BR>("SELECT r FROM BR r WHERE r.P.ObjectNo = ? and r.Ptyp = ? and r.Ctyp = ?", request.M, request.Mtyp, request.Dtyp);
                    isP2C = true;
                }
                else // C is Master
                    brs = Db.SQL<BR>("SELECT r FROM BR r WHERE r.C.ObjectNo = ? and r.Ptyp = ? and r.Ctyp = ?", request.M, request.Dtyp, request.Mtyp);

                foreach (var r in brs)
                {
                    proxy = new BRproxy
                    {
                        RowKey = r.GetObjectNo(),
                        P = r.P.GetObjectNo(),
                        C = r.C.GetObjectNo(),
                        Others = isP2C ? r.PofC : r.CofP,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }
        public override Task<BRproxy> BRupdate(BRproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A")
                    {
                        BR row = new BR
                        {
                            P = Db.FromId(request.P) as BB,
                            C = Db.FromId(request.C) as BB,
                        };
                        UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                        request = CRUDsHelper.ToProxy<BRproxy, BR>(row);
                    }

                    if (request.RowSte == "M")
                    {
                        if (request.RowErr == string.Empty)
                        {
                            BR row = CRUDsHelper.FromProxy<BRproxy, BR>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<BRproxy, BR>(row);
                        }
                    }
                    else if (request.RowSte == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Silemezsiniz";    // Simdilik
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }
    }

}
