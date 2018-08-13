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
        public override async Task KftL(LookupProxy request, IServerStreamWriter<KftLookupProxy> responseStream, ServerCallContext context)
        {
            KftLookupProxy proxy = new KftLookupProxy();
            List<KftLookupProxy> proxyList = new List<KftLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<KFT>("select r from KFT r"))
                    {
                        proxy = new KftLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }

        public override async Task NntL(LookupProxy request, IServerStreamWriter<NntLookupProxy> responseStream, ServerCallContext context)
        {
            NntLookupProxy proxy;
            List<NntLookupProxy> proxyList = new List<NntLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<NNN>("select r from NNN r"))
                    {
                        proxy = new NntLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
                        };

                        proxyList.Add(proxy);
                    }
                }
            });

            foreach (var p in proxyList)
                await responseStream.WriteAsync(p);
        }

        public override async Task AhpL(LookupProxy request, IServerStreamWriter<AhpLookupProxy> responseStream, ServerCallContext context)
        {
            AhpLookupProxy proxy;
            List<AhpLookupProxy> proxyList = new List<AhpLookupProxy>();

            await Scheduling.RunTask(() =>
            {
                for (int i = 0; i < 1; i++)
                {
                    foreach (var row in Db.SQL<AHP>("select r from AHP r"))
                    {
                        proxy = new AhpLookupProxy
                        {
                            RowKey = row.GetObjectNo(),
                            Kd = row.Kd ?? "",
                            Ad = row.Ad ?? "",
                            Info = row.Info ?? "",
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


