namespace ProjectCinema.GUI
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tcBaoCao = new System.Windows.Forms.TabControl();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.pnlDoanhThuFilter = new System.Windows.Forms.Panel();
            this.btnXemDoanhThu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnlDoanhThuSummary = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            
            this.tabPhim = new System.Windows.Forms.TabPage();
            this.dgvPhim = new System.Windows.Forms.DataGridView();
            this.pnlPhimHeader = new System.Windows.Forms.Panel();
            this.btnRefreshPhim = new System.Windows.Forms.Button();

            this.tabVe = new System.Windows.Forms.TabPage();
            this.pnlVeFilter = new System.Windows.Forms.Panel();
            this.btnTimVe = new System.Windows.Forms.Button();
            this.txtTimVe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvVe = new System.Windows.Forms.DataGridView();

            this.tcBaoCao.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            this.pnlDoanhThuFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.pnlDoanhThuSummary.SuspendLayout();
            this.tabPhim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).BeginInit();
            this.pnlPhimHeader.SuspendLayout();
            this.tabVe.SuspendLayout();
            this.pnlVeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.SuspendLayout();

            // 
            // tcBaoCao
            // 
            this.tcBaoCao.Controls.Add(this.tabDoanhThu);
            this.tcBaoCao.Controls.Add(this.tabPhim);
            this.tcBaoCao.Controls.Add(this.tabVe);
            this.tcBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tcBaoCao.Location = new System.Drawing.Point(0, 0);
            this.tcBaoCao.Name = "tcBaoCao";
            this.tcBaoCao.SelectedIndex = 0;
            this.tcBaoCao.Size = new System.Drawing.Size(1100, 650);
            this.tcBaoCao.TabIndex = 0;

            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.tabDoanhThu.Controls.Add(this.pnlDoanhThuSummary);
            this.tabDoanhThu.Controls.Add(this.pnlDoanhThuFilter);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 32);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThu.Size = new System.Drawing.Size(1092, 614);
            this.tabDoanhThu.TabIndex = 0;
            this.tabDoanhThu.Text = "Doanh thu theo ngày";
            this.tabDoanhThu.UseVisualStyleBackColor = true;

            // pnlDoanhThuFilter
            this.pnlDoanhThuFilter.Controls.Add(this.btnXemDoanhThu);
            this.pnlDoanhThuFilter.Controls.Add(this.label2);
            this.pnlDoanhThuFilter.Controls.Add(this.dtpDenNgay);
            this.pnlDoanhThuFilter.Controls.Add(this.label1);
            this.pnlDoanhThuFilter.Controls.Add(this.dtpTuNgay);
            this.pnlDoanhThuFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDoanhThuFilter.Height = 60;

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "Từ ngày:";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 16);
            this.dtpTuNgay.Width = 120;

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 20);
            this.label2.Text = "Đến ngày:";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(320, 16);
            this.dtpDenNgay.Width = 120;

            this.btnXemDoanhThu.Text = "Xem Báo Cáo";
            this.btnXemDoanhThu.Location = new System.Drawing.Point(480, 15);
            this.btnXemDoanhThu.Width = 150;
            this.btnXemDoanhThu.BackColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.btnXemDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnXemDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDoanhThu.Click += new System.EventHandler(this.btnXemDoanhThu_Click);

            // dgvDoanhThu
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;

            // pnlDoanhThuSummary
            this.pnlDoanhThuSummary.Controls.Add(this.lblTongDoanhThu);
            this.pnlDoanhThuSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDoanhThuSummary.Height = 50;
            this.pnlDoanhThuSummary.BackColor = System.Drawing.Color.WhiteSmoke;

            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.Red;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(20, 10);
            this.lblTongDoanhThu.Text = "Tổng cộng: 0 VNĐ";

            // 
            // tabPhim
            // 
            this.tabPhim.Controls.Add(this.dgvPhim);
            this.tabPhim.Controls.Add(this.pnlPhimHeader);
            this.tabPhim.Text = "Top Phim Bán Chạy";
            this.tabPhim.Padding = new System.Windows.Forms.Padding(3);

            this.pnlPhimHeader.Controls.Add(this.btnRefreshPhim);
            this.pnlPhimHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPhimHeader.Height = 50;
            
            this.btnRefreshPhim.Text = "Làm Mới";
            this.btnRefreshPhim.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshPhim.Click += new System.EventHandler(this.btnRefreshPhim_Click);

            this.dgvPhim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhim.BackgroundColor = System.Drawing.Color.White;

            //
            // tabVe
            //
            this.tabVe.Controls.Add(this.dgvVe);
            this.tabVe.Controls.Add(this.pnlVeFilter);
            this.tabVe.Text = "Lịch sử vé bán";
            
            this.pnlVeFilter.Controls.Add(this.label3);
            this.pnlVeFilter.Controls.Add(this.txtTimVe);
            this.pnlVeFilter.Controls.Add(this.btnTimVe);
            this.pnlVeFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVeFilter.Height = 60;

            this.label3.Text = "Tìm kiếm:";
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.AutoSize = true;
            
            this.txtTimVe.Location = new System.Drawing.Point(100, 16);
            this.txtTimVe.Width = 300;
            
            this.btnTimVe.Text = "Tìm kiếm";
            this.btnTimVe.Location = new System.Drawing.Point(420, 15);
            this.btnTimVe.Width = 100;
            this.btnTimVe.Click += new System.EventHandler(this.btnTimVe_Click);

            this.dgvVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVe.BackgroundColor = System.Drawing.Color.White;

            // Form
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tcBaoCao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "Báo Cáo Thống Kê";

            this.tcBaoCao.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            this.pnlDoanhThuFilter.ResumeLayout(false);
            this.pnlDoanhThuFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.pnlDoanhThuSummary.ResumeLayout(false);
            this.pnlDoanhThuSummary.PerformLayout();
            
            this.tabPhim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).EndInit();
            this.pnlPhimHeader.ResumeLayout(false);

            this.tabVe.ResumeLayout(false);
            this.pnlVeFilter.ResumeLayout(false);
            this.pnlVeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tcBaoCao;
        private System.Windows.Forms.TabPage tabDoanhThu;
        private System.Windows.Forms.TabPage tabPhim;
        private System.Windows.Forms.TabPage tabVe;
        
        // Tab Doanh Thu Controls
        private System.Windows.Forms.Panel pnlDoanhThuFilter;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXemDoanhThu;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Panel pnlDoanhThuSummary;
        private System.Windows.Forms.Label lblTongDoanhThu;

        // Tab Phim Controls
        private System.Windows.Forms.Panel pnlPhimHeader;
        private System.Windows.Forms.DataGridView dgvPhim;
        private System.Windows.Forms.Button btnRefreshPhim;

        // Tab Ve Controls
        private System.Windows.Forms.Panel pnlVeFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimVe;
        private System.Windows.Forms.Button btnTimVe;
        private System.Windows.Forms.DataGridView dgvVe;
    }
}
