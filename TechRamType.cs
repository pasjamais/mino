using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechRamType
    {
        public TechRamType()
        {
            Pcs = new HashSet<Pc>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
