using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechDiskType
    {
        public TechDiskType()
        {
            TechHdds = new HashSet<TechHdd>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TechHdd> TechHdds { get; set; }
    }
}
