﻿using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechPrinterCartridgeAlliance
    {
        public long Id { get; set; }
        public long? PrinterModel { get; set; }
        public long? CartridgeModel { get; set; }

        public virtual TechModelsOfCartridge? CartridgeModelNavigation { get; set; }
        public virtual TechModelsOfPrinter? PrinterModelNavigation { get; set; }
    }
}