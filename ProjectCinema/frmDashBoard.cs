using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjectCinema
{
    public partial class frmDashBoard : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmDashBoard()
        {
            InitializeComponent();
            SetupDashboard();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void SetupDashboard()
        {
            // Add columns to DGV
            dgvUpcomingShows.Columns.Add("Time", "THỜI GIAN");
            dgvUpcomingShows.Columns.Add("Movie", "PHIM");
            dgvUpcomingShows.Columns.Add("Room", "PHÒNG CHIẾU");
            dgvUpcomingShows.Columns.Add("Sold", "ĐÃ BÁN");
            dgvUpcomingShows.Columns.Add("Status", "TRẠNG THÁI");

            // Style DGV
            dgvUpcomingShows.DefaultCellStyle.BackColor = Color.FromArgb(19, 23, 32);
            dgvUpcomingShows.DefaultCellStyle.ForeColor = Color.White;
            dgvUpcomingShows.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 107, 254);
            dgvUpcomingShows.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUpcomingShows.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 35, 45);
            dgvUpcomingShows.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUpcomingShows.EnableHeadersVisualStyles = false;

            // Add sample data
            dgvUpcomingShows.Rows.Add("18:30", "Dune: Part Two", "MAX-01", "142 / 180", "Đang chiếu");
            dgvUpcomingShows.Rows.Add("19:00", "Kung Fu Panda 4", "R03", "85 / 120", "Sắp chiếu");
            dgvUpcomingShows.Rows.Add("20:15", "Godzilla x Kong", "IMAX-02", "160 / 200", "Sắp chiếu");

            // Chart Paint Event
            pnlChart.Paint += PnlChart_Paint;
        }

        private void PnlChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

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

            // Draw line
            g.DrawLines(bluePen, points);

            // Draw points
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
    }
}
