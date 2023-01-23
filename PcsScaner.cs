using System;
using System.Collections.Generic;

namespace mino
{
    public partial class PcsScaner
    {
        public long Id { get; set; }
        public byte[] Date { get; set; } = null!;
        public long? Pc { get; set; }
        public long? Scaner { get; set; }
        public long? Quantity { get; set; }

        public virtual Pc? PcNavigation { get; set; }
        public virtual TechScaner? ScanerNavigation { get; set; }
    }
}
