using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starcounter;

namespace M2DB
{
    /// <summary>
    /// Maddenin birimleri tek olmali BirimConversion eziyetli bir surec
    /// Nelerden olustugu Hiyerarside belirtilmeli
    /// 
    /// NULL-KolaPalet: 1
    ///   KolaPalet-KolaKasa: 100Ksa/1Plt (Her bir Paletteki Kasa miktari. Kasa/Palet)
    ///     KolaKasa-KolaSise: 12Adt/1Ksa
    ///       KolaSise-Kola: 0.25Ltr/1Adt
    ///       KolaSise-CamSise: 1Adt/1Adt
    ///       KolaSise-Kapak: 1Adt/1Adt
    ///       KolaSise-DuzIsci: 0.1Saat/1Adt
    ///     KolaKasa-DuzIsci: 0.2Saat/1Adt
    ///   KolaPalet-Palet: 1Adt/1Adt
    ///   KolaPalet-StrechFilm: 15Mtr/1Adt
    ///   KolaPaket-DuzIsci: 0.3Saat/1Adt
    ///   
    /// 100Ksa/Plt x 12Adt/Ksa x 0.25Ltr/Adt = 300Ltr/Plt (1Plt de 300Ltr Kola var)
    /// 100Ksa/Plt x 12Adt/Ksa x 1.00Adt/Adt = 120Adt/Plt (1Plt de 120Adt Sise var)
    /// 100Ksa/Plt x 12Adt/Ksa x 1.00Adt/Adt = 120Adt/Plt (1Plt de 120Adt Kapak var)
    /// 
    /// Alis:
    /// Kola: 1000Ltr 
    /// CamSise: 5000Adt
    /// Kapak: 5000Adt
    /// Uretim: Depolardan alir, Uretim Yapar, Depolara verir
    /// KolaSise: 500Adt
    /// KolaPalet:100Adt
    /// Satis: Depodan alir, NakliyeAracinaYukler, Musterilere verir
    /// KolaPalet: 10Adt
    /// KolaKasa: 200Adt
    /// </summary>
    [Database]
    public class NNN : BB  // Ne
    {
        public XGT BRM { get; set; }     // Birim: KWh, Ltr, Mt, M3, Ton, Kg, Adt, 
        public KDT KDT { get; set; }     // Ureten Kim Departman
        public AHP AHPbrc { get; set; }  // Borclu Ne Hesap
        public AHP AHPalc { get; set; }  // Alacakli Ne Hesap
        public double Fyt { get; set; }  // Simdilik
        
        public bool HasKid
        {
            get
            {
                if (Db.SQL<NNR>("select r from M2DB.NNR r where r.NP = ?", this).FirstOrDefault() == null)
                    return false;
                return true;
            }
        }
        public bool HasPrn
        {
            get
            {
                if (Db.SQL<NNR>("select r from M2DB.NNR r where r.NC = ?", this).FirstOrDefault() == null)
                    return false;
                return true;
            }
        }
        
        // All node's parents Bunu Kim de yap, burdaki deneme
        public static Dictionary<ulong, string> DenemeYtkParentsDictionary()
        {
            Dictionary<ulong, string> sD = new Dictionary<ulong, string>();

            foreach (var r in Db.SQL<NNN>("SELECT r FROM NNN r"))
            {
                sD[r.GetObjectNo()] = DenemeYtkParentsDictionary(r.GetObjectNo());
            }

            return sD;
        }
        // Node's parents in string: <1234><456>...
        // Usage if (DenemeYtkParentsDictionary(r.GetObjectNo()).Contains($"<NodeOno>")) ....
        public static string DenemeYtkParentsDictionary(ulong node)
        {
            var pList = new List<ulong>();
            ParentsList(node, pList);  // Node's Parents

            StringBuilder sb = new StringBuilder();
            foreach (var itm in pList)
                sb.Append($"<{itm}>");

            return sb.ToString();
        }

        public static List<ulong> GetNeKidsList(ulong node)     // OK   Henuz kullanilmiyor
        {
            List<ulong> kList = new List<ulong>();
            KidsList(node, kList);  // Node's Parents
            return kList;
        }
        private static void KidsList(ulong node, List<ulong> kList) // OK
        {
            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NP.ObjectNo = ?", node))
            {
                ulong kid = r.NC.GetObjectNo();

                if (!kList.Contains(kid))
                    kList.Add(kid);

                if (r.NC.HasKid)
                    KidsList(kid, kList);
            }
        }

        public static string GetNeParentsString(ulong node)
        {
            var pList = GetNeParentsList(node);

            StringBuilder sb = new StringBuilder();
            foreach (var itm in pList)
                sb.Append($"<{itm}>");

            return sb.ToString();
        }
        public static List<ulong> GetNeParentsList(ulong node)  // OK
        {
            List<ulong> pList = new List<ulong>();
            pList.Add(node);    // Kendisini de ekle
            ParentsList(node, pList);  // Node's Parents
            return pList;
        }
        private static void ParentsList(ulong node, List<ulong> pList)  // OK
        {
            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NC.ObjectNo = ?", node))
            {
                ulong parent = r.NP.GetObjectNo();

                if (!pList.Contains(parent))
                    pList.Add(parent);
                if (r.NP.HasPrn)
                    ParentsList(parent, pList);
            }
        }

        public static string NeUretenler(ulong n)
        {
            var list = new List<string>();
            foreach (var r in Db.SQL<BR>("SELECT r FROM M2DB.BR r WHERE r.C.ObjectNo = ?", n))
            {
                if (r.Ptyp == "KDT" && r.Ctyp == "NNN")
                    list.Add(r.P.Kd);
            }
            if (list.Count == 0)
                return "";
            return string.Join<string>(", ", list);
        }

        public static Dictionary<NNN, double> UretenUrunTuketimleri(string ureten, ulong urunNo, double uretimMik)
        {
            NNN urun = Db.FromId<NNN>(urunNo);
            // if(n.Ureten != ureten)
            // return null;  // Urunu Ureten imal etmiyorsa cik
            Dictionary<NNN, double> mD = new Dictionary<NNN, double>();
            UretenUrunTuketimleriDty(ureten, urun, uretimMik, mD);

            NNN u = Db.FromId<NNN>(urunNo);
            Console.WriteLine($"{urunNo} {u.Ad,10}:");
            foreach (var d in mD)
            {
                Console.WriteLine($"{d.Key.GetObjectNo()} {d.Key.Ad,10}: {d.Value}");
            }
            Console.WriteLine();

            return mD;
        }
        private static void UretenUrunTuketimleriDty(string ureten, NNN n, double mik, Dictionary<NNN, double> mD)
        {
            foreach(var nnr in Db.SQL<NNR>("SELECT n from NNR n WHERE n.NP = ?", n))
            {
                NNN kid = nnr.NC;
                var aaa = kid.Ad;
                
                if (!mD.ContainsKey(kid))
                    mD[kid] = 0;

                mD[kid] += mik * nnr.Mik;
                if (kid.HasKid) // && kid.GetObjectNo() != 275)
                    UretenUrunTuketimleriDty(ureten, kid, mik * nnr.Mik, mD);

            }
        }
        public static void DenemeCanAddSibling()
        {
            bool aaa = CanAddSibling(303, 299);
        }
        public static bool CanAddSibling(ulong curNo, ulong addNo)  // Henuz Kullanilmiyor
        {
            bool isFound;
            isFound = FindInSiblings(curNo, addNo);
            if (!isFound)
                isFound = FindInParents(curNo, addNo, false);

            return !isFound;
        }
        private static bool FindInSiblings(ulong curNo, ulong fndNo)
        {
            foreach (var r in Db.SQL<NNR>("SELECT r FROM NNR r WHERE r.NP.ObjectNo = ?", curNo))
            {
                string ppp = r.NP.Ad + " " + r.NP.GetObjectNo().ToString();
                string ccc = r.NC.Ad + " " + r.NC.GetObjectNo().ToString();
                if (fndNo == r.NC.GetObjectNo())
                    return true;
            }
            return false;
        }
        private static bool FindInParents(ulong curNo, ulong fndNo, bool isFound)
        {
            foreach (var r in Db.SQL<NNR>("SELECT r FROM NNR r WHERE r.NC.ObjectNo = ?", curNo))
            {
                string ppp = r.NP.Ad + " " + r.NP.GetObjectNo().ToString();
                string ccc = r.NC.Ad + " " + r.NC.GetObjectNo().ToString();
                if (r.NP.GetObjectNo() == fndNo)
                {
                    isFound = true;
                    return isFound;
                }
                else if (!isFound && r.NP.HasPrn)
                {
                    isFound = FindInParents(r.NP.GetObjectNo(), fndNo, isFound);
                    if (isFound)
                        return isFound;
                }
            }

            return isFound;
        }
        private static bool FindInChildren(ulong curNo, ulong fndNo, bool isFound)  // Henuz Kullanilmiyor
        {
            // Once LeafNode lari tara
            if (FindInSiblings(curNo, fndNo))
                return true;

            foreach (var r in Db.SQL<NNR>("SELECT r FROM NNR r WHERE r.NP.ObjectNo = ? AND r.NC.HasKid = ?", curNo, true))
            {
                string ppp = r.NP.Ad + " " + r.NP.GetObjectNo().ToString();
                string ccc = r.NC.Ad + " " + r.NC.GetObjectNo().ToString();
                if (!isFound && r.NC.HasKid)
                {
                    isFound = FindInChildren(r.NC.GetObjectNo(), fndNo, isFound);
                    if (isFound)
                        return isFound;
                }
            }

            return isFound;
        }


        public static double NeMaliyet(ulong sNo)
        {
            double Fyt = 0;
            NNN s = Db.FromId(sNo) as NNN;
            if (s != null)
            {
                if (s.HasKid)
                    Fyt = NeMaliyetDty(sNo);
                else
                    Fyt = s.Fyt;

                //if (dbg)
                Console.WriteLine($"{s.Ad}#{sNo} Maliyeti = {Fyt:n}");
            }
            else
            {
                Fyt = -1;
                //if (dbg)
                Console.WriteLine($"Ne:#{sNo} Bulunamadi");
            }
            return Fyt;
        }
        public static double NeMaliyetDty(ulong sNo)     // Value  KidTut += Mik * Fyt, PrnTut += KidTut * Mik
        {
            double T = 0, kT = 0, pT = 0;

            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NP.ObjectNo = ? order by r.NC.HasKid DESC", sNo))
            {
                if (r.NC.HasKid)
                {
                    kT = NeMaliyetDty(r.NC.GetObjectNo());
                    pT = T;
                    T += r.Mik * kT;
                    //if (dbg)
                    Console.WriteLine($"2:{r.PAd}.{r.KAd}: {pT:n}[{r.PAd}] + {r.Mik}x{kT}={r.Mik * kT}[{r.KAd}] => {T:n}[{r.PAd}]");
                }
                else
                {
                    pT = T;
                    T += r.Mik * r.NC.Fyt;
                    //if (dbg)
                    Console.WriteLine($"1:{r.PAd}.{r.KAd}:  {pT:n}[{r.PAd}] + {r.Mik}x{r.NC.Fyt}={r.Mik * r.NC.Fyt}[{r.KAd}] => {T:n}[{r.PAd}]");
                }
            }
            Console.WriteLine($"--:T={T}, kT={kT}, pT={pT}");
            return T;
        }
    }

    [Database]
    public class NKM    // Ne.Kimde.Miktar      BB'den yap
    {
        public NNN NNN { get; set; }
        public KKK KKK { get; set; }
        public double GirMik { get; set; }
        public double CikMik { get; set; }
        public double KlnMik => GirMik - CikMik;

        public double SonGirMik { get; set; }
        public double SonCikMik { get; set; }
        public DateTime? SonGirTrh { get; set; }
        public DateTime? SonCikTrh { get; set; }
    }

    [Database]
    public class NFA    // Ne.FiyatAnlasmalari
    {
        public NNN NNN { get; set; }    // NeyinFiyati
        public KKK KKK { get; set; }    // Musteri
        public string AoS { get; set; } // Alis/Satis
        public DateTime BasTrh { get; set; }    // AnlasmaBaslangic
        public DateTime BitTrh { get; set; }
        public int OncSra { get; set; }     // Bir Mal birden cok Musteriden Alinabilir, Hangisinden alinacagina karar vermek icin
        public double Fyt { get; set; }
        public XGT ObjDvz { get; set; }
        public string Ack { get; set; } // Aciklama (OdemeSekli, Vade

    }

    [Database]
    public class NNR // Ne.Recete
    {
        public NNN NP { get; set; } // Parent
        public NNN NC { get; set; } // Kid
        public double Mik { get; set; }

        public string PAd => NP?.Ad;
        public string KAd => NC?.Ad;

        /// <summary>
        /// addNode Sibling de olmamali
        /// curNode'un Parentlarinda olmamali
        /// </summary>
        public static void DenemeGetAvailableParents()  // Kullanilmiyor DENEME
        {
            GetAvailableParents(299);
        }
        public static DataTable GetAvailableParents(ulong node) // Kullanilmiyor DENEME
        {
            // Deneme KidsList heniz kullanilmiyor
            //List<ulong> kList = new List<ulong>();
            //KidsList(295, kList);   // Suzan's Kids

            // Node'a Sibling eklerken kullanilacak Lookup table
            // Mevcut Siblings Client da unavailable yapilmali

            // Ya da (Daha az data gidecek)
            // Nelerin hepsi Lookup olarak client da var
            // Burdan sadece Available olanlar gitsin
            // Client da Lookup buna gore olustrulsun

            // Ya da (Daha da az data gidecek)
            // Sadece Node's Parentlarini gonder, Client geregini yapsin 
            // ParentsList ve Siblings disindakileri kullanabilir
            
            DataTable table = new DataTable();
            table.Columns.Add("No", typeof(ulong));    // Node
            table.Columns.Add("Ad", typeof(string));    // Node
            table.Columns.Add("Avl", typeof(bool));    // Available/Usable

            List<ulong> pList = new List<ulong>();
            ParentsList(node, pList);  // Node's Parents

            bool avl = false;
            foreach (var r in Db.SQL<NNN>("SELECT r from NNN r WHERE r.ObjectNo <> ?", node))
            {
                avl = pList.Contains(r.GetObjectNo()) ? false : true; 
                if(avl)
                table.Rows.Add(r.GetObjectNo(), r.Ad, avl);
            }

            return table;
        }

        private static void KidsList(ulong node, List<ulong> kList) // DENEME
        {
            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NP.ObjectNo = ?", node))
            {
                ulong kid = r.NC.GetObjectNo();

                if (!kList.Contains(kid))
                    kList.Add(kid);

                if (r.NC.HasKid)
                    KidsList(kid, kList);
            }
        }

        private static void ParentsList(ulong node, List<ulong> pList)  // DENEME
        {
            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NC.ObjectNo = ?", node))
            {
                ulong parent = r.NP.GetObjectNo();

                if (!pList.Contains(parent))
                    pList.Add(parent);
                if (r.NP.HasPrn)
                    ParentsList(parent, pList);
            }
        }


        public static void Deneme2()
        {
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            List<List<string>> lls = new List<List<string>>();

            foreach (var n in Db.SQL<NNN>("SELECT r FROM NNN r"))
            {
                NNN cn = n;
                bool fnd = true;
                string bbb = cn.Ad;
                string aaa = "";
                while (fnd)
                {
                    NNR nr = Db.SQL<NNR>("SELECT r FROM NNR r WHERE r.NC = ?", cn).FirstOrDefault();
                    if (nr == null)
                        fnd = false;
                    else
                    {
                        cn = nr.NP;
                        aaa = aaa + " " + cn.Ad;
                    }
                }

            }

        }

        public static DataTable DenemeUp()
        {
            DataTable table = new DataTable();
            table.Columns.Add("L", typeof(int));    // Level
            table.Columns.Add("P", typeof(ulong));    // Parent
            table.Columns.Add("K", typeof(ulong));    // Kid
            table.Columns.Add("A", typeof(string)); // Ad
            table.Columns.Add("N", typeof(ulong));  // No
            table.Columns.Add("M", typeof(double)); // Miktar
            table.Columns.Add("F", typeof(double)); // Fiyat

            ulong P = 0;
            ulong K = 1;
            foreach (var n in Db.SQL<NNN>("SELECT r FROM NNN r WHERE r.HasKid = ?", false))
            {
                table.Rows.Add(0, P, K, n.Ad, n.GetObjectNo(), 1, n.Fyt);
                K++;
            }

            for (int L = 1; L < 10; L++)
            {
                DataRow[] dr = table.Select($"L = {L-1}");
                foreach (var r in dr)
                {
                    P = (ulong)r["K"]; // (int)r.ItemArray[2];

                    foreach (var nr in Db.SQL<NNR>("SELECT r FROM NNR r WHERE r.NC.ObjectNo = ?", r["N"]))
                    {
                        table.Rows.Add(L, P, K, nr.PAd, nr.NP.GetObjectNo(), nr.Mik, 0);
                        K++;
                    }

                }
            }

            foreach(DataRow r in table.Rows)
            {
                Console.WriteLine($"{r["L"]}, {r["P"]}, {r["K"]}, {r["A"]}, {r["N"]}, {r["M"]}, {r["F"]}");

            }
            return table;
        }

        public static DataTable DenemeDown()
        {
            DataTable table = new DataTable();
            table.Columns.Add("L", typeof(int));
            table.Columns.Add("P", typeof(ulong));
            table.Columns.Add("K", typeof(ulong));
            table.Columns.Add("A", typeof(string));
            table.Columns.Add("N", typeof(ulong));
            table.Columns.Add("M", typeof(double)); // Miktar
            table.Columns.Add("F", typeof(double)); // Fiyat
            table.Columns.Add("HasKid", typeof(bool));
            table.Columns.Add("Ureten", typeof(string));

            ulong P = 0;
            ulong K = 1;
            foreach (var n in Db.SQL<NNN>("SELECT r FROM NNN r WHERE r.HasPrn = ?", false))
            {
                table.Rows.Add(0, P, K, n.Ad, n.GetObjectNo(), 1, 0, n.HasKid);
                K++;
            }

            for (int L = 1; L < 10; L++)
            {
                DataRow[] dr = table.Select($"L = {L - 1}");
                foreach (var r in dr)
                {
                    P = (ulong)r["K"]; // (int)r.ItemArray[2];

                    foreach (var nr in Db.SQL<NNR>("SELECT r FROM NNR r WHERE r.NP.ObjectNo = ?", r["N"]))
                    {
                        table.Rows.Add(L, P, K, nr.KAd, nr.NC.GetObjectNo(), nr.Mik, nr.NC.Fyt, nr.NC.HasKid);
                        K++;
                    }

                }
            }
            foreach(DataRow t in table.Rows)
            {
                t["Ureten"] = NNN.NeUretenler((ulong)t["N"]);
            }
            return table;
        }

        public static void DenemeYetki()  // UsrYtk'nin altinda OnyYtk var mi?
        {
            // Senay296 da Mehmet294 yok
            // Mehmet294 de Sener299 yok
            // Suzan295 de Ali301 var
            // Senay296 da Ali301 var
            NNN UsrYtk = Db.FromId<NNN>(304);
            NNN OnyYtk = Db.FromId<NNN>(301);
            bool rv = IsOnyYtkMemberOfUsrYtk(UsrYtk, OnyYtk, false); // IsOnyYtkMemberOfUsrYtk

            UpToUsr(OnyYtk, UsrYtk);
            DownToOny(UsrYtk, OnyYtk);

            Dictionary<NNN, List<NNN>> mD = new Dictionary<NNN, List<NNN>>();
            foreach(var r in Db.SQL<NNN>("SELECT r FROM NNN r"))
            {
                var list = new List<NNN>();
                DownTo(r, list);
                mD[r] = list;
            }

            // find ony in node 
            bool fnd = false;
            foreach(var f in mD[UsrYtk])
            {
                if(f.GetObjectNo() == OnyYtk.GetObjectNo())
                {
                    fnd = true;
                    break;
                }
            }

        }

        private static void DownTo(NNN node, List<NNN> lst)    // Start from Usr=node, Downto Ony
        {
            //if (UsrYtk.GetObjectNo() == OnyYtk.GetObjectNo())
            //    return true;

            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NP = ?", node))
            {
                var aaa = r.NP.Ad;
                var bbb = r.NC.Ad;
                /*
                if (r.NP.GetObjectNo() == UsrYtk.GetObjectNo())
                {
                    //rv = true;
                    break;
                }
                else*/
                lst.Add(r.NC);
                if (r.NC.HasKid)
                    DownTo(r.NC, lst);
            }
            //return rv;
        }

        // FindInChildren kullan Eger BR den gidecekse.
        // Yetki deneme, OnyYtk UsrYtk'nin uyesi mi? OnyYtk'nin ustunde UsrYtk var mi? OK
        private static bool IsOnyYtkMemberOfUsrYtk(NNN UsrYtk, NNN OnyYtk, bool varmi)    // UsrYtk, OnyYtk/Constant
        {
            if (UsrYtk.GetObjectNo() == OnyYtk.GetObjectNo())
                return true;

            if (!varmi)
            {
                foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NP = ?", UsrYtk))
                {
                    var aaa = r.NP.Ad;
                    var bbb = r.NC.Ad;
                    if (r.NC.GetObjectNo() == OnyYtk.GetObjectNo())
                    {
                        varmi = true;
                        break;
                    }
                    else if (r.NC.HasKid && !varmi)
                        varmi = IsOnyYtkMemberOfUsrYtk(r.NC, OnyYtk, varmi);
                }
            }
            return varmi;
        }

        private static void DownToOny(NNN node, NNN OnyYtk)    // Start from Usr=node, Downto Ony
        {
            //if (UsrYtk.GetObjectNo() == OnyYtk.GetObjectNo())
            //    return true;

            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NP = ?", node))
            {
                var aaa = r.NP.Ad;
                var bbb = r.NC.Ad;
                /*
                if (r.NP.GetObjectNo() == UsrYtk.GetObjectNo())
                {
                    //rv = true;
                    break;
                }
                else*/
                if (r.NC.HasKid)
                    DownToOny(r.NC, OnyYtk);
            }
            //return rv;
        }

        private static void UpToUsr(NNN node, NNN UsrYtk)    // Start from Ony=node, Upto Usr
        {
            //if (UsrYtk.GetObjectNo() == OnyYtk.GetObjectNo())
            //    return true;

            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NC = ?", node))
            {
                var aaa = r.NP.Ad;
                var bbb = r.NC.Ad;
                /*
                if (r.NP.GetObjectNo() == UsrYtk.GetObjectNo())
                {
                    //rv = true;
                    break;
                }
                else*/
                if(r.NP.HasPrn)
                    UpToUsr(r.NP, UsrYtk);
            }
            //return rv;
        }

        public static void Deneme()
        {
            List<string> nList = new List<string>();
            foreach (var r in Db.SQL<NNN>("SELECT r FROM NNN r"))
            {
                nList.Add(r.Ad);
            }

            Dictionary<string, List<string>> nd = new Dictionary<string,List<string>>();
            foreach(var nl in nList)
            {
                //Dictionary<string, string> sa = new Dictionary<string, string>();
                List<string> sl = new List<string>();
                foreach (var n in Db.SQL<NNR>("SELECT r FROM NNR r WHERE r.NP.Ad = ?", nl))
                {
                    sl.Add(n.KAd);
                }
                nd[nl] = sl;
            }
            char[] charSeparators = new char[] { ',' };

            for (int i = 0; i < 4; i++)
            {
                foreach (var nl in nList)
                {
                    List<string> sl = new List<string>();
                    foreach (var r in nd[nl])
                    {
                        if (r == "[" || r == "]")
                            sl.Add(r);
                        else if (r.EndsWith(":"))
                            sl.Add(r);
                        else if (r != "[" && r != "]" && nd[r].Count > 0)
                        {
                            sl.Add(r + ":");
                            sl.Add("[");
                            foreach (var x in nd[r])
                                sl.Add(x);
                            sl.Add("]");
                        }
                        else
                            sl.Add(r);
                    }

                    nd[nl] = sl;
                }
            }
            foreach (var n in nd)
            {
                string s = "";
                foreach (var l in n.Value)
                {
                    s += l + " ";
                }
            }

            /*
            foreach (var nl in nList)
            {
                List<string> sl = new List<string>();
                foreach (var r in nd[nl])
                {
                    if (r.EndsWith(":"))
                        sl.Add(r);
                    else
                    {
                        sl.Add(r + ":");

                        if (r != "[" && r != "]" && nd[r].Count > 0)
                        {
                            sl.Add("[");
                            foreach (var x in nd[r])
                                sl.Add(x);
                            sl.Add("]");
                        }
                    }
                }

                nd[nl] = sl;
            }*/
        }

        public static DataTable NodesMikInParents()
        {
            DataTable table = new DataTable();
            table.Columns.Add("PNo", typeof(ulong));
            table.Columns.Add("KNo", typeof(ulong));
            table.Columns.Add("PAd", typeof(string));
            table.Columns.Add("KAd", typeof(string));
            table.Columns.Add("M", typeof(double));

            foreach (var n in Db.SQL<NNN>("SELECT r FROM NNN r WHERE r.HasKid = ?", true))
                NodeMikInParents(n.GetObjectNo(), table);
            return table;
        }
        public static void NodeMikInParents(ulong parent, DataTable table)
        {
            Dictionary<ulong, double> mikD = new Dictionary<ulong, double>();  // Gereken

            NodeMikInParent(parent, 1, mikD);  // Kid's Mik of parent.

            NNN p = Db.FromId<NNN>(parent);
            NNN n = null;

            Console.WriteLine($"Nodes @{p.Ad} ---------->");
            ulong pNo = p.GetObjectNo();
            string nAd = "";
            string pAd = p.Ad;
            // ↑↓↕↔
            // ▲▼●
            if (!p.HasPrn)
                pAd = "*" + pAd;  // root
            else
                pAd = "+" + pAd;

            foreach (var r in mikD)
            {
                n = Db.FromId<NNN>(r.Key);
                nAd = n.Ad;
                if (!n.HasKid)
                    nAd = "-" + nAd;  // leaf
                else
                    nAd = "+" + nAd;
                //Console.WriteLine($"{pAd}.{nAd} -> Mik: {r.Value}");
                table.Rows.Add(pNo, p.GetObjectNo(), pAd, nAd, r.Value);
            }

        }
        // Starting Node altindaki Kid ler nekadar kullaniliyor
        private static void NodeMikInParent(ulong node, double Mik, Dictionary<ulong, double> mD)  // Kids Miktar
        {
            ulong Kid = 0;
            double GMik = 0;

            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NP.ObjectNo = ?", node))
            {
                Kid = r.NC.GetObjectNo();
                GMik = Mik * r.Mik;
                if (!mD.ContainsKey(Kid))
                    mD[Kid] = 0;
                mD[Kid] += GMik;

                if (GMik > 0 && r.NC.HasKid)
                    NodeMikInParent(Kid, GMik, mD);
            }
        }

        public static void NodeGerekenKidsMik(ulong node, double Mik)
        {
            // node dan Mik kadar isteniyor, stoktakiler kullanildiginda ne kadar Kids alinmali.
            Dictionary<ulong, double> S = new Dictionary<ulong, double>();  // Stok
            Dictionary<ulong, double> G = new Dictionary<ulong, double>();  // Gereken

            // Burasi Siparis listesindeki her kalem icin donerek, gereken toplam miktarlar alinabilir.
            //foreach(var r in Db.SQL<TTT>("select r from TSD r where r.Prn.ObjectNo = ?", TSBoNo))
            //{
            //    NodeKidsMikDty(node, 1, S, G);
            //}
            NodeGerekenKidsMikDty(node, Mik, S, G);
            NNN s = Db.FromId<NNN>(node);
            Console.WriteLine($"Nodes @{s.Ad} ---------->");
            foreach (var r in G)
            {
                s = Db.FromId<NNN>(r.Key);
                Console.WriteLine($"{s.Ad} -> Stok: {S[r.Key]}, Gereken: {r.Value}");
            }
            /*
            var aaa = Db.FromId(46);    // Musteri
            var bbb = Db.FromId(29);    // Depo
            var tsb = Db.FromId(47) as TSB;    // TSB

            var ccc = ((KMT)tsb.DST).Adres; // DST is KKK
            */
        }
        private static void NodeGerekenKidsMikDty(ulong Prn, double Mik, Dictionary<ulong, double> S, Dictionary<ulong, double> G)
        {
            ulong Kid = 0;
            double GMik = 0;

            foreach (var r in Db.SQL<NNR>("select r from NNR r where r.NP.ObjectNo = ?", Prn))
            {
                Kid = r.NC.GetObjectNo();

                if (!S.ContainsKey(Kid))
                    S[Kid] = 0; //StokMik(Kid);

                GMik = Mik * r.Mik;
                if (GMik > S[Kid])
                {
                    GMik -= S[Kid];
                    S[Kid] = 0;
                }
                else
                {
                    S[Kid] -= GMik;
                    GMik = 0;
                }

                if (!G.ContainsKey(Kid))
                    G[Kid] = 0;
                G[Kid] += GMik;

                if (GMik > 0 && r.NC.HasKid)
                    NodeGerekenKidsMikDty(Kid, GMik, S, G);
            }
        }


    }

    public static class NeOps
    {
        public static void initNNN()
        {
            if (Db.SQL<NNN>("select r from NNN r").FirstOrDefault() != null)
                return; // Kayit var yapma

            Db.Transact(() =>
            {
                Db.SQL("DELETE FROM NNR");
                Db.SQL("DELETE FROM NNN");

                var ahmet = new NNN
                {
                    Kd = "40",
                    Ad = "Ahmet",
                    Fyt = 100
                };
                var mehmet = new NNN
                {
                    Kd = "50",
                    Ad = "Mehmet",
                    Fyt = 110,
                };
                var suzan = new NNN
                {
                    Kd = "30",
                    Ad = "Suzan"
                };
                var senay = new NNN
                {
                    Kd = "30.10",
                    Ad = "Senay"
                };
                var umut = new NNN
                {
                    Kd = "30.10.1",
                    Ad = "Umut",
                    Fyt = 20
                };
                var nazli = new NNN
                {
                    Kd = "30.10.2",
                    Ad = "Nazli",
                };
                var sener = new NNN
                {
                    Kd = "30.20",
                    Ad = "Sener"
                };
                var can = new NNN
                {
                    Kd = "30.20.1",
                    Ad = "Can",
                };
                var ali = new NNN
                {
                    Kd = "30.20.1.1",
                    Ad = "Ali",
                    Fyt = 50
                };
                var ayse = new NNN
                {
                    Kd = "30.20.1.2",
                    Ad = "Ayse",
                    Fyt = 60
                };
                var veli = new NNN
                {
                    Kd = "30.20.1.3",
                    Ad = "Veli",
                    Fyt = 70
                };

                var kemal = new NNN
                {
                    Kd = "kk",
                    Ad = "Kemal",
                    Fyt = 30
                };

                new NNR
                {
                    NP = suzan,
                    NC = senay,
                    Mik = 2
                };
                new NNR
                {
                    NP = senay,
                    NC = umut,
                    Mik = 3
                };
                new NNR
                {
                    NP = senay,
                    NC = nazli,
                    Mik = 4
                };

                new NNR
                {
                    NP = suzan,
                    NC = sener,
                    Mik = 5
                };
                new NNR
                {
                    NP = sener,
                    NC = can,
                    Mik = 6
                };
                new NNR
                {
                    NP = can,
                    NC = ali,
                    Mik = 7
                };
                new NNR
                {
                    NP = can,
                    NC = ayse,
                    Mik = 8
                };
                new NNR
                {
                    NP = can,
                    NC = veli,
                    Mik = 9
                };
                new NNR
                {
                    NP = nazli,
                    NC = can,

                    Mik = 10
                };

                new NNR
                {
                    NP = sener,
                    NC = ahmet,

                    Mik = 11
                };
                new NNR
                {
                    NP = sener,
                    NC = mehmet,

                    Mik = 12
                };
                new NNR
                {
                    NP = sener,
                    NC = senay,

                    Mik = 13
                };
                new NNR
                {
                    NP = kemal,
                    NC = nazli,

                    Mik = 14
                };
                new NNR
                {
                    NP = kemal,
                    NC = sener,

                    Mik = 15
                };
                new NNR
                {
                    NP = suzan,
                    NC = ali,

                    Mik = 17
                };
                new NNR
                {
                    NP = sener,
                    NC = ali,

                    Mik = 18
                };
            });

        }
    }
}
