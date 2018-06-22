using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Rest;
using Starcounter;

namespace RestServer
{
    class Program
    {
        const int Port = 50051;

        static void Main(string[] args)
        {
            var aaa = Db.FromId(362);
            int bbb = 0;

            Server server = new Server
            {
                Services = { CRUDs.BindService(new CRUDsImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                //Ports = { new ServerPort("192.168.1.20", Port, ServerCredentials.Insecure) }
                //Ports = { new ServerPort("217.160.13.102", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

        }
    }

    class CRUDsImpl : Rest.CRUDs.CRUDsBase
    {
        public override async Task TblaFill(QryProxy request, IServerStreamWriter<TblaProxy> responseStream, ServerCallContext context)
        {
            var hr = new TblaProxy
            {
                RowPk = 1,
                FldStr = "Bir",
                FldDbl = 1.23,
                FldDcm = 2.34,
                FldDate = DateTime.Now.Ticks,
                FldInt = 1
            };

            /*
            for (int i = 0; i < 1; i++)
            {
                await Scheduling.RunTask(() =>
                {
                    foreach (var r in Db.SQL<M2DB.TblA>("select r from TblA r"))
                    {
                        //hr.Message = r.Field1;
                        Task.Run(async () =>
                        {
                            await responseStream.WriteAsync(hr);
                        }).Wait();
                    }
                });
            }
            */
            for (int i = 0; i < 100000; i++)
            {
                hr.RowPk = (ulong)i;
                await responseStream.WriteAsync(hr);
            }
        }
    }

}

