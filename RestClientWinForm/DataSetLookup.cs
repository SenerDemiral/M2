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
        public async Task<int> BbL()
        {
            var dt = BBL;
            DataRow row;
            BbLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Rows.Clear();
            using (var response = grpcService.ClientLookupService.BbL(new QueryLookupProxy { Query = "" }))
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

        public async Task<int> KdtL()
        {
            var dt = KDTL;
            DataRow row;
            KdtLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Rows.Clear();
            using (var response = grpcService.ClientLookupService.KdtL(new QueryLookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.BB.Kd;
                    row["Ad"] = proxy.BB.Ad;
                    row["Info"] = proxy.BB.Info;
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
            dt.Rows.Clear();
            using (var response = grpcService.ClientLookupService.KftL(new QueryLookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.BB.Kd;
                    row["Ad"] = proxy.BB.Ad;
                    row["Info"] = proxy.BB.Info;
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            return nor;
        }

        public async Task<int> KptL()
        {
            var dt = KPTL;
            DataRow row;
            KptLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Rows.Clear();
            using (var response = grpcService.ClientLookupService.KptL(new QueryLookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.BB.Kd;
                    row["Ad"] = proxy.BB.Ad;
                    row["Info"] = proxy.BB.Info;
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
            dt.Rows.Clear();
            using (var response = grpcService.ClientLookupService.NntL(new QueryLookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.BB.Kd;
                    row["Ad"] = proxy.BB.Ad;
                    row["Info"] = proxy.BB.Info;
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
            dt.Rows.Clear();    // dr.Clear() Column lari da siliyor ve yavas!!1
            using (var response = grpcService.ClientLookupService.AhpL(new QueryLookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    /*
                    row = dt.NewRow();
                    ProxyHelper.ProxyToRow(dt, row, response.ResponseStream.Current);
                    dt.Rows.Add(row);
                    */

                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.BB.Kd;
                    row["Ad"] = proxy.BB.Ad;
                    row["Info"] = proxy.BB.Info;
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            var ccc = dt.Rows.Count;
            return nor;
        }

        public async Task<int> XgtL()
        {
            var dt = XGTL;
            DataRow row;
            XgtLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Rows.Clear();    // dr.Clear() Column lari da siliyor ve yavas!!1
            using (var response = grpcService.ClientLookupService.XgtL(new QueryLookupProxy { Query = "" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    /*
                    row = dt.NewRow();
                    ProxyHelper.ProxyToRow(dt, row, response.ResponseStream.Current);
                    dt.Rows.Add(row);
                    */

                    proxy = response.ResponseStream.Current;
                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.BB.Kd;
                    row["Ad"] = proxy.BB.Ad;
                    row["Info"] = proxy.BB.Info;
                    row["PKd"] = proxy.PKd;
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            var ccc = dt.Rows.Count;
            return nor;
        }
    }
}
