using Rest;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestClientWinForm
{
    partial class DataSetNe
    {
        Stopwatch sw = new Stopwatch();

        public async Task<string> NNTfill()
        {
            var dt = NNT;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.NNTfill(new QryProxy { Query = "abc" }))
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
        public string NNTupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = NNT;
            var request = new NNTproxy();
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

                    var reply = grpcService.ClientCRUDs.NNTupdate(request);  // --------->

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

        public async Task<string> NNRfill(ulong P)
        {
            var dt = NNR;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.NNRfill(new PKproxy { PK = P }))
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
        public string NNRupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = NNR;
            var request = new NNRproxy();
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

                    var reply = grpcService.ClientCRUDs.NNRupdate(request);  // --------->

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
        public async Task<string> NeParentsFill(ulong P)
        {
            var dt = NeParents;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.NeParentsFill(new PKproxy { PK = P }))
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


        public async Task<string> NeUpFill()
        {
            var dt = NeUp;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.NeUpFill(new QryProxy { Query = "abc" }))
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
        public async Task<string> NeDownFill()
        {
            var dt = NeDown;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.NeDownFill(new QryProxy { Query = "abc" }))
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
        public async Task<string> NodesInParentsFill()
        {
            var dt = NodesInParents;
            DataRow row;
            int nor = 0;

            dt.BeginLoadData();
            sw.Start();
            using (var response = grpcService.ClientCRUDs.NodesInParentsFill(new QryProxy { Query = "abc" }))
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
