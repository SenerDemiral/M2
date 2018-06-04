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

    /// <summary>
    /// Bir kaydin birden cok onayi olabilir
    /// </summary>
    [Database]
    public class XOO    // Genel.Object.Onay
    {
        public ulong RefNo { get; set; }    // RefTableObjNo
        public string RefTo { get; set; }   // Table
        public DateTime? Trh { get; set; }
        public UUU ObjUsr { get; set; }        // Onaylayan (veya Vekil)
        public UYT ObjYtk { get; set; }        // Yetki 
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
    /// 9, null, AFB.Tur
    /// A, 9,    M,       Mahsup   
    /// </summary>
    [Database]
    public class XGT    // Genel Tanimlar
    {
        public XGT ObjP { get; set; }
        public string Kd { get; set; }
        public string Ad { get; set; }
    }

}
