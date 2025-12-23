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
        private Color glowColor = Color.FromArgb(100, 30, 107, 254);

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

        public Color GlowColor
        {
            get => glowColor;
            set { glowColor = value; Invalidate(); }
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
            pevent.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = rectSurface;
            rectBorder.Inflate(-1, -1);

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - 1))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                // Glow Effect
                if (isHovered && !isChecked)
                {
                    using (PathGradientBrush glowBrush = new PathGradientBrush(pathSurface))
                    {
                        glowBrush.CenterColor = Color.FromArgb(50, glowColor);
                        glowBrush.SurroundColors = new Color[] { Color.Transparent };
                        pevent.Graphics.FillPath(glowBrush, pathSurface);
                    }
                }

                // Background
                Color bgColor = isChecked ? CheckedBackColor : (isHovered ? HoverBackColor : this.BackColor);
                if (bgColor != Color.Transparent)
                {
                    using (SolidBrush brush = new SolidBrush(bgColor))
                    {
                        pevent.Graphics.FillPath(brush, pathSurface);
                    }
                }

                // Border
                if (borderSize > 0)
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
                }

                // Text
                Color textColor = isChecked ? CheckedForeColor : this.ForeColor;
                TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, textColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.LeftAndRightPadding);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (GraphicsPath pathSurface = GetRoundedPath(this.ClientRectangle, borderRadius))
            {
                this.Region = new Region(pathSurface);
            }
            Invalidate();
        }
    }
}
