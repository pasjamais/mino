using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechModelsOfCpu
    {
        public TechModelsOfCpu()
        {
            Pcs = new HashSet<Pc>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? ClockRate { get; set; }
        public decimal? Rating { get; set; }
        public string? Comment { get; set; }

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
