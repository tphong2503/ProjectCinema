using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjectCinema.BUS;
using ProjectCinema.DAL.Models;

namespace ProjectCinema.GUI
{
    public partial class frmQuanLySuatChieu : Form
    {
        private SuatChieuBUS _suatChieuBUS;
        private PhimBUS _phimBUS;
        private PhongChieuBUS _phongBUS;

        private DataGridView dgvSuatChieu;
        private ComboBox cboPhim;
        private ComboBox cboPhong;
        private DateTimePicker dtpNgay;
        private DateTimePicker dtpGio;
        private TextBox txtGiaVe;
        private Label lblId;
        private Button btnAdd;
        private Button btnDelete;

        private Color PrimaryColor = Color.FromArgb(84, 110, 122); 

        public frmQuanLySuatChieu()
        {
            InitializeComponent();
            SetupUI();
            _suatChieuBUS = new SuatChieuBUS();
            _phimBUS = new PhimBUS();
            _phongBUS = new PhongChieuBUS();
            
            LoadCombos();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetupUI()
        {
            this.Text = "Quản Lý Suất Chiếu";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(84, 110, 122) };
            Label lblHeader = new Label
            {
                Text = "XẾP LỊCH CHIẾU PHIM",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            pnlHeader.Controls.Add(lblHeader);

            Panel pnlInput = new Panel
            {
                Location = new Point(620, 80),
                Size = new Size(350, 500),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            SetupInputPanel(pnlInput);

            dgvSuatChieu = new DataGridView
            {
                Location = new Point(20, 80),
                Size = new Size(580, 580),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 10F),
                AutoGenerateColumns = false
            };
            dgvSuatChieu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 110, 122);
            dgvSuatChieu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSuatChieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSuatChieu.EnableHeadersVisualStyles = false;
            dgvSuatChieu.SelectionChanged += DgvSuatChieu_SelectionChanged;

            // Các cột thủ công
            dgvSuatChieu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "MaSuatChieu", Width = 50 });
            dgvSuatChieu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phim", DataPropertyName = "PhimDisplay" });
            dgvSuatChieu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phòng", DataPropertyName = "PhongDisplay", Width = 80 });
            dgvSuatChieu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày", DataPropertyName = "NgayHienThi", Width = 100 });
            dgvSuatChieu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giờ", DataPropertyName = "GioHienThi", Width = 80 });
            
            this.Controls.Add(dgvSuatChieu);
            this.Controls.Add(pnlInput);
            this.Controls.Add(pnlHeader);
        }

        private void SetupInputPanel(Panel pnl)
        {
            lblId = new Label { Visible = false };
            
            Label lblPhim = new Label { Text = "Chọn Phim:", Location = new Point(10, 20), AutoSize = true };
            cboPhim = new ComboBox { Location = new Point(10, 45), Size = new Size(320, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblPhong = new Label { Text = "Chọn Phòng:", Location = new Point(10, 90), AutoSize = true };
            cboPhong = new ComboBox { Location = new Point(10, 115), Size = new Size(320, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblNgay = new Label { Text = "Ngày chiếu:", Location = new Point(10, 160), AutoSize = true };
            dtpNgay = new DateTimePicker { Location = new Point(10, 185), Size = new Size(320, 30), Format = DateTimePickerFormat.Short };

            Label lblGio = new Label { Text = "Giờ chiếu:", Location = new Point(10, 230), AutoSize = true };
            dtpGio = new DateTimePicker { Location = new Point(10, 255), Size = new Size(320, 30), Format = DateTimePickerFormat.Time, ShowUpDown = true };

            Label lblGia = new Label { Text = "Giá vé cơ bản:", Location = new Point(10, 300), AutoSize = true };
            txtGiaVe = new TextBox { Location = new Point(10, 325), Size = new Size(320, 30) };
            txtGiaVe.KeyPress += (s, e) => e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            btnAdd = new Button { Text = "Thêm Suất", Location = new Point(10, 380), Size = new Size(150, 40), BackColor = Color.FromArgb(84, 110, 122), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnAdd.Click += BtnAdd_Click;

            btnDelete = new Button { Text = "Xóa Suất", Location = new Point(170, 380), Size = new Size(150, 40), BackColor = Color.Red, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += BtnDelete_Click;

            pnl.Controls.Add(lblId);
            pnl.Controls.Add(lblPhim); pnl.Controls.Add(cboPhim);
            pnl.Controls.Add(lblPhong); pnl.Controls.Add(cboPhong);
            pnl.Controls.Add(lblNgay); pnl.Controls.Add(dtpNgay);
            pnl.Controls.Add(lblGio); pnl.Controls.Add(dtpGio);
            pnl.Controls.Add(lblGia); pnl.Controls.Add(txtGiaVe);
            pnl.Controls.Add(btnAdd); pnl.Controls.Add(btnDelete);
        }

        private void LoadCombos()
        {
            cboPhim.DataSource = _phimBUS.GetAllPhim();
            cboPhim.DisplayMember = "TenPhim";
            cboPhim.ValueMember = "MaPhim";

            cboPhong.DataSource = _phongBUS.GetAllPhongChieu();
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }

        // Lớp Helper để hiển thị dữ liệu gọn gàng trên Grid
        private class SuatChieuViewModel
        {
            public int MaSuatChieu { get; set; }
            public string PhimDisplay { get; set; }
            public string PhongDisplay { get; set; }
            public string NgayHienThi { get; set; }
            public string GioHienThi { get; set; }
        }

        private void LoadData()
        {
            var rawList = _suatChieuBUS.GetAllSuatChieu();
            var viewList = new List<SuatChieuViewModel>();

            foreach(var item in rawList)
            {
                viewList.Add(new SuatChieuViewModel
                {
                    MaSuatChieu = item.MaSuatChieu,
                    PhimDisplay = item.Phim != null ? item.Phim.TenPhim : "N/A",
                    PhongDisplay = item.PhongChieu != null ? item.PhongChieu.TenPhong : "N/A",
                    NgayHienThi = item.NgayChieu.HasValue ? item.NgayChieu.Value.ToString("dd/MM/yyyy") : "",
                    GioHienThi = item.GioBatDau.HasValue ? item.GioBatDau.Value.ToString(@"hh\:mm") : ""
                });
            }

            dgvSuatChieu.DataSource = viewList.OrderByDescending(x => DateTime.ParseExact(x.NgayHienThi, "dd/MM/yyyy", null))
                                              .ThenByDescending(x => x.GioHienThi)
                                              .ToList();
        }

        private void DgvSuatChieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSuatChieu.SelectedRows.Count > 0)
            {
                lblId.Text = dgvSuatChieu.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPhim.SelectedValue == null || cboPhong.SelectedValue == null) return;
                
                SuatChieu sc = new SuatChieu
                {
                    MaPhim = (int)cboPhim.SelectedValue,
                    MaPhong = (int)cboPhong.SelectedValue,
                    NgayChieu = dtpNgay.Value.Date,
                    GioBatDau = dtpGio.Value.TimeOfDay,
                    GiaVeCoBan = decimal.Parse(txtGiaVe.Text)
                };

                if (_suatChieuBUS.AddSuatChieu(sc))
                {
                    CustomMessageBox.Show("Thêm suất chiếu thành công!", "Thành công", MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblId.Text)) return;

            if (CustomMessageBox.Show("Xóa suất chiếu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_suatChieuBUS.DeleteSuatChieu(int.Parse(lblId.Text)))
                    {
                        CustomMessageBox.Show("Đã xóa!", "Thành công", MessageBoxIcon.Information);
                        LoadData();
                        lblId.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(ex.Message, "Lỗi", MessageBoxIcon.Error);
                }
            }
        }
    }
}
