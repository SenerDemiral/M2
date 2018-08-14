using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using Rest;

namespace RestClientWinForm
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static ulong ObjUsr = 262;
        public static MainXF MF;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MF = new MainXF();
            MF.FillTanimlar();
            Application.Run(MF);
        }
    }

    public static class grpcService
    {
        public static Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
        public static LookupService.LookupServiceClient ClientLookupService = new LookupService.LookupServiceClient(channel);
        public static CRUDs.CRUDsClient ClientCRUDs = new CRUDs.CRUDsClient(channel);
    }
}
