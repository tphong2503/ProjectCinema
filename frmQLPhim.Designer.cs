namespace QLRP
{
    partial class frmQLPhim
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPhim = new System.Windows.Forms.DataGridView();
            this.txtTenPhim = new System.Windows.Forms.TextBox();
            this.btnChonPhim = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Size = new System.Drawing.Size(600, 60);
            this.lblTitle.Text = "QUẢN LÝ DANH SÁCH PHIM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // dgvPhim
            this.dgvPhim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhim.Location = new System.Drawing.Point(12, 120);
            this.dgvPhim.Name = "dgvPhim";
            this.dgvPhim.Size = new System.Drawing.Size(576, 250);
            this.dgvPhim.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhim_CellClick);

            // txtTenPhim
            this.txtTenPhim.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTenPhim.Location = new System.Drawing.Point(120, 80);
            this.txtTenPhim.Name = "txtTenPhim";
            this.txtTenPhim.ReadOnly = true;
            this.txtTenPhim.Size = new System.Drawing.Size(300, 26);

            // lblHD
            this.lblHD.AutoSize = true;
            this.lblHD.Location = new System.Drawing.Point(12, 85);
            this.lblHD.Text = "Phim đang chọn:";

            // btnChonPhim
            this.btnChonPhim.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChonPhim.ForeColor = System.Drawing.Color.White;
            this.btnChonPhim.Location = new System.Drawing.Point(430, 78);
            this.btnChonPhim.Size = new System.Drawing.Size(150, 30);
            this.btnChonPhim.Text = "ĐẶT VÉ PHIM NÀY";
            this.btnChonPhim.Click += new System.EventHandler(this.btnChonPhim_Click);

            // frmQLPhim
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnChonPhim);
            this.Controls.Add(this.txtTenPhim);
            this.Controls.Add(this.lblHD);
            this.Controls.Add(this.dgvPhim);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmQLPhim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý phim";
            this.Load += new System.EventHandler(this.frmQLPhim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvPhim;
        private System.Windows.Forms.TextBox txtTenPhim;
        private System.Windows.Forms.Button btnChonPhim;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHD;
    }
}