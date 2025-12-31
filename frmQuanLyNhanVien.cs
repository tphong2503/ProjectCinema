using ProjectCinema.BUS;
using ProjectCinema.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectCinema.GUI
{
    public partial class frmQuanLyNhanVien : Form
    {
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();
        
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxChucVu();
            ResetInput();
        }

        private void LoadData()
        {
            dgvNhanVien.DataSource = nhanVienBUS.GetAllNhanVien()
                .Select(nv => new {
                    nv.MaNV,
                    nv.HoTen,
                    nv.TaiKhoan,
                    nv.ChucVu,
                    SoHoaDon = nv.HoaDons != null ? nv.HoaDons.Count : 0
                }).ToList();
        }

        private void LoadComboBoxChucVu()
        {
            cboChucVu.Items.Clear();
            cboChucVu.Items.Add("Quản lý");
            cboChucVu.Items.Add("Nhân viên");
            cboChucVu.SelectedIndex = 1; // Default "Nhân viên"
        }

        private void ResetInput()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cboChucVu.SelectedIndex = 1;
            
            txtTaiKhoan.ReadOnly = false;
            txtMatKhau.Enabled = true;
            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnDoiMatKhau.Enabled = false;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtTaiKhoan.Text = row.Cells["TaiKhoan"].Value.ToString();
                if (row.Cells["ChucVu"].Value != null)
                {
                    cboChucVu.SelectedItem = row.Cells["ChucVu"].Value.ToString();
                }

                // Edit/Delete mode
                txtTaiKhoan.ReadOnly = true; 
                txtMatKhau.Text = ""; // Don't show password
                txtMatKhau.Enabled = false; // Disable password field in update mode (use Change Password button instead)
                
                btnThem.Enabled = false;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnDoiMatKhau.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string error = "";
            NhanVien nv = new NhanVien()
            {
                HoTen = txtHoTen.Text.Trim(),
                TaiKhoan = txtTaiKhoan.Text.Trim(),
                MatKhau = txtMatKhau.Text,
                ChucVu = cboChucVu.SelectedItem.ToString()
            };

            if (nhanVienBUS.AddNhanVien(nv, ref error))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetInput();
            }
            else
            {
                MessageBox.Show("Thêm thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text)) return;

            string error = "";
            int maNV = int.Parse(txtMaNV.Text);
            NhanVien nv = new NhanVien()
            {
                MaNV = maNV,
                HoTen = txtHoTen.Text.Trim(),
                ChucVu = cboChucVu.SelectedItem.ToString()
            };

            if (nhanVienBUS.UpdateNhanVien(nv, ref error))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetInput();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string error = "";
                int maNV = int.Parse(txtMaNV.Text);

                if (nhanVienBUS.DeleteNhanVien(maNV, ref error))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text)) return;

            // Simple input dialog for new password (or enable the textbox temporarily)
            // For simplicity, let's enable the password box and change button text
            if (btnDoiMatKhau.Text == "Đổi mật khẩu")
            {
                txtMatKhau.Enabled = true;
                txtMatKhau.Focus();
                btnDoiMatKhau.Text = "Lưu mật khẩu";
                MessageBox.Show("Vui lòng nhập mật khẩu mới vào ô Mật khẩu và nhấn 'Lưu mật khẩu'", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string newPass = txtMatKhau.Text;
                string error = "";
                int maNV = int.Parse(txtMaNV.Text);

                if (nhanVienBUS.ChangePassword(maNV, newPass, ref error))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDoiMatKhau.Text = "Đổi mật khẩu";
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvNhanVien.DataSource = nhanVienBUS.SearchNhanVien(keyword)
                .Select(nv => new {
                    nv.MaNV,
                    nv.HoTen,
                    nv.TaiKhoan,
                    nv.ChucVu,
                    SoHoaDon = nv.HoaDons != null ? nv.HoaDons.Count : 0
                }).ToList();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            LoadData();
            ResetInput();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
