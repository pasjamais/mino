using System;
using System.Collections.Generic;

namespace mino
{
    public partial class User
    {
        public User()
        {
            Pcs = new HashSet<Pc>();
            ServiceJournals = new HashSet<ServiceJournal>();
            TechCameras = new HashSet<TechCamera>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Cabinet { get; set; }
        public string? Comment { get; set; }
        public long? Credentials { get; set; }

        public virtual Cabinet? CabinetNavigation { get; set; }
        public virtual Credential? CredentialsNavigation { get; set; }
        public virtual ICollection<Pc> Pcs { get; set; }
        public virtual ICollection<ServiceJournal> ServiceJournals { get; set; }
        public virtual ICollection<TechCamera> TechCameras { get; set; }
    }
}
