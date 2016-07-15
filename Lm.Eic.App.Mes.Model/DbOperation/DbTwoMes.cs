namespace Lm.Eic.App.Mes.Model
{
    using System.Data.Entity;

    public class DbTwoMes : DbContext
    {
        public DbTwoMes()
            : base(ConnectString.DbTwoMes)
        {
        }
        public virtual DbSet<BPM_Daily> BPM_Daily { get; set; }
        public virtual DbSet<BPM_Machines> BPM_Machines { get; set; }
        public virtual DbSet<BPM_Order> BPM_Order { get; set; }
        public virtual DbSet<BPM_OrderRelevance> BPM_OrderRelevance { get; set; }
        public virtual DbSet<BPM_Process> BPM_Process { get; set; }
        public virtual DbSet<BPM_Product> BPM_Product { get; set; }
        public virtual DbSet<BPM_ProductTemplate> BPM_ProductTemplate { get; set; }
        public virtual DbSet<HR_User> HR_User { get; set; }
        public virtual DbSet<BPM_WIP> BPM_WIP { get; set; }
        public virtual DbSet<SYS_TypeList> SYS_TypeList { get; set; }
        public virtual DbSet<Config_CommonParaSet> Config_CommonParaSet { get; set; }

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

            modelBuilder.Entity<BPM_Daily>()
             .Property(e => e.OrderID)
             .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ActualEndDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.DailyNum)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ClassType)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.Job_Num)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.Month)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ProcessName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ProcessSign)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.AssetNum)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.AssetName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.MouldNum)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.MouldName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.EquipmentID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.MasterJobNum)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.MasterName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Daily>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.AssetNum)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.AssetName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.AssetSpec)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.AliasName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.MakeNum)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.AssetType)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.MouldNum)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.MouldName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.MasterJobNum)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.MasterName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Machines>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.StartDate)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.EndDate)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.ActualStartDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.ActualEndDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.Qty)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.PN)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.PO)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.WorkDepartment)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Order>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BPM_OrderRelevance>()
                .Property(e => e.MainOrder)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_OrderRelevance>()
                .Property(e => e.AdditionalOrder)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_OrderRelevance>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_OrderRelevance>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Process>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Process>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Process>()
                .Property(e => e.ProcessSign)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Process>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Process>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Process>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Process>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
              .Property(e => e.Department)
              .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.Units)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.DrawID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.PtID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_Product>()
                .Property(e => e.Pic)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.PtID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.ProcessName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.ProcessSign)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.IsVital)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.IsControl)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.ReWorkProcess)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_ProductTemplate>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Job_Num)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Workshop)
                .IsFixedLength();

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.ClassType)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Job_Title)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Is_Job)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.PhotoPath)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Age)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.IsWedding)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Politics)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.ID_Card)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Nation)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Native_Place)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Degree)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Major)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.School)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.IsWork)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.QQ)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Email_Address)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Present_Assress)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Emergency_Contact)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Emergency_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Resume)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Permission)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R1)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R2)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R3)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R4)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R5)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.USI_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BPM_WIP>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_WIP>()
                .Property(e => e.ClientName)
                .IsFixedLength();

            modelBuilder.Entity<BPM_WIP>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_WIP>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_WIP>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_WIP>()
                .Property(e => e.ProcessName)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_WIP>()
                .Property(e => e.ProcessSign)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_WIP>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_TypeList>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_TypeList>()
                .Property(e => e.Module)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_TypeList>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_TypeList>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_TypeList>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_TypeList>()
                .Property(e => e.R1)
                .IsUnicode(false);

            modelBuilder.Entity<Config_CommonParaSet>()
              .Property(e => e.Id_Key)
              .HasPrecision(18, 0);


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