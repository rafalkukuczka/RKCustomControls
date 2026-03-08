using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RKCustomControls
{
    [Designer("RKCustomControls.Designers.ToggleButtonDesigner, RKCustomControls.Designers")]
    public class ToggleButton : CheckBox, ISupportInitialize
    {
        // Colors
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private Color disableBackColor = Color.DarkGray;
        private Color disableToggleColor = Color.LightGray;

        // Brushes
        private SolidBrush onBackBrush;
        private SolidBrush onToggleBrush;
        private SolidBrush offBackBrush;
        private SolidBrush offToggleBrush;
        private SolidBrush disableBackBrush;
        private SolidBrush disableToggleBrush;

        // Cached GraphicsPath
        private GraphicsPath backgroundPath;

        public ToggleButton()
        {
            MinimumSize = new Size(45, 22);
            MaximumSize = new Size(1000, 44);

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);

            InitializeBrushes();
            CreateBackgroundPath();
        }

        private void InitializeBrushes()
        {
            onBackBrush = new SolidBrush(onBackColor);
            onToggleBrush = new SolidBrush(onToggleColor);
            offBackBrush = new SolidBrush(offBackColor);
            offToggleBrush = new SolidBrush(offToggleColor);
            disableBackBrush = new SolidBrush(disableBackColor);
            disableToggleBrush = new SolidBrush(disableToggleColor);
        }

        // Properties
        public Color OnBackColor
        {
            get => onBackColor;
            set
            {
                onBackColor = value;
                onBackBrush.Color = value;
                Invalidate();
            }
        }

        public Color OnToggleColor
        {
            get => onToggleColor;
            set
            {
                onToggleColor = value;
                onToggleBrush.Color = value;
                Invalidate();
            }
        }

        public Color OffBackColor
        {
            get => offBackColor;
            set
            {
                offBackColor = value;
                offBackBrush.Color = value;
                Invalidate();
            }
        }

        public Color OffToggleColor
        {
            get => offToggleColor;
            set
            {
                offToggleColor = value;
                offToggleBrush.Color = value;
                Invalidate();
            }
        }

        public Color DisableBackColor
        {
            get => disableBackColor;
            set
            {
                disableBackColor = value;
                disableBackBrush.Color = value;
                Invalidate();
            }
        }

        public Color DisableToggleColor
        {
            get => disableToggleColor;
            set
            {
                disableToggleColor = value;
                disableToggleBrush.Color = value;
                Invalidate();
            }
        }

        // Disable text
        [Browsable(false)]
        public new string Text { get => base.Text; private set { } }

        [Browsable(false)]
        public new ContentAlignment TextAlign { get => base.TextAlign; private set { } }

        // ISupportInitialize
        public void BeginInit() { }

        public void EndInit()
        {
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            CreateBackgroundPath();
        }

        private void CreateBackgroundPath()
        {
            backgroundPath?.Dispose();

            int archSize = Height - 1;

            Rectangle rectLeft = new Rectangle(0, 0, archSize, archSize);
            Rectangle rectRight = new Rectangle(Width - archSize - 2, 0, archSize, archSize);

            backgroundPath = new GraphicsPath();

            backgroundPath.StartFigure();
            backgroundPath.AddArc(rectLeft, 90, 180);
            backgroundPath.AddArc(rectRight, 270, 180);
            backgroundPath.CloseFigure();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
#if DEBUG
            LogGdi("OnPaint-BEGIN");
#endif

            int toggleSize = Height - 5;

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent.BackColor);

            if (!Enabled)
            {
                g.FillPath(disableBackBrush, backgroundPath);

                RectangleF rect = Checked
                    ? new RectangleF(Width - Height, 2, toggleSize, toggleSize)
                    : new RectangleF(2, 2, toggleSize, toggleSize);

                g.FillEllipse(disableToggleBrush, rect);

                return;
            }

            if (Checked)
            {
                g.FillPath(onBackBrush, backgroundPath);
                g.FillEllipse(onToggleBrush, new RectangleF(Width - Height, 2, toggleSize, toggleSize));
            }
            else
            {
                g.FillPath(offBackBrush, backgroundPath);
                g.FillEllipse(offToggleBrush, new RectangleF(2, 2, toggleSize, toggleSize));
            }

#if DEBUG
            LogGdi("OnPaint-END");
#endif
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                onBackBrush?.Dispose();
                onToggleBrush?.Dispose();
                offBackBrush?.Dispose();
                offToggleBrush?.Dispose();
                disableBackBrush?.Dispose();
                disableToggleBrush?.Dispose();
                backgroundPath?.Dispose();
            }

            base.Dispose(disposing);
        }

#if DEBUG
        [DllImport("user32.dll")]
        static extern int GetGuiResources(IntPtr hProcess, int uiFlags);

        void LogGdi(string tag)
        {
            int gdi = GetGuiResources(Process.GetCurrentProcess().Handle, 0);
            Debug.WriteLine($"{tag}: GDI={gdi}");
        }
    }
#endif

}
