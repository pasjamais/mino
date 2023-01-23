using System;
using System.Collections.Generic;

namespace mino
{
    public partial class PcsPrinter
    {
        public long Id { get; set; }
        public DateTime Date { get; set; } 
        public long? Pc { get; set; }
        public long? Printer { get; set; }
        public long? Quantity { get; set; }
        public string? Comment { get; set; }

        public virtual Pc? PcNavigation { get; set; }
        public virtual TechPrinter? PrinterNavigation { get; set; }
    }
}
