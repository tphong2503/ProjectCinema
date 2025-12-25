namespace ProjectCinema
{
    partial class frmDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainContentPanel = new ProjectCinema.UI.RoundedPanel();
            this.dgvUpcomingShows = new System.Windows.Forms.DataGridView();
            this.lblUpcomingShowsTitle = new System.Windows.Forms.Label();
            this.pnlHotMovies = new ProjectCinema.UI.RoundedPanel();
            this.movie3 = new ProjectCinema.UI.MovieListItem();
            this.movie2 = new ProjectCinema.UI.MovieListItem();
            this.movie1 = new ProjectCinema.UI.MovieListItem();
            this.lblHotMoviesTitle = new System.Windows.Forms.Label();
            this.pnlChart = new ProjectCinema.UI.RoundedPanel();
            this.cardFillingRate = new ProjectCinema.UI.SummaryCard();
            this.cardShows = new ProjectCinema.UI.SummaryCard();
            this.cardRevenue = new ProjectCinema.UI.SummaryCard();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.sidebarPanel = new ProjectCinema.UI.RoundedPanel();
            this.btnExit = new ProjectCinema.UI.RoundedButton();
            this.btnTickets = new ProjectCinema.UI.RoundedButton();
            this.btnRevenue = new ProjectCinema.UI.RoundedButton();
            this.btnMovies = new ProjectCinema.UI.RoundedButton();
            this.btnSchedule = new ProjectCinema.UI.RoundedButton();
            this.btnDashboard = new ProjectCinema.UI.RoundedButton();
            this.logoLabel = new System.Windows.Forms.Label();
            this.mainContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingShows)).BeginInit();
            this.pnlHotMovies.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(28)))));
            this.mainContentPanel.BorderColor = System.Drawing.Color.Transparent;
            this.mainContentPanel.BorderRadius = 0;
            this.mainContentPanel.BorderSize = 0;
            this.mainContentPanel.Controls.Add(this.dgvUpcomingShows);
            this.mainContentPanel.Controls.Add(this.lblUpcomingShowsTitle);
            this.mainContentPanel.Controls.Add(this.pnlHotMovies);
            this.mainContentPanel.Controls.Add(this.pnlChart);
            this.mainContentPanel.Controls.Add(this.cardFillingRate);
            this.mainContentPanel.Controls.Add(this.cardShows);
            this.mainContentPanel.Controls.Add(this.cardRevenue);
            this.mainContentPanel.Controls.Add(this.lblDescription);
            this.mainContentPanel.Controls.Add(this.lblGreeting);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.GradientAngle = 45F;
            this.mainContentPanel.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(20)))));
            this.mainContentPanel.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.mainContentPanel.Location = new System.Drawing.Point(260, 0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(1020, 800);
            this.mainContentPanel.TabIndex = 1;
            // 
            // dgvUpcomingShows
            // 
            this.dgvUpcomingShows.AllowUserToAddRows = false;
            this.dgvUpcomingShows.AllowUserToDeleteRows = false;
            this.dgvUpcomingShows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpcomingShows.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.dgvUpcomingShows.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUpcomingShows.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUpcomingShows.ColumnHeadersHeight = 40;
            this.dgvUpcomingShows.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.dgvUpcomingShows.Location = new System.Drawing.Point(40, 560);
            this.dgvUpcomingShows.Name = "dgvUpcomingShows";
            this.dgvUpcomingShows.ReadOnly = true;
            this.dgvUpcomingShows.RowHeadersVisible = false;
            this.dgvUpcomingShows.RowHeadersWidth = 51;
            this.dgvUpcomingShows.RowTemplate.Height = 40;
            this.dgvUpcomingShows.Size = new System.Drawing.Size(940, 200);
            this.dgvUpcomingShows.TabIndex = 8;
            // 
            // lblUpcomingShowsTitle
            // 
            this.lblUpcomingShowsTitle.AutoSize = true;
            this.lblUpcomingShowsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUpcomingShowsTitle.ForeColor = System.Drawing.Color.White;
            this.lblUpcomingShowsTitle.Location = new System.Drawing.Point(40, 520);
            this.lblUpcomingShowsTitle.Name = "lblUpcomingShowsTitle";
            this.lblUpcomingShowsTitle.Size = new System.Drawing.Size(182, 28);
            this.lblUpcomingShowsTitle.TabIndex = 7;
            this.lblUpcomingShowsTitle.Text = "Suất chiếu sắp tới";
            // 
            // pnlHotMovies
            // 
            this.pnlHotMovies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.pnlHotMovies.BorderColor = System.Drawing.Color.Transparent;
            this.pnlHotMovies.BorderRadius = 20;
            this.pnlHotMovies.BorderSize = 0;
            this.pnlHotMovies.Controls.Add(this.movie3);
            this.pnlHotMovies.Controls.Add(this.movie2);
            this.pnlHotMovies.Controls.Add(this.movie1);
            this.pnlHotMovies.Controls.Add(this.lblHotMoviesTitle);
            this.pnlHotMovies.GradientAngle = 45F;
            this.pnlHotMovies.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(30)))));
            this.pnlHotMovies.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.pnlHotMovies.Location = new System.Drawing.Point(680, 280);
            this.pnlHotMovies.Name = "pnlHotMovies";
            this.pnlHotMovies.Size = new System.Drawing.Size(300, 250);
            this.pnlHotMovies.TabIndex = 6;
            // 
            // movie3
            // 
            this.movie3.BackColor = System.Drawing.Color.Transparent;
            this.movie3.Location = new System.Drawing.Point(0, 175);
            this.movie3.MovieImage = null;
            this.movie3.MovieInfo = "Action • 1h 55m";
            this.movie3.MovieTitle = "Godzilla x Kong";
            this.movie3.Name = "movie3";
            this.movie3.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.movie3.Size = new System.Drawing.Size(300, 60);
            this.movie3.TabIndex = 3;
            this.movie3.Value = 75;
            // 
            // movie2
            // 
            this.movie2.BackColor = System.Drawing.Color.Transparent;
            this.movie2.Location = new System.Drawing.Point(0, 110);
            this.movie2.MovieImage = null;
            this.movie2.MovieInfo = "Animation • 1h 34m";
            this.movie2.MovieTitle = "Kung Fu Panda 4";
            this.movie2.Name = "movie2";
            this.movie2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(0)))));
            this.movie2.Size = new System.Drawing.Size(300, 60);
            this.movie2.TabIndex = 2;
            this.movie2.Value = 65;
            // 
            // movie1
            // 
            this.movie1.BackColor = System.Drawing.Color.Transparent;
            this.movie1.Location = new System.Drawing.Point(0, 45);
            this.movie1.MovieImage = null;
            this.movie1.MovieInfo = "Sci-Fi • 2h 46m";
            this.movie1.MovieTitle = "Dune: Part Two";
            this.movie1.Name = "movie1";
            this.movie1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(107)))), ((int)(((byte)(254)))));
            this.movie1.Size = new System.Drawing.Size(300, 60);
            this.movie1.TabIndex = 1;
            this.movie1.Value = 95;
            // 
            // lblHotMoviesTitle
            // 
            this.lblHotMoviesTitle.AutoSize = true;
            this.lblHotMoviesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHotMoviesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHotMoviesTitle.ForeColor = System.Drawing.Color.White;
            this.lblHotMoviesTitle.Location = new System.Drawing.Point(20, 20);
            this.lblHotMoviesTitle.Name = "lblHotMoviesTitle";
            this.lblHotMoviesTitle.Size = new System.Drawing.Size(150, 21);
            this.lblHotMoviesTitle.TabIndex = 0;
            this.lblHotMoviesTitle.Text = "Phim đang hot 🔥";
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.pnlChart.BorderColor = System.Drawing.Color.Transparent;
            this.pnlChart.BorderRadius = 20;
            this.pnlChart.BorderSize = 0;
            this.pnlChart.GradientAngle = 45F;
            this.pnlChart.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(30)))));
            this.pnlChart.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.pnlChart.Location = new System.Drawing.Point(40, 280);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(620, 220);
            this.pnlChart.TabIndex = 5;
            // 
            // cardFillingRate
            // 
            this.cardFillingRate.BorderRadius = 20;
            this.cardFillingRate.GradientAngle = 45F;
            this.cardFillingRate.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(50)))), ((int)(((byte)(30)))));
            this.cardFillingRate.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.cardFillingRate.Icon = null;
            this.cardFillingRate.Location = new System.Drawing.Point(680, 140);
            this.cardFillingRate.Name = "cardFillingRate";
            this.cardFillingRate.Size = new System.Drawing.Size(300, 120);
            this.cardFillingRate.SubValue = "+5% so với tuần trước";
            this.cardFillingRate.SubValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cardFillingRate.TabIndex = 4;
            this.cardFillingRate.Title = "Tỷ lệ lấp đầy";
            this.cardFillingRate.Value = "78%";
            // 
            // cardShows
            // 
            this.cardShows.BorderRadius = 20;
            this.cardShows.GradientAngle = 45F;
            this.cardShows.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.cardShows.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(30)))), ((int)(((byte)(120)))));
            this.cardShows.Icon = null;
            this.cardShows.Location = new System.Drawing.Point(360, 140);
            this.cardShows.Name = "cardShows";
            this.cardShows.Size = new System.Drawing.Size(300, 120);
            this.cardShows.SubValue = "Trong tổng số 65 suất hôm nay";
            this.cardShows.SubValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.cardShows.TabIndex = 3;
            this.cardShows.Title = "Suất chiếu còn lại";
            this.cardShows.Value = "42";
            // 
            // cardRevenue
            // 
            this.cardRevenue.BorderRadius = 20;
            this.cardRevenue.GradientAngle = 45F;
            this.cardRevenue.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.cardRevenue.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(180)))));
            this.cardRevenue.Icon = null;
            this.cardRevenue.Location = new System.Drawing.Point(40, 140);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Size = new System.Drawing.Size(300, 120);
            this.cardRevenue.SubValue = "+15% so với hôm qua";
            this.cardRevenue.SubValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cardRevenue.TabIndex = 2;
            this.cardRevenue.Title = "Doanh thu hôm nay";
            this.cardRevenue.Value = "12,500,000 đ";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.lblDescription.Location = new System.Drawing.Point(45, 120);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(433, 23);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Đây là tình hình hoạt động của rạp chiếu phim hôm nay.";
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblGreeting.ForeColor = System.Drawing.Color.White;
            this.lblGreeting.Location = new System.Drawing.Point(40, 40);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(460, 59);
            this.lblGreeting.TabIndex = 0;
            this.lblGreeting.Text = "Xin chào, Quản lý! 👋";
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(18)))), ((int)(((byte)(25)))));
            this.sidebarPanel.BorderColor = System.Drawing.Color.Transparent;
            this.sidebarPanel.BorderRadius = 0;
            this.sidebarPanel.BorderSize = 0;
            this.sidebarPanel.Controls.Add(this.btnExit);
            this.sidebarPanel.Controls.Add(this.btnTickets);
            this.sidebarPanel.Controls.Add(this.btnRevenue);
            this.sidebarPanel.Controls.Add(this.btnMovies);
            this.sidebarPanel.Controls.Add(this.btnSchedule);
            this.sidebarPanel.Controls.Add(this.btnDashboard);
            this.sidebarPanel.Controls.Add(this.logoLabel);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.GradientAngle = 90F;
            this.sidebarPanel.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(18)))), ((int)(((byte)(25)))));
            this.sidebarPanel.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(260, 800);
            this.sidebarPanel.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderRadius = 10;
            this.btnExit.BorderSize = 0;
            this.btnExit.Checked = false;
            this.btnExit.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(107)))), ((int)(((byte)(254)))));
            this.btnExit.CheckedForeColor = System.Drawing.Color.White;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnExit.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.btnExit.Location = new System.Drawing.Point(10, 720);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(240, 50);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "   Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTickets
            // 
            this.btnTickets.BackColor = System.Drawing.Color.Transparent;
            this.btnTickets.BorderColor = System.Drawing.Color.Transparent;
            this.btnTickets.BorderRadius = 10;
            this.btnTickets.BorderSize = 0;
            this.btnTickets.Checked = false;
            this.btnTickets.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(107)))), ((int)(((byte)(254)))));
            this.btnTickets.CheckedForeColor = System.Drawing.Color.White;
            this.btnTickets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTickets.FlatAppearance.BorderSize = 0;
            this.btnTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTickets.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTickets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.btnTickets.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.btnTickets.Location = new System.Drawing.Point(10, 320);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Size = new System.Drawing.Size(240, 50);
            this.btnTickets.TabIndex = 5;
            this.btnTickets.Text = "   Vé đã bán";
            this.btnTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTickets.UseVisualStyleBackColor = false;
            // 
            // btnRevenue
            // 
            this.btnRevenue.BackColor = System.Drawing.Color.Transparent;
            this.btnRevenue.BorderColor = System.Drawing.Color.Transparent;
            this.btnRevenue.BorderRadius = 10;
            this.btnRevenue.BorderSize = 0;
            this.btnRevenue.Checked = false;
            this.btnRevenue.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(107)))), ((int)(((byte)(254)))));
            this.btnRevenue.CheckedForeColor = System.Drawing.Color.White;
            this.btnRevenue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevenue.FlatAppearance.BorderSize = 0;
            this.btnRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevenue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.btnRevenue.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.btnRevenue.Location = new System.Drawing.Point(10, 265);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(240, 50);
            this.btnRevenue.TabIndex = 4;
            this.btnRevenue.Text = "   Doanh thu";
            this.btnRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRevenue.UseVisualStyleBackColor = false;
            // 
            // btnMovies
            // 
            this.btnMovies.BackColor = System.Drawing.Color.Transparent;
            this.btnMovies.BorderColor = System.Drawing.Color.Transparent;
            this.btnMovies.BorderRadius = 10;
            this.btnMovies.BorderSize = 0;
            this.btnMovies.Checked = false;
            this.btnMovies.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(107)))), ((int)(((byte)(254)))));
            this.btnMovies.CheckedForeColor = System.Drawing.Color.White;
            this.btnMovies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMovies.FlatAppearance.BorderSize = 0;
            this.btnMovies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovies.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMovies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.btnMovies.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.btnMovies.Location = new System.Drawing.Point(10, 210);
            this.btnMovies.Name = "btnMovies";
            this.btnMovies.Size = new System.Drawing.Size(240, 50);
            this.btnMovies.TabIndex = 3;
            this.btnMovies.Text = "   Phim";
            this.btnMovies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMovies.UseVisualStyleBackColor = false;
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSchedule.BorderColor = System.Drawing.Color.Transparent;
            this.btnSchedule.BorderRadius = 10;
            this.btnSchedule.BorderSize = 0;
            this.btnSchedule.Checked = false;
            this.btnSchedule.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(107)))), ((int)(((byte)(254)))));
            this.btnSchedule.CheckedForeColor = System.Drawing.Color.White;
            this.btnSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.btnSchedule.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.btnSchedule.Location = new System.Drawing.Point(10, 155);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(240, 50);
            this.btnSchedule.TabIndex = 2;
            this.btnSchedule.Text = "   Lịch chiếu";
            this.btnSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BorderColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BorderRadius = 10;
            this.btnDashboard.BorderSize = 0;
            this.btnDashboard.Checked = true;
            this.btnDashboard.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(107)))), ((int)(((byte)(254)))));
            this.btnDashboard.CheckedForeColor = System.Drawing.Color.White;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.btnDashboard.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.btnDashboard.Location = new System.Drawing.Point(10, 100);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(240, 50);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "   Tổng quan";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(20, 25);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(240, 45);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "Cinema CMS";
            // 
            // frmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.DoubleBuffered = true;
            this.Name = "frmDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cinema CMS Dashboard";
            this.Load += new System.EventHandler(this.frmDashBoard_Load);
            this.mainContentPanel.ResumeLayout(false);
            this.mainContentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingShows)).EndInit();
            this.pnlHotMovies.ResumeLayout(false);
            this.pnlHotMovies.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private ProjectCinema.UI.RoundedPanel sidebarPanel;
        private ProjectCinema.UI.RoundedPanel mainContentPanel;
        private System.Windows.Forms.Label logoLabel;
        private ProjectCinema.UI.RoundedButton btnDashboard;
        private ProjectCinema.UI.RoundedButton btnSchedule;
        private ProjectCinema.UI.RoundedButton btnMovies;
        private ProjectCinema.UI.RoundedButton btnRevenue;
        private ProjectCinema.UI.RoundedButton btnTickets;
        private ProjectCinema.UI.RoundedButton btnExit;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label lblDescription;
        private ProjectCinema.UI.SummaryCard cardRevenue;
        private ProjectCinema.UI.SummaryCard cardShows;
        private ProjectCinema.UI.SummaryCard cardFillingRate;
        private ProjectCinema.UI.RoundedPanel pnlChart;
        private ProjectCinema.UI.RoundedPanel pnlHotMovies;
        private System.Windows.Forms.Label lblHotMoviesTitle;
        private ProjectCinema.UI.MovieListItem movie1;
        private ProjectCinema.UI.MovieListItem movie2;
        private ProjectCinema.UI.MovieListItem movie3;
        private System.Windows.Forms.Label lblUpcomingShowsTitle;
        private System.Windows.Forms.DataGridView dgvUpcomingShows;

        #endregion
    }
}