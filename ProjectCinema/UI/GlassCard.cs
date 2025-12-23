using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjectCinema.UI
{
    public class GlassCard : Panel
    {
        private int borderRadius = 20;
        private Color glassColor = Color.FromArgb(40, 255, 255, 255);
        private Color borderColor = Color.FromArgb(80, 255, 255, 255);
        private int borderSize = 1;

        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; Invalidate(); }
        }

        public Color GlassColor
        {
            get => glassColor;
            set { glassColor = value; Invalidate(); }
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

        public GlassCard()
        {
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = rectSurface;
            rectBorder.Inflate(-borderSize, -borderSize);

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - borderSize))
            using (SolidBrush brushGlass = new SolidBrush(glassColor))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                // Draw Glass Background
                e.Graphics.FillPath(brushGlass, pathSurface);

                // Draw Border
                if (borderSize > 0)
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(penBorder, pathBorder);
                }
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

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            using (GraphicsPath pathSurface = GetRoundedPath(this.ClientRectangle, borderRadius))
            {
                this.Region = new Region(pathSurface);
            }
            Invalidate();
        }
    }
}
