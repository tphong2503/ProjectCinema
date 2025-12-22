namespace ProjectCinema.Modals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ghe")]
    public partial class Ghe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ghe()
        {
            Ves = new HashSet<Ve>();
        }

        [Key]
        public int MaGhe { get; set; }

        public int MaPhong { get; set; }

        [Required]
        [StringLength(10)]
        public string SoGhe { get; set; }

        [Required]
        [StringLength(1)]
        public string HangGhe { get; set; }

        public int SoThuTu { get; set; }

        [StringLength(50)]
        public string LoaiGhe { get; set; }

        public decimal GiaGhe { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual PhongChieu PhongChieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
