using System;
using System.Data;
using System.Windows.Forms;
using QLRP.DAL;

namespace QLRP.GUI
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
            dgvSuatChieu.DataSource = SuatChieuDAL.GetAll();
        }

        void LoadCombo()
        {
            cboPhim.DataSource = SuatChieuDAL.GetPhim();
            cboPhim.DisplayMember = "TenPhim";
            cboPhim.ValueMember = "MaPhim";

            cboPhong.DataSource = SuatChieuDAL.GetPhong();
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue is int)
            {
                DataRowView row = cboPhong.SelectedItem as DataRowView;
                soGhePhong = Convert.ToInt32(row["SoGhe"]);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SuatChieuDAL.Insert(
                (int)cboPhim.SelectedValue,
                (int)cboPhong.SelectedValue,
                dtpNgay.Value.ToString("yyyy-MM-dd"),
                dtpGio.Value.ToString("HH:mm"),
                decimal.Parse(txtGiaVe.Text),
                soGhePhong
            );
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maSC < 0) return;

            SuatChieuDAL.Update(
                maSC,
                (int)cboPhim.SelectedValue,
                (int)cboPhong.SelectedValue,
                dtpNgay.Value.ToString("yyyy-MM-dd"),
                dtpGio.Value.ToString("HH:mm"),
                decimal.Parse(txtGiaVe.Text)
            );
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maSC < 0) return;
            SuatChieuDAL.Delete(maSC);
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
