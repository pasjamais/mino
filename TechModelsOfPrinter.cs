using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechModelsOfPrinter
    {
        public TechModelsOfPrinter()
        {
            TechPrinterCartridgeAlliances = new HashSet<TechPrinterCartridgeAlliance>();
            TechPrinters = new HashSet<TechPrinter>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public bool? IsMfu { get; set; }
        public long? MfuScanerModel { get; set; }

        public virtual TechModelsOfScaner? MfuScanerModelNavigation { get; set; }
        public virtual ICollection<TechPrinterCartridgeAlliance> TechPrinterCartridgeAlliances { get; set; }
        public virtual ICollection<TechPrinter> TechPrinters { get; set; }
    }
}
