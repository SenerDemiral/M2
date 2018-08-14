using Grpc.Core;
using Rest;
using System;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestClientWinForm
{
    partial class DataSetLookup
    {
        
        private static Channel channel;
        private static LookupService.LookupServiceClient client;

        public static void lookupServiceClientInit()
        {
            channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            client = new LookupService.LookupServiceClient(channel);
        }
        public static void lookupServiceClientShutDown()
        {
            channel.ShutdownAsync();//.Wait();
        }
        
        public async Task<int> BbL()
        {
            var dt = BBL;
            DataRow row;
            BbLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Clear();
            using (var response = grpcService.ClientLookupService.BbL(new LookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Typ"] = proxy.Typ;
                    row["Kd"] = proxy.Kd;
                    row["Ad"] = proxy.Ad;
                    row["Info"] = proxy.Info;
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            return nor;
        }

        public async Task<int> KftL()
        {
            var dt = KFTL;
            DataRow row;
            KftLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Clear();
            /*
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new LookupService.LookupServiceClient(channel);
            CancellationToken token = new CancellationToken();
            */
            using (var response = grpcService.ClientLookupService.KftL(new LookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.Kd;
                    row["Ad"] = proxy.Ad;
                    row["Info"] = proxy.Info;
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            return nor;
        }

        public async Task<int> NntL()
        {
            var dt = NNTL;
            DataRow row;
            NntLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Clear();

            using (var response = grpcService.ClientLookupService.NntL(new LookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.Kd;
                    row["Ad"] = proxy.Ad;
                    row["Info"] = proxy.Info;
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            return nor;
        }

        public async Task<int> AhpL()
        {
            var dt = AHPL;
            DataRow row;
            AhpLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Clear();

            using (var response = grpcService.ClientLookupService.AhpL(new LookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.Kd;
                    row["Ad"] = proxy.Ad;
                    row["Info"] = proxy.Info;
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            return nor;
        }
    }
}
