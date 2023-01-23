using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechCartridgesRotation
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public long? ModelId { get; set; }
        public long? Place { get; set; }
        public long? Quantity { get; set; }
        public string? Comment { get; set; }

        public virtual TechModelsOfCartridge? Model { get; set; }
        public virtual Place? PlaceNavigation { get; set; }
    }
}
