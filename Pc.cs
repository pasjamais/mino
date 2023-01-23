using System;
using System.Collections.Generic;

namespace mino
{
    public partial class Pc
    {
        public Pc()
        {
            PcsPrinters = new HashSet<PcsPrinter>();
            PcsScaners = new HashSet<PcsScaner>();
        }

        public long Id { get; set; }
        public long? User { get; set; }
        public string? Comment { get; set; }
        public string? Name { get; set; }
        public string? Ip { get; set; }
        public long? CpuModel { get; set; }
        public byte[]? LastServiceDate { get; set; }
        public long? RamType { get; set; }
        public long? RamSize { get; set; }
        public long? RamBarsInUse { get; set; }
        public long? RamBarsTotal { get; set; }
        public long? Monitor { get; set; }
        public string? SpecialSoft { get; set; }
        public long? Printer { get; set; }
        public long? Scaner { get; set; }
        public string? InventoryN { get; set; }
        public long? Ups { get; set; }
        public long? SoftAntivirus { get; set; }
        public long? SoftOffice { get; set; }
        public long? SoftOs { get; set; }
        public byte[]? IsNotebook { get; set; }

        public virtual TechModelsOfCpu? CpuModelNavigation { get; set; }
        public virtual TechMonitor? MonitorNavigation { get; set; }
        public virtual TechPrinter? PrinterNavigation { get; set; }
        public virtual TechRamType? RamTypeNavigation { get; set; }
        public virtual TechScaner? ScanerNavigation { get; set; }
        public virtual TechSoftAntivirus? SoftAntivirusNavigation { get; set; }
        public virtual TechSoftOffice? SoftOfficeNavigation { get; set; }
        public virtual TechSoftO? SoftOsNavigation { get; set; }
        public virtual TechUpss? UpsNavigation { get; set; }
        public virtual User? UserNavigation { get; set; }
        public virtual ICollection<PcsPrinter> PcsPrinters { get; set; }
        public virtual ICollection<PcsScaner> PcsScaners { get; set; }
    }
}
