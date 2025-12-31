using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ProjectCinema.BUS;

namespace ProjectCinema.GUI
{
    public partial class frmDashBoard : MaterialForm
    {
        private DashboardBUS _dashboardBUS;
        private Panel pnlSidebar, pnlMain, pnlKPI;
        private Button btnToggleSidebar;
        private Label lblWelcome, lblDoanhThu, lblSoVe, lblSuatChieu, lblPhim;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private bool _sidebarExpanded = true;
        private Timer _toggleTimer;

        public frmDashBoard()
        {
            InitializeComponent();
            _dashboardBUS = new DashboardBUS();
            
            this.Text = "Dashboard - Quản Lý Rạp Chiếu Phim";
            this.Size = new System.Drawing.Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.IsMdiContainer = true; // Bật chế độ MDI
            
            InitializeSidebar();
            InitializeMainContent();
            
            // Sửa Z-Order cho Docking
            // Sidebar phải ở phía Sau để được xử lý trước (chiếm cạnh Trái)
            // Nội dung chính phải ở phía Trước để lấp đầy không gian *còn lại*
            pnlSidebar.SendToBack();
            pnlMain.BringToFront();

            LoadDashboardData();
        }

        private void InitializeSidebar()
        {
            // Panel Sidebar
            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = System.Drawing.Color.FromArgb(84, 110, 122)
            };

            // Nút bật/tắt
            btnToggleSidebar = new Button
            {
                Location = new System.Drawing.Point(10, 80),
                Size = new System.Drawing.Size(180, 40),
                Text = "☰ MENU",
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(69, 90, 100),
                ForeColor = System.Drawing.Color.White,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            btnToggleSidebar.FlatAppearance.BorderSize = 0;
            btnToggleSidebar.Click += BtnToggleSidebar_Click;

            // Các mục menu
            var yPos = 140;
            var btnDashboard = CreateMenuButton("🏠", "Dashboard", yPos);
            btnDashboard.Click += (s, e) => ShowDashboardHome();
            
            var btnPhim = CreateMenuButton("🎬", "Quản lý Phim", yPos += 60);
            btnPhim.Click += (s, e) => OpenChildForm(new frmQuanLyPhim());

            var btnPhong = CreateMenuButton("💺", "Phòng chiếu", yPos += 60);
            btnPhong.Click += (s, e) => 
            {
                if (Session.CurrentEmployee != null && (Session.CurrentEmployee.ChucVu == "Quản lý" || Session.CurrentEmployee.ChucVu == "Admin"))
                {
                    OpenChildForm(new frmQuanLyPhongChieu());
                }
                else
                {
                    CustomMessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            
            var btnSuatChieu = CreateMenuButton("📅", "Suất chiếu", yPos += 60);
            btnSuatChieu.Click += (s, e) => OpenChildForm(new frmQuanLySuatChieu());
            
            var btnBanVe = CreateMenuButton("🎫", "Bán vé", yPos += 60);
            btnBanVe.Click += (s, e) => OpenChildForm(new frmBanVe());
            
            var btnNhanVien = CreateMenuButton("👥", "Nhân viên", yPos += 60);
            btnNhanVien.Click += (s, e) => 
            {
                if (Session.CurrentEmployee != null && (Session.CurrentEmployee.ChucVu == "Quản lý" || Session.CurrentEmployee.ChucVu == "Admin"))
                {
                    OpenChildForm(new frmQuanLyNhanVien());
                }
                else
                {
                    CustomMessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            
            var btnBaoCao = CreateMenuButton("📊", "Báo cáo", yPos += 60);
            btnBaoCao.Click += (s, e) => OpenChildForm(new frmBaoCao());

            // Nút đăng xuất ở dưới cùng
            var btnLogout = new Button
            {
                Location = new System.Drawing.Point(10, 600),
                Size = new System.Drawing.Size(180, 40),
                Text = "🚪 Đăng xuất",
                Font = new System.Drawing.Font("Segoe UI", 10F),
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(229, 115, 115),
                ForeColor = System.Drawing.Color.White,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += BtnLogout_Click;

            pnlSidebar.Controls.Add(btnToggleSidebar);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(btnPhim);
            pnlSidebar.Controls.Add(btnPhong); // Added this line
            pnlSidebar.Controls.Add(btnSuatChieu);
            pnlSidebar.Controls.Add(btnBanVe);
            pnlSidebar.Controls.Add(btnNhanVien);
            pnlSidebar.Controls.Add(btnBaoCao);
            pnlSidebar.Controls.Add(btnLogout);
            
            this.Controls.Add(pnlSidebar);
        }

        private Button CreateMenuButton(string icon, string text, int yPos)
        {
            var btn = new Button
            {
                Location = new System.Drawing.Point(0, yPos),
                Size = new System.Drawing.Size(200, 50),
                Text = $"{icon}  {text}",
                Font = new System.Drawing.Font("Segoe UI", 11F),
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(84, 110, 122),
                ForeColor = System.Drawing.Color.White,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = System.Drawing.Color.FromArgb(69, 90, 100);
            btn.MouseLeave += (s, e) => btn.BackColor = System.Drawing.Color.FromArgb(84, 110, 122);
            return btn;
        }

        private void InitializeMainContent()
        {
            // Panel nội dung chính
            pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            };

            // Container Chào mừng + KPI
            pnlKPI = new Panel
            {
                Location = new System.Drawing.Point(20, 80),
                Size = new System.Drawing.Size(940, 200),
                BackColor = System.Drawing.Color.White
            };

            // Text Chào mừng
            lblWelcome = new Label
            {
                Location = new System.Drawing.Point(20, 15),
                Size = new System.Drawing.Size(600, 30),
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(84, 110, 122),
                Text = Session.CurrentEmployee != null 
                    ? $"Xin chào, {Session.CurrentEmployee.HoTen}" 
                    : "Xin chào"
            };
            pnlKPI.Controls.Add(lblWelcome);

            // KPI Cards
            CreateKPICard("Tổng doanh thu", "0 VNĐ", 20, 60, out lblDoanhThu, System.Drawing.Color.FromArgb(102, 187, 106));
            CreateKPICard("Tổng vé bán", "0", 250, 60, out lblSoVe, System.Drawing.Color.FromArgb(66, 165, 245));
            CreateKPICard("Tổng suất chiếu", "0", 480, 60, out lblSuatChieu, System.Drawing.Color.FromArgb(255, 167, 38));
            CreateKPICard("Tổng phim", "0", 710, 60, out lblPhim, System.Drawing.Color.FromArgb(171, 71, 188));

            pnlMain.Controls.Add(pnlKPI);

            // Chart Doanh Thu
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartRevenue.Location = new System.Drawing.Point(20, 300);
            chartRevenue.Size = new System.Drawing.Size(940, 350);
            chartRevenue.BackColor = System.Drawing.Color.White;
            
            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.AxisX.Title = "Ngày";
            chartArea.AxisY.Title = "Doanh thu (VNĐ)";
            chartRevenue.ChartAreas.Add(chartArea);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series();
            series.Name = "DoanhThu";
            series.Color = System.Drawing.Color.FromArgb(66, 165, 245);
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            chartRevenue.Series.Add(series);

            var title = new System.Windows.Forms.DataVisualization.Charting.Title();
            title.Text = "DOANH THU 7 NGÀY GẦN NHẤT";
            title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            title.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            chartRevenue.Titles.Add(title);
            
            pnlMain.Controls.Add(chartRevenue);

            this.Controls.Add(pnlMain);
        }

        private void CreateKPICard(string title, string defaultValue, int x, int y, out Label valueLabel, System.Drawing.Color color)
        {
            var panel = new Panel
            {
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(220, 120),
                BackColor = color
            };

            var lblTitle = new Label
            {
                Location = new System.Drawing.Point(15, 15),
                Size = new System.Drawing.Size(190, 40),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Text = title
            };

            valueLabel = new Label
            {
                Location = new System.Drawing.Point(15, 60),
                Size = new System.Drawing.Size(190, 50),
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Text = defaultValue
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(valueLabel);
            pnlKPI.Controls.Add(panel);
        }

        private void OpenChildForm(Form childForm)
        {
            if (pnlMain.Controls.Count > 0)
                pnlMain.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ShowDashboardHome()
        {
            if (pnlMain.Controls.Count > 0)
                pnlMain.Controls.Clear();
            
            pnlMain.Controls.Add(pnlKPI);
            LoadDashboardData();
        }

        private void BtnToggleSidebar_Click(object sender, EventArgs e)
        {
            if (_toggleTimer != null && _toggleTimer.Enabled)
                return;

            _toggleTimer = new Timer { Interval = 10 };
            int targetWidth = _sidebarExpanded ? 60 : 200;
            int step = _sidebarExpanded ? -10 : 10;

            _toggleTimer.Tick += (s, ev) =>
            {
                pnlSidebar.Width += step;
                
                if ((_sidebarExpanded && pnlSidebar.Width <= targetWidth) ||
                    (!_sidebarExpanded && pnlSidebar.Width >= targetWidth))
                {
                    pnlSidebar.Width = targetWidth;
                    _toggleTimer.Stop();
                    _sidebarExpanded = !_sidebarExpanded;
                    
                    // Cập nhật văn bản nút
                    btnToggleSidebar.Text = _sidebarExpanded ? "☰ MENU" : "☰";
                }
            };
            _toggleTimer.Start();
        }

        private void LoadDashboardData()
        {
            try
            {
                var summary = _dashboardBUS.GetDashboardSummary();
                
                lblDoanhThu.Text = string.Format("{0:N0} VNĐ", summary.TodayRevenue);
                lblSoVe.Text = summary.TodayTicketCount.ToString();
                lblSuatChieu.Text = summary.ActiveShowtimesCount.ToString();
                lblSuatChieu.Text = summary.ActiveShowtimesCount.ToString();
                lblPhim.Text = summary.ActiveMoviesCount.ToString();

                // Load Chart
                var revenueData = _dashboardBUS.GetRevenueLast7Days();
                chartRevenue.Series["DoanhThu"].Points.Clear();
                foreach(var item in revenueData)
                {
                   chartRevenue.Series["DoanhThu"].Points.AddXY(item.Key.ToString("dd/MM"), item.Value);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi khi tải dữ liệu Dashboard: " + ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Session.CurrentEmployee = null;
                this.Close();
                var frmLogin = new frmDangNhap();
                frmLogin.Show();
            }
        }
    }
}
