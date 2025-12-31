using System;
using System.Drawing;
using System.Windows.Forms;
using ProjectCinema.BUS;
using ProjectCinema.DAL.Models;

namespace ProjectCinema.GUI
{
    public partial class frmQuanLyPhim : Form
    {
        private PhimBUS _phimBUS;
        private DataGridView dgvPhim;
        private TextBox txtSearch;
        private TextBox txtTenPhim;
        private TextBox txtThoiLuong;
        private ComboBox cboDinhDang;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lblId;
        private PictureBox pbAnhBia;
        private Button btnChonAnh;
        private string currentImagePath = ""; // Lưu đường dẫn ảnh hiện tại

        private Color PrimaryColor = Color.FromArgb(84, 110, 122); // BlueGrey 600
        private Color DarkPrimaryColor = Color.FromArgb(69, 90, 100); // BlueGrey 700

        public frmQuanLyPhim()
        {
            InitializeComponent();
            SetupUI();
            _phimBUS = new PhimBUS();
            LoadData();
        }

        private void SetupUI()
        {
            this.Text = "Quản Lý Phim";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // Panel Tiêu đề
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(84, 110, 122)
            };
            Label lblHeader = new Label
            {
                Text = "QUẢN LÝ DANH SÁCH PHIM",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            pnlHeader.Controls.Add(lblHeader);

            // Panel Tìm kiếm
            Panel pnlSearch = new Panel
            {
                Location = new Point(20, 80),
                Size = new Size(950, 50),
                BackColor = Color.White
            };
            txtSearch = new TextBox
            {
                Size = new Size(300, 30),
                Location = new Point(10, 12),
                Font = new Font("Segoe UI", 10F)
            };
            Button btnSearch = CreateButton("Tìm kiếm", new Point(320, 8), Color.FromArgb(84, 110, 122));
            btnSearch.Click += BtnSearch_Click;
            btnRefresh = CreateButton("Làm mới", new Point(440, 8), Color.Gray);
            btnRefresh.Click += (s, e) => { LoadData(); ResetForm(); };

            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnRefresh);

            // Panel Nhập liệu (Bên phải)
            Panel pnlInput = new Panel
            {
                Location = new Point(620, 150),
                Size = new Size(350, 420),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            SetupInputPanel(pnlInput);

            // DataGridView (Bên trái)
            dgvPhim = new DataGridView
            {
                Location = new Point(20, 150),
                Size = new Size(580, 500),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 10F),
                AutoGenerateColumns = false
            };
            dgvPhim.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 110, 122);
            dgvPhim.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhim.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPhim.EnableHeadersVisualStyles = false;
            dgvPhim.SelectionChanged += DgvPhim_SelectionChanged;

            // Thêm cột thủ công
            dgvPhim.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPhim", DataPropertyName = "MaPhim", HeaderText = "Mã", Width = 50 });
            dgvPhim.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenPhim", DataPropertyName = "TenPhim", HeaderText = "Tên Phim" });
            dgvPhim.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThoiLuong", DataPropertyName = "ThoiLuong", HeaderText = "Thời lượng(phút)" });
            dgvPhim.Columns.Add(new DataGridViewTextBoxColumn { Name = "DinhDang", DataPropertyName = "DinhDang", HeaderText = "Định dạng" });

            // Thêm các điều khiển
            this.Controls.Add(dgvPhim);
            this.Controls.Add(pnlInput);
            this.Controls.Add(pnlSearch);
            this.Controls.Add(pnlHeader);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetupInputPanel(Panel pnl)
        {
            Label lblTitle = new Label { Text = "THÔNG TIN PHIM", Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = PrimaryColor, Location = new Point(10, 10), AutoSize = true };
            
            lblId = new Label { Text = "ID: ", Location = new Point(10, 40), Visible = false };

            Label lblName = new Label { Text = "Tên phim (*):", Location = new Point(10, 50), AutoSize = true };
            txtTenPhim = new TextBox { Location = new Point(10, 75), Size = new Size(340, 30), Font = new Font("Segoe UI", 10F) };

            Label lblDuration = new Label { Text = "Thời lượng (phút) (*):", Location = new Point(10, 120), AutoSize = true };
            txtThoiLuong = new TextBox { Location = new Point(10, 145), Size = new Size(340, 30), Font = new Font("Segoe UI", 10F) };
            txtThoiLuong.KeyPress += (s, e) => e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            Label lblFormat = new Label { Text = "Định dạng:", Location = new Point(10, 190), AutoSize = true };
            cboDinhDang = new ComboBox { Location = new Point(10, 215), Size = new Size(340, 30), Font = new Font("Segoe UI", 10F), DropDownStyle = ComboBoxStyle.DropDownList };
            cboDinhDang.Items.AddRange(new string[] { "2D", "3D", "IMAX" });
            cboDinhDang.SelectedIndex = 0;

            // Ảnh bìa
            Label lblAnh = new Label { Text = "Ảnh bìa:", Location = new Point(10, 260), AutoSize = true };
            pbAnhBia = new PictureBox { Location = new Point(10, 285), Size = new Size(100, 140), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            btnChonAnh = CreateButton("Chọn ảnh", new Point(120, 285), Color.Gray);
            btnChonAnh.Click += BtnChonAnh_Click;

            // Buttons adjust position
            int btnY = 440; // Shift down
            // Resize Panel
            pnl.Height = 500; 

            btnAdd = CreateButton("Thêm", new Point(10, 440), Color.FromArgb(84, 110, 122));
            btnAdd.Size = new Size(100, 40);
            btnAdd.Click += BtnAdd_Click;

            btnEdit = CreateButton("Sửa", new Point(130, 440), Color.Orange);
            btnEdit.Size = new Size(100, 40);
            btnEdit.Click += BtnEdit_Click;

            btnDelete = CreateButton("Xóa", new Point(250, 440), Color.Red);
            btnDelete.Size = new Size(100, 40);
            btnDelete.Click += BtnDelete_Click;

            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblId);
            pnl.Controls.Add(lblName);
            pnl.Controls.Add(txtTenPhim);
            pnl.Controls.Add(lblDuration);
            pnl.Controls.Add(txtThoiLuong);
            pnl.Controls.Add(lblFormat);
            pnl.Controls.Add(cboDinhDang);
            pnl.Controls.Add(lblAnh);
            pnl.Controls.Add(pbAnhBia);
            pnl.Controls.Add(btnChonAnh);
            pnl.Controls.Add(btnAdd);
            pnl.Controls.Add(btnEdit);
            pnl.Controls.Add(btnDelete);
        }

        private Button CreateButton(string text, Point loc, Color bg)
        {
            var btn = new Button
            {
                Text = text,
                Location = loc,
                Size = new Size(100, 35),
                BackColor = bg,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void LoadData()
        {
            dgvPhim.DataSource = null;
            dgvPhim.DataSource = _phimBUS.GetAllPhim();
        }

        /* Cấu hình Grid đã bị loại bỏ vì các cột được định nghĩa thủ công */

        private void ResetForm()
        {
            lblId.Text = "";
            txtTenPhim.Clear();
            txtThoiLuong.Clear();
            cboDinhDang.SelectedIndex = 0;
            currentImagePath = "";
            pbAnhBia.Image = null;
            txtTenPhim.Focus();
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbAnhBia.Image = Image.FromFile(dialog.FileName);
                currentImagePath = dialog.FileName; // Tạm lưu đường dẫn gốc
            }
        }

        private string SaveImage(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath)) return null;
            if (!System.IO.File.Exists(sourcePath)) return sourcePath; // Nếu đã là đường dẫn trong hệ thống

            string destFolder = System.IO.Path.Combine(Application.StartupPath, "Images", "Posters");
            if (!System.IO.Directory.Exists(destFolder))
            {
                System.IO.Directory.CreateDirectory(destFolder);
            }

            string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(sourcePath);
            string destPath = System.IO.Path.Combine(destFolder, fileName);
            
            System.IO.File.Copy(sourcePath, destPath, true);
            return "Images/Posters/" + fileName; // Lưu đường dẫn tương đối
        }

        private void DgvPhim_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhim.SelectedRows.Count > 0)
            {
                var row = dgvPhim.SelectedRows[0];
                lblId.Text = row.Cells["MaPhim"].Value.ToString();
                txtTenPhim.Text = row.Cells["TenPhim"].Value.ToString();
                txtThoiLuong.Text = row.Cells["ThoiLuong"].Value.ToString();
                cboDinhDang.Text = row.Cells["DinhDang"].Value?.ToString();

                // Load Image
                var phim = _phimBUS.GetPhimById(int.Parse(lblId.Text));
                if (phim != null && !string.IsNullOrEmpty(phim.AnhBia))
                {
                    string fullPath = System.IO.Path.Combine(Application.StartupPath, phim.AnhBia);
                    if (System.IO.File.Exists(fullPath))
                    {
                        pbAnhBia.Image = Image.FromFile(fullPath);
                        currentImagePath = fullPath;
                    }
                    else
                    {
                        pbAnhBia.Image = null;
                        currentImagePath = "";
                    }
                }
                else
                {
                    pbAnhBia.Image = null;
                    currentImagePath = "";
                }
            }
        }
        
        // Search Click stays same...
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                dgvPhim.DataSource = _phimBUS.SearchPhim(keyword);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try 
            {
                if(string.IsNullOrWhiteSpace(txtThoiLuong.Text)) throw new Exception("Vui lòng nhập thời lượng");
                
                string savedPath = SaveImage(currentImagePath);

                Phim p = new Phim
                {
                    TenPhim = txtTenPhim.Text.Trim(),
                    ThoiLuong = int.Parse(txtThoiLuong.Text),
                    DinhDang = cboDinhDang.Text,
                    AnhBia = savedPath
                };

                if (_phimBUS.AddPhim(p))
                {
                    CustomMessageBox.Show("Thêm phim thành công!", "Thành công", MessageBoxIcon.Information);
                    LoadData();
                    ResetForm();
                }
            }
            catch(Exception ex)
            {
                CustomMessageBox.Show(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(lblId.Text)) { CustomMessageBox.Show("Vui lòng chọn phim để sửa", "Cảnh báo", MessageBoxIcon.Warning); return; }

            try
            {
                // Logic ảnh: Nếu user chọn ảnh mới (currentImagePath khác đường dẫn cũ trong DB) -> Save mới
                // Đơn giản hóa: Cứ save lại nếu currentImagePath có giá trị
                 string savedPath = null;
                 // Lấy phim cũ để xem path cũ
                 var oldPhim = _phimBUS.GetPhimById(int.Parse(lblId.Text));
                 
                 // Nếu currentImagePath chứa "Images/Posters" nghĩa là chưa đổi, giữ nguyên
                 // Nếu là path tuyệt đối từ ổ đĩa khác -> SaveImage
                 if (!string.IsNullOrEmpty(currentImagePath) && !currentImagePath.Contains("Images\\Posters") && !currentImagePath.Contains("Images/Posters"))
                 {
                     savedPath = SaveImage(currentImagePath);
                 }
                 else
                 {
                     savedPath = oldPhim.AnhBia; // Giữ nguyên
                 }

                Phim p = new Phim
                {
                    MaPhim = int.Parse(lblId.Text),
                    TenPhim = txtTenPhim.Text.Trim(),
                    ThoiLuong = int.Parse(txtThoiLuong.Text),
                    DinhDang = cboDinhDang.Text,
                    AnhBia = savedPath
                };

                if (_phimBUS.UpdatePhim(p))
                {
                    CustomMessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxIcon.Information);
                    LoadData();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }
    
        // Delete Click stays same...
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblId.Text)) { CustomMessageBox.Show("Vui lòng chọn phim để xóa", "Cảnh báo", MessageBoxIcon.Warning); return; }

            var result = CustomMessageBox.Show("Bạn có chắc muốn xóa phim này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(lblId.Text);
                    if (_phimBUS.DeletePhim(id))
                    {
                        CustomMessageBox.Show("Xóa thành công!", "Thành công", MessageBoxIcon.Information);
                        LoadData();
                        ResetForm();
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxIcon.Error);
                }
            }
        }
    }
}
