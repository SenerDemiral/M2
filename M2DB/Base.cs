﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starcounter;

namespace M2DB
{
    /// <summary>
    /// Tur
    ///     FRM:Firma,
    ///     FRC:FirmaContact,
    ///     DPT:Departman (Uretim/Depo/Fire/Imha/Kayip),
    ///     PRS:Personel,
    ///     HBR:Haberlesme,
    ///     TAG:Etiket
    ///     NNN:Ne
    /// </summary>

    [Database]
    public class BB    // Base
    {
        public string Tbl { get; set; }     
        public string Kd { get; set; }
        public string Ad { get; set; }
        public string Info { get; set; }

    }

    [Database]
    public class BR    // Base.Relation
    {
        public BB P { get; set; } // Base Parent/Left
        public BB C { get; set; } // Base Child/Right

        public string Ptyp => P?.GetType().Name;
        public string Ctyp => C?.GetType().Name;

    }

    [Database]
    public class dnmA
    {
        public string Ad { get; set; }
    }

    [Database]
    public class dnmB : dnmA
    {
        public string Soyad { get; set; }
        public string Isim => Ad + Soyad;
    }

    [Database]
    public class dnmC
    {
        public dnmA A { get; set; }
        public string typ => A.GetType().Name;

        public static void dnm()
        {
            /*
            var A = Db.FromId(321) as dnmA; // 321 B'den girilmis, A gibi gostermek problem degil, zaten debug A'yi dnmB olarak goruyor
            string ccc = A.Ad;  
            string aaa = (A as dnmB).Isim;  
            var B = Db.FromId(330) as dnmA; // A'dan girilimis karsiligi B de yok
            string bbb = (B as dnmB)?.Ad;   // B dnmB degilse null
            if(B is dnmB dd)
            {
                // Use dd as dnmB
                dd.Ad
            }
            var C = Db.FromId(322) as dnmC;
            string ddd = (C.A as dnmB).Isim;
            */
        }
    }


}