using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLRP
{
    public partial class frmQLPhim : Form
    {
        public frmQLPhim()
        {
            InitializeComponent();
        }

        private void frmQLPhim_Load(object sender, EventArgs e)
        {
            NapDuLieuMau();
        }

        private void NapDuLieuMau()
        {
            // Tạo bảng tạm để hiển thị lên dgvPhim
            DataTable dt = new DataTable();
            dt.Columns.Add("MaPhim");
            dt.Columns.Add("TenPhim");
            dt.Columns.Add("TheLoai");

            dt.Rows.Add("P01", "Avatar: The Way of Water", "Hành động");
            dt.Rows.Add("P02", "Oppenheimer", "Chính kịch");
            dt.Rows.Add("P03", "Bố Già", "Tâm lý");

            dgvPhim.DataSource = dt;
        }

        private void dgvPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhim.Rows[e.RowIndex];
                txtTenPhim.Text = row.Cells["TenPhim"].Value.ToString();
            }
        }

        private void btnChonPhim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenPhim.Text))
            {
                MessageBox.Show("Vui lòng chọn một bộ phim từ danh sách!");
                return;
            }

            // Mở Form Ghế và truyền tên phim sang
            frmQLGhe fGhe = new frmQLGhe(txtTenPhim.Text);
            this.Hide();
            fGhe.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}