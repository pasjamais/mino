using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechCamera
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? User { get; set; }
        public string? InventoryNumber { get; set; }

        public virtual User? UserNavigation { get; set; }
    }
}
