using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjectCinema.BUS;
using ProjectCinema.DAL.Models;

namespace ProjectCinema.GUI
{
    public partial class frmBanVe : Form
    {
        private PhimBUS _phimBUS;
        private SuatChieuBUS _suatChieuBUS;
        private GheBUS _gheBUS;
        private VeBUS _veBUS;

        // Controls
        private DateTimePicker dtpNgay;
        private ComboBox cboPhim;
        private ComboBox cboSuatChieu;
        private FlowLayoutPanel pnlGhe; // Panel chứa ghế
        private Label lblTongTien;
        private ListBox lstGheChon; // Danh sách ghế đang chọn
        private Button btnThanhToan;
        private PictureBox pbPoster;

        // Data
        private List<Ghe> _listGhe;
        private List<Ve> _listVeDaBan;
        private List<Ghe> _selectedSeats = new List<Ghe>();
        private SuatChieu _currentSuatChieu;

        public frmBanVe()
        {
            InitializeComponent();
            SetupUI();

            _phimBUS = new PhimBUS();
            _suatChieuBUS = new SuatChieuBUS();
            _gheBUS = new GheBUS();
            _veBUS = new VeBUS();

            LoadInitData();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void SetupUI()
        {
            this.Text = "Bán Vé Xem Phim";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // 1. Header
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(84, 110, 122) };
            Label lblHeader = new Label
            {
                Text = "BÁN VÉ XEM PHIM",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            pnlHeader.Controls.Add(lblHeader);
            this.Controls.Add(pnlHeader);

            // 2. Filter Panel (Top, below Header)
            Panel pnlFilter = new Panel { Location = new Point(20, 70), Size = new Size(960, 60), BackColor = Color.White };
            
            Label lblNgay = new Label { Text = "Ngày chiếu:", Location = new Point(10, 20), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            dtpNgay = new DateTimePicker { Location = new Point(90, 18), Size = new Size(120, 30), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10F) };
            dtpNgay.MinDate = DateTime.Today; // Fix: Prevent selecting past dates
            dtpNgay.ValueChanged += DtpNgay_ValueChanged;

            Label lblPhim = new Label { Text = "Phim:", Location = new Point(230, 20), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            cboPhim = new ComboBox { Location = new Point(280, 18), Size = new Size(250, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
            cboPhim.SelectedIndexChanged += CboPhim_SelectedIndexChanged;

            Label lblSuat = new Label { Text = "Suất:", Location = new Point(550, 20), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            cboSuatChieu = new ComboBox { Location = new Point(600, 18), Size = new Size(150, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
            cboSuatChieu.SelectedIndexChanged += CboSuatChieu_SelectedIndexChanged;

            Button btnLoad = new Button { Text = "Tải Sơ Đồ", Location = new Point(780, 15), Size = new Size(100, 35), BackColor = Color.FromArgb(84, 110, 122), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            btnLoad.Click += BtnLoad_Click;

            pnlFilter.Controls.AddRange(new Control[] { lblNgay, dtpNgay, lblPhim, cboPhim, lblSuat, cboSuatChieu, btnLoad });
            this.Controls.Add(pnlFilter);
            
            // ... (Rest of SetupUI)


            // 3. Seat Map (Left)
            Label lblScreen = new Label { Text = "MÀN HÌNH (SCREEN)", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.Black, ForeColor = Color.White, Font = new Font("Segoe UI", 12F, FontStyle.Bold), Location = new Point(20, 140), Size = new Size(600, 30) };
            this.Controls.Add(lblScreen);

            pnlGhe = new FlowLayoutPanel { Location = new Point(20, 180), Size = new Size(600, 450), BackColor = Color.White, AutoScroll = true, BorderStyle = BorderStyle.FixedSingle, FlowDirection = FlowDirection.TopDown, WrapContents = false };
            this.Controls.Add(pnlGhe);

            // 4. Booking Info (Right)
            Panel pnlInfo = new Panel { Location = new Point(640, 140), Size = new Size(340, 490), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            Label lblInfoTitle = new Label { Text = "THÔNG TIN VÉ", Location = new Point(10, 10), Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.FromArgb(84, 110, 122), AutoSize = true };
            
            // Poster
            pbPoster = new PictureBox { Location = new Point(10, 40), Size = new Size(110, 160), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };

            Label lblSelected = new Label { Text = "Ghế chọn:", Location = new Point(130, 40), AutoSize = true };
            lstGheChon = new ListBox { Location = new Point(130, 65), Size = new Size(200, 135), Font = new Font("Segoe UI", 10F) };

            Label lblTotal = new Label { Text = "Tổng tiền:", Location = new Point(10, 300), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            lblTongTien = new Label { Text = "0 VNĐ", Location = new Point(100, 300), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.Red };

            btnThanhToan = new Button { Text = "THANH TOÁN", Location = new Point(10, 350), Size = new Size(320, 50), BackColor = Color.FromArgb(84, 110, 122), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            btnThanhToan.Click += BtnThanhToan_Click;

            // Legend (Chú thích)
            Panel pnlLegend = new Panel { Location = new Point(10, 420), Size = new Size(320, 60), BorderStyle = BorderStyle.FixedSingle };
            Label lblAvail = new Label { Text = "Trống", Location = new Point(40, 20), AutoSize = true }; Button btnAvail = new Button { Location = new Point(10, 15), Size = new Size(25, 25), BackColor = Color.WhiteSmoke, FlatStyle = FlatStyle.Flat, Enabled = false };
            Label lblSold = new Label { Text = "Đã bán", Location = new Point(120, 20), AutoSize = true }; Button btnSold = new Button { Location = new Point(90, 15), Size = new Size(25, 25), BackColor = Color.Red, FlatStyle = FlatStyle.Flat, Enabled = false };
            Label lblSelect = new Label { Text = "Đang chọn", Location = new Point(200, 20), AutoSize = true }; Button btnSelect = new Button { Location = new Point(170, 15), Size = new Size(25, 25), BackColor = Color.Yellow, FlatStyle = FlatStyle.Flat, Enabled = false };
            pnlLegend.Controls.AddRange(new Control[] { btnAvail, lblAvail, btnSold, lblSold, btnSelect, lblSelect });

            pnlInfo.Controls.AddRange(new Control[] { lblInfoTitle, pbPoster, lblSelected, lstGheChon, lblTotal, lblTongTien, btnThanhToan, pnlLegend });
            this.Controls.Add(pnlInfo);
        }

        private void LoadInitData()
        {
            // Load danh sách phim trong ngày hôm nay
            LoadPhim(dtpNgay.Value);
        }

        private void DtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadPhim(dtpNgay.Value);
        }

        private void LoadPhim(DateTime date)
        {
            // Logic: Lấy tất cả phim có suất chiếu trong ngày (cần thêm method trong SuatChieuBUS để lấy Distinct Phim theo Ngày, tạm thời lấy All Phim)
            var listPhim = _phimBUS.GetAllPhim(); // Tạm thời
            cboPhim.DisplayMember = "TenPhim";
            cboPhim.ValueMember = "MaPhim";
            cboPhim.DataSource = listPhim;
        }

        private void CboPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhim.SelectedValue == null) return;
            if (int.TryParse(cboPhim.SelectedValue.ToString(), out int maPhim))
            {
                LoadSuatChieu(maPhim, dtpNgay.Value);

                // Load Poster
                var phim = cboPhim.SelectedItem as Phim;
                if (phim != null && !string.IsNullOrEmpty(phim.AnhBia))
                {
                    string fullPath = System.IO.Path.Combine(Application.StartupPath, phim.AnhBia);
                    if (System.IO.File.Exists(fullPath))
                        pbPoster.Image = Image.FromFile(fullPath);
                    else
                        pbPoster.Image = null;
                }
                else
                {
                    pbPoster.Image = null;
                }
            }
        }

        private void LoadSuatChieu(int maPhim, DateTime date)
        {
            // Logic: lấy suất chiếu của phim trong ngày
            var allSuat = _suatChieuBUS.GetAllSuatChieu(); // Cần tối ưu lọc theo ngày/phim trong db
            var suatChieuPhim = allSuat.Where(s => s.MaPhim == maPhim && s.NgayChieu.HasValue && s.NgayChieu.Value.Date == date.Date).ToList();
            
            // Filter: Nếu là ngày hiện tại, chỉ lấy suất chưa chiếu (GioBatDau > GioHienTai)
            if (date.Date == DateTime.Today)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                suatChieuPhim = suatChieuPhim.Where(s => s.GioBatDau.HasValue && s.GioBatDau.Value > currentTime).ToList();
            }

            var bindingList = suatChieuPhim.Select(s => new 
            { 
                s.MaSuatChieu, 
                GioHienThi = s.GioBatDau.HasValue ? s.GioBatDau.Value.ToString(@"hh\:mm") : "N/A"
            }).OrderBy(x => x.GioHienThi).ToList(); // Sort for better UX

            cboSuatChieu.DataSource = bindingList;
            cboSuatChieu.DisplayMember = "GioHienThi";
            cboSuatChieu.ValueMember = "MaSuatChieu";
        }

        private void CboSuatChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear map khi đổi suất
            pnlGhe.Controls.Clear();
            _currentSuatChieu = null;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (cboSuatChieu.SelectedValue == null)
            {
                CustomMessageBox.Show("Vui lòng chọn suất chiếu!");
                return;
            }

            int maSuat = (int)cboSuatChieu.SelectedValue;
            _currentSuatChieu = _suatChieuBUS.GetSuatChieuById(maSuat);
            
            if (_currentSuatChieu == null) return;

            LoadSeatMap(_currentSuatChieu);
        }

        // Helper to store display alias (MaGhe -> DisplayName)
        private Dictionary<int, string> _seatDisplayNames = new Dictionary<int, string>();

        private void LoadSeatMap(SuatChieu suat)
        {
            int maPhong = (int)suat.MaPhong;
            _listGhe = _gheBUS.GetAllGheByPhong(maPhong);
            _listVeDaBan = _veBUS.GetVeBySuatChieu(suat.MaSuatChieu);

            // Dark Theme Settings
            pnlGhe.BackColor = Color.FromArgb(23, 23, 23);
            pnlGhe.Padding = new Padding(20, 20, 0, 0);

            pnlGhe.Controls.Clear();
            _selectedSeats.Clear();
            _seatDisplayNames.Clear(); // Reset alias map
            UpdateSummary();

            // Sắp xếp tất cả ghế theo thứ tự tự nhiên (A1, A2... A10...)
            var allSeatsSorted = _listGhe
                .OrderBy(g => g.TenGhe.Length).ThenBy(g => g.TenGhe)
                .ToList();

            // Config: 8 ghế mỗi hàng
            int seatsPerRow = 8;
            int totalRows = (int)Math.Ceiling((double)allSeatsSorted.Count / seatsPerRow);
            
            // Row Labels: A, B, C...
            char[] rowLabels = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 0; i < totalRows; i++)
            {
                // Lấy 8 ghế cho hàng hiện tại
                var rowSeats = allSeatsSorted.Skip(i * seatsPerRow).Take(seatsPerRow).ToList();
                
                // Xác định Label (A, B...)
                char currentRowLabel = (i < rowLabels.Length) ? rowLabels[i] : '?';

                FlowLayoutPanel pnlRow = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    Margin = new Padding(0, 0, 0, 5),
                    BackColor = Color.Transparent
                };

                // Row Label Control
                Label lblRow = new Label
                {
                    Text = currentRowLabel.ToString(),
                    AutoSize = false,
                    Size = new Size(30, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    BackColor = Color.Transparent,
                    Margin = new Padding(0, 2, 10, 2)
                };
                pnlRow.Controls.Add(lblRow);

                // Determine Row Color 
                // User Request: Available = Gray, Sold = Red. (Replacing Purple/Red row logic)
                Color seatColor = Color.DarkGray; // Available = Gray

                for (int j = 0; j < rowSeats.Count; j++)
                {
                    var ghe = rowSeats[j];
                    
                    // Generate Visual Display Name (Aliasing)
                    string displayName = $"{currentRowLabel}{j + 1}";
                    
                    if (!_seatDisplayNames.ContainsKey(ghe.MaGhe))
                        _seatDisplayNames.Add(ghe.MaGhe, displayName);

                    Button btnGhe = new Button();
                    btnGhe.Text = displayName;
                    btnGhe.Size = new Size(35, 30);
                    btnGhe.Tag = ghe;
                    btnGhe.Margin = new Padding(1);
                    btnGhe.FlatStyle = FlatStyle.Flat;
                    btnGhe.FlatAppearance.BorderSize = 0;
                    btnGhe.ForeColor = Color.White;
                    btnGhe.Font = new Font("Segoe UI", 7F, FontStyle.Regular);

                    // Check Status
                    // Fix: Check Status == "DaBan" to determine Red color.
                    // Pre-populated "Trong" tickets should be Available (Gray).
                    bool isSold = _listVeDaBan.Any(v => v.MaGhe == ghe.MaGhe && v.TrangThai == "DaBan");
                    if (isSold)
                    {
                        btnGhe.BackColor = Color.Red; // Sold
                        btnGhe.Enabled = false;
                    }
                    else
                    {
                        btnGhe.BackColor = seatColor; // Available = Gray
                        btnGhe.Click += BtnGhe_Click;
                    }

                    pnlRow.Controls.Add(btnGhe);

                    // Aisle Spacer: Chia 4-4
                    if (j == 3) 
                    {
                        Label lblSpacer = new Label { AutoSize = false, Size = new Size(30, 30), BackColor = Color.Transparent };
                        pnlRow.Controls.Add(lblSpacer);
                    }
                }
                pnlGhe.Controls.Add(pnlRow);
            }
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Ghe ghe = btn.Tag as Ghe;

            if (_selectedSeats.Contains(ghe))
            {
                // Bỏ chọn
                _selectedSeats.Remove(ghe);
                btn.BackColor = Color.DarkGray; // Restore Available Color
                btn.ForeColor = Color.White;
            }
            else
            {
                // Chọn
                _selectedSeats.Add(ghe);
                btn.BackColor = Color.Yellow; // Selected = Yellow
                btn.ForeColor = Color.Black; 
            }
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            lstGheChon.Items.Clear();
            decimal total = 0;
            foreach (var ghe in _selectedSeats)
            {
                // Use Display Alias if available, else fallback to DB Name
                string displayName = _seatDisplayNames.ContainsKey(ghe.MaGhe) ? _seatDisplayNames[ghe.MaGhe] : ghe.TenGhe;
                lstGheChon.Items.Add(displayName); // Show visual name
                total += _currentSuatChieu.GiaVeCoBan;
            }
            lblTongTien.Text = total.ToString("N0") + " VNĐ";
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (_selectedSeats.Count == 0)
            {
                CustomMessageBox.Show("Vui lòng chọn ít nhất một ghế!");
                return;
            }

            if (CustomMessageBox.Show($"Bạn có chắc muốn thanh toán {_selectedSeats.Count} vé?\nTổng tiền: {lblTongTien.Text}", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    List<Ve> ticketsToPrint = new List<Ve>();
                    foreach (var ghe in _selectedSeats)
                    {
                        Ve ve = new Ve
                        {
                            MaSuatChieu = _currentSuatChieu.MaSuatChieu,
                            MaGhe = ghe.MaGhe,
                            GiaBan = _currentSuatChieu.GiaVeCoBan,
                            TrangThai = "DaBan"
                        };
                        _veBUS.AddVe(ve);
                        ticketsToPrint.Add(ve);
                    }
                    CustomMessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // In vé
                    PrintTickets(ticketsToPrint);
                    
                    LoadSeatMap(_currentSuatChieu); // Tải lại sơ đồ
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Lỗi thanh toán: " + ex.Message);
                }
            }
        }
        private void PrintTickets(List<Ve> tickets)
        {
            if (tickets == null || tickets.Count == 0) return;

            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += (s, e) => PrintTicketPage(e, tickets);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            // Hack to bring preview to front
            ((Form)preview).WindowState = FormWindowState.Maximized; 
            preview.ShowDialog();
        }

        private void PrintTicketPage(System.Drawing.Printing.PrintPageEventArgs e, List<Ve> tickets)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Courier New", 18, FontStyle.Bold);
            Font fontContent = new Font("Courier New", 12);
            Font fontBold = new Font("Courier New", 12, FontStyle.Bold);
            
            float y = 50;
            float leftMargin = 50;
            float width = e.PageBounds.Width - 100;

            StringFormat center = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat left = new StringFormat { Alignment = StringAlignment.Near };
            StringFormat right = new StringFormat { Alignment = StringAlignment.Far };

            // Header common
            g.DrawString("RẠP CHIÊU PHIM APP", fontTitle, Brushes.Black, new RectangleF(leftMargin, y, width, 40), center);
            y += 40;
            g.DrawString("--------------------------------", fontContent, Brushes.Black, new RectangleF(leftMargin, y, width, 20), center);
            y += 30;

            // Info (Phim, Suất) from first ticket (assuming same showtime)
            var firstTicket = tickets[0];
            // Need to get Phim Name, Room Name. 
            // _currentSuatChieu has MaPhong, MaPhim... need names.
            // But we have cboPhim.Text and cboSuatChieu.Text available?
            // Or fetch from DB? Fetching is safer.
            
            // For simplicitly, using cached data if available or assumption
            string filmName = cboPhim.Text;
            string roomName = "Phòng " + _currentSuatChieu.MaPhong; // Simple assignment
            string time = _currentSuatChieu.GioBatDau.HasValue ? _currentSuatChieu.GioBatDau.Value.ToString(@"hh\:mm") : "";
            string date = _currentSuatChieu.NgayChieu.HasValue ? _currentSuatChieu.NgayChieu.Value.ToString("dd/MM/yyyy") : "";

            g.DrawString($"Phim: {filmName}", fontBold, Brushes.Black, leftMargin, y);
            y += 25;
            g.DrawString($"Ngày: {date} - Suất: {time}", fontContent, Brushes.Black, leftMargin, y);
            y += 25;
            g.DrawString($"Rạp: {roomName}", fontContent, Brushes.Black, leftMargin, y);
            y += 30;
            g.DrawString("--------------------------------", fontContent, Brushes.Black, new RectangleF(leftMargin, y, width, 20), center);
            y += 30;

            // List Seats
            g.DrawString("GHẾ", fontBold, Brushes.Black, leftMargin, y);
            g.DrawString("GIÁ VÉ", fontBold, Brushes.Black, e.PageBounds.Width - leftMargin - 100, y);
            y += 25;

            decimal total = 0;
            foreach (var t in tickets)
            {
                // Find seat name
                // We have _selectedSeats which are objects. Tickets have MaGhe.
                // Map back
                var seat = _selectedSeats.FirstOrDefault(s => s.MaGhe == t.MaGhe);
                string seatName = seat != null ? seat.TenGhe : t.MaGhe.ToString();
                
                // Use display alias if map exists
                if (t.MaGhe.HasValue && _seatDisplayNames.ContainsKey(t.MaGhe.Value)) seatName = _seatDisplayNames[t.MaGhe.Value];

                g.DrawString(seatName, fontContent, Brushes.Black, leftMargin, y);
                g.DrawString(((decimal)t.GiaBan).ToString("N0"), fontContent, Brushes.Black, e.PageBounds.Width - leftMargin - 100, y);
                y += 25;
                total += (decimal)t.GiaBan;
            }

            y += 20;
            g.DrawString("--------------------------------", fontContent, Brushes.Black, new RectangleF(leftMargin, y, width, 20), center);
            y += 30;
            
            g.DrawString($"TỔNG CỘNG: {total:N0} VNĐ", fontBold, Brushes.Black, new RectangleF(leftMargin, y, width, 30), right);
            y += 50;
            
            g.DrawString("Cảm ơn quý khách!", fontContent, Brushes.Black, new RectangleF(leftMargin, y, width, 20), center);
        }
    }
}
