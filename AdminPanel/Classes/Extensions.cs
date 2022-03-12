using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AdminPanel.Classes
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

        public static List<string> DirSearch(string sDir)
        {
            var files = new List<string>();
            try
            {
                files.AddRange(Directory.GetFiles(sDir));
                foreach (var d in Directory.GetDirectories(sDir)) files.AddRange(DirSearch(d));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return files;
        }
    }
}