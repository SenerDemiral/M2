using System;
using Starcounter;

namespace M2DB
{
    [Database]
    public class UOO    // Onaylar
    {
        public UUU Usr { get; set; }        // Onaylayan
        public DateTime Trh { get; set; }   // Nazaman
        public string RefTbl { get; set; }  // OnayladigiTable. Type dbTyp = Type.GetType("M2DB"+refTbl)
        public ulong RefObj { get; set; }   // OnayladigiObjectNo
    }
    [Database]
    public class UUU    // User
    {
        public string Ad { get; set; }
        public UYT UYT { get; set; }    // User Yetkisi
    }
    [Database]
    public class UYT    // UserYetkiTanimlari
    {
        public string Ad { get; set; }
    }
    [Database]
    public class UYH    // User YetkiHiyerarsi
    {
        public UYT Prn { get; set; }
        public UYT Kid { get; set; }
    }

}
