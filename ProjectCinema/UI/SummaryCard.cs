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
            this.DoubleBuffered = true;
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
            this.mainPanel.BorderRadius = 20;
            this.mainPanel.Controls.Add(this.picIcon);
            this.mainPanel.Controls.Add(this.lblSubValue);
            this.mainPanel.Controls.Add(this.lblValue);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Location = new Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new Size(300, 120);
            this.mainPanel.TabIndex = 0;
            // 
            // picIcon
            // 
            this.picIcon.BackColor = Color.Transparent;
            this.picIcon.Location = new Point(20, 18);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new Size(24, 24);
            this.picIcon.SizeMode = PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblTitle.ForeColor = Color.FromArgb(180, 185, 197);
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(33, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.BackColor = Color.Transparent;
            this.lblValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblValue.ForeColor = Color.White;
            this.lblValue.Location = new Point(18, 52);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new Size(160, 32);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "0 đ";
            // 
            // lblSubValue
            // 
            this.lblSubValue.AutoSize = true;
            this.lblSubValue.BackColor = Color.Transparent;
            this.lblSubValue.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            this.lblSubValue.ForeColor = Color.FromArgb(46, 204, 113);
            this.lblSubValue.Location = new Point(20, 92);
            this.lblSubValue.Name = "lblSubValue";
            this.lblSubValue.Size = new Size(76, 13);
            this.lblSubValue.TabIndex = 3;
            this.lblSubValue.Text = "Summary text";
            // 
            // SummaryCard
            // 
            this.Controls.Add(this.mainPanel);
            this.Name = "SummaryCard";
            this.Size = new Size(300, 120);
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

        public Color GradientColor1 { get => mainPanel.GradientColor1; set => mainPanel.GradientColor1 = value; }
        public Color GradientColor2 { get => mainPanel.GradientColor2; set => mainPanel.GradientColor2 = value; }
        public float GradientAngle { get => mainPanel.GradientAngle; set => mainPanel.GradientAngle = value; }
        public int BorderRadius { get => mainPanel.BorderRadius; set => mainPanel.BorderRadius = value; }
    }
}
