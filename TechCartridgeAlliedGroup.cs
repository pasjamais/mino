using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechCartridgeAlliedGroup
    {
        public TechCartridgeAlliedGroup()
        {
            TechModelsOfCartridges = new HashSet<TechModelsOfCartridge>();
            TechModelsOfPrinters = new HashSet<TechModelsOfPrinter>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TechModelsOfCartridge> TechModelsOfCartridges { get; set; }
        public virtual ICollection<TechModelsOfPrinter> TechModelsOfPrinters { get; set; }
    }
}
