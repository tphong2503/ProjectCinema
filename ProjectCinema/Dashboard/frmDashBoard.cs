using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using ProjectCinema.Modals;

namespace ProjectCinema
{
    public partial class frmDashBoard : Form
    {
        private readonly DashBoard db = new DashBoard();

        public frmDashBoard()
        {
            InitializeComponent();
            
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
                // Calculate revenue from HoaDon where NgayLap is today
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
                // Count tickets sold for today's shows
                var totalTicketsToday = db.Ves
                    .Count(v => v.SuatChieu.NgayChieu == today);
                
                // Calculate total capacity of all shows today
                var totalCapacityToday = db.SuatChieux
                    .Where(s => s.NgayChieu == today)
                    .Sum(s => (int?)s.PhongChieu.SoGhe) ?? 0;

                double fillingRate = 0;
                if (totalCapacityToday > 0)
                {
                    fillingRate = (double)totalTicketsToday / totalCapacityToday * 100;
                }
                cardFillingRate.Value = fillingRate.ToString("F1") + "%";

                // 4. Load suất chiếu sắp tới vào Grid
                var upcomingShowsRaw = db.SuatChieux
                    .Where(s => s.NgayChieu >= today) 
                    // Get shows from now onwards (including future days or later today)
                    .Where(s => s.NgayChieu > today || (s.NgayChieu == today && s.GioChieu > currentTime))
                    .OrderBy(s => s.NgayChieu).ThenBy(s => s.GioChieu)
                    .Take(10)
                    .Select(s => new {
                        Date = s.NgayChieu,
                        RawTime = s.GioChieu,
                        Movie = s.Phim.TenPhim,
                        Room = s.PhongChieu.TenPhong,
                        SoldTickets = s.Ves.Count,
                        TotalSeats = s.PhongChieu.SoGhe,
                        Status = s.TrangThai
                    }).ToList();

                var upcomingShowsList = upcomingShowsRaw.Select(s => new {
                    Time = s.Date == today ? s.RawTime.ToString(@"hh\:mm") : s.Date.ToString("dd/MM") + " " + s.RawTime.ToString(@"hh\:mm"),
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

                // 5. Load phim hot (Top 3 movies by ticket sales relative to total sales)
                // Filter Ves by broad time range (e.g. this month or all time active?) 
                // Using 'Today' might be too sparse. Let's look at active movies (Last 30 days)
                var last30Days = today.AddDays(-30);
                
                var topMovies = db.Ves
                    .Where(v => v.SuatChieu.NgayChieu >= last30Days)
                    .GroupBy(v => v.SuatChieu.Phim)
                    .Select(g => new {
                        Phim = g.Key,
                        TicketCount = g.Count()
                    })
                    .OrderByDescending(x => x.TicketCount)
                    .Take(3)
                    .ToList();
                
                // Helper to set movie data safely
                void SetMovieData(UI.MovieListItem item, dynamic data, int maxTickets)
                {
                   if (data != null && item != null)
                   {
                        item.MovieTitle = data.Phim.TenPhim;
                        // Use default info if TheLoai is null
                        string genre = data.Phim.TheLoai != null ? data.Phim.TheLoai.TenTheLoai : "Phim hay";
                        item.MovieInfo = $"{genre} • {data.Phim.ThoiLuong} phút";
                        
                        // Calculate simplified "popularity" percentage based on relative share of top movies
                        int percent = maxTickets > 0 ? (int)((double)data.TicketCount / maxTickets * 100) : 0;
                        item.Value = percent;
                        item.Visible = true;
                   }
                   else if (item != null)
                   {
                        item.Visible = false; // Hide if not enough top movies
                   }
                }

                int maxCount = topMovies.Any() ? topMovies.Max(x => x.TicketCount) : 1;
                
                // Set data or hide widgets
                SetMovieData(movie1, topMovies.Count > 0 ? topMovies[0] : null, maxCount);
                SetMovieData(movie2, topMovies.Count > 1 ? topMovies[1] : null, maxCount);
                SetMovieData(movie3, topMovies.Count > 2 ? topMovies[2] : null, maxCount);
            }
            catch (Exception ex)
            {
                // Log error safely or show simple message
                // MessageBox.Show("Lỗi load dữ liệu database: " + ex.Message);
                // For Dashboard, maybe just ignore or show status in a status bar?
                // Let's keep it silent or debug print to avoid annoying popups on every refresh
                Console.WriteLine("Dashboard Load Error: " + ex.ToString());
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

        // Current active form
        private Form activeForm = null;

        // Method to open child form
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            
            // Clear Dashboard content but keep the main panel container intact
            // Note: We need to remove existing controls or hide them. 
            // Better approach: Hide Dashboard specific controls and add Child Form
            // Or simpler: Clear mainContentPanel if it holds ONLY dashboard items.
            // Let's check Designer first. mainContentPanel holds the dashboard widgets.
            
            mainContentPanel.Controls.Clear();
            mainContentPanel.Controls.Add(childForm);
            mainContentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Restore Dashboard View
        private void ShowDashboard()
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
            
            mainContentPanel.Controls.Clear();
            
            // Re-initialize Dashboard controls. 
            // Since we cleared them, we need to rebuild or reload.
            // A better way for MDI is to separate Dashboard into a UserControl or separate Form too.
            // EXCEPT: The user asked to integrate AS child forms.
            // To allow "Back to Dashboard", the easiest restart is:
            // 1. Move Dashboard content to a UserControl (cleanest)
            // 2. OR just re-call Cancel/Restart (messy)
            // 3. OR just Hide dashboard controls instead of Clear (fastest now)
            
            // Re-initializing components for now (Simulated Reload)
            InitializeDashboardControls(); 
            LoadDashboardData();
        }

        private void InitializeDashboardControls()
        {
            // Re-add controls that were in InitializeComponent
            // ideally we would move these to a "DashboardControl" UserControl
            // But to save time and stay in this file, let's just cheat and restart the app 
            // OR simpler: Just reload the form? No.
            
            // Let's implement the "Hide/Show" strategy for next step if this gets complex.
            // For now, let's just try to build the OpenChildForm logic
            
            this.Controls.Clear();
            this.InitializeComponent(); 
            SetupDashboard();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
             OpenChildForm(new frmQLSuatChieu());
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
             OpenChildForm(new frmQLPhim());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
            // HACK: Re-init to restore dashboard state
            this.Controls.Clear();
            this.InitializeComponent();
            SetupDashboard();
            LoadDashboardData(); // Reload data
        }
        
        private void btnTickets_Click(object sender, EventArgs e)
        {
            // Open Ticket Booking (requires movie name usually, but we open default)
            OpenChildForm(new frmQLGhe("Chưa chọn phim"));
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

    
    }
}

