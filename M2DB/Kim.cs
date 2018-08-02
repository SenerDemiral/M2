using System;
using System.Collections.Generic;
using System.Linq;
using Starcounter;

namespace M2DB
{
    [Database]
    public class KKK : BB    // Kim (Base)
    {
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
        public KYT KYT { get; set; }            // Yetkisi
        public KPT()
        {
            Tbl = "KPT";
        }
    }

    [Database]
    public class KYT : BB   // Kim.Yetki.Tanim
    {
        public KYT()
        {
            Tbl = "KYT";
        }



        public static bool CanAppend(KYT curYtk, KYT apndYtk)
        {
            // CanAppend(NNN curNe, NNN apndNe) // CurrentNe ye AppendNe eklenebilir mi? HasParentsExistsInKids, Circular referans olamaz
            // Su anda Adina bakiyor, oNo ya bakmali

            // Zaten eklenmis ise
            if (Db.SQL<BR>("SELECT r FROM BR r WHERE r.P = ? AND r.C = ?", curYtk, apndYtk).FirstOrDefault() != null)
                return false;

            List<string> pList = new List<string>();
            // curNe and Parents
            BR nnr = null;
            KYT pNe = curYtk;
            do
            {
                if (nnr == null)
                    pNe = curYtk;
                else
                    pNe = nnr.P as KYT;
                //pNe = nnr?.P ?? curYtk;
                pList.Add(pNe.Ad);
                nnr = Db.SQL<BR>("SELECT r FROM BR r WHERE r.C = ?", pNe).FirstOrDefault();
            } while (nnr != null);

            // Search Kids, Varsa true
            return !HasKidInParents(apndYtk, pList);
        }
        private static bool HasKidInParents(KYT Kid, List<string> pList)
        {
            bool rv = false;
            foreach (var r in Db.SQL<BR>("select r from BR r where r.P = ?", Kid))
            {
                var aaa = r.C.Ad;
                foreach (var p in pList)
                {
                    if (p == r.C.Ad)
                    {
                        rv = true;
                        break;
                    }
                }
                if (rv)
                    break;
                ///////////////////////////else if (r.C.HasKid)
                    HasKidInParents(r.C as KYT, pList);
            }
            return rv;
        }


    }

    [Database]
    public class KYR : BR   // Kim.Yetki.Relation
    {
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

}
