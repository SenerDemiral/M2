using System;
using Starcounter;

namespace M2DB
{
    [Database]
    public class KKK    // Kim, Musteri/Depo/UretimHatti/Personel
    {
        public string Ad { get; set; }
        public string Tur { get; set; }     //DP:Depo, UH:UretimHatti, Firma, Personel, Imha, Fire, Kayip
    }

    public class KDT : KKK   // Kim.Depo.Tanim
    {
        public string Sorumlu { get; set; }
        public string Tel { get; set; }
    }

    public class KFT : KKK   // Kim.Musteri.Tanim
    {
        public string Tel { get; set; }
        public string Adres { get; set; }
        public string Sorumlu { get; set; }
        public string VrgDN { get; set; }
        public XGT ObjMusFytGrp { get; set; }     // MusteriFiyatGrubu: A, B, C
        public AHP AHPbrc { get; set; }        // Borclu Musteri Hesap
        public AHP AHPalc { get; set; }        // Alacakli Musteri Hesap
    }

    public class KMC : KKK   // Kim.Musteri.Contact
    {
        public KFT KFT { get; set; }
        public string Tel { get; set; }
        public string KmlNo { get; set; }
        public string TAGs { get; set; }
    }

}
