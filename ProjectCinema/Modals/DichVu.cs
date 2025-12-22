namespace ProjectCinema.Modals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            ChiTietHoaDonDVs = new HashSet<ChiTietHoaDonDV>();
        }

        [Key]
        public int MaDichVu { get; set; }

        public int? MaLoaiDV { get; set; }

        [Required]
        [StringLength(200)]
        public string TenDichVu { get; set; }

        public decimal DonGia { get; set; }

        [StringLength(50)]
        public string DonVi { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(500)]
        public string HinhAnh { get; set; }

        public int? SoLuongTon { get; set; }

        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonDV> ChiTietHoaDonDVs { get; set; }

        public virtual LoaiDichVu LoaiDichVu { get; set; }
    }
}
