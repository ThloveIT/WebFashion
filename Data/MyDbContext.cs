using Microsoft.EntityFrameworkCore;

namespace WebFashion.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoa> hangHoas { get; set; }
        public DbSet<Loai> loais { get; set; }

        public DbSet<DonHang> donHangs { get; set; }
        public DbSet<ChiTietDonHang> chiTietDonHangs { get; set; }
        #endregion

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<ChiTietDonHang>(e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(ct => new {ct.MaDH, ct.MaHangHoa});

                //relationship voi DonHang
                e.HasOne(ct => ct.DonHang)
                .WithMany(ct => ct.ChiTietDonHangs)
                .HasForeignKey(ct => ct.MaDH)
                .HasConstraintName("FK_ChiTietDonHang_DonHang");

                //relationship
                e.HasOne(ct => ct.HangHoa)
                .WithMany(ct => ct.ChiTietDonHangs)
                .HasForeignKey(ct => ct.MaHangHoa)
                .HasConstraintName("FK_ChiTietDonHang_HangHoa");
            });
        }
    }
}
