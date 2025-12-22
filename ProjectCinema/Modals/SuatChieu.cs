namespace ProjectCinema.Modals
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SuatChieu")]
    public partial class SuatChieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuatChieu()
        {
            Ves = new HashSet<Ve>();
        }

        [Key]
        public int MaSuatChieu { get; set; }

        public int MaPhim { get; set; }

        public int MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayChieu { get; set; }

        public TimeSpan GioChieu { get; set; }

        public TimeSpan? GioKetThuc { get; set; }

        public decimal GiaVe { get; set; }

        public int? SoGheTrong { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public DateTime? NgayTao { get; set; }

        public virtual Phim Phim { get; set; }

        public virtual PhongChieu PhongChieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
