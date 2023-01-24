using System;
using System.Collections.Generic;

namespace mino
{
    public partial class TechHdd
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Size { get; set; }
        public long? IdDiskType { get; set; }
        public bool? HasSystemPartition { get; set; }
        public long? IdPc { get; set; }
        public string? SerialNumber { get; set; }
        public string? Comment { get; set; }

        public virtual TechDiskType? IdDiskTypeNavigation { get; set; }
        public virtual Pc? IdPcNavigation { get; set; }
    }
}
