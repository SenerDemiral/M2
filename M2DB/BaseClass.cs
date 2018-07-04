using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starcounter;

namespace M2DB
{
    [Database]
    public class BUM    // BaseUserModify
    {
        public UUU InsUsr { get; set; }
        public DateTime? InsTrh { get; set; }
        public UUU UpdUsr { get; set; }
        public DateTime? UpdTrh { get; set; }
    }
}
