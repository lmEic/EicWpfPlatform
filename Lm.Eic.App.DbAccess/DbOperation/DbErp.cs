namespace Lm.Eic.App.Mes.Model
{
    using System.Data.Entity;

    public class DbErp : DbContext
    {
        public DbErp()
            : base(ConnectString.DbErp)
        {
        }

        public virtual DbSet<MOCTA> MOCTA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MOCTA>()
                .Property(e => e.COMPANY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.CREATOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.USR_GROUP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.CREATE_DATE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.MODIFIER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.MODI_DATE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.FLAG)
                .HasPrecision(3, 0);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA001)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA002)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA003)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA004)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA005)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA006)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA007)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA008)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA009)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA010)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA011)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA012)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA013)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA014)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA015)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA016)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA017)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA018)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA019)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA020)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA021)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA022)
                .HasPrecision(17, 8);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA023)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA024)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA025)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA026)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA027)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA028)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA029)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA030)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA031)
                .HasPrecision(1, 0);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA032)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA033)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA034)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA035)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA036)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA037)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA038)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA039)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA040)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA041)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA042)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA043)
                .HasPrecision(10, 7);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA044)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA045)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA046)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA047)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA048)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA049)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA050)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA051)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA052)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA053)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA054)
                .HasPrecision(1, 0);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA055)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA056)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA057)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA058)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA059)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA060)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA061)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA062)
                .HasPrecision(1, 0);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA063)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA064)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA065)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA066)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA067)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA068)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA069)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA070)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA071)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA072)
                .HasPrecision(5, 4);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA073)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.TA074)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF01)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF02)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF03)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF04)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF05)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF06)
                .IsUnicode(false);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF51)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF52)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF53)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF54)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF55)
                .HasPrecision(16, 6);

            modelBuilder.Entity<MOCTA>()
                .Property(e => e.UDF56)
                .HasPrecision(16, 6);
        }
    }
}