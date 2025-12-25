using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLRP
{
    public partial class frmQLGhe : Form
    {
        private readonly string tenPhimDangChon = "";
        private readonly Dictionary<string, NumericUpDown> dictDichVu = new Dictionary<string, NumericUpDown>();

        const int GIA_THUONG = 60000;
        const int GIA_VIP = 90000;
        const int GIA_SWEETBOX = 250000;

        public frmQLGhe() // Constructor mặc định cho Designer
        {
            InitializeComponent();
        }

        public frmQLGhe(string tenPhim) // Constructor nhận tên phim từ frmQLPhim
        {
            InitializeComponent();
            this.tenPhimDangChon = tenPhim;
        }

        private void frmQLGhe_Load(object sender, EventArgs e)
        {
            lblManAnh.Text = "MÀN HÌNH: " + tenPhimDangChon;
            this.Text = "ĐẶT VÉ PHIM: " + tenPhimDangChon;
            VeSoDoGhe();
            NapMenuBapNuoc();
        }

        private void VeSoDoGhe()
        {
            pnlSeats.Controls.Clear();
            int bSize = 35, gap = 6;
            for (int r = 0; r < 10; r++)
            {
                char rowChar = (char)('A' + r);
                for (int c = 0; c < 14; c++)
                {
                    if (c == 3 || c == 11) continue;
                    Button btn = new Button { FlatStyle = FlatStyle.Flat, Font = new Font("Arial", 7, FontStyle.Bold), Size = new Size(bSize, bSize) };

                    if (r == 9) // Hàng cuối Sweetbox
                    {
                        if (c % 2 != 0) continue;
                        btn.Size = new Size(bSize * 2 + gap, bSize);
                        btn.BackColor = Color.HotPink;
                        btn.Tag = GIA_SWEETBOX;
                        btn.Text = "SWEET " + (c / 2 + 1);
                    }
                    else if (r >= 4 && r <= 7) // Ghế VIP
                    {
                        btn.BackColor = Color.Orange;
                        btn.Tag = GIA_VIP;
                        btn.Text = rowChar + (c + 1).ToString();
                    }
                    else // Ghế thường
                    {
                        btn.BackColor = Color.LightGray;
                        btn.Tag = GIA_THUONG;
                        btn.Text = rowChar + (c + 1).ToString();
                    }

                    btn.Location = new Point(30 + c * (bSize + gap), 10 + r * (bSize + gap));
                    btn.Click += Ghe_Click;
                    pnlSeats.Controls.Add(btn);
                }
            }
        }

        private void Ghe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor == Color.Black) return;

            if (btn.ForeColor != Color.White) // Đang chọn
            {
                btn.BackColor = Color.DodgerBlue;
                btn.ForeColor = Color.White;
            }
            else // Hủy chọn
            {
                btn.ForeColor = Color.Black;
                int gia = (int)btn.Tag;
                btn.BackColor = (gia == GIA_SWEETBOX) ? Color.HotPink : (gia == GIA_VIP ? Color.Orange : Color.LightGray);
            }
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            long tong = 0;
            foreach (Control c in pnlSeats.Controls)
                if (c is Button b && b.BackColor == Color.DodgerBlue) tong += (int)b.Tag;

            foreach (var item in dictDichVu)
                tong += (long)item.Value.Value * (int)item.Value.Tag;

            lblTotal.Text = string.Format("{0:N0} VNĐ", tong);
        }

        private void NapMenuBapNuoc()
        {
            flpBapNuoc.Controls.Clear();
            string[] items = { "Coca Cola", "Panta","7 up","Bắp Phô Mai","Bắp ngọt" };
            int[] prices = { 35000, 35000,35000,60000,54000};
            for (int i = 0; i < items.Length; i++)
            {
                Panel p = new Panel { Size = new Size(250, 40) };
                NumericUpDown n = new NumericUpDown { Location = new Point(150, 5), Width = 50, Tag = prices[i] };
                n.ValueChanged += (s, ev) => TinhTongTien();
                p.Controls.Add(new Label { Text = items[i], AutoSize = true });
                p.Controls.Add(n);
                flpBapNuoc.Controls.Add(p);
                dictDichVu.Add(items[i], n);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thanh toán phim: " + tenPhimDangChon, "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Control c in pnlSeats.Controls)
                    if (c is Button b && b.BackColor == Color.DodgerBlue) { b.BackColor = Color.Black; b.Enabled = false; }
                lblTotal.Text = "0 VNĐ";
            }
        }
    }
}