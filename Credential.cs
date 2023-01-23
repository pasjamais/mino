using System;
using System.Collections.Generic;

namespace mino
{
    public partial class Credential
    {
        public Credential()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Pass { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
