using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mino
{
    public partial class minoContext : DbContext
    {
        public minoContext()
        {
        }

        public minoContext(DbContextOptions<minoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabinet> Cabinets { get; set; } = null!;
        public virtual DbSet<Credential> Credentials { get; set; } = null!;
        public virtual DbSet<Pc> Pcs { get; set; } = null!;
        public virtual DbSet<PcsPrinter> PcsPrinters { get; set; } = null!;
        public virtual DbSet<PcsScaner> PcsScaners { get; set; } = null!;
        public virtual DbSet<Place> Places { get; set; } = null!;
        public virtual DbSet<Query> Queries { get; set; } = null!;
        public virtual DbSet<ServiceJournal> ServiceJournals { get; set; } = null!;
        public virtual DbSet<TechCamera> TechCameras { get; set; } = null!;
        public virtual DbSet<TechCartridgesRotation> TechCartridgesRotations { get; set; } = null!;
        public virtual DbSet<TechDiskType> TechDiskTypes { get; set; } = null!;
        public virtual DbSet<TechHdd> TechHdds { get; set; } = null!;
        public virtual DbSet<TechModelsOfCartridge> TechModelsOfCartridges { get; set; } = null!;
        public virtual DbSet<TechModelsOfCpu> TechModelsOfCpus { get; set; } = null!;
        public virtual DbSet<TechModelsOfPrinter> TechModelsOfPrinters { get; set; } = null!;
        public virtual DbSet<TechModelsOfScaner> TechModelsOfScaners { get; set; } = null!;
        public virtual DbSet<TechMonitor> TechMonitors { get; set; } = null!;
        public virtual DbSet<TechMonitorDiagonal> TechMonitorDiagonals { get; set; } = null!;
        public virtual DbSet<TechPrinter> TechPrinters { get; set; } = null!;
        public virtual DbSet<TechPrinterCartridgeAlliance> TechPrinterCartridgeAlliances { get; set; } = null!;
        public virtual DbSet<TechRamType> TechRamTypes { get; set; } = null!;
        public virtual DbSet<TechScaner> TechScaners { get; set; } = null!;
        public virtual DbSet<TechSoftAntivirus> TechSoftAntiviruses { get; set; } = null!;
        public virtual DbSet<TechSoftO> TechSoftOs { get; set; } = null!;
        public virtual DbSet<TechSoftOffice> TechSoftOffices { get; set; } = null!;
        public virtual DbSet<TechUpss> TechUpsses { get; set; } = null!;
        public virtual DbSet<TypesOfService> TypesOfServices { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<АссортиментИКоличествоКартриджейВНаличии> АссортиментИКоличествоКартриджейВНаличииs { get; set; } = null!;
        public virtual DbSet<ГдеКакойПринтерСейчас> ГдеКакойПринтерСейчасs { get; set; } = null!;
        public virtual DbSet<ДвижениеКартриджей> ДвижениеКартриджейs { get; set; } = null!;
        public virtual DbSet<ДвижениеПринтеров> ДвижениеПринтеровs { get; set; } = null!;
        public virtual DbSet<Журнал> Журналs { get; set; } = null!;
        public virtual DbSet<Пк> Пкs { get; set; } = null!;
        public virtual DbSet<РейтингАктивностиСотрудников> РейтингАктивностиСотрудниковs { get; set; } = null!;
        public virtual DbSet<РейтингВостребованностиСервисов> РейтингВостребованностиСервисовs { get; set; } = null!;
        public virtual DbSet<СписокПользователейИИхПк> СписокПользователейИИхПкs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=mino.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Cabinets_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Cabinets_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR (3)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Credentials_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Credentials_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Pass).HasColumnName("pass");
            });

            modelBuilder.Entity<Pc>(entity =>
            {
                entity.ToTable("PCs");

                entity.HasIndex(e => e.Id, "IX_PCs_id")
                    .IsUnique();

                entity.HasIndex(e => e.InventoryN, "IX_PCs_inventory_N")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.CpuModel).HasColumnName("CPU_model");

                entity.Property(e => e.InventoryN)
                    .HasColumnType("VARCHAR (30)")
                    .HasColumnName("inventory_N");

                entity.Property(e => e.Ip)
                    .HasColumnType("VARCHAR (15)")
                    .HasColumnName("IP");

                entity.Property(e => e.IsNotebook)
                    .HasColumnType("BOOLEAN")
                    .HasColumnName("isNotebook");

                entity.Property(e => e.LastInfoGetDate)
                    .HasColumnType("DATE")
                    .HasColumnName("last_info_get_date");

                entity.Property(e => e.LastServiceDate)
                    .HasColumnType("DATE")
                    .HasColumnName("last_service_date");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("name");

                entity.Property(e => e.OsSetupDate)
                    .HasColumnType("DATE")
                    .HasColumnName("OS_Setup_Date");

                entity.Property(e => e.RamBarsInUse).HasColumnName("ram_bars_in_use");

                entity.Property(e => e.RamBarsTotal).HasColumnName("ram_bars_total");

                entity.Property(e => e.RamSize).HasColumnName("ram_size");

                entity.Property(e => e.RamType).HasColumnName("ram_type");

                entity.Property(e => e.SoftAntivirus).HasColumnName("soft_Antivirus");

                entity.Property(e => e.SoftOffice).HasColumnName("soft_Office");

                entity.Property(e => e.SoftOs).HasColumnName("soft_OS");

                entity.Property(e => e.SpecialSoft).HasColumnName("special_soft");

                entity.Property(e => e.Ups).HasColumnName("ups");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.CpuModelNavigation)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.CpuModel)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.RamTypeNavigation)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.RamType)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SoftAntivirusNavigation)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.SoftAntivirus)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SoftOfficeNavigation)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.SoftOffice)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SoftOsNavigation)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.SoftOs)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.UpsNavigation)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.Ups)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PcsPrinter>(entity =>
            {
                entity.ToTable("PCs_Printers");

                entity.HasIndex(e => e.Id, "IX_PCs_Printers_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Date)
                    .HasColumnType("DATETIME")
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Pc).HasColumnName("PC");

                entity.Property(e => e.Printer).HasColumnName("printer");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.PcNavigation)
                    .WithMany(p => p.PcsPrinters)
                    .HasForeignKey(d => d.Pc)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.PrinterNavigation)
                    .WithMany(p => p.PcsPrinters)
                    .HasForeignKey(d => d.Printer)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<PcsScaner>(entity =>
            {
                entity.ToTable("PCs_Scaners");

                entity.HasIndex(e => e.Id, "IX_PCs_Scaners_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Date)
                    .HasColumnType("DATETIME")
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Pc).HasColumnName("PC");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Scaner).HasColumnName("scaner");

                entity.HasOne(d => d.PcNavigation)
                    .WithMany(p => p.PcsScaners)
                    .HasForeignKey(d => d.Pc)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ScanerNavigation)
                    .WithMany(p => p.PcsScaners)
                    .HasForeignKey(d => d.Scaner)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Places_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Places_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Query>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Queries_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<ServiceJournal>(entity =>
            {
                entity.ToTable("ServiceJournal");

                entity.HasIndex(e => e.Id, "IX_ServiceJournal_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Client).HasColumnName("client");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Date)
                    .HasColumnType("DATETIME")
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Manipulation).HasColumnName("manipulation");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.ServiceJournals)
                    .HasForeignKey(d => d.Client)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ManipulationNavigation)
                    .WithMany(p => p.ServiceJournals)
                    .HasForeignKey(d => d.Manipulation)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TechCamera>(entity =>
            {
                entity.ToTable("tech_Cameras");

                entity.HasIndex(e => e.Id, "IX_tech_Cameras_id")
                    .IsUnique();

                entity.HasIndex(e => e.InventoryNumber, "IX_tech_Cameras_InventoryNumber")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("name");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.TechCameras)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TechCartridgesRotation>(entity =>
            {
                entity.ToTable("tech_Cartridges_Rotation");

                entity.HasIndex(e => e.Id, "IX_tech_Cartridges_Rotation_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Date)
                    .HasColumnType("DATETIME")
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.TechCartridgesRotations)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PlaceNavigation)
                    .WithMany(p => p.TechCartridgesRotations)
                    .HasForeignKey(d => d.Place)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TechDiskType>(entity =>
            {
                entity.ToTable("tech_Disk_Types");

                entity.HasIndex(e => e.Id, "IX_tech_Disk_Types_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_Disk_Types_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<TechHdd>(entity =>
            {
                entity.ToTable("tech_HDDs");

                entity.HasIndex(e => e.Id, "IX_tech_HDDs_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnType("VARCHAR");

                entity.Property(e => e.HasSystemPartition)
                    .HasColumnType("BOOLEAN")
                    .HasColumnName("Has_System_Partition");

                entity.Property(e => e.IdDiskType).HasColumnName("Id_Disk_Type");

                entity.Property(e => e.IdPc).HasColumnName("id_PC");

                entity.Property(e => e.Name).HasColumnType("VARCHAR");

                entity.Property(e => e.SerialNumber)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("Serial_Number");

                entity.HasOne(d => d.IdDiskTypeNavigation)
                    .WithMany(p => p.TechHdds)
                    .HasForeignKey(d => d.IdDiskType);

                entity.HasOne(d => d.IdPcNavigation)
                    .WithMany(p => p.TechHdds)
                    .HasForeignKey(d => d.IdPc);
            });

            modelBuilder.Entity<TechModelsOfCartridge>(entity =>
            {
                entity.ToTable("tech_Models_of_Cartridge");

                entity.HasIndex(e => e.Id, "IX_tech_Models_of_Cartridge_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_Models_of_Cartridge_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR (100)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TechModelsOfCpu>(entity =>
            {
                entity.ToTable("tech_Models_of_CPU");

                entity.HasIndex(e => e.Id, "IX_tech_Models_of_CPU_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_Models_of_CPU_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClockRate).HasColumnName("clock_rate");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Rating)
                    .HasColumnType("DECIMAL")
                    .HasColumnName("rating");
            });

            modelBuilder.Entity<TechModelsOfPrinter>(entity =>
            {
                entity.ToTable("tech_Models_of_Printer");

                entity.HasIndex(e => e.Id, "IX_tech_Models_of_Printer_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_Models_of_Printer_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsMfu)
                    .HasColumnType("BOOLEAN")
                    .HasColumnName("isMFU");

                entity.Property(e => e.MfuScanerModel).HasColumnName("MFU_Scaner_Model");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR (40)")
                    .HasColumnName("name");

                entity.HasOne(d => d.MfuScanerModelNavigation)
                    .WithMany(p => p.TechModelsOfPrinters)
                    .HasForeignKey(d => d.MfuScanerModel)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<TechModelsOfScaner>(entity =>
            {
                entity.ToTable("tech_Models_of_Scaner");

                entity.HasIndex(e => e.Id, "IX_tech_Models_of_Scaner_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_Models_of_Scaner_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR (40)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TechMonitor>(entity =>
            {
                entity.ToTable("tech_Monitors");

                entity.HasIndex(e => e.Id, "IX_tech_Monitors_id")
                    .IsUnique();

                entity.HasIndex(e => e.InventoryNumber, "IX_tech_Monitors_InventoryNumber")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Diagonal).HasColumnName("diagonal");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Pc).HasColumnName("PC");

                entity.HasOne(d => d.DiagonalNavigation)
                    .WithMany(p => p.TechMonitors)
                    .HasForeignKey(d => d.Diagonal)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PcNavigation)
                    .WithMany(p => p.TechMonitors)
                    .HasForeignKey(d => d.Pc)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TechMonitorDiagonal>(entity =>
            {
                entity.ToTable("tech_Monitor_diagonals");

                entity.HasIndex(e => e.Diagonal, "IX_tech_Monitor_diagonals_diagonal")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "IX_tech_Monitor_diagonals_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Diagonal)
                    .HasColumnType("DECIMAL")
                    .HasColumnName("diagonal");
            });

            modelBuilder.Entity<TechPrinter>(entity =>
            {
                entity.ToTable("tech_Printers");

                entity.HasIndex(e => e.Id, "IX_tech_Printers_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasDefaultValueSql("\"tech_Printers.model\"");

                entity.Property(e => e.InventoryNumber)
                    .HasColumnType("VARCHAR (30)")
                    .HasColumnName("inventory_number");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.HasOne(d => d.ModelNavigation)
                    .WithMany(p => p.TechPrinters)
                    .HasForeignKey(d => d.Model)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<TechPrinterCartridgeAlliance>(entity =>
            {
                entity.ToTable("tech_Printer_Cartridge_Alliance");

                entity.HasIndex(e => e.Id, "IX_tech_Printer_Cartridge_Alliance_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartridgeModel).HasColumnName("cartridge_model");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.PrinterModel).HasColumnName("printer_model");

                entity.HasOne(d => d.CartridgeModelNavigation)
                    .WithMany(p => p.TechPrinterCartridgeAlliances)
                    .HasForeignKey(d => d.CartridgeModel)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PrinterModelNavigation)
                    .WithMany(p => p.TechPrinterCartridgeAlliances)
                    .HasForeignKey(d => d.PrinterModel)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<TechRamType>(entity =>
            {
                entity.ToTable("tech_Ram_type");

                entity.HasIndex(e => e.Id, "IX_tech_Ram_type_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_Ram_type_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR (20)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TechScaner>(entity =>
            {
                entity.ToTable("tech_Scaners");

                entity.HasIndex(e => e.Id, "IX_tech_Scaners_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_Scaners_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.ModelId).HasColumnName("modelId");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Pc).HasColumnName("PC");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.TechScaners)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PcNavigation)
                    .WithMany(p => p.TechScaners)
                    .HasForeignKey(d => d.Pc)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TechSoftAntivirus>(entity =>
            {
                entity.ToTable("tech_soft_Antivirus");

                entity.HasIndex(e => e.Id, "IX_tech_soft_Antivirus_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_soft_Antivirus_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<TechSoftO>(entity =>
            {
                entity.ToTable("tech_soft_OS");

                entity.HasIndex(e => e.Id, "IX_tech_soft_OS_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_soft_OS_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<TechSoftOffice>(entity =>
            {
                entity.ToTable("tech_soft_Office");

                entity.HasIndex(e => e.Id, "IX_tech_soft_Office_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_tech_soft_Office_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<TechUpss>(entity =>
            {
                entity.ToTable("tech_UPSs");

                entity.HasIndex(e => e.Id, "IX_tech_UPSs_id")
                    .IsUnique();

                entity.HasIndex(e => e.InventoryNumber, "IX_tech_UPSs_InventoryNumber")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<TypesOfService>(entity =>
            {
                entity.ToTable("types_of_Service");

                entity.HasIndex(e => e.Id, "IX_types_of_Service_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_types_of_Service_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Users_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cabinet).HasColumnName("cabinet");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Credentials).HasColumnName("credentials");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.CabinetNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Cabinet)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.CredentialsNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Credentials)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<АссортиментИКоличествоКартриджейВНаличии>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Ассортимент  и количество картриджей в наличии");

                entity.Property(e => e.Картридж).HasColumnType("VARCHAR (100)");
            });

            modelBuilder.Entity<ГдеКакойПринтерСейчас>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Где какой принтер сейчас");

                entity.Property(e => e.Дата).HasColumnName("ДАТА");

                entity.Property(e => e.ИнфоОПринтере).HasColumnName("Инфо о принтере");

                entity.Property(e => e.Кабинет).HasColumnType("VARCHAR (3)");

                entity.Property(e => e.Модель).HasColumnType("VARCHAR (40)");

                entity.Property(e => e.Пк)
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("ПК");
            });

            modelBuilder.Entity<ДвижениеКартриджей>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Движение картриджей");

                entity.Property(e => e.Дата).HasColumnType("DATETIME");

                entity.Property(e => e.МодельКартриджа)
                    .HasColumnType("VARCHAR (100)")
                    .HasColumnName("Модель картриджа");
            });

            modelBuilder.Entity<ДвижениеПринтеров>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Движение принтеров");

                entity.Property(e => e.Дата).HasColumnType("DATETIME");

                entity.Property(e => e.Модель).HasColumnType("VARCHAR (40)");

                entity.Property(e => e.Пк)
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("ПК");

                entity.Property(e => e.СведенияОПринтере).HasColumnName("Сведения о принтере");

                entity.Property(e => e.ЧтоБыло).HasColumnName("Что было");
            });

            modelBuilder.Entity<Журнал>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Журнал");

                entity.Property(e => e.Дата).HasColumnType("DATETIME");
            });

            modelBuilder.Entity<Пк>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ПК");

                entity.Property(e => e.Ip)
                    .HasColumnType("VARCHAR (15)")
                    .HasColumnName("IP");

                entity.Property(e => e.Ибп).HasColumnName("ИБП");

                entity.Property(e => e.ИмяПк)
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("Имя ПК");

                entity.Property(e => e.Инвентарный)
                    .HasColumnType("VARCHAR (30)")
                    .HasColumnName("Инвентарный №");

                entity.Property(e => e.МодельЦп).HasColumnName("Модель ЦП");

                entity.Property(e => e.Ноутбук).HasColumnType("BOOLEAN");

                entity.Property(e => e.ОзуГб).HasColumnName("ОЗУ, ГБ");

                entity.Property(e => e.Ос).HasColumnName("ОС");

                entity.Property(e => e.ОфисныйПакет).HasColumnName("Офисный пакет");

                entity.Property(e => e.ПоследнееОбновлениеСведений)
                    .HasColumnType("DATE")
                    .HasColumnName("Последнее обновление сведений");

                entity.Property(e => e.ПоследнееСервиснОбслуживания)
                    .HasColumnType("DATE")
                    .HasColumnName("Последнее сервисн. обслуживания");

                entity.Property(e => e.РейтингЦп)
                    .HasColumnType("DECIMAL")
                    .HasColumnName("Рейтинг ЦП");

                entity.Property(e => e.СлотовОзуВсего).HasColumnName("Слотов ОЗУ всего");

                entity.Property(e => e.СлотовОзуИспольз).HasColumnName("Слотов ОЗУ использ.");

                entity.Property(e => e.СпециальныйСофт).HasColumnName("Специальный софт");

                entity.Property(e => e.ТипОзу)
                    .HasColumnType("VARCHAR (20)")
                    .HasColumnName("Тип ОЗУ");

                entity.Property(e => e.ЧастотаЦп).HasColumnName("частота ЦП");
            });

            modelBuilder.Entity<РейтингАктивностиСотрудников>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Рейтинг активности сотрудников");
            });

            modelBuilder.Entity<РейтингВостребованностиСервисов>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Рейтинг востребованности сервисов");

                entity.Property(e => e.КоличествоОбращений).HasColumnName("Количество обращений");

                entity.Property(e => e.ТипСервиса).HasColumnName("Тип сервиса");
            });

            modelBuilder.Entity<СписокПользователейИИхПк>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Список пользователей и их ПК");

                entity.Property(e => e.Ip)
                    .HasColumnType("VARCHAR (15)")
                    .HasColumnName("IP");

                entity.Property(e => e.Кабинет).HasColumnType("VARCHAR (3)");

                entity.Property(e => e.Пк)
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("ПК");

                entity.Property(e => e.Фио).HasColumnName("ФИО");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
