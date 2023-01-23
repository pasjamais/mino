using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechModelsOfCartridge
    {
        public TechModelsOfCartridge()
        {
            TechCartridgesRotations = new HashSet<TechCartridgesRotation>();
            TechPrinterCartridgeAlliances = new HashSet<TechPrinterCartridgeAlliance>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TechCartridgesRotation> TechCartridgesRotations { get; set; }
        public virtual ICollection<TechPrinterCartridgeAlliance> TechPrinterCartridgeAlliances { get; set; }
    }
}
