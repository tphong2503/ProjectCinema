using System.Drawing;
using System.Windows.Forms;

namespace ProjectCinema.UI
{
    public partial class MovieListItem : UserControl
    {
        private Panel mainPanel;
        private Label lblTitle;
        private Label lblInfo;
        private CustomProgressBar progressBar;
        private Label lblPercentage;
        private PictureBox picMovie;

        public MovieListItem()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mainPanel = new Panel();
            this.lblTitle = new Label();
            this.lblInfo = new Label();
            this.progressBar = new CustomProgressBar();
            this.lblPercentage = new Label();
            this.picMovie = new PictureBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = Color.Transparent;
            this.mainPanel.Controls.Add(this.picMovie);
            this.mainPanel.Controls.Add(this.lblPercentage);
            this.mainPanel.Controls.Add(this.progressBar);
            this.mainPanel.Controls.Add(this.lblInfo);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Location = new Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new Size(250, 70);
            this.mainPanel.TabIndex = 0;
            // 
            // picMovie
            // 
            this.picMovie.Location = new Point(5, 10);
            this.picMovie.Name = "picMovie";
            this.picMovie.Size = new Size(40, 50);
            this.picMovie.SizeMode = PictureBoxSizeMode.Zoom;
            this.picMovie.TabIndex = 0;
            this.picMovie.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(55, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(91, 15);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Movie Title";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new Font("Segoe UI", 8F);
            this.lblInfo.ForeColor = Color.FromArgb(160, 165, 177);
            this.lblInfo.Location = new Point(55, 28);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new Size(78, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Genre • Time";
            // 
            // progressBar
            // 
            this.progressBar.BorderRadius = 3;
            this.progressBar.ProgressBackColor = Color.FromArgb(30, 35, 45);
            this.progressBar.Location = new Point(58, 48);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = Color.FromArgb(30, 107, 254);
            this.progressBar.Size = new Size(150, 6);
            this.progressBar.TabIndex = 3;
            this.progressBar.Value = 50;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblPercentage.ForeColor = Color.FromArgb(160, 165, 177);
            this.lblPercentage.Location = new Point(215, 44);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new Size(29, 13);
            this.lblPercentage.TabIndex = 4;
            this.lblPercentage.Text = "50%";
            // 
            // MovieListItem
            // 
            this.Controls.Add(this.mainPanel);
            this.Name = "MovieListItem";
            this.Size = new Size(250, 70);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        public string MovieTitle { get => lblTitle.Text; set => lblTitle.Text = value; }
        public string MovieInfo { get => lblInfo.Text; set => lblInfo.Text = value; }
        public int Value { get => progressBar.Value; set { progressBar.Value = value; lblPercentage.Text = value + "%"; } }
        public Color ProgressColor { get => progressBar.ProgressColor; set { progressBar.ProgressColor = value; } }
        public Image MovieImage { get => picMovie.Image; set => picMovie.Image = value; }
    }
}
