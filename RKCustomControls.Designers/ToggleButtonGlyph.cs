using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace RKCustomControls.Designers
{
    public class ToggleButtonGlyph : Glyph
    {
        private readonly Control _control;
        private readonly BehaviorService _behaviorService;

        public ToggleButtonGlyph(
            Control control,
            Behavior behavior,
            BehaviorService behaviorService)
            : base(behavior)
        {
            _control = control;
            _behaviorService = behaviorService;
        }


        public override Rectangle Bounds
        {
            get
            {
               
                // 🔑 kluczowe: mapowanie do AdornerWindow
                return _behaviorService
                    .ControlRectInAdornerWindow(_control);
            }
        }

        public override Cursor GetHitTest(Point p)
        {
            return Bounds.Contains(p) ? Cursors.Hand : null;
        }

        public override void Paint(PaintEventArgs pe)
        {
            //// celowo puste – kontrolka rysuje się sama
            //pe.Graphics.FillRectangle(
            //    new SolidBrush(Color.FromArgb(128, Color.LightBlue)),
            //    Bounds);
        }
    }
}