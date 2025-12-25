namespace QLRP.GUI
{
    partial class frmQLSuatChieu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSuatChieu;
        private System.Windows.Forms.ComboBox cboPhim;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.DateTimePicker dtpGio;
        private System.Windows.Forms.TextBox txtGiaVe;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvSuatChieu = new System.Windows.Forms.DataGridView();
            this.cboPhim = new System.Windows.Forms.ComboBox();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpGio = new System.Windows.Forms.DateTimePicker();
            this.txtGiaVe = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuatChieu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSuatChieu
            // 
            this.dgvSuatChieu.ColumnHeadersHeight = 29;
            this.dgvSuatChieu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSuatChieu.Location = new System.Drawing.Point(0, 237);
            this.dgvSuatChieu.Name = "dgvSuatChieu";
            this.dgvSuatChieu.RowHeadersWidth = 51;
            this.dgvSuatChieu.Size = new System.Drawing.Size(739, 250);
            this.dgvSuatChieu.TabIndex = 0;
            this.dgvSuatChieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuatChieu_CellClick);
            // 
            // cboPhim
            // 
            this.cboPhim.Location = new System.Drawing.Point(30, 30);
            this.cboPhim.Name = "cboPhim";
            this.cboPhim.Size = new System.Drawing.Size(121, 24);
            this.cboPhim.TabIndex = 1;
            // 
            // cboPhong
            // 
            this.cboPhong.Location = new System.Drawing.Point(30, 70);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(121, 24);
            this.cboPhong.TabIndex = 2;
            this.cboPhong.SelectedIndexChanged += new System.EventHandler(this.cboPhong_SelectedIndexChanged);
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(30, 110);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(200, 22);
            this.dtpNgay.TabIndex = 3;
            // 
            // dtpGio
            // 
            this.dtpGio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGio.Location = new System.Drawing.Point(30, 150);
            this.dtpGio.Name = "dtpGio";
            this.dtpGio.ShowUpDown = true;
            this.dtpGio.Size = new System.Drawing.Size(200, 22);
            this.dtpGio.TabIndex = 4;
            // 
            // txtGiaVe
            // 
            this.txtGiaVe.Location = new System.Drawing.Point(30, 190);
            this.txtGiaVe.Name = "txtGiaVe";
            this.txtGiaVe.Size = new System.Drawing.Size(100, 22);
            this.txtGiaVe.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(300, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(300, 70);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(300, 110);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmQLSuatChieu
            // 
            this.ClientSize = new System.Drawing.Size(739, 487);
            this.Controls.Add(this.dgvSuatChieu);
            this.Controls.Add(this.cboPhim);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.dtpGio);
            this.Controls.Add(this.txtGiaVe);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Name = "frmQLSuatChieu";
            this.Text = "Quản lý suất chiếu";
            this.Load += new System.EventHandler(this.frmQLSuatChieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuatChieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
