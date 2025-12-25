namespace QLRP
{
    partial class frmQLGhe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvGhe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaGhe;
        private System.Windows.Forms.TextBox txtTenGhe;
        private System.Windows.Forms.TextBox txtLoaiGhe;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvGhe = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaGhe = new System.Windows.Forms.TextBox();
            this.txtTenGhe = new System.Windows.Forms.TextBox();
            this.txtLoaiGhe = new System.Windows.Forms.TextBox();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGhe
            // 
            this.dgvGhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGhe.Location = new System.Drawing.Point(12, 12);
            this.dgvGhe.Name = "dgvGhe";
            this.dgvGhe.RowHeadersWidth = 51;
            this.dgvGhe.RowTemplate.Height = 24;
            this.dgvGhe.Size = new System.Drawing.Size(600, 250);
            this.dgvGhe.TabIndex = 0;
            this.dgvGhe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGhe_CellClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã ghế";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên ghế";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loại ghế";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Trạng thái";
            // 
            // txtMaGhe
            // 
            this.txtMaGhe.Location = new System.Drawing.Point(120, 277);
            this.txtMaGhe.Name = "txtMaGhe";
            this.txtMaGhe.Size = new System.Drawing.Size(100, 22);
            this.txtMaGhe.TabIndex = 5;
            // 
            // txtTenGhe
            // 
            this.txtTenGhe.Location = new System.Drawing.Point(120, 317);
            this.txtTenGhe.Name = "txtTenGhe";
            this.txtTenGhe.Size = new System.Drawing.Size(100, 22);
            this.txtTenGhe.TabIndex = 6;
            // 
            // txtLoaiGhe
            // 
            this.txtLoaiGhe.Location = new System.Drawing.Point(120, 357);
            this.txtLoaiGhe.Name = "txtLoaiGhe";
            this.txtLoaiGhe.Size = new System.Drawing.Size(100, 22);
            this.txtLoaiGhe.TabIndex = 7;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(120, 397);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(100, 22);
            this.txtTrangThai.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(350, 277);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(350, 317);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(350, 357);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(450, 277);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 12;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(450, 317);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmQLGhe
            // 
            this.ClientSize = new System.Drawing.Size(626, 437);
            this.Controls.Add(this.dgvGhe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaGhe);
            this.Controls.Add(this.txtTenGhe);
            this.Controls.Add(this.txtLoaiGhe);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Name = "frmQLGhe";
            this.Text = "Quản lý ghế";
            this.Load += new System.EventHandler(this.frmQLGhe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
