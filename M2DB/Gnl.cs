using System;
using System.IO;
using System.Linq;
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
        public string PKd => ObjP?.Kd;
        public string Kd { get; set; }
        public string Ad { get; set; }
    }

    [Database]
    public class XDK    // Genel DovizKurlari
    {
        public XGT ObjDvz { get; set; }
        public DateTime Trh { get; set; }
        public double Kur { get; set; }
    }

    public static class GnlOps
    {
        public static Tuple<object,double> TrhDvzKur(DateTime Trh)
        {
            return new Tuple<object, double>(365, 4.57);
        }

        public static void PopXGT()
        {
            if (Db.SQL<XGT>("select r from XGT r").FirstOrDefault() != null)
                return; // Kayit var yapma

            using (StreamReader sr = new StreamReader($@"C:\Starcounter\M2Data\XGT.csv", System.Text.Encoding.UTF8))
            {
                string line;
                Db.Transact(() =>
                {
                    XGT xgt = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] ra = line.Split('|');

                        xgt = null;
                        if (!string.IsNullOrWhiteSpace(ra[0]))
                        {
                            xgt = Db.SQL<XGT>("select r FROM XGT r WHERE r.ObjP IS NULL and r.Kd = ?", ra[0]).FirstOrDefault();
                        }
                        new XGT
                        {
                            ObjP = xgt,
                            Kd = ra[1],
                            Ad = ra[2]
                        };
                    }
                });

            }

        }
    }
}
