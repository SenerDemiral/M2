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
                            Kd = row.Kd,
                            Ad = row.Ad,
                            Info = row.Info,
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
                            else if (!AHP.IsAhpKdUnique(pAhp, request.Kd))
                                request.RowErr = $"Kd: {request.Kd} kullanılmış";
                        }
                        else if (request.RowSte == "M")
                        {
                            AHP oldRec = Db.FromId<AHP>(request.RowKey);
                            if (request.IsW && oldRec.HasK)
                                request.RowErr = "Üst hesap çalışamaz.";
                            else if (!request.IsW && oldRec.HasH)
                                request.RowErr = "Çalışan hesap, Hareketleri var.";
                            else if (oldRec.Kd != request.Kd && !AHP.IsAhpKdUnique(pAhp, request.Kd))
                                request.RowErr = $"Kd: {request.Kd} kullanılmış";
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

        // VoucherKind/FisTurleri
        public override async Task AN2Hfill(QryProxy request, IServerStreamWriter<AN2Hproxy> responseStream, ServerCallContext context)
        {
            AN2Hproxy proxy = new AN2Hproxy();
            List<AN2Hproxy> proxyList = new List<AN2Hproxy>();

            Type proxyType = typeof(AN2Hproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<AN2H>("select r from AN2H r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new AN2Hproxy
                        {
                            RowKey = row.GetObjectNo(),
                            NNT = row.NNT == null ? 0 : row.NNT.GetObjectNo(),
                            ABK = row.ABK == null ? 0 : row.ABK.GetObjectNo(),
                            AHP = row.AHP == null ? 0 : row.AHP.GetObjectNo(),
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
        public override Task<AN2Hproxy> AN2Hupdate(AN2Hproxy request, ServerCallContext context)
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
                            AN2H row = CRUDsHelper.FromProxy<AN2Hproxy, AN2H>(request);
                            request = CRUDsHelper.ToProxy<AN2Hproxy, AN2H>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        var rec = (AVK)Db.FromId(request.RowKey);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        // VoucherKind/FisTurleri
        public override async Task AVKfill(QryProxy request, IServerStreamWriter<AVKproxy> responseStream, ServerCallContext context)
        {
            AVKproxy proxy = new AVKproxy();
            List<AVKproxy> proxyList = new List<AVKproxy>();

            Type proxyType = typeof(AVKproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<AVK>("select r from AVK r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new AVKproxy
                        {
                            RowKey = row.GetObjectNo(),
                            Kd = row.Kd,
                            Ad = row.Ad,
                            Info = row.Info, //row.Info ?? "",
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
        public override Task<AVKproxy> AVKupdate(AVKproxy request, ServerCallContext context)
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
                            AVK row = CRUDsHelper.FromProxy<AVKproxy, AVK>(request);
                            request = CRUDsHelper.ToProxy<AVKproxy, AVK>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        var rec = (AVK)Db.FromId(request.RowKey);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        // BillKind/FaturaTurleri
        public override async Task ABKfill(QryProxy request, IServerStreamWriter<ABKproxy> responseStream, ServerCallContext context)
        {
            ABKproxy proxy = new ABKproxy();
            List<ABKproxy> proxyList = new List<ABKproxy>();

            Type proxyType = typeof(ABKproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<ABK>("select r from ABK r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new ABKproxy
                        {
                            RowKey = row.GetObjectNo(),
                            Kd = row.Kd,
                            Ad = row.Ad,
                            Info = row.Info, //row.Info ?? "",
                            IsBrc = row.IsBrc
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
        public override Task<ABKproxy> ABKupdate(ABKproxy request, ServerCallContext context)
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
                            ABK row = CRUDsHelper.FromProxy<ABKproxy, ABK>(request);
                            request = CRUDsHelper.ToProxy<ABKproxy, ABK>(row);
                        }

                    }
                    else if (request.RowSte == "D")
                    {
                        var rec = (AVK)Db.FromId(request.RowKey);
                        if (rec == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(request);
        }

        // Voucher/Fis Master
        public override async Task AVMfill(QryProxy request, IServerStreamWriter<AVMproxy> responseStream, ServerCallContext context)
        {
            AVMproxy proxy = new AVMproxy();
            List<AVMproxy> proxyList = new List<AVMproxy>();

            Type proxyType = typeof(AVMproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<AVM>("select r from AVM r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new AVMproxy
                        {
                            RowKey = row.GetObjectNo(),
                            ORG = row.ORG == null ? 0 : row.ORG.GetObjectNo(),
                            Trh = ((DateTime)row.Trh).Ticks,
                            AVK = row.AVK == null ? 0 : row.AVK.GetObjectNo(),
                            Drm = row.Drm,
                            Kd = row.Kd,
                            Ad = row.Ad,
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
        public override Task<AVMproxy> AVMupdate(AVMproxy request, ServerCallContext context)
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
                            AVM son = Db.FromId<AVM>(request.RowKey);
                            if (request.Drm == "P")
                            {
                                if (son.Drm == "P")
                                {
                                    request = CRUDsHelper.ToProxy<AVMproxy, AVM>(son);   // Recent Row gonder, baskasi tarafindan degistirilmis
                                    request.RowErr = "LOCKED Already";
                                }
                                else
                                {
                                    request = CRUDsHelper.ToProxy<AVMproxy, AVM>(son);   // Recent Row gonder, baskasi tarafindan degistirilmis
                                    request.Drm = "P";
                                }
                            }
                            else if (request.Drm == "K")
                            {
                                if (son.Brc != son.Alc)
                                    request.RowErr = "Brc = Alc olmalı.";
                            }
                        }
                        if (request.RowErr == string.Empty)
                        {
                            AVM row = CRUDsHelper.FromProxy<AVMproxy, AVM>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<AVMproxy, AVM>(row);
                        }

                    }
                    else if (request.RowSte == "D" && request.Drm == "A")
                    {
                        var row = (AVM)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<AVD>("select r from AVD r where r.AVM.ObjectNo = ?", request.RowKey).FirstOrDefault() != null)
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

        // Voucher/Fis Detay
        public override async Task AVDfill(QryMDproxy request, IServerStreamWriter<AVDproxy> responseStream, ServerCallContext context)
        {
            AVDproxy proxy = new AVDproxy();
            List<AVDproxy> proxyList = new List<AVDproxy>();

            Type proxyType = typeof(AVDproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<AVD>("SELECT r FROM ABD r WHERE r.AVM.ObjectNo = ?", request.M))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new AVDproxy
                    {
                        RowKey = row.GetObjectNo(),
                        AVM = row.AVM == null ? 0 : row.AVM.GetObjectNo(),
                        AHP = row.AHP == null ? 0 : row.AHP.GetObjectNo(),
                        Kd = row.Kd,
                        Ad = row.Ad,
                        Info = row.Info, //row.Info ?? "",
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
        public override Task<AVDproxy> AVDupdate(AVDproxy request, ServerCallContext context)
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
                            AVD row = CRUDsHelper.FromProxy<AVDproxy, AVD>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<AVDproxy, AVD>(row);
                        }
                    }
                    else if (request.RowSte == "D")
                    {
                        var row = (AVD)Db.FromId(request.RowKey);
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

        // Bill/Fatura Master
        public override async Task ABMfill(QryProxy request, IServerStreamWriter<ABMproxy> responseStream, ServerCallContext context)
        {
            ABMproxy proxy = new ABMproxy();
            List<ABMproxy> proxyList = new List<ABMproxy>();

            Type proxyType = typeof(ABMproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<ABM>("select r from ABM r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new ABMproxy
                        {
                            RowKey = row.GetObjectNo(),
                            Trh = ((DateTime)row.Trh).Ticks,
                            ABK = row.ABK == null ? 0 : row.ABK.GetObjectNo(),
                            KFT = row.KFT == null ? 0 : row.KFT.GetObjectNo(),
                            DVT = row.DVT == null ? 0 : row.DVT.GetObjectNo(),
                            BA = row.BA,
                            Kur = row.Kur,
                            Drm = row.Drm,
                            Kd = row.Kd,
                            Ad = row.Ad,
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
        public override Task<ABMproxy> ABMupdate(ABMproxy request, ServerCallContext context)
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
                            ABM son = Db.FromId<ABM>(request.RowKey);  // Record'un enSon/enYeni/Guncel hali
                            if (request.Drm == "P")
                            {
                                request = CRUDsHelper.ToProxy<ABMproxy, ABM>(son);   // Latest Row gonder, baskasi tarafindan degistirilmis
                                if (son.Drm == "P")
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
                            ABM row = CRUDsHelper.FromProxy<ABMproxy, ABM>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<ABMproxy, ABM>(row);
                        }

                    }
                    else if (request.RowSte == "D" && request.Drm == "A")
                    {
                        var row = (AVM)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<AVD>("select r from AVD r where r.AVM.ObjectNo = ?", request.RowKey).FirstOrDefault() != null)
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

        // Bill/Fatura Detay
        public override async Task ABDfill(QryMDproxy request, IServerStreamWriter<ABDproxy> responseStream, ServerCallContext context)
        {
            ABDproxy proxy = new ABDproxy();
            List<ABDproxy> proxyList = new List<ABDproxy>();

            Type proxyType = typeof(ABDproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<ABD>("SELECT r FROM ABD r WHERE r.ABM.ObjectNo = ?", request.M))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new ABDproxy
                    {
                        RowKey = row.GetObjectNo(),
                        ABM = row.ABM == null ? 0 : row.ABM.GetObjectNo(),
                        NNT = row.NNT == null ? 0 : row.NNT.GetObjectNo(),
                        AHP = row.AHP == null ? 0 : row.AHP.GetObjectNo(),
                        DVT = row.DVT == null ? 0 : row.DVT.GetObjectNo(),
                        Fyt = row.Fyt,
                        Mik = row.Mik,
                        KDY = row.KDY,
                        Kur = row.Kur,
                        Kd = row.Kd,
                        Ad = row.Ad,
                        Info = row.Info, //row.Info ?? "",
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

        // Order/Siparis Master
        public override async Task TOMfill(QryProxy request, IServerStreamWriter<TOMproxy> responseStream, ServerCallContext context)
        {
            TOMproxy proxy = new TOMproxy();
            List<TOMproxy> proxyList = new List<TOMproxy>();

            Type proxyType = typeof(TOMproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<TOM>("select r from TOM r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new TOMproxy
                        {
                            RowKey = row.GetObjectNo(),
                            ORG = row.ORG == null ? 0 : row.ORG.GetObjectNo(),
                            DST = row.ORG == null ? 0 : row.ORG.GetObjectNo(),
                            Trh = row.Trh.Ticks,
                            KND = row.KND == null ? 0 : row.KND.GetObjectNo(),
                            Drm = row.Drm,
                            Kd = row.Kd,
                            Ad = row.Ad,
                            Info = row.Info, //row.Info ?? "",
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
        public override Task<TOMproxy> TOMupdate(TOMproxy request, ServerCallContext context)
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
                            TOM son = Db.FromId<TOM>(request.RowKey);
                            if (request.Drm == "P")
                            {
                                if (son.Drm == "P")
                                {
                                    request = CRUDsHelper.ToProxy<TOMproxy, TOM>(son);   // Recent Row gonder, baskasi tarafindan degistirilmis
                                    request.RowErr = "LOCKED Already";
                                }
                                else
                                {
                                    request = CRUDsHelper.ToProxy<TOMproxy, TOM>(son);   // Recent Row gonder, baskasi tarafindan degistirilmis
                                    request.Drm = "P";
                                }
                            }
                            else if (request.Drm == "K")
                            {
                            }
                        }
                        if (request.RowErr == string.Empty)
                        {
                            if (request.KND == 0)
                                request.KND = GnlOps.XGTfind("TOM.KND", "I").GetObjectNo();   // Default

                            TOM row = CRUDsHelper.FromProxy<TOMproxy, TOM>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<TOMproxy, TOM>(row);
                        }

                    }
                    else if (request.RowSte == "D" && request.Drm == "A")
                    {
                        var row = (TOM)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<TOD>("select r from TOD r where r.TOM.ObjectNo = ?", request.RowKey).FirstOrDefault() != null)
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

        // Waybill/Siparis Master
        public override async Task TWMfill(QryProxy request, IServerStreamWriter<TWMproxy> responseStream, ServerCallContext context)
        {
            TWMproxy proxy = new TWMproxy();
            List<TWMproxy> proxyList = new List<TWMproxy>();

            Type proxyType = typeof(TWMproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<TWM>("select r from TWM r"))
                    {
                        //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                        proxy = new TWMproxy
                        {
                            RowKey = row.GetObjectNo(),
                            Trh = row.Trh.Ticks,
                            KND = row.KND == null ? 0 : row.KND.GetObjectNo(),
                            Drm = row.Drm,
                            Kd = row.Kd,
                            Ad = row.Ad,
                            Info = row.Info, //row.Info ?? "",
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
        public override Task<TWMproxy> TWMupdate(TWMproxy request, ServerCallContext context)
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
                            TWM son = Db.FromId<TWM>(request.RowKey);
                            if (request.Drm == "P")
                            {
                                if (son.Drm == "P")
                                {
                                    request = CRUDsHelper.ToProxy<TWMproxy, TWM>(son);   // Recent Row gonder, baskasi tarafindan degistirilmis
                                    request.RowErr = "LOCKED Already";
                                }
                                else
                                {
                                    request = CRUDsHelper.ToProxy<TWMproxy, TWM>(son);   // Recent Row gonder, baskasi tarafindan degistirilmis
                                    request.Drm = "P";
                                }
                            }
                            else if (request.Drm == "K")
                            {
                            }
                        }
                        if (request.RowErr == string.Empty)
                        {
                            if (request.KND == 0)
                                request.KND = GnlOps.XGTfind("TWM.KND", "I").GetObjectNo();   // Default

                            TWM row = CRUDsHelper.FromProxy<TWMproxy, TWM>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<TWMproxy, TWM>(row);
                        }

                    }
                    else if (request.RowSte == "D" && request.Drm == "A")
                    {
                        var row = (TWM)Db.FromId(request.RowKey);
                        if (row == null)
                        {
                            request.RowErr = "Rec not found";
                        }
                        else
                        {
                            if (Db.SQL<TWD>("select r from TWD r where r.TWM.ObjectNo = ?", request.RowKey).FirstOrDefault() != null)
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

            Type proxyType = typeof(UUUproxy);
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
        public override async Task NNTfill(QryProxy request, IServerStreamWriter<NNTproxy> responseStream, ServerCallContext context)
        {
            NNTproxy proxy = new NNTproxy();
            List<NNTproxy> proxyList = new List<NNTproxy>();
            string sel = $"SELECT r FROM KMT r";

            Type proxyType = typeof(NNTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<NNT>("SELECT r FROM NNT r"))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new NNTproxy
                    {
                        RowKey = row.GetObjectNo(),
                        Kd = row.Kd,
                        Ad = row.Ad,
                        Info = row.Info, //row.Info ?? "",
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
        public override Task<NNTproxy> NNTupdate(NNTproxy request, ServerCallContext context)
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
                            NNT row = CRUDsHelper.FromProxy<NNTproxy, NNT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<NNTproxy, NNT>(row);
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

        // NeRelation
        public override async Task NNRfill(PKproxy request, IServerStreamWriter<NNRproxy> responseStream, ServerCallContext context)
        {
            NNRproxy proxy = new NNRproxy();
            List<NNRproxy> proxyList = new List<NNRproxy>();

            Type proxyType = typeof(NNRproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<NNR>("SELECT r FROM NNR r WHERE r.NP.ObjectNo = ?", request.PK))
                {
                    //proxy = ReflectionExample.ToProxy<AHPproxy, AHP>(row);

                    proxy = new NNRproxy
                    {
                        RowKey = row.GetObjectNo(),
                        NP = row.NP.GetObjectNo(),
                        NC = row.NC.GetObjectNo(),
                        Mik = row.Mik,
                    };
                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }
        public override Task<NNRproxy> NNRupdate(NNRproxy request, ServerCallContext context)
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
                            NNR row = CRUDsHelper.FromProxy<NNRproxy, NNR>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<NNRproxy, NNR>(row);
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
        public override async Task NeParentsFill(PKproxy request, IServerStreamWriter<NeParentsProxy> responseStream, ServerCallContext context)
        {
            NeParentsProxy proxy;
            string pString = null;

            await Scheduling.RunTask(() =>
            {
                pString = NNT.GetNeParentsString(request.PK);
            });

            proxy = new NeParentsProxy
            {
                Ne = request.PK,
                Parents = pString
            };
            await responseStream.WriteAsync(proxy);
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
                    P = (ulong)r["P"],
                    K = (ulong)r["K"],
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
                    P = (ulong)r["P"],
                    K = (ulong)r["K"],
                    A = (string)r["A"],
                    N = (ulong)r["N"],
                    M = (double)r["M"],
                    F = (double)r["F"],
                    HasKid = (bool)r["HasKid"],
                    MT = 1,
                    Ureten = (string)r["Ureten"]
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
                table = M2DB.NNR.NodesMikInParents();
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
                        Kd = row.Kd,
                        Ad = row.Ad,
                        Info = row.Info, //row.Info ?? "",
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
                        Info = row.Info, //row.Info ?? "",
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
        public override async Task KDTtreeDownFill(QryProxy request, IServerStreamWriter<KDTtreeProxy> responseStream, ServerCallContext context)
        {
            KDTtreeProxy proxy;
            DataTable table = null;

            await Scheduling.RunTask(() =>
            {
                table = M2DB.KDT.TreeDown();
            });


            foreach (DataRow r in table.Rows)
            {
                proxy = new KDTtreeProxy
                {
                    L = (int)r["L"],
                    P = (ulong)r["P"],
                    K = (ulong)r["K"],
                    A = (string)r["A"],
                    N = (ulong)r["N"],
                };

                await responseStream.WriteAsync(proxy);
            }
        }

        // KimHaberlesmeTanim
        public override async Task KHTfill(QryPproxy request, IServerStreamWriter<KHTproxy> responseStream, ServerCallContext context)
        {
            KHTproxy proxy = new KHTproxy();
            List<KHTproxy> proxyList = new List<KHTproxy>();

            Type proxyType = typeof(KHTproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<KHT>("SELECT r FROM KHT r WHERE r.M.ObjectNo = ?", request.P))
                {
                    proxy = CRUDsHelper.ToProxy<KHTproxy, KHT>(row);

                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }
        public override Task<KHTproxy> KHTupdate(KHTproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            KHT row = CRUDsHelper.FromProxy<KHTproxy, KHT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<KHTproxy, KHT>(row);
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

        // KimContactTanim
        public override async Task KCTfill(QryPproxy request, IServerStreamWriter<KCTproxy> responseStream, ServerCallContext context)
        {
            KCTproxy proxy = new KCTproxy();
            List<KCTproxy> proxyList = new List<KCTproxy>();

            PropertyInfo[] proxyProperties = typeof(KCTproxy).GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                foreach (var row in Db.SQL<KCT>("SELECT r FROM KCT r"))
                {
                    proxy = CRUDsHelper.ToProxy<KCTproxy, KCT>(row);

                    proxyList.Add(proxy);
                }
            });

            foreach (var p in proxyList)
            {
                await responseStream.WriteAsync(p);
            }
        }
        public override Task<KCTproxy> KCTupdate(KCTproxy request, ServerCallContext context)
        {
            Scheduling.RunTask(() =>
            {
                // RowSte: Added, Modified, Deletede, Unchanged
                Db.Transact(() =>
                {
                    if (request.RowSte == "A" || request.RowSte == "M")
                    {
                        // Parent Hesabi olmali

                        if (request.RowErr == string.Empty)
                        {
                            KCT row = CRUDsHelper.FromProxy<KCTproxy, KCT>(request);
                            UHT.Append(request.RowUsr, row.GetObjectNo(), request.RowSte);
                            request = CRUDsHelper.ToProxy<KCTproxy, KCT>(row);
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

        public override async Task BRfill(QryBRproxy request, IServerStreamWriter<BRproxy> responseStream, ServerCallContext context)
        {
            BRproxy proxy = new BRproxy();
            List<BRproxy> proxyList = new List<BRproxy>();

            Type proxyType = typeof(BRproxy);
            PropertyInfo[] proxyProperties = proxyType.GetProperties().Where(x => x.CanRead && x.CanWrite).ToArray();

            await Scheduling.RunTask(() =>
            {
                IEnumerable<BR> brs;
                bool isP2C = false;
                if (string.Compare(request.Mtyp, request.Dtyp) <= 0)  // P is Master
                {
                    //brs = Db.SQL<BR>($"SELECT r FROM BR r WHERE r.P.ObjectNo = ? and r.P IS {request.Mtyp} and r.C IS {request.Dtyp}", request.M);    Bug ikinci IS'i gormuyor
                    brs = Db.SQL<BR>($"SELECT r FROM BR r WHERE r.P.ObjectNo = ? and r.P IS {request.Mtyp} and r.C.Typ = ?", request.M, request.Dtyp);  // Workaround
                    isP2C = true;
                }
                else // C is Master
                {
                    //brs = Db.SQL<BR>($"SELECT r FROM BR r WHERE r.C.ObjectNo = ? and r.P IS {request.Dtyp} and r.C IS {request.Mtyp}", request.M);    // Bug
                    brs = Db.SQL<BR>($"SELECT r FROM BR r WHERE r.C.ObjectNo = ? and r.P IS {request.Dtyp} and r.C.Typ = ?", request.M, request.Mtyp);  // Workaround
                }
                //brs = Db.SQL<BR>("SELECT r FROM BR r WHERE r.P.ObjectNo = ? and r.Ptyp = ? and r.Ctyp = ?", request.M, request.Mtyp, request.Dtyp);
                //brs = Db.SQL<BR>("SELECT r FROM BR r WHERE r.C.ObjectNo = ? and r.Ptyp = ? and r.Ctyp = ?", request.M, request.Dtyp, request.Mtyp);

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
        public override async Task BRparentsFill(PKproxy request, IServerStreamWriter<BRparentsProxy> responseStream, ServerCallContext context)
        {
            BRparentsProxy proxy;
            string pString = null;

            await Scheduling.RunTask(() =>
            {
                pString = BR.GetParentsString(request.PK);
            });

            proxy = new BRparentsProxy
            {
                Node = request.PK,
                Parents = pString
            };
            await responseStream.WriteAsync(proxy);
        }
    }

}
