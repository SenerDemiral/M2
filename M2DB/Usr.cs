using System;
using System.Linq;
using Starcounter;

namespace M2DB
{
    /// <summary>
    /// Programa girebilmek icin UUU kaydinin olmasi gerekir
    /// </summary>

    [Database]
    public class UUU    // User
    {
        public string Ad { get; set; }
        public UYT UYT { get; set; }    // User Yetkisi (tek bir yetkisi olabilir)
        public string Pwd { get; set; }
        public DateTime PwdLCD { get; set; }    // Pwd LastChangeDate

        public string UYTAd => UYT?.Ad;
    }

    [Database]
    public class UYT    // User.YetkiTanimlari
    {
        public string Ad { get; set; }
    }

    [Database]
    public class UYH    // User.YetkiHiyerarsi M2M
    {
        public UYT P { get; set; }  // Parent
        public UYT K { get; set; }  // Kid/Child

        public string PAd => P?.Ad;
        public string KAd => K?.Ad;
    }

    [Database]
    public class UHT    // User History Transaction
    {
        public UUU UUU { get; set; }        // User
        public ulong RefNO { get; set; }    // Islem ObjectNo
        public string Skl { get; set; }     // Add/Mdf/Dlt
        public DateTime Trh { get; set; }

        public string UUUAd => UUU?.Ad;
        public IObjectView objectView => Db.FromId(RefNO);
        public string typeName => (Db.FromId(this.RefNO)).GetType().Name;
        

        public static void Append(ulong rowUsr, ulong refNO, string rowState)
        {
            var uth = new UHT
            {
                UUU = Db.FromId(rowUsr) as UUU,
                RefNO = refNO,
                Skl = rowState,
                Trh = DateTime.Now,
            };
            /*
            try
            {
                dynamic aaa = Db.FromId(uth.RefNO);
                aaa.Ad = 1234;
            }
            catch { } //(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            */
        }
    }

    [Database]
    public class UHO    // User History Onay
    {
        public UUU UUU { get; set; }        // User
        public ulong RefNO { get; set; }    // Islemin yapildigi rec ObjectNo
        public UYT UYT { get; set; }        // Yetki (Herzaman kendi yetkisi olmayabilir, Ust/Alt yetki kullanabilir
        public DateTime Trh { get; set; }

        public string UUUAd => UUU?.Ad;

        public static void Append(ulong rowUsr, ulong refNO, ulong ytkNO)
        {
            var uth = new UHO
            {
                UUU = Db.FromId(rowUsr) as UUU,
                RefNO = refNO,
                UYT = Db.FromId(ytkNO) as UYT,
                Trh = DateTime.Now,
            };
        }
    }

    public static class UsrOps
    {
        public static void PopUUU()
        {
            if (Db.SQL<UUU>("select r from UUU r").FirstOrDefault() != null)
                return; // Kayit var yapma

            Db.Transact(() =>
            {
                var y1 = new UYT
                {
                    Ad = "GnlMdr",
                };
                var y2 = new UYT
                {
                    Ad = "Muhasebe",
                };
                var y3 = new UYT
                {
                    Ad = "Operasyon",
                };
                var y21 = new UYT
                {
                    Ad = "Muhasebe Dış",
                };
                var y22 = new UYT
                {
                    Ad = "Muhasebe İç",
                };
                var y31 = new UYT
                {
                    Ad = "Operasyon Dış",
                };
                var y32 = new UYT
                {
                    Ad = "Operasyon İç",
                };

                new UYH
                {
                    P = null,
                    K = y1
                };
                new UYH
                {
                    P = y1,
                    K = y2
                };
                new UYH
                {
                    P = y2,
                    K = y21
                };
                new UYH
                {
                    P = y2,
                    K = y22
                };
                new UYH
                {
                    P = y1,
                    K = y3
                };
                new UYH
                {
                    P = y3,
                    K = y31
                };
                new UYH
                {
                    P = y3,
                    K = y32
                };
                new UYH
                {
                    P = y3,
                    K = y2
                };

                new UUU
                {
                    Ad = "Sener",
                    UYT = y1
                };
                new UUU
                {
                    Ad = "Can",
                    UYT = y2
                };
                new UUU
                {
                    Ad = "Dilara",
                    UYT = y3
                };
                new UUU
                {
                    Ad = "Ahmet",
                    UYT = y21
                };
                new UUU
                {
                    Ad = "Mehmet",
                    UYT = y22
                };
                new UUU
                {
                    Ad = "Hasan",
                    UYT = y31
                };
                new UUU
                {
                    Ad = "Huseyin",
                    UYT = y31
                };
                new UUU
                {
                    Ad = "Ali",
                    UYT = y32
                };
                new UUU
                {
                    Ad = "Veli",
                    UYT = y32
                };

            });
        }
    }
}
