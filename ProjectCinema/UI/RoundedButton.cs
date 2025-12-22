using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjectCinema.UI
{
    public class RoundedButton : Button
    {
        private int borderRadius = 10;
        private Color borderColor = Color.Transparent;
        private int borderSize = 0;
        private bool isHovered = false;
        private bool isChecked = false;

        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        public int BorderSize
        {
            get => borderSize;
            set { borderSize = value; Invalidate(); }
        }

        public bool Checked
        {
            get => isChecked;
            set { isChecked = value; Invalidate(); }
        }

        public Color CheckedBackColor { get; set; } = Color.FromArgb(30, 107, 254);
        public Color CheckedForeColor { get; set; } = Color.White;
        public Color HoverBackColor { get; set; } = Color.FromArgb(30, 35, 45);

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.FromArgb(160, 165, 177);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 2, this.Height - 2);

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - 1))
            using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                this.Region = new Region(pathSurface);

                // Background
                Color bgColor = isChecked ? CheckedBackColor : (isHovered ? HoverBackColor : this.BackColor);
                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    pevent.Graphics.FillPath(brush, pathSurface);
                }

                // Border
                if (borderSize > 0)
                    pevent.Graphics.DrawPath(penBorder, pathBorder);

                // Text
                Color textColor = isChecked ? CheckedForeColor : this.ForeColor;
                TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, textColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();

            // Ensure radius is not negative or too large
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            float curveSize = radius * 2F;

            // Ensure curveSize doesn't exceed rect dimensions
            if (curveSize > rect.Width) curveSize = rect.Width;
            if (curveSize > rect.Height) curveSize = rect.Height;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180F, 90F);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270F, 90F);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0F, 90F);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90F, 90F);
            path.CloseFigure();
            return path;
        }
    }
}
