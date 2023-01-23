using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechUpss
    {
        public TechUpss()
        {
            Pcs = new HashSet<Pc>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? InventoryNumber { get; set; }
        public string? Comment { get; set; }

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
