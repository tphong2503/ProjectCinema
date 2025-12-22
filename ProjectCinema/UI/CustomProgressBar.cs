using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjectCinema.UI
{
    public class CustomProgressBar : Control
    {
        private int progressValue = 0;
        private int borderRadius = 3;
        private Color progressColor = Color.FromArgb(30, 107, 254);
        private Color backgroundColor = Color.FromArgb(30, 35, 45);

        public int Value
        {
            get => progressValue;
            set
            {
                if (value < 0) progressValue = 0;
                else if (value > 100) progressValue = 100;
                else progressValue = value;
                Invalidate();
            }
        }

        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; Invalidate(); }
        }

        public Color ProgressColor
        {
            get => progressColor;
            set { progressColor = value; Invalidate(); }
        }

        public Color ProgressBackColor
        {
            get => backgroundColor;
            set { backgroundColor = value; Invalidate(); }
        }

        public CustomProgressBar()
        {
            this.DoubleBuffered = true;
            this.Height = 6;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Background
            using (GraphicsPath pathBg = GetRoundedPath(new RectangleF(0, 0, this.Width, this.Height), borderRadius))
            using (SolidBrush brushBg = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillPath(brushBg, pathBg);
            }

            // Progress
            if (progressValue > 0)
            {
                float progressWidth = (float)this.Width * progressValue / 100;
                using (GraphicsPath pathProgress = GetRoundedPath(new RectangleF(0, 0, progressWidth, this.Height), borderRadius))
                using (SolidBrush brushProgress = new SolidBrush(progressColor))
                {
                    e.Graphics.FillPath(brushProgress, pathProgress);
                }
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
