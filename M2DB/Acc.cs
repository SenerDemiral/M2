using System;
using System.Linq;
using Starcounter;

namespace M2DB
{
    [Database]
    public class AHT // Account: HesapTanim 1toM
    {
        public AHT P { get; set; }        // Parent Hesap
        public string No { get; set; }    // Node HspNo
        public string Ad { get; set; }

        public double Brc { get; set; }
        public double Alc { get; set; }

        //public bool HasP => P == null ? false : true;
        //public bool HasK => Db.SQL("select r from M2DB.AHT r where r.P = ?", this.GetObjectNo()).FirstOrDefault() == null ? false : true;
        /*
        public bool HasK
        {
            get
            {
                if (Db.SQL("select r from M2DB.AHT where r.P = ?", this.GetObjectNo()).FirstOrDefault() == null)
                    return false;
                return true;
            }
        }*/
        public string HspNo
        {
            get
            {
                string HspNo = No;
                AHT pH = P;

                while (pH != null)
                {
                    HspNo = $"{pH.No}.{HspNo}";
                    pH = pH.P;
                }
                return HspNo;
            }
        }
        public int Lvl
        {
            get
            {
                int Lvl = 0;
                AHT pH = P;

                while (pH != null)
                {
                    Lvl++;
                    pH = pH.P;
                }
                return Lvl;
            }
        }
    }

    [Database]
    public class AFB    // Account: FisBaslik
    {
        public DateTime Trh { get; set; }
        public XGT Tur { get; set; }        // Tür 
        public string AoK { get; set; }     // Acik/Kapali
        public string Info { get; set; }
    }

    [Database]
    public class AFD    // Account: FisDetay
    {
        public AFB AFB { get; set; }    // Baslik
        public AHT AHT { get; set; }    // Hesap

        public string Info { get; set; }
        public double Tut { get; set; }

        public string BA => Tut >= 0 ? "B" : "A";
        public double Brc => Tut >= 0 ? Tut : 0;
        public double Alc => Tut <  0 ? -Tut : 0;
    }
}
