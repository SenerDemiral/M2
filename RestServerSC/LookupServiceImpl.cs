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
    class LookupServiceImpl : Rest.LookupService.LookupServiceBase
    {
        // Base Deneme
        public override async Task BbL(QueryLookupProxy request, IServerStreamWriter<BbLookupProxy> responseStream, ServerCallContext context)
        {
            BbLookupProxy proxy = new BbLookupProxy();
            List<BbLookupProxy> proxyList = new List<BbLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                string srch = request.Query;
                bool all = string.IsNullOrEmpty(srch);

                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<BB>("select r from BB r"))
                    {
                        if (all || srch.Contains(row.Typ))
                        {
                            proxy = new BbLookupProxy
                            {
                                RowKey = row.GetObjectNo(),
                                Typ = row.Typ,
                                Kd = row.Kd ?? "",
                                Ad = row.Ad ?? "",
                                Info = row.Info ?? "",
                            };

                            proxyList.Add(proxy);
                        }
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
        // DepartmanTanim
        public override async Task KdtL(QueryLookupProxy request, IServerStreamWriter<KdtLookupProxy> responseStream, ServerCallContext context)
        {
            KdtLookupProxy proxy;
            BbMsg bbMsg;
            List<KdtLookupProxy> proxyList = new List<KdtLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<KDT>("select r from KDT r"))
                    {
                        bbMsg = new BbMsg
                        {
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };
                        proxy = new KdtLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            BB = bbMsg
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
        // FirmaTanim
        public override async Task KftL(QueryLookupProxy request, IServerStreamWriter<KftLookupProxy> responseStream, ServerCallContext context)
        {
            KftLookupProxy proxy;
            BbMsg bbMsg;
            List<KftLookupProxy> proxyList = new List<KftLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<KFT>("select r from KFT r"))
                    {
                        bbMsg = new BbMsg
                        {
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };
                        proxy = new KftLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            BB = bbMsg
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
        // PersonelTanim
        public override async Task KptL(QueryLookupProxy request, IServerStreamWriter<KptLookupProxy> responseStream, ServerCallContext context)
        {
            KptLookupProxy proxy;
            BbMsg bbMsg;
            List<KptLookupProxy> proxyList = new List<KptLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<KPT>("select r from KPT r"))
                    {
                        bbMsg = new BbMsg
                        {
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };
                        proxy = new KptLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            BB = bbMsg
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
        // NeTanim
        public override async Task NntL(QueryLookupProxy request, IServerStreamWriter<NntLookupProxy> responseStream, ServerCallContext context)
        {
            NntLookupProxy proxy;
            BbMsg bbMsg;
            List<NntLookupProxy> proxyList = new List<NntLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<NNN>("select r from NNN r"))
                    {
                        bbMsg = new BbMsg
                        {
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };
                        proxy = new NntLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            BB = bbMsg
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
        // HesapPlani
        public override async Task AhpL(QueryLookupProxy request, IServerStreamWriter<AhpLookupProxy> responseStream, ServerCallContext context)
        {
            AhpLookupProxy proxy;
            BbMsg bbMsg;
            List<AhpLookupProxy> proxyList = new List<AhpLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<AHP>("select r from AHP r"))
                    {
                        bbMsg = new BbMsg
                        {
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };
                        proxy = new AhpLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            BB = bbMsg,
                            HspNo = row.HspNo,
                            P = row.P == null ? 0 : row.P.GetObjectNo(),
                            IsW = row.IsW
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
        // VoucherKind
        public override async Task AvkL(QueryLookupProxy request, IServerStreamWriter<AvkLookupProxy> responseStream, ServerCallContext context)
        {
            AvkLookupProxy proxy;
            BbMsg bbMsg;
            List<AvkLookupProxy> proxyList = new List<AvkLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<AVK>("select r from AVK r"))
                    {
                        bbMsg = new BbMsg
                        {
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };
                        proxy = new AvkLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            BB = bbMsg
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
        // BillKind
        public override async Task AbkL(QueryLookupProxy request, IServerStreamWriter<AbkLookupProxy> responseStream, ServerCallContext context)
        {
            AbkLookupProxy proxy;
            BbMsg bbMsg;
            List<AbkLookupProxy> proxyList = new List<AbkLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<ABK>("select r from ABK r"))
                    {
                        bbMsg = new BbMsg
                        {
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };
                        proxy = new AbkLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            BB = bbMsg
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
        // GenelTanim
        public override async Task XgtL(QueryLookupProxy request, IServerStreamWriter<XgtLookupProxy> responseStream, ServerCallContext context)
        {
            XgtLookupProxy proxy;
            BbMsg bbMsg;
            List<XgtLookupProxy> proxyList = new List<XgtLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<XGT>("select r from XGT r WHERE r.P IS NOT NULL"))
                    {
                        bbMsg = new BbMsg
                        {
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };
                        proxy = new XgtLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            BB = bbMsg,
                            PKd = row.PKd
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }
    }

}


