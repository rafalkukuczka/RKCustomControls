using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RKCustomControls
{
    [Designer("RKCustomControls.Designers.ToggleButtonDesigner, RKCustomControls.Designers")]
    public class ToggleButton : CheckBox, ISupportInitialize
    {
        //Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private Color disableBackColor = Color.DarkGray;
        private Color disableToggleColor = Color.LightGray;

        //ctors
        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
            this.MaximumSize = new Size(1000, 22);

            this.SetStyle(ControlStyles.UserPaint |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.OptimizedDoubleBuffer, true);
        }

        //props
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OnBackColor { get { return onBackColor; } set { onBackColor = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OnToggleColor { get => onToggleColor; set { onToggleColor = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OffBackColor { get => offBackColor; set { offBackColor = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OffToggleColor { get => offToggleColor; set { offToggleColor = value; Invalidate(); } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color DisableBackColor { get => disableBackColor; set => disableBackColor = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color DisableToggleColor { get => disableToggleColor; set => disableToggleColor = value; }

        //props to be desibled in designer
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text { get => base.Text; private set { } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContentAlignment TextAlign { get => base.TextAlign; private set { } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TextImageRelation TextImageRelation { get => base.TextImageRelation; private set { } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatStyle FlatStyle { get => base.FlatStyle; private set { } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatButtonAppearance FlatAppearance { get => base.FlatAppearance; private set { } }


        //Interfaces
        public void BeginInit()
        {

        }

        public void EndInit()
        {
            Invalidate();
        }


        //Overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.DesignMode)
            {
                var changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                if (changeService != null)
                {
                    changeService.ComponentChanged -= OnComponentChanged; // Unikamy duplikacji
                    changeService.ComponentChanged += OnComponentChanged;
                }
            }
        }

        private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            if (e.Component == this && e.Member?.Name == "Enabled")
            {
                this.Invalidate();
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.DesignMode)
            {
                bool actualEnabled = true;

                PropertyDescriptor pd = TypeDescriptor.GetProperties(this)["Enabled"];
                if (pd != null)
                {
                    actualEnabled = (bool)pd.GetValue(this);
                }

                if (!actualEnabled)
                {
                    if (this.Checked)
                    {
                        DrawDisabledStateChecked(pevent, toggleSize);
                    }
                    else
                    {
                        DrawDisabledStateUnchecked(pevent, toggleSize);
                    }
                }
                else
                {
                    if (this.Checked)
                    {
                        DrawCheckedState(pevent, toggleSize);
                    }
                    else
                    {
                        DrawUncheckedState(pevent, toggleSize);
                    }
                }
            }
            else
            {
                if (!this.Enabled)
                {
                    DrawDisabledStateChecked(pevent, toggleSize);
                }
                else
                {
                    if (this.Checked)
                    {
                        DrawCheckedState(pevent, toggleSize);
                    }
                    else
                    {
                        DrawUncheckedState(pevent, toggleSize);
                    }
                }
            }
        }

        //Utils

        private void DrawDisabledStateChecked(PaintEventArgs pevent, int toggleSize)
        {
            pevent.Graphics.FillPath(new SolidBrush(disableBackColor), GetFigure());
            pevent.Graphics.FillEllipse(new SolidBrush(disableToggleColor), new RectangleF(this.Width - this.Height, 2, toggleSize, toggleSize));
        }

        private void DrawDisabledStateUnchecked(PaintEventArgs pevent, int toggleSize)
        {
            pevent.Graphics.FillPath(new SolidBrush(disableBackColor), GetFigure());
            pevent.Graphics.FillEllipse(new SolidBrush(disableToggleColor), new RectangleF(2, 2, toggleSize, toggleSize));
        }

        private void DrawUncheckedState(PaintEventArgs pevent, int toggleSize)
        {
            pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigure());
            pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor), new RectangleF(2, 2, toggleSize, toggleSize));
        }

        private void DrawCheckedState(PaintEventArgs pevent, int toggleSize)
        {
            pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigure());
            pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), new RectangleF(this.Width - this.Height, 2, toggleSize, toggleSize));
        }

        

        private GraphicsPath GetFigure()
        {
            var archSize = this.Height - 1;
            var rectLeft = new Rectangle(0, 0, archSize, archSize);
            var rectRight = new Rectangle(this.Width - archSize - 2, 0, archSize, archSize);


            var path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(rectLeft, 90, 180);
            path.AddArc(rectRight, 270, 180);

            path.CloseFigure();

            return path;
        }
    }
}
