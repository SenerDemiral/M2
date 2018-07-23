using System;
using Starcounter;

namespace M2DB
{
    [Database]
    public class KKK    // Kim (Base) IPTAL
    {
        public string Tur { get; set; }     // FRM:Firma, DPT:Departman (Uretim/Depo/Fire/Imha/Kayip), PRS:Personel, CNT:Contact, HBR:Haberlesme, TAG:Etiket
        public string Ad { get; set; }
        public string Info { get; set; }
    }

    [Database]
    public class KFT : BB   // Kim.Firma.Tanim
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

    public class KCT : BB   // Kim.Contact.Tanim
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
    public class KDT : BB   // Kim.Departman.Tanim
    {
        public string Skl { get; set; }     // Uretim/Depo/Fire/Imha/Kayip
        public KDT()
        {
            Tbl = "KDT";
        }
    }

    [Database]
    public class KPT : BB   // Kim.Personel.Tanim
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
    public class KHT : BB   // Kim.Haberlesme.Tanim
    {
        public BB M { get; set; }       // Masters are KDT,KPT,KFT,KCT,

        public string Mtyp => M?.GetType().Name;
        public string Mad => M?.Ad;

        public KHT()
        {
            Tbl = "KHT";
        }
    }

    [Database]
    public class KKR    // Kim.Relation IPTAL
    {
        public KKK KP { get; set; } // Parent/Left Kim
        public KKK KC { get; set; } // Child/Right Kim
        /*
        public static void deneme()
        {
            KFT kft = null;
            KCT kct = null;
            new KKR
            {
                KP = kft,
                KC = kct,
            };
            new KKR
            {
                KP = Db.FromId(111) as KDT,
                KC = Db.FromId(222) as KPT,
            };

        }*/
    }

}
