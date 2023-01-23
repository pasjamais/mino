using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TypesOfService
    {
        public TypesOfService()
        {
            ServiceJournals = new HashSet<ServiceJournal>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ServiceJournal> ServiceJournals { get; set; }
    }
}
