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
        public async Task<int> BbL()    // Base Deneme
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

                    /* Asagidakiler hiz kazandirmiyor.!!
                    1: dt.Rows.Add(proxy.RowKey, proxy.Typ, proxy.Kd, proxy.Ad, proxy.Info);
                    2: Index kullanarak 
                    row[0] = proxy.RowKey;
                    row[1] = proxy.Typ;
                    row[2] = proxy.Kd;
                    row[3] = proxy.Ad;
                    row[4] = proxy.Info;
                    */
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

        public async Task<int> KdtL()   // DepartmanTanim
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

        public async Task<int> KftL()   // FirmaTanim
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

        public async Task<int> KptL()   // PersonelTanim
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

        public async Task<int> NntL()   // NeTanim
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

        public async Task<int> AhpL()   // HesapPlani
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
                    proxy = response.ResponseStream.Current;

                    row = dt.NewRow();
                    row["RowKey"] = proxy.RowKey;
                    row["Kd"] = proxy.BB.Kd;
                    row["Ad"] = proxy.BB.Ad;
                    row["Info"] = proxy.BB.Info;
                    row["P"] = proxy.P;
                    row["IsW"] = proxy.IsW;
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            dt.AcceptChanges();
            dt.EndLoadData();
            var ccc = dt.Rows.Count;
            return nor;
        }

        public async Task<int> AvkL()   // VoucherKind
        {
            var dt = AVKL;
            DataRow row;
            AvkLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Rows.Clear();    // dr.Clear() Column lari da siliyor ve yavas!!1
            using (var response = grpcService.ClientLookupService.AvkL(new QueryLookupProxy { Query = "" }))
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

        public async Task<int> AbkL()   // BillKind
        {
            var dt = ABKL;
            DataRow row;
            AbkLookupProxy proxy;
            int nor = 0;

            dt.BeginLoadData();
            dt.Rows.Clear();    // dr.Clear() Column lari da siliyor ve yavas!!1
            using (var response = grpcService.ClientLookupService.AbkL(new QueryLookupProxy { Query = "" }))
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

        public async Task<int> XgtL()   // GenelTanim
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
