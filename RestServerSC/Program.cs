using System;
using System.Threading.Tasks;
using Starcounter;
using Grpc.Core;
using Rest;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2DB;

namespace RestServerSC
{
    class Program
    {
        const int Port = 50051;

        static void Main()
        {
            M2DB.AccOps.PopAHP();
            M2DB.GnlOps.PopXGT();

            Db.Transact(() =>
            {
                new AFB
                {
                    AoK = "A",
                    Trh = DateTime.Today,
                };
                /*
                var afb = new AFB
                {
                    Info = "deneme",
                    AoK = "A",
                    Trh = DateTime.Now
                };

                new AFD
                {
                    ObjAFB = afb,
                    Tut = 100,
                };
                new AFD
                {
                    ObjAFB = afb,
                    Tut = -300,
                };
                new AFD
                {
                    ObjAFB = afb,
                    Info = null,
                };*/

                //ReflectionExample.deneme<M2DB.AHT>(3);

            });
            

            /*
            M2DB.TblB tb = null;

            Db.Transact(() =>
            {
                tb = new M2DB.TblB
                {
                    FldStr = "Sener",
                    FldDate = DateTime.Now
                };

            });
            TblaProxy a = ReflectionExample.ToProxy<TblaProxy, M2DB.TblB>(tb);
            a.RowErr = "";

            Console.WriteLine("Deneme");

            a.FldStr = a.FldStr.ToUpper();
            //a.RowPk = 0;

            Db.Transact(() =>
            {
                // Converting the proxy object into the database object.
                // This will set the database object property values.
                // Those the changes made to the proxy object will be saved to the database.
                M2DB.TblB tblb = ReflectionExample.FromProxy<TblaProxy, M2DB.TblB>(a);
            });
*/
            Console.WriteLine("Deneme");


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

        // Reflection yerine fastMember kullanilabilir, hizli ama gerekli mi?
        // https://github.com/mgravell/fast-member

    }

}