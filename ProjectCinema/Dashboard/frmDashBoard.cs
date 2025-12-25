using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ProjectCinema.Modals;

namespace ProjectCinema
{
    public partial class frmDashBoard : Form
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly DashBoard db = new DashBoard();

        public frmDashBoard()
        {
            InitializeComponent();
            
            // Initialize MaterialSkin
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey900,
                Primary.BlueGrey800,
                Primary.Blue400,
                Accent.Purple400,
                TextShade.WHITE
            );
            
            this.BackColor = Color.FromArgb(11, 14, 20);
            this.ForeColor = Color.White;
            
            SetupDashboard();
        }

        private void SetupDashboard()
        {
            // Style DGV
            dgvUpcomingShows.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 35, 45);
            dgvUpcomingShows.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUpcomingShows.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvUpcomingShows.EnableHeadersVisualStyles = false;
            
            dgvUpcomingShows.DefaultCellStyle.BackColor = Color.FromArgb(19, 23, 32);
            dgvUpcomingShows.DefaultCellStyle.ForeColor = Color.White;
            dgvUpcomingShows.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 107, 254);
            dgvUpcomingShows.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUpcomingShows.GridColor = Color.FromArgb(30, 35, 45);

            // Chart Paint Event
            pnlChart.Paint += PnlChart_Paint;
        }

        private void LoadDashboardData()
        {
            try
            {
                var today = DateTime.Today;

                // 1. Doanh thu hôm nay
                var revenueToday = db.HoaDons
                    .Where(h => h.NgayLap.HasValue && DbFunctions.TruncateTime(h.NgayLap.Value) == today)
                    .Sum(h => (decimal?)h.ThanhTien) ?? 0;
                cardRevenue.Value = revenueToday.ToString("N0") + " đ";

                // 2. Suất chiếu còn lại (sắp tới trong hôm nay)
                var currentTime = DateTime.Now.TimeOfDay;
                var pendingShows = db.SuatChieux
                    .Count(s => s.NgayChieu == today && s.GioChieu > currentTime);
                var totalShowsToday = db.SuatChieux.Count(s => s.NgayChieu == today);
                cardShows.Value = pendingShows.ToString();
                cardShows.SubValue = $"Trong tổng số {totalShowsToday} suất hôm nay";

                // 3. Tỷ lệ lấp đầy
                var totalTicketsToday = db.Ves
                    .Count(v => v.SuatChieu.NgayChieu == today);
                var totalCapacityToday = db.SuatChieux
                    .Where(s => s.NgayChieu == today)
                    .Sum(s => (int?)s.PhongChieu.SoGhe) ?? 1; // Tránh chia cho 0
                
                double fillingRate = (double)totalTicketsToday / Math.Max(1, totalCapacityToday) * 100;
                cardFillingRate.Value = fillingRate.ToString("F0") + "%";

                // 4. Load suất chiếu sắp tới vào Grid
                var upcomingShowsRaw = db.SuatChieux
                    .Where(s => s.NgayChieu >= today)
                    .OrderBy(s => s.NgayChieu).ThenBy(s => s.GioChieu)
                    .Take(10)
                    .Select(s => new {
                        RawTime = s.GioChieu,
                        Movie = s.Phim.TenPhim,
                        Room = s.PhongChieu.TenPhong,
                        SoldTickets = s.Ves.Count,
                        TotalSeats = s.PhongChieu.SoGhe,
                        Status = s.TrangThai
                    }).ToList();

                var upcomingShowsList = upcomingShowsRaw.Select(s => new {
                    Time = s.RawTime.ToString(@"hh\:mm"),
                    Movie = s.Movie,
                    Room = s.Room,
                    Sold = s.SoldTickets + " / " + s.TotalSeats,
                    Status = s.Status
                }).ToList();

                dgvUpcomingShows.DataSource = upcomingShowsList;
                if (dgvUpcomingShows.Columns.Count > 0)
                {
                    dgvUpcomingShows.Columns["Time"].HeaderText = "THỜI GIAN";
                    dgvUpcomingShows.Columns["Movie"].HeaderText = "PHIM";
                    dgvUpcomingShows.Columns["Room"].HeaderText = "PHÒNG CHIẾU";
                    dgvUpcomingShows.Columns["Sold"].HeaderText = "ĐÃ BÁN";
                    dgvUpcomingShows.Columns["Status"].HeaderText = "TRẠNG THÁI";
                }

                // 5. Load phim hot
                var topMovies = db.Ves
                    .GroupBy(v => v.SuatChieu.Phim)
                    .OrderByDescending(g => g.Count())
                    .Take(3)
                    .ToList();

                if (topMovies.Count >= 1) {
                    movie1.MovieTitle = topMovies[0].Key.TenPhim;
                    movie1.MovieInfo = topMovies[0].Key.TheLoai?.TenTheLoai + " • " + topMovies[0].Key.ThoiLuong + " phút";
                    movie1.Value = 95; // Demo percentage
                }
                if (topMovies.Count >= 2) {
                    movie2.MovieTitle = topMovies[1].Key.TenPhim;
                    movie2.MovieInfo = topMovies[1].Key.TheLoai?.TenTheLoai + " • " + topMovies[1].Key.ThoiLuong + " phút";
                    movie2.Value = 75;
                }
                if (topMovies.Count >= 3) {
                    movie3.MovieTitle = topMovies[2].Key.TenPhim;
                    movie3.MovieInfo = topMovies[2].Key.TheLoai?.TenTheLoai + " • " + topMovies[2].Key.ThoiLuong + " phút";
                    movie3.Value = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu database: " + ex.Message);
            }
        }

        private void PnlChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Pen bluePen = new Pen(Color.FromArgb(30, 107, 254), 3);
            Point[] points = new Point[] {
                new Point(50, 250),
                new Point(120, 200),
                new Point(190, 220),
                new Point(260, 150),
                new Point(330, 180),
                new Point(400, 100),
                new Point(470, 130)
            };

            g.DrawLines(bluePen, points);
            foreach (var p in points)
            {
                g.FillEllipse(Brushes.White, p.X - 4, p.Y - 4, 8, 8);
                g.DrawEllipse(bluePen, p.X - 4, p.Y - 4, 8, 8);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
    }
}

