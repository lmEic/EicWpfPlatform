namespace Lm.Eic.App.Mes.Model
{
    using System.Data.Entity;

    public class DbMes : DbContext
    {
        public DbMes()
            : base(ConnectString.DbMes)
        {
        }

        public virtual DbSet<Ast_Equipment> Ast_Equipment { get; set; }
        public virtual DbSet<Bpm_Order> Bpm_Order { get; set; }
        public virtual DbSet<Bpm_OrderWip> Bpm_OrderWip { get; set; }
        public virtual DbSet<Bpm_Process> Bpm_Process { get; set; }
        public virtual DbSet<Bpm_ProcessTemplate> Bpm_ProcessTemplate { get; set; }
        public virtual DbSet<Bpm_Product> Bpm_Product { get; set; }
        public virtual DbSet<Bpm_Daily> BpmDaily { get; set; }
        public virtual DbSet<Config_CommonParaSet> Config_CommonParaSet { get; set; }
        public virtual DbSet<Hr_UserInfo> Hr_UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ast_Equipment>()
    .Property(e => e.AssetNum)
    .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
                .Property(e => e.AssetName)
                .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
                .Property(e => e.AssetSpec)
                .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
                .Property(e => e.AliasName)
                .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
                .Property(e => e.MakeNum)
                .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
                .Property(e => e.AssetType)
                .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
             .Property(e => e.ProcessID)
             .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
             .Property(e => e.MouldNum)
             .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
             .Property(e => e.MouldName)
             .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
            .Property(e => e.MasterJobNum)
            .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
            .Property(e => e.MasterName)
            .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<Ast_Equipment>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.StartDate)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.EndDate)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.ActualStartDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.ActualEndDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.Qty)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.WorkDepartment)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Order>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_OrderWip>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_OrderWip>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_OrderWip>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_OrderWip>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_OrderWip>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_OrderWip>()
                .Property(e => e.ProcessName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_OrderWip>()
                .Property(e => e.ProcessSign)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_OrderWip>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bpm_Process>()
               .Property(e => e.ProcessID)
               .IsUnicode(false);

            modelBuilder.Entity<Bpm_Process>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Process>()
              .Property(e => e.ProcessSign)
              .IsUnicode(false);

            modelBuilder.Entity<Bpm_Process>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Process>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Process>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Process>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.PtID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.ProcessName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.ProcessSign)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.IsVital)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.IsControl)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.ReWorkProcess)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_ProcessTemplate>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.Units)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.DrawID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.PtID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.Pic)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Product>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ActualEndDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.DailyNum)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ClassType)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.JobNum)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Month)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProcessName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProcessSign)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
           .Property(e => e.MasterJobNum)
           .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
            .Property(e => e.MasterName)
            .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.EquipmentID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Config_CommonParaSet>()
                .Property(e => e.Id_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.JobNum)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.ClassType)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_UserInfo>()
                .Property(e => e.IsJob)
                .IsUnicode(false);
        }
    }
}