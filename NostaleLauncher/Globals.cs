using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NostaleLauncher.Classes;
using NostaleLauncher.Structs;
using Microsoft.Win32;

namespace NostaleLauncher
{
    public static class Globals
    {
        /// <summary>
        ///     States for the Patcher
        /// </summary>
        public enum PatcherStates
        {
            Idle,
            Updating,
            JsonNotFound,
            Error,
            Finished,
            Maintenance
        }

        /// <summary>
        ///     Get the JSON-File of the Current Client Files
        /// </summary>
        private static List<NosFile> _filesOnWeb;

        /// <summary>
        ///     Other Files like .exe/launcher etc.
        /// </summary>
        private static List<RandFile> _randFilesOnWeb;

        /// <summary>
        ///     Get the JSON-File of the News File
        /// </summary>
        private static NewsFile? _newsFile;

        /// <summary>
        ///     Local Directory of the Nos-Files
        /// </summary>
        private static string _nosDirectory;

        /// <summary>
        ///     Re-Usable Webclient
        /// </summary>
        private static WebClient _wClient;

        public static List<NosFile> FILES_ON_WEB
        {
            get
            {
                if (!_filesOnWeb.IsNullOrEmpty()) return _filesOnWeb;
                try
                {
                    Span<byte> span = Task.Run(() =>
                            WClient.DownloadData(Path.Combine(RES.FILES_ON_WEB_URL, "NosFiles.json")))
                        .Result;
                    _filesOnWeb = JsonSerializer.Deserialize<List<NosFile>>(span, JsonOptions);
                }
                catch (Exception e)
                {
                    MessageBox.Show($@"Error Occured:{Environment.NewLine}{e.Message}",
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    App.CurrentState = PatcherStates.Error;
                    return null;
                }

                return _filesOnWeb;
            }
        }

        /// <summary>
        ///     Capsulated Field for _randFilesOnWeb
        /// </summary>
        public static List<RandFile> RAND_FILES_ON_WEB
        {
            get
            {
                if (!_randFilesOnWeb.IsNullOrEmpty()) return _randFilesOnWeb;
                try
                {
                    Span<byte> span = Task.Run(() =>
                            WClient.DownloadData(Path.Combine(RES.RAND_FILES_ON_WEB_URL.Substring(0, RES.RAND_FILES_ON_WEB_URL.LastIndexOf('/')), "RandFiles.json")))
                        .Result;
                    _randFilesOnWeb = JsonSerializer.Deserialize<List<RandFile>>(span, JsonOptions);
                }
                catch (Exception e)
                {
                    MessageBox.Show($@"Error Occured:{Environment.NewLine}{e.Message}",
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    App.CurrentState = PatcherStates.Error;
                    return null;
                }

                return _randFilesOnWeb;
            }
        }

        /// <summary>
        ///     Capsulated Field for _newsFile
        /// </summary>
        public static NewsFile? NEWS_FILE
        {
            get
            {
                if (_newsFile != null) return _newsFile;

                try
                {
                    Span<byte> span = Task
                        .Run(() => WClient.DownloadData(Path.Combine(RES.NEWS_MANIFEST, "NewsFile.json")))
                        .Result;
                    _newsFile = JsonSerializer.Deserialize<NewsFile>(span, JsonOptions);
                }
                catch (Exception e)
                {
                    MessageBox.Show($@"Couldn't load News {Environment.NewLine}{e.Message}");
                    return null;
                }

                return _newsFile;
            }
        }

        /// <summary>
        ///     Capsulated Field for _nosDirectory
        /// </summary>
        public static string NOS_DIRECTORY
        {
            get
            {
                if (_nosDirectory.IsNullOrEmpty()) _nosDirectory = Path.Combine(Environment.CurrentDirectory, "NostaleData");

                return _nosDirectory;
            }
        }

        /// <summary>
        ///     Get the WebClient
        /// </summary>
        public static WebClient WClient => _wClient ??= new WebClient();

        /// <summary>
        ///     JsonSerializerOptions to be re-used
        /// </summary>
        public static JsonSerializerOptions JsonOptions { get; } = new()
        {
            WriteIndented = true
        };

        /// <summary>
        ///     Open Browser Function since fucking .NET5 breaks everything
        /// </summary>
        /// <param name="url"></param>
        public static Process OpenBrowser(string url)
        {
            try
            {
                return Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    return Process.Start(new ProcessStartInfo("cmd", $"/c start {url}")
                    {
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    });
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    return Process.Start("xdg-open", url);
                }
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    return Process.Start("open", url);
                }
                throw;
            }
        }

        public static bool IsRunning() { return Process.GetProcesses().Any(p => p.MainWindowTitle.Contains(RES.CLIENT_NAME)); }

        public static void TryCloseGame() { Process.GetProcesses().Where(x => x.MainWindowTitle.Contains(RES.CLIENT_NAME)).ToList().ForEach(x => x.Kill()); }

        public static bool CanUpdate()
        {
            if (!IsRunning()) return true;

            TryCloseGame();
            if (!IsRunning()) return true;

            MessageBox.Show(@"The Game is currently open, Please Close it for the Update", @"Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return false;
        }

        public static string[] ACCOUNTS
        {
            get
            {
                if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "accounts"))) File.Create(Path.Combine(Environment.CurrentDirectory, "accounts"));
                return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "accounts"));
            }
            set => File.WriteAllLines(Path.Combine(Environment.CurrentDirectory, "accounts"), value);
        }

        public static bool IsInstalled(string programDisplayName)
        {
            var registryKey = new[] { @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall" };

            foreach (var s in registryKey)
            {
                var key = Registry.LocalMachine.OpenSubKey(s);
                if (key == null) continue;
                foreach (var subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    if (subkey?.GetValue("DisplayName") is string displayName && displayName.Contains(programDisplayName))
                    {
                        return true;
                    }
                }
                key.Close();
            }

            return false;
        }

        //Copy start
        //
        //
        //Copy from another Launcher - Owner of CryptoTale wanted this Code to be present

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint procId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int SetWindowText(IntPtr hWnd, string text);

        public static void SendCredentials(string uname, string upass)
        {
            try
            {
                const string targetProcessWindowTitle = "Nostale";
                uint loginWindowProcId = 0;
                var hWnd = IntPtr.Zero;
                var done = false;
                while (!done)
                {
                    Thread.Sleep(50);
                    hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, targetProcessWindowTitle);

                    foreach (var pList in Process.GetProcesses())
                    {
                        if (pList.MainWindowTitle == targetProcessWindowTitle)
                        {
                            hWnd = pList.MainWindowHandle;
                        }
                    }

                    GetWindowThreadProcessId(hWnd, out loginWindowProcId);
                    if (0 == loginWindowProcId) continue;
                    done = true;
                }

                var loginWindowProcess = Process.GetProcessById((int)loginWindowProcId);
                Thread.Sleep(750);
                loginWindowProcess.WaitForInputIdle();
                Thread.Sleep(750);
                SetForegroundWindow(hWnd);
                Thread.Sleep(750);
                SendKeys.SendWait(uname);
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(upass);
                SendKeys.SendWait("{ENTER}");

                SetWindowText(loginWindowProcess.MainWindowHandle, RES.CLIENT_NAME + Guid.NewGuid().ToString("n").Substring(0, 8));
            }
            catch
            {
                MessageBox.Show(@"Cant log in automatically!");
            }
            Thread.Sleep(200);
        }
        //
        //
        //Copy end
    }
}