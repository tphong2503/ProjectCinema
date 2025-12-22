using System.Data.Entity;

namespace ProjectCinema.Modals
{
    public partial class DashBoard : DbContext
    {
        public DashBoard()
            : base("name=DashBoard")
        {
        }

        public virtual DbSet<ChiTietHoaDonDV> ChiTietHoaDonDVs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<Ghe> Ghes { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<PhongChieu> PhongChieux { get; set; }
        public virtual DbSet<SuatChieu> SuatChieux { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDonDV>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietHoaDonDV>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietHoaDonDVs)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ghe>()
                .Property(e => e.HangGhe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ghe>()
                .Property(e => e.GiaGhe)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Ghe>()
                .HasMany(e => e.Ves)
                .WithRequired(e => e.Ghe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.GiamGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDonDVs)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.Ves)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.GiaTriGiam)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Phim>()
                .Property(e => e.DanhGia)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.SuatChieux)
                .WithRequired(e => e.Phim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongChieu>()
                .HasMany(e => e.Ghes)
                .WithRequired(e => e.PhongChieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongChieu>()
                .HasMany(e => e.SuatChieux)
                .WithRequired(e => e.PhongChieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuatChieu>()
                .Property(e => e.GiaVe)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SuatChieu>()
                .HasMany(e => e.Ves)
                .WithRequired(e => e.SuatChieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ve>()
                .Property(e => e.GiaVe)
                .HasPrecision(18, 0);
        }
    }
}
