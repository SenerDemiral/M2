using System;
using System.IO;
using System.Linq;
using Starcounter;

namespace M2DB
{
    [Database]
    public class AHP // Account: HesapPlani 1toM
    {
        public AHP ObjP { get; set; }     // Parent Hesap
        public string No { get; set; }    // Node HspNo
        public string Ad { get; set; }

        public double Brc { get; set; }
        public double Alc { get; set; }

        public bool HasP => ObjP == null ? false : true;
        public bool HasK => Db.SQL<AHP>($"select r from {typeof(AHP)} r where {nameof(ObjP)} = ?", this).FirstOrDefault() == null ? false : true;
        public bool HasH => Db.SQL<AFD>($"select r from {typeof(AFD)} r where {nameof(AFD.ObjAHP)} = ?", this).FirstOrDefault() == null ? false : true;

        public string HspNo
        {
            get
            {
                string HspNo = No;
                AHP pH = ObjP;

                while (pH != null)
                {
                    HspNo = $"{pH.No}.{HspNo}";
                    pH = pH.ObjP;
                }
                return HspNo;
            }
        }
        public int Lvl
        {
            get
            {
                int Lvl = 0;
                AHP pH = ObjP;

                while (pH != null)
                {
                    Lvl++;
                    pH = pH.ObjP;
                }
                return Lvl;
            }
        }
    }

    [Database]
    public class AFB    // Account: FisBaslik
    {
        public DateTime Trh { get; set; }
        public XGT ObjTur { get; set; }     // Tür 
        public string AoK { get; set; }     // Acik/Kapali
        public string Info { get; set; }

        public double BrcTop => Db.SQL<AFD>($"SELECT r FROM {typeof(AFD)} r WHERE r.ObjAFB = ?", this).Sum(x => x.Brc);
        public double AlcTop => Db.SQL<AFD>($"SELECT r FROM {typeof(AFD)} r WHERE {nameof(AFD.ObjAFB)} = ?", this).Sum(x => x.Alc);
        public bool HasD => Db.SQL<AFD>($"select r from {typeof(AFD)} r where {nameof(AFD.ObjAFB)} = ?", this).FirstOrDefault() == null ? false : true; // HasDetail
    }

    [Database]
    public class AFD    // Account: FisDetay
    {
        public AFB ObjAFB { get; set; }    // Baslik
        public AHP ObjAHP { get; set; }    // Hesap

        public string Info { get; set; }
        public double Tut { get; set; }     // Brc: +, Alc: -
        public XGT ObjDvz { get; set; }
        public float Kur { get; set; }
        public double TutTL { get; set; }

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
                    ObjP = Db.FromId<AHP>(1)
                };
                new AHP
                {
                    No = "01",
                    Ad = "TL",
                    ObjP = MK
                };
                new AHP
                {
                    No = "02",
                    Ad = "USD",
                    ObjP = MK
                };
                new AHP
                {
                    No = "03",
                    Ad = "EUR",
                    ObjP = MK
                };

            });

        }
    }
}
