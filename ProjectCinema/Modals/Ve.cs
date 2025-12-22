namespace ProjectCinema.Modals
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ve")]
    public partial class Ve
    {
        [Key]
        public int MaVe { get; set; }

        public int MaHoaDon { get; set; }

        public int MaSuatChieu { get; set; }

        public int MaGhe { get; set; }

        public decimal GiaVe { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public DateTime? NgayDat { get; set; }

        public virtual Ghe Ghe { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SuatChieu SuatChieu { get; set; }
    }
}
