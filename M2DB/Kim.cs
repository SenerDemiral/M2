using System;
using Starcounter;

namespace M2DB
{
    [Database]
    public class KKK : BB    // Kim (Base)
    {
    }

    [Database]
    public class KFT : KKK   // Kim.Firma.Tanim
    {
        public string Skl { get; set; }         // ALC:Alıcı/STC:Satıcı/A&S:AliciSatici....
        public string VrgDN { get; set; }
        public XGT ObjMusFytGrp { get; set; }  // MusteriFiyatGrubu: A, B, C
        public AHP AHPbrc { get; set; }        // Borclu Musteri Hesap
        public AHP AHPalc { get; set; }        // Alacakli Musteri Hesap
        public KFT()
        {
            Tbl = "KFT";
        }
    }

    public class KCT : KKK   // Kim.Contact.Tanim
    {
        public BB M { get; set; }       // Masters is KFT
        public string Unvan { get; set; }
        public string TAGs { get; set; }
        public KCT()
        {
            Tbl = "KCT";
        }
    }

    [Database]
    public class KDT : KKK   // Kim.Departman.Tanim
    {
        public string Skl { get; set; }     // Uretim/Depo/Fire/Imha/Kayip
        public KDT()
        {
            Tbl = "KDT";
        }
    }

    [Database]
    public class KPT : KKK   // Kim.Personel.Tanim
    {
        public string KmlNo { get; set; }
        public DateTime IsGrsTrh { get; set; }
        public DateTime IsCksTrh { get; set; }
        public DateTime DgmTrh { get; set; }
        public KPT()
        {
            Tbl = "KPT";
        }
    }

    [Database]
    public class KHT : KKK   // Kim.Haberlesme.Tanim
    {
        public BB M { get; set; }       // Masters are KDT,KPT,KFT,KCT,

        public string Mtyp => M?.GetType().Name;
        public string Mad => M?.Ad;

        public KHT()
        {
            Tbl = "KHT";
        }
    }

}
