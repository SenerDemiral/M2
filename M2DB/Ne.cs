using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starcounter;

namespace M2DB
{
    /// <summary>
    /// Maddenin birimleri tek olmali BirimConversion eziyetli bir surec
    /// Nelerden olustugu Hiyerarside belirtilmeli
    /// 
    /// NULL-KolaPalet: 1
    ///   KolaPalet-KolaKasa: 100Ksa/1Plt (Her bir Paletteki Kasa miktari. Kasa/Palet)
    ///     KolaKasa-KolaSise: 12Adt/1Ksa
    ///       KolaSise-Kola: 0.25Ltr/1Adt
    ///       KolaSise-CamSise: 1Adt/1Adt
    ///       KolaSise-Kapak: 1Adt/1Adt
    ///       KolaSise-DuzIsci: 0.1Saat/1Adt
    ///     KolaKasa-DuzIsci: 0.2Saat/1Adt
    ///   KolaPalet-Palet: 1Adt/1Adt
    ///   KolaPalet-StrechFilm: 15Mtr/1Adt
    ///   KolaPaket-DuzIsci: 0.3Saat/1Adt
    ///   
    /// 100Ksa/Plt x 12Adt/Ksa x 0.25Ltr/Adt = 300Ltr/Plt (1Plt de 300Ltr Kola var)
    /// 100Ksa/Plt x 12Adt/Ksa x 1.00Adt/Adt = 120Adt/Plt (1Plt de 120Adt Sise var)
    /// 100Ksa/Plt x 12Adt/Ksa x 1.00Adt/Adt = 120Adt/Plt (1Plt de 120Adt Kapak var)
    /// 
    /// Alis:
    /// Kola: 1000Ltr 
    /// CamSise: 5000Adt
    /// Kapak: 5000Adt
    /// Uretim: Depolardan alir, Uretim Yapar, Depolara verir
    /// KolaSise: 500Adt
    /// KolaPalet:100Adt
    /// Satis: Depodan alir, NakliyeAracinaYukler, Musterilere verir
    /// KolaPalet: 10Adt
    /// KolaKasa: 200Adt
    /// </summary>
    [Database]
    public class NNN // Ne
    {
        public string No { get; set; }
        public string Ad { get; set; }
        public XGT ObjTur { get; set; }     // HamMadde, YariMamul, Mamul, TuketimMlz.Su/Elektrik/Yakit, Iscilik
        public XGT ObjBrm { get; set; }     // Birim: KWh, Ltr, Mt, M3, Ton, Kg, Adt, 
        public AHP ObjAHPbrc { get; set; }  // Borclu Ne Hesap
        public AHP ObjAHPalc { get; set; }  // Alacakli Ne Hesap
        public double Fyt { get; set; }  // Simdilik
        public bool HasKid
        {
            get
            {
                if (Db.SQL<NHT>("select r from M1DB.NHT r where r.Prn = ?", this).FirstOrDefault() == null)
                    return false;
                return true;
            }
        }
        public bool HasPrn
        {
            get
            {
                if (Db.SQL<NHT>("select r from M1DB.NHT r where r.Kid = ? and r.Prn is not null", this).FirstOrDefault() == null)
                    return false;
                return true;
            }
        }
    }

    [Database]
    public class NKM    // Ne.Kimde.Miktar
    {
        public NNN ObjNNN { get; set; }
        public KKK ObjKKK { get; set; }
        public double GirMik { get; set; }
        public double CikMik { get; set; }
        public double KlnMik => GirMik - CikMik;

        public double SonGirMik { get; set; }
        public double SonCikMik { get; set; }
        public DateTime? SonGirTrh { get; set; }
        public DateTime? SonCikTrh { get; set; }
    }

    [Database]
    public class NFA    // Ne.FiyatAnlasmalari
    {
        public NNN ObjNNN { get; set; }    // NeyinFiyati
        public KKK ObjKKK { get; set; }    // Musteri
        public string AoS { get; set; } // Alis/Satis
        public DateTime BasTrh { get; set; }    // AnlasmaBaslangic
        public DateTime BitTrh { get; set; }
        public int OncSra { get; set; }     // Bir Mal birden cok Musteriden Alinabilir, Hangisinden alinacagina karar vermek icin
        public double Fyt { get; set; }
        public XGT ObjDvz { get; set; }
        public string Ack { get; set; } // Aciklama (OdemeSekli, Vade

    }

    /// <summary>
    /// Birim Fiyat Analizleri gibi. TemelKalemler(Atom/Indivisible:Element) -> Analiz(Molekul) -> Aktivite(Polymer)
    /// </summary>
    [Database]
    public class NHT // Ne.Hiyerarsi.Tree IPTAL
    {
        public NNN ObjPrnNNN { get; set; }
        public NNN ObjKidNNN { get; set; }
        public double Mik { get; set; }

        public string PrnAd => ObjPrnNNN?.Ad;
        public string PrnNo => ObjPrnNNN?.No;
        public string KidAd => ObjKidNNN?.Ad;
        public string KidNo => ObjKidNNN?.No;
    }

    [Database]
    public class NNR // Ne.Recete
    {
        public NNN ObjNeP { get; set; } // Parent
        public NNN ObjNeK { get; set; } // Kid
        public double Mik { get; set; }

        public string PrnAd => ObjNeP?.Ad;
        public string KidAd => ObjNeK?.Ad;

        public static void KidInRootsMik(ulong KidObjNo)
        {
            if (!(Db.FromId(KidObjNo) is NNN Kid))
                return;

            //NNN Kid = Db.FromId(KidObjNo) as NNN;
            //if (Kid == null)
            //    return;

            StringBuilder sb = new StringBuilder();
            Dictionary<ulong, double> MikDict = new Dictionary<ulong, double>();

            Console.WriteLine("");
            Console.WriteLine("KidInRootsMikDty++++");

            MikDict.Clear();
            KidInRootsMikDty(KidObjNo, MikDict);

            NNN Ne;
            foreach (var i in MikDict)
            {
                Ne = Db.FromId<NNN>(i.Key);
                if (!Ne.HasPrn)  // Root
                    Console.WriteLine($">>{Kid.Ad}@{Ne.Ad}={i.Value:n}");

            }
            Console.WriteLine("");
            Console.WriteLine("KidInRootsMikDty----");
        }

        private static void KidInRootsMikDty(ulong sNo, Dictionary<ulong, double> mD)
        {
            ulong PoNo = 0, KoNo = 0;
            double pMik = 0, kMik = 0;
            string s = "";

            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.ObjK.ObjectNo = ?", sNo))
            {
                PoNo = r.ObjNeP.GetObjectNo();
                KoNo = r.ObjNeK.GetObjectNo();

                if (!mD.ContainsKey(PoNo))
                    mD[PoNo] = 0;

                kMik = mD.ContainsKey(KoNo) ? mD[KoNo] : 1;

                if (!r.ObjNeP.HasPrn)  // Root
                {
                    pMik = mD[PoNo];
                    mD[PoNo] += kMik * r.Mik;
                    s = $"{r.PrnAd}.{r.KidAd}:{r.Mik} =>";
                    Console.WriteLine($"+ {s,40} {r.PrnAd}[{pMik}] + ({r.Mik} x {r.KidAd}[{kMik}] = {kMik * r.Mik}) => {r.PrnAd}[{mD[PoNo]}]");
                    //Console.WriteLine($"\t+ {r.PrnAd}.{r.KidAd}:{r.Mik}\t{r.PrnAd}[{pMik}] + ({r.Mik} x {r.KidAd}[{kMik}] = {kMik * r.Mik}) => {r.PrnAd}[{mD[PoNo]}]");
                }
                else
                {
                    mD[PoNo] = kMik * r.Mik;
                    s = $"{r.PrnAd}.{r.KidAd}:{r.Mik} =>";
                    if (mD.ContainsKey(KoNo))
                        Console.WriteLine($"* {s,40} {r.KidAd}[{kMik}] x {r.Mik} => {r.PrnAd}[{mD[PoNo]}]");
                    else
                        Console.WriteLine($"& {s,40} {r.PrnAd}[{mD[PoNo]}]");
                }


                if (r.ObjNeP.HasPrn)
                    KidInRootsMikDty(r.ObjNeP.GetObjectNo(), mD);
            }

            return;
        }

        public static void NodeGerekenKidsMik(ulong node, double Mik)
        {
            // node dan Mik kadar isteniyor, stoktakiler kullanildiginda ne kadar Kids alinmali.
            Dictionary<ulong, double> S = new Dictionary<ulong, double>();  // Stok
            Dictionary<ulong, double> G = new Dictionary<ulong, double>();  // Gereken

            // Burasi Siparis listesindeki her kalem icin donerek, gereken toplam miktarlar alinabilir.
            //foreach(var r in Db.SQL<TTT>("select r from TSD r where r.Prn.ObjectNo = ?", TSBoNo))
            //{
            //    NodeKidsMikDty(node, 1, S, G);
            //}
            NodeGerekenKidsMikDty(node, Mik, S, G);
            NNN s = Db.FromId<NNN>(node);
            Console.WriteLine($"Nodes @{s.Ad} ---------->");
            foreach (var r in G)
            {
                s = Db.FromId<NNN>(r.Key);
                Console.WriteLine($"{s.Ad} -> Stok: {S[r.Key]}, Gereken: {r.Value}");
            }
            /*
            var aaa = Db.FromId(46);    // Musteri
            var bbb = Db.FromId(29);    // Depo
            var tsb = Db.FromId(47) as TSB;    // TSB

            var ccc = ((KMT)tsb.DST).Adres; // DST is KKK
            */
        }

        private static void NodeGerekenKidsMikDty(ulong Prn, double Mik, Dictionary<ulong, double> S, Dictionary<ulong, double> G)
        {
            ulong Kid = 0;
            double GMik = 0;

            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.ObjNeP.ObjectNo = ?", Prn))
            {
                Kid = r.ObjNeK.GetObjectNo();

                if (!S.ContainsKey(Kid))
                    S[Kid] = 0; //StokMik(Kid);

                GMik = Mik * r.Mik;
                if (GMik > S[Kid])
                {
                    GMik -= S[Kid];
                    S[Kid] = 0;
                }
                else
                {
                    S[Kid] -= GMik;
                    GMik = 0;
                }

                if (!G.ContainsKey(Kid))
                    G[Kid] = 0;
                G[Kid] += GMik;

                if (GMik > 0 && r.ObjNeK.HasKid)
                    NodeGerekenKidsMikDty(Kid, GMik, S, G);
            }
        }



    }






}
