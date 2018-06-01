using System;
using Starcounter;

namespace M2
{
    class Program
    {
        static void Main()
        {
            var dt = DateTime.Now.Ticks;
            var a = new DateTime(dt);
            //decimal d = 123.56M;
            var c = Convert.ToDateTime(dt);
        }
    }


}