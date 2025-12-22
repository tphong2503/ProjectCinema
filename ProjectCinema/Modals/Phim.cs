namespace ProjectCinema.Modals
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Phim")]
    public partial class Phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            SuatChieux = new HashSet<SuatChieu>();
        }

        [Key]
        public int MaPhim { get; set; }

        [Required]
        [StringLength(200)]
        public string TenPhim { get; set; }

        public int? MaTheLoai { get; set; }

        [StringLength(200)]
        public string DaoDien { get; set; }

        [StringLength(500)]
        public string DienVien { get; set; }

        public int? ThoiLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKhoiChieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [StringLength(100)]
        public string QuocGia { get; set; }

        public int? NamSanXuat { get; set; }

        public string MoTa { get; set; }

        [StringLength(500)]
        public string Poster { get; set; }

        [StringLength(500)]
        public string Trailer { get; set; }

        public int? DoTuoi { get; set; }

        public decimal? DanhGia { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public DateTime? NgayTao { get; set; }

        public virtual TheLoai TheLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuatChieu> SuatChieux { get; set; }
    }
}
