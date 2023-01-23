using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechPrinterCartridgeAlliance
    {
        public long Id { get; set; }
        public long PrinterModel { get; set; }
        public long CartridgeModel { get; set; }
        public string? Comment { get; set; }

        public virtual TechModelsOfCartridge CartridgeModelNavigation { get; set; } = null!;
        public virtual TechModelsOfPrinter PrinterModelNavigation { get; set; } = null!;
    }
}
