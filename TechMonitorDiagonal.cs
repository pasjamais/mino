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
        public byte[] Diagonal { get; set; } = null!;

        public virtual ICollection<TechMonitor> TechMonitors { get; set; }
    }
}
