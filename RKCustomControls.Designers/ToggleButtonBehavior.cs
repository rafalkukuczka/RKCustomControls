using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace RKCustomControls.Designers
{
    public class ToggleButtonBehavior : Behavior
    {
        private readonly Control _control;
        private readonly IComponentChangeService _changeService;

        public ToggleButtonBehavior(
            Control control,
            IComponentChangeService changeService)
        {
#if DEBUG
            if (Debugger.IsAttached)
                Debugger.Break();
#endif

            _control = control;
            _changeService = changeService;
        }

        public override bool OnMouseDown(
            Glyph g,
            MouseButtons button,
            Point mouseLoc)
        {

#if DEBUG
            if (Debugger.IsAttached)
                Debugger.Break();
#endif

            if (button != MouseButtons.Left)
                return false;

            var prop = TypeDescriptor.GetProperties(_control)["Checked"];

            _changeService?.OnComponentChanging(_control, prop);
            //_control.Checked = !_control.Checked;
            _changeService?.OnComponentChanged(
                _control,
                prop,
                null,
                null);// _control.Checked);

            _control.Invalidate();

            return true; // 🔥 zdarzenie obsłużone
        }
    }
}