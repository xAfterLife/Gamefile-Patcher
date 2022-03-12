using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace NostaleLauncher.Classes
{
    public static class Extensions
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) return true;
            return !source.Any();
        }



    }
}