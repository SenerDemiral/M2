using System;
using Starcounter;

namespace M2DB
{
    [Database]
    public class XOM    // Genel.Object.Modify
    {
        public ulong RefNo { get; set; }    // RefTableObjNo
        public string RefTo { get; set; }   // Table
        public DateTime? Ins { get; set; }
        public DateTime? Upd { get; set; }
    }

    [Database]
    public class XOO    // Genel.Object.Onay
    {
        public ulong RefNo { get; set; }    // RefTableObjNo
        public string RefTo { get; set; }   // Table
        public string OnyUsr { get; set; }
        public string OnyYtk { get; set; }
        public DateTime? OnyTrh { get; set; }
    }

    /// <summary>
    /// ParentNode lari ben olusturacagim, Altini Kullanici
    /// #, Prn,  Kd,      Ad
    /// 1, null, Dvz,     Doviz Tanimlari
    /// 2, 1,    USD,     ABD Dolari
    /// 3, 1,    EUR,     Avro
    /// 4, null, NNN.Tur, Stok Turleri
    /// 5, 4,    HM,      HamMadde
    /// 6, 4,    YM,      YariMamul
    /// 7, null, NNN.Brm, StokBirimleri
    /// 8, 7,    Kg,      Kilogram
    /// </summary>
    [Database]
    public class XGT    // Genel Tanimlar
    {
        public XGT Prn { get; set; }
        public string Kd { get; set; }
        public string Ad { get; set; }
    }

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
}
