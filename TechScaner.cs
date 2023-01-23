using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechScaner
    {
        public TechScaner()
        {
            PcsScaners = new HashSet<PcsScaner>();
        }

        public long Id { get; set; }
        public long? ModelId { get; set; }
        public string? Name { get; set; }
        public long? Pc { get; set; }
        public string? Comment { get; set; }

        public virtual TechModelsOfScaner? Model { get; set; }
        public virtual Pc? PcNavigation { get; set; }
        public virtual ICollection<PcsScaner> PcsScaners { get; set; }
    }
}
