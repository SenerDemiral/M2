using Grpc.Core;
using Rest;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestClientWinForm
{
    partial class AccDataSet
    {
        public string AHPupdate()
        {
            StringBuilder sb = new StringBuilder();

            string rs = "";

            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);

            var request = new AHPproxy();

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges

            for (int i = 0; i < AHP.Rows.Count; i++)
            {

                // States: Added, Modified, Deletede, Unchanged
                rs = AHP.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M")
                {
                    AHP.Rows[i].ClearErrors();
                    request.RowState = rs;

                    ProxyHelper.RowToProxy(AHP, AHP.Rows[i], request);
                    
                    var reply = client.AHPupdate(request);

                    if (string.IsNullOrEmpty(reply.RowErr))
                    {
                        ProxyHelper.ProxyToRow(AHP, AHP.Rows[i], reply);
                        AHP.Rows[i].AcceptChanges();
                    }
                    else
                    {
                        AHP.Rows[i].RowError = reply.RowErr;
                        sb.AppendLine(reply.RowErr);
                        AHP.Rows[i].RejectChanges();

                    }
                }
            }
            channel.ShutdownAsync().Wait();

            return sb.ToString();
        }


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
                    ml += response.ResponseStream.Current.CalculateSize();
                    //MessageBox.Show(rec.Message);
                }
            }
            sw.Stop();
            dt.AcceptChanges();
            dt.EndLoadData();
            //MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
            return $"{nor:n0} records ({ml:n0} bytes) retrieved in {sw.ElapsedMilliseconds:n0} ms  ({(nor / sw.ElapsedMilliseconds * 1000):n0} recs/sec)";
        }

    }
}
