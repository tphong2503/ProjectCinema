namespace ProjectCinema.Modals
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDonDVs = new HashSet<ChiTietHoaDonDV>();
            Ves = new HashSet<Ve>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        public int? MaKhachHang { get; set; }

        public int? MaNguoiDung { get; set; }

        public DateTime? NgayLap { get; set; }

        public decimal TongTien { get; set; }

        public decimal? GiamGia { get; set; }

        public decimal ThanhTien { get; set; }

        [StringLength(50)]
        public string PhuongThucTT { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonDV> ChiTietHoaDonDVs { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
