using Avalonia.Platform;
using PageTransitionWithNativeHostWindows.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageTransitionWithNativeHostWindows.Desktop
{
    public class NativeControlFactory : INativeControlFactory
    {
        public IPlatformHandle CreateNativeControl(IPlatformHandle parent)
        {
            TextBox textBox = new();
            textBox.Text = "Hello from WinForms!";
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.LightGreen;
            textBox.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            textBox.Font = new System.Drawing.Font("Segoe UI", 12);
            textBox.Width = 200;
            textBox.Height = 200;
            return new PlatformHandle(textBox.Handle, "Hndl");
        }

        public void DestroyNativeControl(IPlatformHandle control)
        {
            DestroyWindow(control.Handle);
        }

        [DllImport("user32.dll")]
        public static extern bool DestroyWindow(IntPtr hWnd);
    }
}
