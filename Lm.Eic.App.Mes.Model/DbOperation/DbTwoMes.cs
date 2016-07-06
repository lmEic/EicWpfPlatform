namespace Lm.Eic.App.Mes.Model
{
    using System.Data.Entity;

    public class DbTwoMes : DbContext
    {
        public DbTwoMes()
            : base(ConnectString.DbTwoMes)
        {
        }

        public virtual DbSet<OQC_InspectStatnard> OQC_InspectStatnard { get; set; }
        public virtual DbSet<OQC_OrderInspectConfig> OQC_OrderInspectConfig { get; set; }
        public virtual DbSet<OQC_OrderInspectStatnard> OQC_OrderInspectStatnard { get; set; }
        public virtual DbSet<OQC_OrderPackLot> OQC_OrderPackLot { get; set; }
        public virtual DbSet<OQC_OrderPrintConfig> OQC_OrderPrintConfig { get; set; }
        public virtual DbSet<OQC_OrderPrintLabInfo> OQC_OrderPrintLabInfo { get; set; }
        public virtual DbSet<OQC_Pack3D> OQC_Pack3D { get; set; }
        public virtual DbSet<OQC_PackExfo> OQC_PackExfo { get; set; }
        public virtual DbSet<OQC_ProductInspectStandard> OQC_ProductInspectStandard { get; set; }
        public virtual DbSet<OQC_ProductPrintConfig> OQC_ProductPrintConfig { get; set; }
        public virtual DbSet<OQC_ProductSerialNumberConfig> OQC_ProductSerialNumberConfig { get; set; }
        public virtual DbSet<OQC_SerialNumber> OQC_SerialNumber { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OQC_InspectStatnard>()
               .Property(e => e.InspectStandardName)
               .IsUnicode(false);

            modelBuilder.Entity<OQC_InspectStatnard>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_InspectStatnard>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_InspectStatnard>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_OrderInspectConfig>()
               .Property(e => e.OrderID)
               .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectConfig>()
                .Property(e => e.InspectMethod)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectConfig>()
                .Property(e => e.PrintMethod)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectConfig>()
                .Property(e => e.InspectStandardName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectConfig>()
                .Property(e => e.ConnectList)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectConfig>()
                .Property(e => e.InspectStandard_3D)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectConfig>()
                .Property(e => e.InspectStandard_Exfo)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectConfig>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_OrderInspectStatnard>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectStatnard>()
                .Property(e => e.InspectStandardName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectStatnard>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectStatnard>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderInspectStatnard>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_OrderPackLot>()
                .Property(e => e.PackLot)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPackLot>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPackLot>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPackLot>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPackLot>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPackLot>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintConfig>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintConfig>()
                .Property(e => e.PackLot)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintConfig>()
                .Property(e => e.PrintType)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintConfig>()
                .Property(e => e.LabName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintConfig>()
                .Property(e => e.LabPath)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintConfig>()
               .Property(e => e.DataSourcesPath)
               .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintLabInfo>()
               .Property(e => e.OrderID)
               .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintLabInfo>()
                .Property(e => e.PackLot)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintLabInfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintLabInfo>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_OrderPrintLabInfo>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.SN)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Curvature)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Curvature_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Spherical)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Spherical_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Planar)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Planar_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Apex_Offset)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Apex_Offset_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Bearing)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Bearing_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Apex_Angle)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Apex_Angle_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Tilt_Offset)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Tilt_Offset_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Tilt_Angle)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Tilt_Angle_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.KeyError)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.KeyError_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.FiberRq)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.FiberRq_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.FiberRa)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.FiberRa_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.FerruleRq)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.FerruleRq_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.FerruleRa)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.FerruleRa_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Diameter)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Diameter_Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Test_Date)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.Test_Time)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.D)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.E)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.F)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.A)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.PackLot)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.PackDate)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.ClientSN)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_Pack3D>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.SN)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.TestDate)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.PartNumber)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.Result)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.Wave)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.IL_A)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.Refl_A)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.IL_B)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.Refl_B)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.ClientSN)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.PackLot)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
               .Property(e => e.OrderID)
               .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.BatchNo)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_PackExfo>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_ProductInspectStandard>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductInspectStandard>()
                .Property(e => e.TabName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductInspectStandard>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductInspectStandard>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductInspectStandard>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_ProductPrintConfig>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductPrintConfig>()
                .Property(e => e.PrintType)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductPrintConfig>()
                .Property(e => e.LabName)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductPrintConfig>()
                .Property(e => e.LabPath)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductPrintConfig>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_ProductSerialNumberConfig>()
                .Property(e => e.ProductID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_ProductSerialNumberConfig>()
                .Property(e => e.ConnectorList)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductSerialNumberConfig>()
                .Property(e => e.PigtailList)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_ProductSerialNumberConfig>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OQC_SerialNumber>()
                 .Property(e => e.SN)
                 .IsUnicode(false);

            modelBuilder.Entity<OQC_SerialNumber>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_SerialNumber>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_SerialNumber>()
                .Property(e => e.PackLot)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_SerialNumber>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OQC_SerialNumber>()
                .Property(e => e.R1)
                .IsUnicode(false);
        }
    }
}