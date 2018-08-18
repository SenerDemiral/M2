using System;
using System.Collections.Generic;
using System.Data;
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
    }

    public class KCT : BB   // Kim.Contact.Tanim
    {
        public BB M { get; set; }       // Masters is KFT
        public string Unvan { get; set; }
        public string TAGs { get; set; }
    }

    [Database]
    public class KDT : BB   // Kim.Departman.Tanim
    {
        public string Skl { get; set; }     // Uretim/Depo/Fire/Imha/Kayip

        public bool HasKid
        {
            get
            {
                if (Db.SQL<BR>("select r from M2DB.BR r where r.P = ?", this).FirstOrDefault() == null)
                    return false;
                return true;
            }
        }
        public bool HasPrn
        {
            get
            {
                if (Db.SQL<BR>("select r from M2DB.BR r where r.C = ?", this).FirstOrDefault() == null)
                    return false;
                return true;
            }
        }

        public static DataTable TreeDown()
        {
            DataTable table = new DataTable();
            table.Columns.Add("L", typeof(int));
            table.Columns.Add("P", typeof(ulong));
            table.Columns.Add("K", typeof(ulong));
            table.Columns.Add("A", typeof(string));
            table.Columns.Add("N", typeof(ulong));

            ulong P = 0;
            ulong K = 1;
            foreach (var n in Db.SQL<KDT>("SELECT r FROM KDT r WHERE r.HasPrn = ?", false))
            {
                table.Rows.Add(0, P, K, n.Ad, n.GetObjectNo());
                K++;
            }

            for (int L = 1; L < 10; L++)
            {
                DataRow[] dr = table.Select($"L = {L - 1}");
                foreach (var r in dr)
                {
                    P = (ulong)r["K"];

                    foreach (var nr in Db.SQL<BR>("SELECT r FROM BR r WHERE r.P.ObjectNo = ? and r.Ptyp = ? and r.Ctyp = ?", r["N"], "KDT", "KDT"))
                    {
                        table.Rows.Add(L, P, K, nr.C.Ad, nr.C.GetObjectNo());
                        K++;
                    }

                }
            }
            return table;
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
    }

    [Database]
    public class KYT : BB   // Kim.Yetki.Tanim
    {
        public static bool CanAppend(KYT curYtk, KYT apndYtk)
        {
            // CanAppend(NNT curNe, NNT apndNe) // CurrentNe ye AppendNe eklenebilir mi? HasParentsExistsInKids, Circular referans olamaz
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
    }

}
