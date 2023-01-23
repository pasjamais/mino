using System;
using System.Collections.Generic;

namespace mino
{
    public partial class Place
    {
        public Place()
        {
            TechCartridgesRotations = new HashSet<TechCartridgesRotation>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Comment { get; set; }

        public virtual ICollection<TechCartridgesRotation> TechCartridgesRotations { get; set; }
    }
}
