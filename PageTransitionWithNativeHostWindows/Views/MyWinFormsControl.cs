using Avalonia.Controls;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PageTransitionWithNativeHostWindows.Views
{
    public class MyWinFormsControl : NativeControlHost
    {
        public static INativeControlFactory Factory { get; set; }

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
        {
            if (Factory != null)
            {
                return Factory.CreateNativeControl(parent);
            }
            else
            {
                return base.CreateNativeControlCore(parent);
            }
        }

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
            if (Factory != null)
            {
                Factory.DestroyNativeControl(control);
            }
            else
            {
                base.DestroyNativeControlCore(control);
            }
        }
    }

    public interface INativeControlFactory
    {
        IPlatformHandle CreateNativeControl(IPlatformHandle parent);
        void DestroyNativeControl(IPlatformHandle control);
    }
}
