namespace ProjectCinema.Modals
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [Key]
        public int MaKhuyenMai { get; set; }

        [Required]
        [StringLength(200)]
        public string TenKhuyenMai { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string LoaiGiamGia { get; set; }

        public decimal GiaTriGiam { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThuc { get; set; }

        [StringLength(500)]
        public string DieuKien { get; set; }

        public int? SoLuong { get; set; }

        public int? DaSuDung { get; set; }

        public bool? TrangThai { get; set; }
    }
}
