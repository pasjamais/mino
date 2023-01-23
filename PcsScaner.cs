using System;
using System.Collections.Generic;

namespace mino
{
    public partial class PcsScaner
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; } 
        public long? Pc { get; set; }
        public long? Scaner { get; set; }
        public long? Quantity { get; set; }
        public string? Comment { get; set; }

        public virtual Pc? PcNavigation { get; set; }
        public virtual TechScaner? ScanerNavigation { get; set; }
    }
}
