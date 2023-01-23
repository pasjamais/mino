using System;
using System.Collections.Generic;

namespace mino
{
    public partial class Cabinet
    {
        public Cabinet()
        {
            TechCartridgesRotations = new HashSet<TechCartridgesRotation>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Comment { get; set; }

        public virtual ICollection<TechCartridgesRotation> TechCartridgesRotations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
