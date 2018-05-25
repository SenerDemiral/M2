using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using Rest;

namespace RestClientWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test();
        }

        async void Test()
        {
            //var dt = dataSet1.Tables[0];
            StringBuilder sb = new StringBuilder();
            int nor = 0, ml = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = client.SelectTbla(new TblaQry { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(token))
                {
                    var rec = response.ResponseStream.Current;
                    //dt.Rows.Add(rec.Message);

                    sb.AppendLine(rec.Ono.ToString());
                    nor++;
                    ml += rec.CalculateSize();
                    //MessageBox.Show(rec.Message);
                }
            }
            sw.Stop();
            //MessageBox.Show(sb.ToString());
            MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
        }
    }
}
