using System;
using System.Windows.Forms;
using ProjectCinema.BUS;

namespace ProjectCinema.GUI
{
    using MaterialSkin;
    using MaterialSkin.Controls;

    public partial class frmDangNhap : MaterialForm
    {
        private readonly AuthenticationBUS _authBUS;

        public frmDangNhap()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey600, Primary.BlueGrey700, Primary.BlueGrey200, Accent.LightBlue200, TextShade.WHITE);

            _authBUS = new AuthenticationBUS();
            
            this.FormClosing += FrmDangNhap_FormClosing;
            
             if (!string.IsNullOrEmpty(Properties.Settings.Default.RememberedUsername))
             {
                txtTaiKhoan.Text = Properties.Settings.Default.RememberedUsername;
                chkGhiNho.Checked = true;
                this.ActiveControl = txtMatKhau;
             }
        }



        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            try
            {
                var employee = _authBUS.ValidateCredentials(username, password);
                if (employee != null)
                {
                    // Cập nhật Session (giả sử lớp Session tĩnh tồn tại, sẽ triển khai tiếp theo)
                    Session.CurrentEmployee = employee;

                     if (chkGhiNho.Checked)
                     {
                         Properties.Settings.Default.RememberedUsername = username;
                     }
                     else
                     {
                         Properties.Settings.Default.RememberedUsername = "";
                     }
                     Properties.Settings.Default.Save();

                    CustomMessageBox.Show("Đăng nhập thành công! Xin chào " + employee.HoTen, "Thông báo", MessageBoxIcon.Information);
                    
                    var frmDashBoard = new frmDashBoard();
                    frmDashBoard.Show();
                    this.Hide();
                }
                else
                {
                    ShowError("Tài khoản hoặc mật khẩu không chính xác.");
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu người dùng chủ động đóng form đăng nhập, thoát ứng dụng
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
