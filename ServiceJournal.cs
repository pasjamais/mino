using System;
using System.Collections.Generic;

namespace mino
{
    public partial class ServiceJournal
    {
        public long Id { get; set; }
        public long? Manipulation { get; set; }
        public DateTime? Date { get; set; } 
        public string? Comment { get; set; }
        public long? Client { get; set; }

        public virtual User? ClientNavigation { get; set; }
        public virtual TypesOfService? ManipulationNavigation { get; set; }
    }
}
