using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestServerSC
{
    public static class Owner
    {
        public static Dictionary<string, object> Dct = new Dictionary<string, object>();

        public static void Init()
        {
            Dct["FirmaAd"] = "SOS";

            Dct["%1KdvBrcHspNo"]  = "191.1.1";
            Dct["%8KdvBrcHspNo"]  = "191.1.8";
            Dct["%18KdvBrcHspNo"] = "191.1.18";

            Dct["%1KdvAlcHspNo"]  = "191.2.1";
            Dct["%8KdvAlcHspNo"]  = "191.2.8";
            Dct["%18KdvAlcHspNo"] = "191.2.18";
        }
    }
}
