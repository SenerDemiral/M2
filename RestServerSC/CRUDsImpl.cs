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

                        AHP pAhp = (AHP)Db.FromId(request.ObjP);
                        if (request.RowState == "A")
                        {
                            if (request.ObjP > 0 && pAhp == null)
                                request.RowErr = "Üst Hesabı tanımsız";
                            else if (pAhp.IsW || pAhp.HasH)
                                request.RowErr = "Çalışan hesaba alt hesap açamazsınız";
                            else if (!AHP.IsAhpNoUnique(pAhp, request.No))
                                request.RowErr = $"No: {request.No} kullanılmış";
                        }
                        else if (request.RowState == "M")
                        {
                            AHP oldRec = Db.FromId<AHP>(request.RowPk);
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
            var proxy = new AFBproxy
            {
                RowPk = request.RowPk,
            };
            Scheduling.RunTask(() =>
            {
                // RowState: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    request.RowErr = "";
                    if (request.RowState == "A" || request.RowState == "M")
                    {
                        if(request.RowState == "M")
                        {
                            AFB sonAFB = Db.FromId<AFB>(request.RowPk);
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
                            if (request.ObjTur == 0)
                                request.ObjTur = GnlOps.XGTfind("AFB.Tur", "MHS").GetObjectNo();

                            AFB row = CRUDsHelper.FromProxy<AFBproxy, AFB>(request);
                            request = CRUDsHelper.ToProxy<AFBproxy, AFB>(row);
                        }

                    }
                    else if (request.RowState == "D" && request.Drm == "A")
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
                            RowPk = row.GetObjectNo(),
                            Trh = ((DateTime)row.Trh).Ticks,
                            ObjTur = row.ObjTur == null ? 0 : row.ObjTur.GetObjectNo(),
                            ObjKKK = row.ObjKKK == null ? 0 : row.ObjKKK.GetObjectNo(),
                            ObjDvz = row.ObjDvz == null ? 0 : row.ObjDvz.GetObjectNo(),
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
            var proxy = new ABBproxy
            {
                RowPk = request.RowPk,
            };
            Scheduling.RunTask(() =>
            {
                // RowState: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    request.RowErr = "";
                    if (request.RowState == "A" || request.RowState == "M")
                    {
                        if (request.RowState == "M")
                        {
                            ABB latestRec = Db.FromId<ABB>(request.RowPk);  // Record'un enSon/enYeni/Guncel hali
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
                            if (request.ObjTur == 0)
                                request.ObjTur = GnlOps.XGTfind("ABB.TUR", "BS").GetObjectNo();

                            ABB row = CRUDsHelper.FromProxy<ABBproxy, ABB>(request);
                            request = CRUDsHelper.ToProxy<ABBproxy, ABB>(row);
                        }

                    }
                    else if (request.RowState == "D" && request.Drm == "A")
                    {
                        var rec = (AFB)Db.FromId(request.RowPk);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<ABD>("select r from ABD r where r.ObjABB.ObjectNo = ?", request.RowPk).FirstOrDefault() != null)
                                request.RowErr = $"Detayı var silemezsiniz.";
                            else
                                rec.Delete();
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

            Type proxyType = typeof(AFDproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<ABD>(sel, ulong.Parse(request.Param)))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new ABDproxy
                    {
                        RowPk = row.GetObjectNo(),
                        ObjABB = row.ObjABB == null ? 0 : row.ObjABB.GetObjectNo(),
                        ObjNNN = row.ObjNNN == null ? 0 : row.ObjNNN.GetObjectNo(),
                        ObjAHP = row.ObjAHP == null ? 0 : row.ObjAHP.GetObjectNo(),
                        ObjDvz = row.ObjDvz == null ? 0 : row.ObjDvz.GetObjectNo(),
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
            var proxy = new ABDproxy
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
                            ABD row = CRUDsHelper.FromProxy<ABDproxy, ABD>(request);
                            request = CRUDsHelper.ToProxy<ABDproxy, ABD>(row);
                        }

                    }
                    else if (request.RowState == "D")
                    {
                        var rec = (ABD)Db.FromId(request.RowPk);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }


        public override async Task KMTfill(QryProxy request, IServerStreamWriter<KMTproxy> responseStream, ServerCallContext context)
        {
            KMTproxy proxy = new KMTproxy();
            List<KMTproxy> proxyList = new List<KMTproxy>();
            string sel = $"SELECT r FROM KMT r";

            Type proxyType = typeof(AFDproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<KMT>("SELECT r FROM KMT r"))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new KMTproxy
                    {
                        RowPk = row.GetObjectNo(),
                        ObjTur = row.ObjTur == null ? 0 : row.ObjTur.GetObjectNo(),
                        Ad = row.Ad,
                        Adres = row.Adres,
                        Tel = row.Tel,
                        Sorumlu = row.Sorumlu,
                        VrgDN = row.VrgDN,
                        ObjAHPbrc = row.ObjAHPbrc == null ? 0 : row.ObjAHPbrc.GetObjectNo(),
                        ObjAHPalc = row.ObjAHPalc == null ? 0 : row.ObjAHPalc.GetObjectNo(),
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }

        public override Task<KMTproxy> KMTupdate(KMTproxy request, ServerCallContext context)
        {
            var proxy = new KMTproxy
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
                            KMT row = CRUDsHelper.FromProxy<KMTproxy, KMT>(request);
                            request = CRUDsHelper.ToProxy<KMTproxy, KMT>(row);
                        }

                    }
                    else if (request.RowState == "D")
                    {
                        // Ilgili kayit varsa sildirme
                        request.RowErr = "Müşteri Silemezsiniz";    // Simdilik
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
