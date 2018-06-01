using System;
using Starcounter;

namespace M2DB
{
    [Database]
    public class NNN // Ne
    {
        public string No { get; set; }
        public string Ad { get; set; }
        public XGT Tur { get; set; }     // HamMadde, YariMamul, Mamul, TuketimMlz.Su/Elektrik/Yakit, Iscilik
        public XGT Brm { get; set; }     // Birim: KWh, Ltr, Mt, M3, Ton, Kg, Adt, 
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
        public NNN Ne { get; set; }
        public KKK Kim { get; set; }
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
        public NNN Ne { get; set; }    // NeyinFiyati
        public KKK Kim { get; set; }    // Musteri
        public string AoS { get; set; } // Alis/Satis
        public DateTime BasTrh { get; set; }    // AnlasmaBaslangic
        public DateTime BitTrh { get; set; }
        public int OncSra { get; set; }     // Bir Mal birden cok Musteriden Alinabilir, Hangisinden alinacagina karar vermek icin
        public double Fyt { get; set; }
        public XGT Dvz { get; set; }
        public string Ack { get; set; } // Aciklama (OdemeSekli, Vade

    }

    /// <summary>
    /// Birim Fiyat Analizleri gibi. TemelKalemler(Atom/Indivisible:Element) -> Analiz(Molekul) -> Aktivite(Polymer)
    /// </summary>
    [Database]
    public class NHT // Ne.Hiyerarsi.Tree
    {
        public NNN Prn { get; set; }
        public NNN Kid { get; set; }
        public double Mik { get; set; }

        public string PrnAd => Prn?.Ad;
        public string PrnNo => Prn?.No;
        public string KidAd => Kid?.Ad;
        public string KidNo => Kid?.No;
    }
}
