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

    [Database]
    public class KPT : BB   // Kim.Personel.Tanim
    {
        public KFT KFT { get; set; } 
        public string Drm { get; set; }
        public string Unvan { get; set; }
        public string KmlNo { get; set; }
        public DateTime IsGrsTrh { get; set; }
        public DateTime IsCksTrh { get; set; }
        public DateTime DgmTrh { get; set; }
        public string TAGs { get; set; }

        public int YtkStsNo { get; set; }       // 0: Yetkisiz else Onaylama sirasi
        public int YtkAlsNo { get; set; }       // 0: Yetkisiz else Onaylama sirasi
        public int YtkTrnNo { get; set; }       // 0: Yetkisiz else Onaylama sirasi
        // Bu Prs yetkili ise onay verebilir.
        //   Ornegin Siparis verilirken: 
        //   Siparisin sekline gore, 
        //   Yetkililerin her biri icin  SiraNo ya gore 
        //   XOH da kayit acilir, Ilgili personele alert gonderilir, 
        //   Personel Kabul/Red onayi verir (PrsNo ve Tarih)
    }

    [Database]
    public class KDT : BB   // Kim.Departman.Tanim
    {
        public string Skl { get; set; }         // Uretim/Depo/Fire/Imha/Kayip

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

    /* KULLANILMIYOR, SILME ornek
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
    */
    [Database]
    public class KHT : BB   // Kim.Haberlesme.Tanim
    {
        public BB M { get; set; }       // Masters are KDT,KPT,KFT,KCT,

        public string Mtyp => M?.GetType().Name;
        public string Mad => M?.Ad;
    }

    public static class KimOps
    {
        public static void PopKDT()
        {
            if (Db.SQL<KDT>("select r from KDT r").FirstOrDefault() != null)
                return; // Kayit var yapma

            Db.Transact(() =>
            {
                var ceo = new KDT
                {
                    Kd = "CEO",
                    Ad = "Chief Executive Officer",
                    Info = "is responsible for corporate vision and strategy. Creates the annual plans, validates budgets and revenue, organisational growth and expansion plans. Communicates strategy and plans to board and takes approvals. Connects with investors to ensure cash flow and fund for growth and expansion. Signs the annual reports of the organization."
                };
                var cfo = new KDT
                {
                    Kd = "CFO",
                    Ad = "Chief Financial Officer",
                    Info = "is responsible for financial operations in relation to payables, receivable, expenses and treasury. The month closing and data for year end annual reports are also his responsibility."
                };
                var coo = new KDT
                {
                    Kd = "COO",
                    Ad = "Chief Operating Officer",
                    Info = "is responsible for the day to day operations of the organization. Execution of plans created and validated by CEO is responsibility of COO."
                };
                var cmo = new KDT
                {
                    Kd = "CMO",
                    Ad = "Chief Marketing Officer",
                    Info = "is responsible for organizations’ marketing strategies in terms of products and offerings, target geographies and target customers and executes these plans with COO"
                };
                var cio = new KDT
                {
                    Kd = "CIO",
                    Ad = "Chief Information Officer",
                    Info = "is responsible for information distribution and processing in terms of budgets, expenses, payables, receivable, production data, logistics data, supplier data, salaries, leave records and all other information that is generated and consumed within the organization. CIO leverage ERP, IT and Data management solutions to perform their responsibilities."
                };
                var cto = new KDT
                {
                    Kd = "CTO",
                    Ad = "Chief Technology Officer",
                    Info = "is responsible for technology inputs for product development, offering improvisation and innovation."
                };
                var cxo = new KDT
                {
                    Kd = "CXO",
                    Ad = "Chief Experience Officer",
                    Info = "is ultimately responsible for the strategy behind and user interface design of the organization's products and services, and may further oversee marketing communications, community relations, internal relations, HR relations, investor relations, and other interactions between the organization and its various audiences."
                };
                var chro = new KDT
                {
                    Kd = "CHRO",
                    Ad = "Chief Human Resources Officer",
                };
                var cso = new KDT
                {
                    Kd = "CSO",
                    Ad = "Chief Sales Officer",
                };
                var cro = new KDT
                {
                    Kd = "CRO",
                    Ad = "Chief Revenue Officer",
                };

                new BR
                {
                    P = ceo,
                    C = cfo
                };
                new BR
                {
                    P = ceo,
                    C = coo
                };
                new BR
                {
                    P = ceo,
                    C = cmo
                };
                new BR
                {
                    P = ceo,
                    C = cio
                };
                new BR
                {
                    P = ceo,
                    C = cto
                };
                new BR
                {
                    P = ceo,
                    C = cxo
                };
                new BR
                {
                    P = ceo,
                    C = chro
                };
                new BR
                {
                    P = ceo,
                    C = cso
                };
                new BR
                {
                    P = ceo,
                    C = cro
                };

            });
        }
    }


}
