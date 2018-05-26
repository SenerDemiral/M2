using System;
using System.Threading.Tasks;
using Starcounter;
using Grpc.Core;
using Rest;

namespace RestServerSC
{
    class Program
    {
        const int Port = 50051;

        static void Main()
        {
            Db.Transact(() =>
            {
                new M2DB.TblA
                {
                    FldStr = "Sener"
                };

            });

            Server server = new Server
            {
                Services = { CRUDs.BindService(new CRUDsImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                //Ports = { new ServerPort("217.160.13.102", Port, ServerCredentials.Insecure) }
                //Ports = { new ServerPort("192.168.1.20", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Rest server listening on port " + Port);

        }
    }

    class CRUDsImpl : Rest.CRUDs.CRUDsBase
    {
        public override Task<TblaRec> TblaUpdate(TblaRec request, ServerCallContext context)
        {
            var result = new TblaRec
            {
                RowPk = request.RowPk,
                FldStr = request.FldStr,
                FldDbl = request.FldDbl,
                FldDcm = request.FldDcm,
                FldDateTicks = request.FldDateTicks,
                FldInt = request.FldInt
            };

            Scheduling.RunTask(() =>
            {
                // RowState: Added, Modified, Deletede, Unchanged
                Db.TransactAsync(() =>
                {
                    if (request.RowState == "A")
                    {
                        var rec = new M2DB.TblA
                        {
                            FldStr = request.FldStr,
                            FldInt = request.FldInt,
                            FldDate = new DateTime(request.FldDateTicks)
                        };
                        result.RowPk = rec.GetObjectNo();
                    }
                    else if (request.RowState == "M")
                    {
                        var rec = Db.FromId(request.RowPk) as M2DB.TblA;
                        if (rec == null)
                        {
                            result.RowErr = "TblA Rec not found";
                        }
                        else
                        {
                            rec.FldStr = request.FldStr;
                            rec.FldInt = request.FldInt;
                            rec.FldDate = new DateTime(request.FldDateTicks);
                        }
                    }
                    else if (request.RowState == "D")
                    {
                        var rec = Db.FromId(request.RowPk) as M2DB.TblA;
                        if (rec == null)
                        {
                            result.RowErr = "TblA Rec not found";
                        }
                        else
                        {
                            rec.Delete();
                        }
                    }
                });
            }).Wait();

            return Task.FromResult(result);

        }

        public override async Task TblaFill(QryStr request, IServerStreamWriter<TblaRec> responseStream, ServerCallContext context)
        {
            var hr = new TblaRec
            {
                RowPk = 1,
                FldStr = "Bir",
                FldDbl = 1.23,
                FldDcm = 2.34,
                FldDateTicks = DateTime.Now.Ticks,
                FldInt = 1
            };

            
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
            /*
            for (int i = 0; i < 10000; i++)
            {
                hr.Ono = (ulong)i;
                await responseStream.WriteAsync(hr);
            }*/
        }
    }

}