using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechMonitorDiagonal
    {
        public TechMonitorDiagonal()
        {
            TechMonitors = new HashSet<TechMonitor>();
        }

        public long Id { get; set; }
        public decimal Diagonal { get; set; } 

        public virtual ICollection<TechMonitor> TechMonitors { get; set; }
    }
}
