
using System;
using Starcounter;

namespace M2DB
{

    [Database]
    public class TblA
    {
        public ulong ONo { get; set; }  // Remove
        public string FldStr { get; set; }
        public int FldInt { get; set; }
        public double FldDbl { get; set; }
        public decimal FldDcm { get; set; }
        public DateTime FldDate { get; set; }

    }
}