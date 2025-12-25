using System;
using System.Data;
using System.Windows.Forms;
// using QLRP.DAL;

namespace ProjectCinema
{
    public partial class frmQLSuatChieu : Form
    {
        int maSC = -1;
        int soGhePhong = 0;

        public frmQLSuatChieu()
        {
            InitializeComponent();
        }

        private void frmQLSuatChieu_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCombo();
        }

        void LoadData()
        {
            // dgvSuatChieu.DataSource = SuatChieuDAL.GetAll();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSuatChieu");
            dt.Columns.Add("TenPhim");
            dt.Columns.Add("TenPhong");
            dt.Columns.Add("NgayChieu");
            dt.Columns.Add("GioChieu");
            dt.Columns.Add("GiaVe");
            
            dt.Rows.Add(1, "Avatar 2", "Phòng 1", "2025-12-25", "19:00", 150000);
            dgvSuatChieu.DataSource = dt;
        }

        void LoadCombo()
        {
            // cboPhim.DataSource = SuatChieuDAL.GetPhim();
            // cboPhim.DisplayMember = "TenPhim";
            // cboPhim.ValueMember = "MaPhim";
            DataTable dtPhim = new DataTable();
            dtPhim.Columns.Add("MaPhim", typeof(int));
            dtPhim.Columns.Add("TenPhim");
            dtPhim.Rows.Add(1, "Avatar 2");
            cboPhim.DataSource = dtPhim;
            cboPhim.DisplayMember = "TenPhim";
            cboPhim.ValueMember = "MaPhim";

            // cboPhong.DataSource = SuatChieuDAL.GetPhong();
            // cboPhong.DisplayMember = "TenPhong";
            // cboPhong.ValueMember = "MaPhong";
             DataTable dtPhong = new DataTable();
            dtPhong.Columns.Add("MaPhong", typeof(int));
            dtPhong.Columns.Add("TenPhong");
            dtPhong.Columns.Add("SoGhe");
            dtPhong.Rows.Add(1, "Phòng 1", 100);
            cboPhong.DataSource = dtPhong;
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue is int)
            {
                DataRowView row = cboPhong.SelectedItem as DataRowView;
                if (row != null && row.DataView.Table.Columns.Contains("SoGhe"))
                    soGhePhong = Convert.ToInt32(row["SoGhe"]);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // SuatChieuDAL.Insert(...);
            MessageBox.Show("Chức năng đang bảo trì (Demo)");
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // SuatChieuDAL.Update(...);
            MessageBox.Show("Chức năng đang bảo trì (Demo)");
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // SuatChieuDAL.Delete(maSC);
            MessageBox.Show("Chức năng đang bảo trì (Demo)");
            LoadData();
        }

        private void dgvSuatChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                maSC = Convert.ToInt32(dgvSuatChieu.Rows[e.RowIndex].Cells["MaSuatChieu"].Value);
                txtGiaVe.Text = dgvSuatChieu.Rows[e.RowIndex].Cells["GiaVe"].Value.ToString();
            }
        }
    }
}
