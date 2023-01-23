using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechSoftAntivirus
    {
        public TechSoftAntivirus()
        {
            Pcs = new HashSet<Pc>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? Version { get; set; }

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
