using System;
using System.Linq;
using System.Windows.Forms;
using ProjectCinema.BUS;
using ProjectCinema.DAL.Models;

namespace ProjectCinema.GUI
{
    public partial class frmQuanLyPhongChieu : Form
    {
        private PhongChieuBUS _bus;

        public frmQuanLyPhongChieu()
        {
            InitializeComponent();
            _bus = new PhongChieuBUS();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _bus.GetAllPhongChieu();
                dgvPhongChieu.DataSource = list.Select(p => new
                {
                    p.MaPhong,
                    p.TenPhong,
                    p.SoLuongGhe
                }).ToList();

                // Format Headers
                if (dgvPhongChieu.Columns["MaPhong"] != null) dgvPhongChieu.Columns["MaPhong"].HeaderText = "Mã Phòng";
                if (dgvPhongChieu.Columns["TenPhong"] != null) dgvPhongChieu.Columns["TenPhong"].HeaderText = "Tên Phòng";
                if (dgvPhongChieu.Columns["SoLuongGhe"] != null) dgvPhongChieu.Columns["SoLuongGhe"].HeaderText = "Số Lượng Ghế";
                
                // Clear bindings
                ResetInput();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void ResetInput()
        {
            txtTenPhong.Clear();
            nudSoLuongGhe.Value = 0;
            txtTenPhong.Focus();
            
            // Enable/Disable buttons
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            nudSoLuongGhe.Enabled = true; // Enable for Add
            dgvPhongChieu.ClearSelection();
        }

        private void dgvPhongChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPhongChieu.Rows[e.RowIndex];
                txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString();
                if (row.Cells["SoLuongGhe"].Value != null)
                    nudSoLuongGhe.Value = Convert.ToDecimal(row.Cells["SoLuongGhe"].Value);

                // Validation: Cannot change seat count on update
                nudSoLuongGhe.Enabled = false; 

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                
                // Store ID in Tag or use Grid selection
                txtTenPhong.Tag = row.Cells["MaPhong"].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var room = new PhongChieu
                {
                    TenPhong = txtTenPhong.Text.Trim(),
                    SoLuongGhe = (int)nudSoLuongGhe.Value
                };

                if (_bus.AddPhongChieu(room))
                {
                    CustomMessageBox.Show("Thêm phòng chiếu thành công! Dữ liệu ghế đã được tạo tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenPhong.Tag == null) return;
            try
            {
                int id = Convert.ToInt32(txtTenPhong.Tag);
                var room = new PhongChieu
                {
                    MaPhong = id,
                    TenPhong = txtTenPhong.Text.Trim()
                };

                if (CustomMessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin phòng không? (Số lượng ghế sẽ không đổi)", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_bus.UpdatePhongChieu(room))
                    {
                        CustomMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        CustomMessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTenPhong.Tag == null) return;
            try
            {
                int id = Convert.ToInt32(txtTenPhong.Tag);
                
                if (CustomMessageBox.Show("Bạn có chắc chắn muốn xóa phòng này? Tất cả ghế và dữ liệu liên quan sẽ bị xóa vĩnh viễn!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_bus.DeletePhongChieu(id))
                    {
                        CustomMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Không thể xóa: " + ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetInput();
            LoadData(); // Reload to refresh grid
        }
    }
}
