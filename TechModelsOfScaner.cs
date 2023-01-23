using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechModelsOfScaner
    {
        public TechModelsOfScaner()
        {
            TechModelsOfPrinters = new HashSet<TechModelsOfPrinter>();
            TechScaners = new HashSet<TechScaner>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TechModelsOfPrinter> TechModelsOfPrinters { get; set; }
        public virtual ICollection<TechScaner> TechScaners { get; set; }
    }
}
