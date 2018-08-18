using Rest;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestClientWinForm
{


    partial class DataSetTrnsfr
    {
        Stopwatch sw = new Stopwatch();

        // OrderMaster
        public async Task<string> TOMfill()
        {
            var dt = TOM;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.TOMfill(new QryProxy { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    row = dt.NewRow();
                    ProxyHelper.ProxyToRow(dt, row, response.ResponseStream.Current);
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            sw.Stop();
            dt.AcceptChanges();
            dt.EndLoadData();
            return $"{nor:n0} records retrieved in {sw.ElapsedMilliseconds:n0} ms";
        }
        public string TOMupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = TOM;
            var request = new TOMproxy();
            string rs = "";

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M" || rs == "D")
                {
                    dt.Rows[i].ClearErrors();
                    request.RowSte = rs;
                    request.RowUsr = Program.ObjUsr;

                    if (rs == "D")
                        request.RowKey = (ulong)dt.Rows[i]["RowKey", DataRowVersion.Original];
                    else
                        ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = grpcService.ClientCRUDs.TOMupdate(request);  // --------->

                    if (string.IsNullOrEmpty(reply.RowErr))
                    {
                        if (rs != "D")
                            ProxyHelper.ProxyToRow(dt, dt.Rows[i], reply);
                        dt.Rows[i].AcceptChanges();
                    }
                    else
                    {
                        dt.Rows[i].RowError = reply.RowErr;
                        sb.AppendLine(reply.RowErr);
                        //dt.Rows[i].RejectChanges();
                        ProxyHelper.ProxyToRow(dt, dt.Rows[i], reply);
                        dt.Rows[i].AcceptChanges();
                    }
                }
            }
            return sb.ToString();
        }
        // OrderDetail
        public async Task<string> TODfill(ulong M)
        {
            var dt = TOD;
            DataRow row;
            int nor = 0;
            Stopwatch sw = new Stopwatch();

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.TODfill(new QryMDproxy { M = M, Mtyp = "AVM" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    row = dt.NewRow();

                    ProxyHelper.ProxyToRow(dt, row, response.ResponseStream.Current);
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            sw.Stop();
            dt.AcceptChanges();
            dt.EndLoadData();
            return $"{nor:n0} records retrieved in {sw.ElapsedMilliseconds:n0} ms";
        }
        public string TODupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = TOD;
            var request = new TODproxy();
            string rs = "";

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M" || rs == "D")
                {
                    dt.Rows[i].ClearErrors();
                    request.RowSte = rs;
                    request.RowUsr = Program.ObjUsr;

                    if (rs == "D")
                        request.RowKey = (ulong)dt.Rows[i]["RowKey", DataRowVersion.Original];
                    else
                        ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = grpcService.ClientCRUDs.TODupdate(request);  // --------->

                    if (string.IsNullOrEmpty(reply.RowErr))
                    {
                        if (rs != "D")
                            ProxyHelper.ProxyToRow(dt, dt.Rows[i], reply);
                        dt.Rows[i].AcceptChanges();
                    }
                    else
                    {
                        dt.Rows[i].RowError = reply.RowErr;
                        sb.AppendLine(reply.RowErr);
                        dt.Rows[i].RejectChanges();

                    }
                }
            }
            return sb.ToString();
        }

        // WaybillMaster
        public async Task<string> TWMfill()
        {
            var dt = TWM;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.TWMfill(new QryProxy { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    row = dt.NewRow();
                    ProxyHelper.ProxyToRow(dt, row, response.ResponseStream.Current);
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            sw.Stop();
            dt.AcceptChanges();
            dt.EndLoadData();
            return $"{nor:n0} records retrieved in {sw.ElapsedMilliseconds:n0} ms";
        }
        public string TWMupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = TWM;
            var request = new TWMproxy();
            string rs = "";

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M" || rs == "D")
                {
                    dt.Rows[i].ClearErrors();
                    request.RowSte = rs;
                    request.RowUsr = Program.ObjUsr;

                    if (rs == "D")
                        request.RowKey = (ulong)dt.Rows[i]["RowKey", DataRowVersion.Original];
                    else
                        ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = grpcService.ClientCRUDs.TWMupdate(request);  // --------->

                    if (string.IsNullOrEmpty(reply.RowErr))
                    {
                        if (rs != "D")
                            ProxyHelper.ProxyToRow(dt, dt.Rows[i], reply);
                        dt.Rows[i].AcceptChanges();
                    }
                    else
                    {
                        dt.Rows[i].RowError = reply.RowErr;
                        sb.AppendLine(reply.RowErr);
                        //dt.Rows[i].RejectChanges();
                        ProxyHelper.ProxyToRow(dt, dt.Rows[i], reply);
                        dt.Rows[i].AcceptChanges();
                    }
                }
            }
            return sb.ToString();
        }
        // WaybillDetail
        public async Task<string> TWDfill(ulong M)
        {
            var dt = TWD;
            DataRow row;
            int nor = 0;
            Stopwatch sw = new Stopwatch();

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.TWDfill(new QryMDproxy { M = M, Mtyp = "AVM" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    row = dt.NewRow();

                    ProxyHelper.ProxyToRow(dt, row, response.ResponseStream.Current);
                    dt.Rows.Add(row);

                    nor++;
                }
            }
            sw.Stop();
            dt.AcceptChanges();
            dt.EndLoadData();
            return $"{nor:n0} records retrieved in {sw.ElapsedMilliseconds:n0} ms";
        }
        public string TWDupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = TWD;
            var request = new TWDproxy();
            string rs = "";

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M" || rs == "D")
                {
                    dt.Rows[i].ClearErrors();
                    request.RowSte = rs;
                    request.RowUsr = Program.ObjUsr;

                    if (rs == "D")
                        request.RowKey = (ulong)dt.Rows[i]["RowKey", DataRowVersion.Original];
                    else
                        ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = grpcService.ClientCRUDs.TWDupdate(request);  // --------->

                    if (string.IsNullOrEmpty(reply.RowErr))
                    {
                        if (rs != "D")
                            ProxyHelper.ProxyToRow(dt, dt.Rows[i], reply);
                        dt.Rows[i].AcceptChanges();
                    }
                    else
                    {
                        dt.Rows[i].RowError = reply.RowErr;
                        sb.AppendLine(reply.RowErr);
                        dt.Rows[i].RejectChanges();

                    }
                }
            }
            return sb.ToString();
        }
    }
}
