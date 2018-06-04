using System;
using System.Linq;
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
    public class NHT // Ne.Hiyerarsi.Tree
    {
        public NNN ObjPrnNNN { get; set; }
        public NNN ObjKidNNN { get; set; }
        public double Mik { get; set; }

        public string PrnAd => ObjPrnNNN?.Ad;
        public string PrnNo => ObjPrnNNN?.No;
        public string KidAd => ObjKidNNN?.Ad;
        public string KidNo => ObjKidNNN?.No;
    }
}
