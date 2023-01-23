using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechMonitor
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Diagonal { get; set; }
        public string? Comment { get; set; }
        public long? Pc { get; set; }
        public string? InventoryNumber { get; set; }

        public virtual TechMonitorDiagonal? DiagonalNavigation { get; set; }
        public virtual Pc? PcNavigation { get; set; }
    }
}
