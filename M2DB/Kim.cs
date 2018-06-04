using System;
using Starcounter;

namespace M2DB
{
    [Database]
    public class KKK    // Kim, Musteri/Depo/UretimHatti/Personel
    {
        public string Ad { get; set; }
        public string Tur { get; set; }     //Depo, UretimHatti, Musteri, Personel, Imha, Fire, Kayip
    }

    public class KDT : KKK   // Kim.Depo.Tanim
    {
        public string Sorumlu { get; set; }
        public string Tel { get; set; }
    }

    public class KMT : KKK   // Kim.Musteri.Tanim
    {
        public string Tel { get; set; }
        public string Adres { get; set; }
        public string Sorumlu { get; set; }
        public string VrgDN { get; set; }
        public XGT ObjMusFytGrp { get; set; }    // MusteriFiyatGrubu: A, B, C
    }

    public class KMC : KKK   // Kim.Musteri.Contact
    {
        public KMT ObjP { get; set; }
        public string Tel { get; set; }
        public string KmlNo { get; set; }
        public string TAGs { get; set; }
    }

}
