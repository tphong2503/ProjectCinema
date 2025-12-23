using System;
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
        private Color glowColor = Color.FromArgb(100, 30, 107, 254);

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

        public Color GlowColor
        {
            get => glowColor;
            set { glowColor = value; Invalidate(); }
        }

        public CustomProgressBar()
        {
            this.DoubleBuffered = true;
            this.Height = 8;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle rectBg = this.ClientRectangle;
            
            // Background
            using (GraphicsPath pathBg = GetRoundedPath(rectBg, borderRadius))
            using (SolidBrush brushBg = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillPath(brushBg, pathBg);
            }

            // Progress
            if (progressValue > 0)
            {
                int progressWidth = (int)(this.Width * progressValue / 100.0);
                if (progressWidth < borderRadius * 2 && progressWidth > 0) progressWidth = borderRadius * 2;
                
                Rectangle rectProgress = new Rectangle(0, 0, progressWidth, this.Height);
                using (GraphicsPath pathProgress = GetRoundedPath(rectProgress, borderRadius))
                {
                    // Glow
                    if (progressWidth > 4)
                    {
                        using (PathGradientBrush glowBrush = new PathGradientBrush(pathProgress))
                        {
                            glowBrush.CenterColor = Color.FromArgb(60, glowColor);
                            glowBrush.SurroundColors = new Color[] { Color.Transparent };
                            e.Graphics.FillPath(glowBrush, pathProgress);
                        }
                    }

                    // Foreground Gradient
                    using (LinearGradientBrush brushProgress = new LinearGradientBrush(rectProgress, progressColor, 
                        Color.FromArgb(200, progressColor), LinearGradientMode.Horizontal))
                    {
                        e.Graphics.FillPath(brushProgress, pathProgress);
                    }
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
    }
}
