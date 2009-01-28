using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;


namespace MediaRenamer.Common
{
    public class VistaGlass
    {
        public struct Margins
        {
            public Margins(Rectangle t)
            {
                Left = (int)t.Left;
                Right = (int)t.Right;
                Top = (int)t.Top;
                Bottom = (int)t.Bottom;
            }
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        [DllImport("dwmapi.dll")]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMargins);

        [DllImport("dwmapi.dll")]
        static extern void DwmIsCompositionEnabled(ref bool pfEnabled);

        public static bool IsGlassSupported()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                // Feature is only available in Vista and later
                return false;
            }   

            bool isGlassSupported = false;
            DwmIsCompositionEnabled(ref isGlassSupported);
            return isGlassSupported;
        }

        public static void ExtendGlassFrame(IntPtr hwnd, ref Margins marg)
        {
            if (!VistaGlass.IsGlassSupported()) return;
            DwmExtendFrameIntoClientArea(hwnd, ref marg);
        }
    }
}