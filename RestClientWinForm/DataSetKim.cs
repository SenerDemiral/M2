using Rest;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestClientWinForm
{

    partial class DataSetKim
    {
        Stopwatch sw = new Stopwatch();

        public async Task<string> KFTfill()
        {
            var dt = KFT;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.KFTfill(new QryProxy { Query = "abc" }))
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
        public string KFTupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = KFT;
            var request = new KFTproxy();
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

                    var reply = grpcService.ClientCRUDs.KFTupdate(request);  // --------->

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

        public async Task<string> KHTfill(ulong P, string Ptyp)
        {
            var dt = KHT;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.KHTfill(new QryPproxy { P = P, Ptyp = Ptyp }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    //var proxy = response.ResponseStream.Current;

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
        public string KHTupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = KHT;
            var request = new KHTproxy();
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

                    var reply = grpcService.ClientCRUDs.KHTupdate(request);  // --------->

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

        public async Task<string> KPTfill(ulong M)
        {
            var dt = KPT;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.KPTfill(new QryMDproxy { M = M }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    //var proxy = response.ResponseStream.Current;

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
        public string KPTupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = KPT;
            var request = new KPTproxy();
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

                    var reply = grpcService.ClientCRUDs.KPTupdate(request);  // --------->

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

        public async Task<string> KDTfill()
        {
            var dt = KDT;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.KDTfill(new QryProxy { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken()))
                {
                    //var proxy = response.ResponseStream.Current;

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
        public string KDTupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = KDT;
            var request = new KDTproxy();
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

                    var reply = grpcService.ClientCRUDs.KDTupdate(request);  // --------->

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
        public async Task<string> KDTtreeDownFill()
        {
            var dt = KdtTreeDown;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.KDTtreeDownFill(new QryProxy { Query = "abc" }))
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

    }
}
