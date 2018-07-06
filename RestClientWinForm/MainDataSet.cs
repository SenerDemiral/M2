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
    partial class MainDataSet
    {
        public async Task<string> AHPfill()
        {
            var dt = AHP;

            dt.BeginLoadData();
            int nor = 0, ml = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            DataRow row;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = client.AHPfill(new QryProxy { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(token))
                {
                    //var proxy = response.ResponseStream.Current;

                    row = dt.NewRow();
                    ProxyHelper.ProxyToRow(dt, row, response.ResponseStream.Current);
                    dt.Rows.Add(row);

                    nor++;
                    //ml += response.ResponseStream.Current.CalculateSize();
                    //MessageBox.Show(rec.Message);
                }
            }
            sw.Stop();
            dt.AcceptChanges();
            dt.EndLoadData();
            //MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
            return $"{nor:n0} records ({ml:n0} bytes) retrieved in {sw.ElapsedMilliseconds:n0} ms  ({(nor / sw.ElapsedMilliseconds * 1000):n0} recs/sec)";
        }

        public async Task<string> XGTfill()
        {
            var dt = XGT;

            dt.BeginLoadData();
            int nor = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            DataRow row;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = client.XGTfill(new QryProxy { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(token))
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
            //MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
            return $"{nor:n0} records retrieved in {sw.ElapsedMilliseconds:n0} ms  ({(nor / sw.ElapsedMilliseconds * 1000):n0} recs/sec)";
        }

        public string XGTupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = XGT;
            var request = new XGTproxy();

            string rs = "";

            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M" || rs == "D")
                {
                    dt.Rows[i].ClearErrors();
                    request.RowState = rs;

                    if (rs == "D")
                        request.RowPk = (ulong)dt.Rows[i]["RowPk", DataRowVersion.Original];
                    else
                        ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = client.XGTupdate(request);

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
            channel.ShutdownAsync().Wait();

            return sb.ToString();
        }

        public async Task<string> XDKfill(QryProxy qp)     // DovizKurlari
        {
            var dt = XDK;

            dt.BeginLoadData();
            int nor = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            DataRow row;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //QryProxy qp = new QryProxy();
            //qp.Query = "Trh";
            //qp.Param = DateTime.Today.Ticks.ToString();

            using (var response = client.XDKfill(qp))
            {
                while (await response.ResponseStream.MoveNext(token))
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
            //MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
            return $"{nor:n0} records retrieved in {sw.ElapsedMilliseconds:n0} ms  ({(nor / sw.ElapsedMilliseconds * 1000):n0} recs/sec)";
        }

        public string XDKupdate()     // DovizKurlari
        {
            StringBuilder sb = new StringBuilder();
            var dt = XDK;
            var request = new XDKproxy();

            string rs = "";

            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M" || rs == "D")
                {
                    dt.Rows[i].ClearErrors();
                    request.RowState = rs;

                    if (rs == "D")
                        request.RowPk = (ulong)dt.Rows[i]["RowPk", DataRowVersion.Original];
                    else
                        ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = client.XDKupdate(request);

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
            channel.ShutdownAsync().Wait();

            return sb.ToString();
        }

        public async Task<string> KFTfill()
        {
            var dt = KFT;

            dt.BeginLoadData();
            int nor = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            DataRow row;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = client.KFTfill(new QryProxy { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(token))
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
            //MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
            return $"{nor:n0} records retrieved in {sw.ElapsedMilliseconds:n0} ms  ({(nor / sw.ElapsedMilliseconds * 1000):n0} recs/sec)";
        }

        public string KFTupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = KFT;
            var request = new KFTproxy();

            string rs = "";

            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M" || rs == "D")
                {
                    dt.Rows[i].ClearErrors();
                    request.RowState = rs;
                    request.RowUsr = Program.ObjUsr;

                    if (rs == "D")
                        request.RowPk = (ulong)dt.Rows[i]["RowPk", DataRowVersion.Original];
                    else
                        ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = client.KFTupdate(request);  // --------->

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
            channel.ShutdownAsync().Wait();

            return sb.ToString();
        }

        public async Task<string> UYHfill()
        {
            var dt = UYH;

            dt.BeginLoadData();
            int nor = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            DataRow row;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = client.UYHfill(new QryProxy { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(token))
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
            //MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
            return $"{nor:n0} records retrieved in {sw.ElapsedMilliseconds:n0} ms  ({(nor / sw.ElapsedMilliseconds * 1000):n0} recs/sec)";
        }

        public string UYHupdate()
        {
            StringBuilder sb = new StringBuilder();
            var dt = UYH;
            var request = new UYHproxy();

            string rs = "";

            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M" || rs == "D")
                {
                    dt.Rows[i].ClearErrors();
                    request.RowState = rs;
                    request.RowUsr = Program.ObjUsr;

                    if (rs == "D")
                        request.RowPk = (ulong)dt.Rows[i]["RowPk", DataRowVersion.Original];
                    else
                        ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = client.UYHupdate(request);  // --------->

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
            channel.ShutdownAsync().Wait();

            return sb.ToString();
        }

    }
}
