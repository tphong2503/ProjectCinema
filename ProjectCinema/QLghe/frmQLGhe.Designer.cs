namespace QLRP
{
    partial class frmQLGhe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblManAnh = new System.Windows.Forms.Label();
            this.pnlSeats = new System.Windows.Forms.Panel();
            this.flpBapNuoc = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPayment = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblManAnh
            this.lblManAnh.BackColor = System.Drawing.Color.DimGray;
            this.lblManAnh.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblManAnh.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblManAnh.ForeColor = System.Drawing.Color.White;
            this.lblManAnh.Location = new System.Drawing.Point(0, 0);
            this.lblManAnh.Size = new System.Drawing.Size(1000, 40);
            this.lblManAnh.Text = "MÀN HÌNH";
            this.lblManAnh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlSeats
            this.pnlSeats.Location = new System.Drawing.Point(12, 60);
            this.pnlSeats.Size = new System.Drawing.Size(650, 450);

            // flpBapNuoc
            this.flpBapNuoc.Location = new System.Drawing.Point(680, 60);
            this.flpBapNuoc.Size = new System.Drawing.Size(300, 350);
            this.flpBapNuoc.AutoScroll = true;

            // lblTotal
            this.lblTotal.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(680, 420);
            this.lblTotal.Size = new System.Drawing.Size(300, 40);
            this.lblTotal.Text = "0 VNĐ";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnPayment
            this.btnPayment.BackColor = System.Drawing.Color.Orange;
            this.btnPayment.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnPayment.Location = new System.Drawing.Point(680, 470);
            this.btnPayment.Size = new System.Drawing.Size(300, 50);
            this.btnPayment.Text = "THANH TOÁN";
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);

            // frmQLGhe
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.flpBapNuoc);
            this.Controls.Add(this.pnlSeats);
            this.Controls.Add(this.lblManAnh);
            this.Name = "frmQLGhe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmQLGhe_Load); // Chỉ để DUY NHẤT 1 dòng này
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblManAnh;
        private System.Windows.Forms.Panel pnlSeats;
        private System.Windows.Forms.FlowLayoutPanel flpBapNuoc;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPayment;
    }
}