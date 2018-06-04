using System;
using System.IO;
using System.Linq;
using Starcounter;

namespace M2DB
{
    [Database]
    public class AHP // Account: HesapPlani 1toM
    {
        public AHP P { get; set; }        // Parent Hesap
        public string No { get; set; }    // Node HspNo
        public string Ad { get; set; }

        public double Brc { get; set; }
        public double Alc { get; set; }

        public bool HasP => P == null ? false : true;
        public bool HasK => Db.SQL<AHP>("select r from M2DB.AHP r where r.P = ?", this).FirstOrDefault() == null ? false : true;
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
                AHP pH = P;

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
                AHP pH = P;

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
        public AHP AHP { get; set; }    // Hesap

        public string Info { get; set; }
        public double Tut { get; set; }

        public string BA => Tut >= 0 ? "B" : "A";
        public double Brc => Tut >= 0 ? Tut : 0;
        public double Alc => Tut < 0 ? -Tut : 0;
    }

    public static class AccOps
    {
        public static void PopAHP()
        {
            if (Db.SQL<AHP>("select r from AHP r").FirstOrDefault() != null)
                return; // Kayit var yapma

            using (StreamReader sr = new StreamReader($@"C:\Starcounter\M2Data\AHP.csv", System.Text.Encoding.UTF8))
            {
                string line;
                Db.Transact(() =>
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] ra = line.Split('|');

                        new AHP
                        {
                            No = ra[0],
                            Ad = ra[1]
                        };
                    }
                });

            }

            Db.Transact(() =>
            {
                var MK = new AHP
                {
                    No = "01",
                    Ad = "Merkez Kasa",
                    P = Db.FromId<AHP>(1)
                };
                new AHP
                {
                    No = "01",
                    Ad = "TL",
                    P = MK
                };
                new AHP
                {
                    No = "02",
                    Ad = "USD",
                    P = MK
                };
                new AHP
                {
                    No = "03",
                    Ad = "EUR",
                    P = MK
                };

            });

        }
    }
}
