using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechScaner
    {
        public TechScaner()
        {
            Pcs = new HashSet<Pc>();
            PcsScaners = new HashSet<PcsScaner>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Pc> Pcs { get; set; }
        public virtual ICollection<PcsScaner> PcsScaners { get; set; }
    }
}
