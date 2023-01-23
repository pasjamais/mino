using System;
using System.Collections.Generic;

namespace mino
{
    public partial class ServiceJournal
    {
        public long Id { get; set; }
        public long? Manipulation { get; set; }
        public byte[] Date { get; set; } = null!;
        public string? Comment { get; set; }
        public long? Client { get; set; }

        public virtual User? ClientNavigation { get; set; }
        public virtual TypesOfService? ManipulationNavigation { get; set; }
    }
}
