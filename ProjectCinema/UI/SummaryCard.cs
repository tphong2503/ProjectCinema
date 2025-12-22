using System.Drawing;
using System.Windows.Forms;

namespace ProjectCinema.UI
{
    public partial class SummaryCard : UserControl
    {
        private RoundedPanel mainPanel;
        private Label lblTitle;
        private Label lblValue;
        private Label lblSubValue;
        private PictureBox picIcon;

        public SummaryCard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mainPanel = new RoundedPanel();
            this.lblTitle = new Label();
            this.lblValue = new Label();
            this.lblSubValue = new Label();
            this.picIcon = new PictureBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = Color.FromArgb(19, 23, 32);
            this.mainPanel.BorderRadius = 15;
            this.mainPanel.Controls.Add(this.picIcon);
            this.mainPanel.Controls.Add(this.lblSubValue);
            this.mainPanel.Controls.Add(this.lblValue);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Location = new Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new Size(250, 120);
            this.mainPanel.TabIndex = 0;
            // 
            // picIcon
            // 
            this.picIcon.Location = new Point(20, 15);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new Size(24, 24);
            this.picIcon.SizeMode = PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblTitle.ForeColor = Color.FromArgb(160, 165, 177);
            this.lblTitle.Location = new Point(55, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(29, 15);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblValue.ForeColor = Color.White;
            this.lblValue.Location = new Point(20, 50);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new Size(130, 30);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "12,500,000 đ";
            // 
            // lblSubValue
            // 
            this.lblSubValue.AutoSize = true;
            this.lblSubValue.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            this.lblSubValue.ForeColor = Color.FromArgb(46, 204, 113);
            this.lblSubValue.Location = new Point(22, 90);
            this.lblSubValue.Name = "lblSubValue";
            this.lblSubValue.Size = new Size(76, 13);
            this.lblSubValue.TabIndex = 3;
            this.lblSubValue.Text = "+15% so với hôm qua";
            // 
            // SummaryCard
            // 
            this.Controls.Add(this.mainPanel);
            this.Name = "SummaryCard";
            this.Size = new Size(250, 120);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
        }

        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public string Value { get => lblValue.Text; set => lblValue.Text = value; }
        public string SubValue { get => lblSubValue.Text; set => lblSubValue.Text = value; }
        public Color SubValueColor { get => lblSubValue.ForeColor; set => lblSubValue.ForeColor = value; }
        public Image Icon { get => picIcon.Image; set => picIcon.Image = value; }
    }
}
