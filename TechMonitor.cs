using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechMonitor
    {
        public TechMonitor()
        {
            Pcs = new HashSet<Pc>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Diagonal { get; set; }

        public virtual TechMonitorDiagonal? DiagonalNavigation { get; set; }
        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
