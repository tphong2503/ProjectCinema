using System;
using System.Linq;
using System.Windows.Forms;
using ProjectCinema.BUS;

namespace ProjectCinema.GUI
{
    public partial class frmBaoCao : Form
    {
        private BaoCaoBUS _bus;

        public frmBaoCao()
        {
            InitializeComponent();
            _bus = new BaoCaoBUS();

            // Init Dates
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            LoadInitData();
            SetupAdditionalUI();
        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhim;

        private void SetupAdditionalUI()
        {
            // 1. Export Buttons
            Button btnExportDT = CreateExportButton(new System.Drawing.Point(650, 15));
            btnExportDT.Click += (s, e) => ExportToCSV(dgvDoanhThu, "DoanhThu");
            pnlDoanhThuFilter.Controls.Add(btnExportDT);

            Button btnExportPhim = CreateExportButton(new System.Drawing.Point(150, 10));
            btnExportPhim.Click += (s, e) => ExportToCSV(dgvPhim, "PhimBanChay");
            pnlPhimHeader.Controls.Add(btnExportPhim);

            Button btnExportVe = CreateExportButton(new System.Drawing.Point(530, 15));
            btnExportVe.Click += (s, e) => ExportToCSV(dgvVe, "LichSuVe");
            pnlVeFilter.Controls.Add(btnExportVe);

            // 2. Chart Phim (Pie)
            dgvPhim.Dock = DockStyle.Left;
            dgvPhim.Width = 600;

            chartPhim = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartPhim.Dock = DockStyle.Fill;
            chartPhim.MinimumSize = new System.Drawing.Size(100, 100); // Prevent 0 size error
            chartPhim.BackColor = System.Drawing.Color.White;

            var area = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartPhim.ChartAreas.Add(area);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Revenue",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "{0:N0}"
            };
            chartPhim.Series.Add(series);
            
            var title = new System.Windows.Forms.DataVisualization.Charting.Title
            {
                Text = "TỶ TRỌNG DOANH THU THEO PHIM",
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(84, 110, 122)
            };
            chartPhim.Titles.Add(title);

            // Legend
            var legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
            chartPhim.Legends.Add(legend);

            tabPhim.Controls.Add(chartPhim);
            chartPhim.BringToFront();
        }

        private Button CreateExportButton(System.Drawing.Point loc)
        {
            return new Button
            {
                Text = "Xuất Excel",
                Location = loc,
                Size = new System.Drawing.Size(100, 30),
                BackColor = System.Drawing.Color.SeaGreen,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
            };
        }

        private void ExportToCSV(DataGridView dgv, string fileName)
        {
            if (dgv.Rows.Count == 0)
            {
                CustomMessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Write Header
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sw.Write(dgv.Columns[i].HeaderText);
                            if (i < dgv.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();

                        // Write Rows
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                {
                                    string val = row.Cells[i].Value.ToString().Replace(",", " "); // Handle comma
                                    sw.Write(val);
                                }
                                if (i < dgv.Columns.Count - 1) sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                    CustomMessageBox.Show("Xuất file thành công!", "Thành công", MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxIcon.Error);
                }
            }
        }

        private void LoadInitData()
        {
            LoadDoanhThu();
            LoadPhimBanChay();
            LoadLichSuVe();
        }

        private void btnXemDoanhThu_Click(object sender, EventArgs e)
        {
            LoadDoanhThu();
        }

        private void LoadDoanhThu()
        {
            try
            {
                var data = _bus.GetDoanhThuTheoKhoangThoiGian(dtpTuNgay.Value, dtpDenNgay.Value);
                dgvDoanhThu.DataSource = data;

                // Format Header
                if (dgvDoanhThu.Columns["Ngay"] != null) dgvDoanhThu.Columns["Ngay"].HeaderText = "Ngày";
                if (dgvDoanhThu.Columns["TongDoanhThu"] != null)
                {
                    dgvDoanhThu.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu";
                    dgvDoanhThu.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
                }

                // Calculate Total
                decimal total = data.Sum(x => x.TongDoanhThu);
                lblTongDoanhThu.Text = "Tổng cộng: " + total.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi tải doanh thu: " + ex.Message);
            }
        }

        private void btnRefreshPhim_Click(object sender, EventArgs e)
        {
            LoadPhimBanChay();
        }

        private void LoadPhimBanChay()
        {
            try
            {
                var data = _bus.GetPhimBanChay();
                dgvPhim.DataSource = data;
                
                if (dgvPhim.Columns["DoanhThu"] != null) dgvPhim.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";

                // Bind to Chart
                if (chartPhim != null)
                {
                    chartPhim.Series[0].Points.Clear();
                    foreach (var item in data)
                    {
                        if (item.DoanhThu > 0)
                        {
                             var p = chartPhim.Series[0].Points.Add(Convert.ToDouble(item.DoanhThu));
                             p.AxisLabel = item.TenPhim;
                             p.LegendText = item.TenPhim;
                             p.Label = "#PERCENT"; // Show percentage on slice
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi tải phim: " + ex.Message);
            }
        }

        private void btnTimVe_Click(object sender, EventArgs e)
        {
            LoadLichSuVe();
        }

        private void LoadLichSuVe()
        {
            try
            {
                var data = _bus.GetLichSuVeBan(txtTimVe.Text.Trim());
                dgvVe.DataSource = data;

                if (dgvVe.Columns["GiaBan"] != null) dgvVe.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                if (dgvVe.Columns["GioBatDau"] != null) dgvVe.Columns["GioBatDau"].DefaultCellStyle.Format = @"hh\:mm";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi tải vé: " + ex.Message);
            }
        }
    }
}
