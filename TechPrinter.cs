using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechPrinter
    {
        public TechPrinter()
        {
            PcsPrinters = new HashSet<PcsPrinter>();
        }

        public long Id { get; set; }
        public long? Model { get; set; }
        public string? Comment { get; set; }
        public string? InventoryNumber { get; set; }

        public virtual TechModelsOfPrinter? ModelNavigation { get; set; }
        public virtual ICollection<PcsPrinter> PcsPrinters { get; set; }
    }
}
