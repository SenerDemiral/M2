using System;
using System.IO;
using System.Linq;
using Starcounter;

namespace M2DB
{
    [Database]
    public class AKH    // KDV Hesaplari
    {
        public string Key { get; set; }     // B/A+KDY   B1, B8, B18, A1, A8, A18
        public AHP AHP { get; set; }
    }

    [Database]
    public class AHP // Account: HesapPlani 1toM
    {
        public AHP P { get; set; }     // Parent Hesap
        public string No { get; set; }    // Node HspNo
        public string Ad { get; set; }

        public double Brc { get; set; }
        public double Alc { get; set; }
        public bool IsW { get; set; }     // Calisan Hesap?

        public bool HasP => P == null ? false : true;
        public bool HasK => Db.SQL<AHP>($"select r from {typeof(AHP)} r where {nameof(P)} = ?", this).FirstOrDefault() == null ? false : true;
        public bool HasH => Db.SQL<AFD>($"select r from {typeof(AFD)} r where {nameof(AFD.AHP)} = ?", this).FirstOrDefault() == null ? false : true;

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

        public static bool IsAhpNoUnique(AHP pAhp, string newNo)
        {
            AHP ahp;
            if (pAhp == null)
                ahp = Db.SQL<AHP>("select r from AHP r where r.P IS NULL and r.No = ?", newNo).FirstOrDefault();
            else
                ahp = Db.SQL<AHP>("select r from AHP r where r.P = ? and r.No = ?", pAhp, newNo).FirstOrDefault();

            if (ahp == null)
                return true;
            return false;
        }

        public static void AhpTopUpdAfd(AHP ahp)
        {
            Db.Transact(() =>
            {
                //Tuple<double, double> res = Db.SQL<Tuple<double, double>>("SELECT SUM(r.Brc), SUM(r.Alc) FROM AFD r WHERE r.ObjAHP = ? and r.ObjAFB.Drm = ?", ahp, "K")?.FirstOrDefault();
                Tuple<double, double> res = Db.SQL<Tuple<double, double>>("SELECT SUM(r.Brc), SUM(r.Alc) FROM AFD r WHERE r.AHP = ?", ahp)?.FirstOrDefault();
                if (res != null)
                {
                    ahp.Brc = res.Item1;
                    ahp.Alc = res.Item2;

                    if (ahp.P != null)   // Ust hesabi varsa
                    {
                        AHP pAHP = ahp.P;
                        double Brc = 0, Alc = 0;
                        do
                        {
                            Brc = 0;
                            Alc = 0;
                            foreach (var m in Db.SQL<AHP>("select m from AHP m where m.P = ?", pAHP))
                            {
                                Brc += m.Brc;
                                Alc += m.Alc;
                            }
                            pAHP.Brc = Brc;
                            pAHP.Alc = Alc;

                            pAHP = pAHP.P;
                        }
                        while (pAHP != null);
                    }
                }
            });
         }

    }

    [Database]
    public class AFB    // Account: FisBaslik
    {
        public string Drm { get; set; }     // Acik/Kapali/Pending
        public DateTime Trh { get; set; }
        public XGT TUR { get; set; }     // Tür
        public string RefTo { get; set; }   // Master (Nerden geldi)
        public ulong RefNo { get; set; }    // Master No
        public string Info { get; set; }

        public double Brc => Db.SQL<AFD>($"SELECT r FROM {typeof(AFD)} r WHERE r.AFB = ?", this).Sum(x => x.Brc);
        public double Alc => Db.SQL<AFD>($"SELECT r FROM {typeof(AFD)} r WHERE {nameof(AFD.AFB)} = ?", this).Sum(x => x.Alc);
        public bool HasD => Db.SQL<AFD>($"select r from {typeof(AFD)} r where {nameof(AFD.AFB)} = ?", this).FirstOrDefault() == null ? false : true; // HasDetail
    }

    [Database]
    public class AFD    // Account: FisDetay
    {
        public AFB AFB { get; set; }    // Baslik
        public AHP AHP { get; set; }    // Hesap

        public string Info { get; set; }
        public double Tut { get; set; }     // Brc: +, Alc: -
        public XGT DVT { get; set; }
        public float Kur { get; set; }
        public double TutTL { get; set; }

        public string BA => Tut >= 0 ? "B" : "A";
        public double Brc => Tut >= 0 ? TutTL : 0;
        public double Alc => Tut < 0 ? -TutTL : 0;
    }

    [Database]
    public class ABB    // Account: Bill/Fatura Baslik
    {
        public string Drm { get; set; }     // Acik/Kapali/Pending
        public DateTime Trh { get; set; }
        public XGT TUR { get; set; }     // BillTür Satis(B)/SatisIade(A) Alis(A)/AlisIade(B)
        public KKK KKK { get; set; }     // Kim/Musteri
        public string BA { get; set; }      // Kim Brclu/Alacakli
        public XGT DVT { get; set; }     // Fatura Doviz
        public float Kur { get; set; }      // Doviz Kuru
        public string Info { get; set; }

        public double Tut => Db.SQL<ABD>($"SELECT r FROM {typeof(ABD)} r WHERE r.ABB = ?", this).Sum(x => x.TutB);
        public bool HasD => Db.SQL<ABD>($"select r from {typeof(ABD)} r where {nameof(ABD.ABB)} = ?", this).FirstOrDefault() == null ? false : true; // HasDetail

        public static void ABB2AFB(ABB abb) // Insert AFB & AFDs from ABB & ABDs
        {
            Db.Transact(() =>
            {
                double TopTut = 0;
                double TopTutTL = 0;

                AFB afb = new AFB();
                afb.RefTo = "ABB";  // Bill/Fatura dan yaratildi
                afb.RefNo = abb.GetObjectNo();

                AFD afd;

                // Icindekileri Fise koy
                foreach (var abd in Db.SQL<ABD>("SELECT r FROM ABD r WHERE r.ObjABB = ?", abb))
                {
                    afd = new AFD();
                    afd.AFB = afb;

                    if (abb.BA == "A")  // Basligin tersi
                        afd.AHP = abd.NNN.AHPbrc;
                    else
                        afd.AHP = abd.NNN.AHPalc;

                    afd.Tut = abd.TutB;
                    afd.DVT = abb.DVT;
                    afd.Kur = abb.Kur;
                    afd.TutTL = abd.TutTL;

                    TopTut += afd.Tut;
                    TopTutTL += afd.TutTL;
                }

                // Bill Musteriyi Detaya Koy BA
                afd = new AFD();
                afd.AFB = afb;

                if (abb.BA == "B")
                    afd.AHP = (abb.KKK as KFT).AHPbrc;
                else
                    afd.AHP = (abb.KKK as KFT).AHPalc;
                afd.Tut = TopTut;
                afd.DVT = abb.DVT;
                afd.Kur = abb.Kur;
                afd.TutTL = TopTutTL;
            });
        }
    }

    [Database]
    public class ABD    // Account: Bill/Fatura Detay
    {
        public ABB ABB { get; set; }    // Baslik
        public NNN NNN { get; set; }    // Ne
        public AHP AHP { get; set; }    // Ne Hesap

        public double Fyt { get; set; }
        public double Mik { get; set; }
        public XGT DVT { get; set; }
        public float Kur { get; set; }
        public Int16 KDY { get; set; }
        public string Info { get; set; }

        public double Tut => Math.Round(Fyt * Mik * (1.0 + KDY), 2);
        public double TutTL => Math.Round(Tut * Kur, 2);
        public double TutB => DVT == ABB.DVT ? Tut : Math.Round(TutTL / ABB.Kur, 2);    // BaslikDovize gore

        public double TutNet => Math.Round(Fyt * Mik, 2);
        public double TutNetTL => Math.Round(TutNet * Kur, 2);
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
