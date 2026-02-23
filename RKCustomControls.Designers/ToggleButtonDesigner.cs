using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.Design;


namespace RKCustomControls.Designers
{
    

    public class ToggleButtonDesigner : ControlDesigner
    {

        private IComponentChangeService _changeService;

        public override void Initialize(IComponent component)
        {
        

            base.Initialize(component);

            Debug.WriteLine("ToggleButtonDesigner initialized.");

#if DEBUG
            if (!Debugger.IsAttached)
                Debugger.Break();
#endif

            _changeService =
                (IComponentChangeService)GetService(typeof(IComponentChangeService));

            if (_changeService != null)
            {
                _changeService.ComponentChanged += OnComponentChanged;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _changeService != null)
            {
                _changeService.ComponentChanged -= OnComponentChanged;
                _changeService = null;
            }

            base.Dispose(disposing);
        }

        private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            Debugger.Launch();

            if (e.Member?.Name == nameof(Control.Enabled))
            {
                Control?.Invalidate(); 
            }
        }
    }

}
