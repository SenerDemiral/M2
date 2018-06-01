using System;
using Starcounter;

namespace M2DB
{
    [Database]
    public class AHT // Account.HesapTanim 1toM
    {
        public AHT Prn { get; set; }        // Parent Hesap
        public string No { get; set; }      // Node HspNo
        public string Ad { get; set; }
        public int Lvl { get; set; }
        public double Brc { get; set; }
        public double Alc { get; set; }
        public bool HasKid { get; set; }

        public string HspNo
        {
            get
            {
                string H = No;
                AHT pH = Prn;

                while (pH != null)
                {
                    H = pH.No + "." + H;
                    pH = pH.Prn;
                }
                return H;
            }
        }
    }

    [Database]
    public class AFB    // Account, Fis Baslik
    {
        public DateTime Trh { get; set; }
        public string Tur { get; set; }
        public string Drm { get; set; }
        public string Aciklama { get; set; }
    }

    [Database]
    public class AFD    // Muhasebe, Fis Detay
    {
        public AFB AFB { get; set; }    // Baslik
        public AHT AHT { get; set; }    // Hesap

        public string Ack { get; set; } // Aciklama
        public string BA { get; set; }
        public double Tut { get; set; }
        public double Brc => BA == "B" ? Tut : 0;
        public double Alc => BA == "A" ? Tut : 0;
    }
}
