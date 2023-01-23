using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechSoftO
    {
        public TechSoftO()
        {
            Pcs = new HashSet<Pc>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
