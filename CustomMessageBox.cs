using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectCinema.GUI
{
    public class CustomMessageBox : Form
    {
        private Label lblMessage;
        private Button btnOK;
        private Button btnYes;
        private Button btnNo;
        private Panel pnlHeader;
        private Panel pnlContent;

        // Đổ bóng
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public CustomMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent(message, title, buttons, icon);
        }

        private void InitializeComponent(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            this.Text = "";
            this.Size = new Size(500, 280); 
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent; 
            this.BackColor = Color.White;
            this.TopMost = true;

            Color headerColor = GetHeaderColor(icon);
            Color buttonColor = headerColor;

            pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(2)
            };

            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = headerColor
            };

            Label lblTitle = new Label
            {
                Text = title.ToUpper(),
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 20),
                AutoSize = true
            };
            pnlHeader.Controls.Add(lblTitle);

            lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(30, 90),
                MaximumSize = new Size(440, 0),
                AutoSize = true
            };
            this.Controls.Add(lblMessage);

            // Logic các nút
            if (buttons == MessageBoxButtons.OK)
            {
                btnOK = CreateButton("ĐỒNG Ý", new Point(180, 200), buttonColor, DialogResult.OK);
                this.Controls.Add(btnOK);
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                btnYes = CreateButton("CÓ", new Point(100, 200), buttonColor, DialogResult.Yes);
                btnNo = CreateButton("KHÔNG", new Point(260, 200), Color.Gray, DialogResult.No);
                this.Controls.Add(btnYes);
                this.Controls.Add(btnNo);
            }

            this.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);
            };

            this.Controls.Add(pnlHeader); 
        }

        private Button CreateButton(string text, Point location, Color backColor, DialogResult result)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(140, 45),
                Location = location,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = result
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => this.DialogResult = result;
            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Dark(backColor, 0.1f);
            btn.MouseLeave += (s, e) => btn.BackColor = backColor;
            return btn;
        }

        private Color GetHeaderColor(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Information: return Color.FromArgb(84, 110, 122); // BlueGrey 600
                case MessageBoxIcon.Warning: return Color.FromArgb(255, 152, 0); // Orange
                case MessageBoxIcon.Error: return Color.FromArgb(244, 67, 54); // Red
                case MessageBoxIcon.Question: return Color.FromArgb(69, 90, 100); // BlueGrey 700
                default: return Color.FromArgb(84, 110, 122); // BlueGrey 600
            }
        }

        public static DialogResult Show(string message, string title = "Thông báo", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            Form overlay = new Form();
            try {
                if (Application.OpenForms.Count > 0)
                {
                    Form active = Application.OpenForms[0];
                    foreach(Form f in Application.OpenForms)
                    {
                        if(f is Form && f.Visible && !f.TopMost && f.Name != "CustomMessageBox") 
                        {
                            active = f;
                            break;
                        }
                    }

                    overlay.FormBorderStyle = FormBorderStyle.None;
                    overlay.BackColor = Color.Black;
                    overlay.Opacity = 0.5;
                    overlay.Size = active.Size;
                    overlay.Location = active.Location;
                    overlay.StartPosition = FormStartPosition.Manual;
                    overlay.ShowInTaskbar = false;
                    overlay.Owner = active;
                    overlay.Show();
                }
            }
            catch {}

            DialogResult result;
            using (var msgBox = new CustomMessageBox(message, title, buttons, icon))
            {
                result = msgBox.ShowDialog();
            }
            
            overlay.Close();
            overlay.Dispose();
            return result;
        }

        // Nạp chồng để tương thích ngược (mặc định là OK)
        public static DialogResult Show(string message, string title, MessageBoxIcon icon)
        {
            return Show(message, title, MessageBoxButtons.OK, icon);
        }
    }
}
