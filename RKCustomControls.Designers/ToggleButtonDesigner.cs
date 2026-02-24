using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;


namespace RKCustomControls.Designers
{

    public class ToggleButtonDesigner : ControlDesigner
    {

        private IComponentChangeService _changeService;

        private BehaviorService _behaviorService;
        private Glyph _glyph;

        public ToggleButtonDesigner()
        {
#if DEBUG
            if (Debugger.IsAttached)
                Debugger.Break();
#endif            
        }

        public override void Initialize(IComponent component)
        {

            base.Initialize(component);

            _changeService =
                (IComponentChangeService)GetService(typeof(IComponentChangeService));

            if (_changeService != null)
            {
                _changeService.ComponentChanged += ComponentChanged;
            }

            _behaviorService =
                (BehaviorService)GetService(typeof(BehaviorService));

            var behavior = new ToggleButtonBehavior(
                (Control)component,
                _changeService);

            _glyph = new ToggleButtonGlyph(
                (Control)component,
                behavior,
                _behaviorService);

            // 0 = główny Adorner
            _behaviorService.Adorners[0].Glyphs.Add(_glyph);
        }

         

        protected override void Dispose(bool disposing)
        {
            if (disposing && _changeService != null)
            {
                _changeService.ComponentChanged -= ComponentChanged;
                _changeService = null;
            }

            if (disposing && _behaviorService != null)
            {
                _behaviorService = null;
            }

            if (disposing && _glyph != null)
            {
                _behaviorService?.Adorners[0].Glyphs.Remove(_glyph);
                _glyph = null;
            }

            base.Dispose(disposing);
        }

        private void ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            if (e.Member?.Name == nameof(Control.Enabled))
            {
                Control?.Invalidate();
            }
        }

       
    }

}
