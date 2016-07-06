namespace Lm.Eic.App.Mes.Model
{
    using System.Data.Entity;

    public class DbTwoLine : DbContext
    {
        public DbTwoLine()
            : base(ConnectString.DbTwoLine)
        {
        }

        public virtual DbSet<User_3D_Test_Good> User_3D_Test_Good { get; set; }
        public virtual DbSet<User_JDS_Test_Good> User_JDS_Test_Good { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.SN)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Curvature)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Curvature_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Spherical)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Spherical_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Planar)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Planar_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Apex_Offset)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Apex_Offset_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Bearing)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Bearing_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Apex_Angle)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Apex_Angle_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Tilt_Offset)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Tilt_Offset_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Tilt_Angle)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Tilt_Angle_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.KeyError)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.KeyError_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.FiberRq)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.FiberRq_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.FiberRa)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.FiberRa_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.FerruleRq)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.FerruleRq_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.FerruleRa)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.FerruleRa_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Diameter)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Diameter_Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Test_Date)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.Test_Time)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.D)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.E)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.F)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.A)
                .IsUnicode(false);

            modelBuilder.Entity<User_3D_Test_Good>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.TestDate)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.PartNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.SN)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.Result)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.Wave)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.IL_A)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.Refl_A)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.IL_B)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.Refl_B)
                .IsUnicode(false);

            modelBuilder.Entity<User_JDS_Test_Good>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);
        }
    }
}