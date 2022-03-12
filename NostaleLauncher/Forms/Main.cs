using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using NostaleLauncher.Classes;
using NostaleLauncher.Structs;
using static NostaleLauncher.Classes.Extensions;
using static NostaleLauncher.Globals;
using static NostaleLauncher.Globals.PatcherStates;
using static NostaleLauncher.RES;

namespace NostaleLauncher.Forms
{
    public partial class Main : Form
    {
        private DownloadHandler _downloadHandler;
        private bool _isFirstLoad = true;

        public Main() { InitializeComponent(); }

        private void App_StateChanged(object sender, EventsAndArgs.StateChangedEventArgs e)
        {
            switch (e.State)
            {
                case Idle:
                    Invoke(new MethodInvoker(() =>
                    {
                        btnStart.Enabled = false;
                        btnStart.BackgroundImage = no_play_button;
                        lblStatus.Text = @"The Update is going to start now";
                    }));
                    break;
                case JsonNotFound:

                    Invoke(new MethodInvoker(() =>
                    {
                        btnStart.Enabled = false;
                        btnStart.BackgroundImage = no_play_button;
                        lblStatus.Text = @"Couldn't download Update-Manifest - Try again later";
                    }));
                    break;
                case Updating:

                    Invoke(new MethodInvoker(() =>
                    {
                        pbProgress.Value = 0;
                        pbProgress.Maximum = _downloadHandler.MaxFiles;
                        btnStart.Enabled = false;
                        btnStart.BackgroundImage = no_play_button;
                        lblStatus.Text = @"Update running - This is going to take a few seconds";
                    }));
                    break;
                case Error:

                    MessageBox.Show(@"An Error occured, please try again or look for help on our Discord",
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Application.Exit();
                    break;
                case Maintenance:

                    Invoke(new MethodInvoker(() =>
                    {
                        btnStart.Enabled = false;
                        btnStart.BackgroundImage = no_play_button;
                        lblStatus.Text = @"The Server is currently under maintenance";
                    }));
                    break;
                case Finished:

                    Invoke(new MethodInvoker(() =>
                    {
                        btnStart.Enabled = true;
                        btnStart.BackgroundImage = play_button;
                        lblStatus.Text = @"Update finished - You can start the Game";
                        pbProgress.Value = pbProgress.Maximum;
                    }));
                    break;
            }
        }

        private void DownloadHandler_ProgressChanged(object sender, EventsAndArgs.ProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                pbProgress.Value++;
                lblStatus.Text = $@"Current File: {e.FileName} - {pbProgress.Value}/{pbProgress.Maximum}";
            }));
        }

        private static void DownloadHandler_FileError(object sender, EventsAndArgs.FileErrorEventArgs e)
        {
            MessageBox.Show($@"Error while Downloading File: {e.FileName}{Environment.NewLine}{e.ExceptionText}",
                @"Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            App.CurrentState = Error;
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "accounts")))
            {
                File.Create(Path.Combine(Environment.CurrentDirectory, "accounts"));
            }
            else
            {
                cmbAccounts.Items.Clear();
                cmbAccounts.Items.AddRange(ACCOUNTS.Select(x => x.Split('|')[0]).ToArray());
                if (cmbAccounts.Items.Count > 0) cmbAccounts.SelectedIndex = 0;
            }
            Text = WINDOW_CAPTION;

            _downloadHandler = new DownloadHandler();
            _downloadHandler.FileError += DownloadHandler_FileError;
            _downloadHandler.ProgressChanged += DownloadHandler_ProgressChanged;
            App.StateChanged += App_StateChanged;
            App.CurrentState = Idle;

            GetNews();
            GetRandFiles();
            StartUpdate();
        }

        private void GetNews()
        {
            try
            {
                if (!NEWS_FILE.HasValue) return;
                Invoke(new MethodInvoker(() =>
                {
                    linkEvent.Text = NEWS_FILE.Value.EventText;
                    linkEvent.Left = pnlWebBrowser.Left + rtbNews.Width - linkEvent.Width;
                    linkEvent.LinkClicked += (sender, e) => { OpenBrowser($"discord://{NEWS_FILE.Value.EventLink}"); };
                    rtbNews.Text = NEWS_FILE.Value.News;
                    label1.Text = NEWS_FILE.Value.News;
                }));
            }
            catch (Exception e)
            {
                var st = new StackTrace(e, true);
                var stackFrame = st.GetFrame(0);

                MessageBox.Show(string.Format(@"At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                    stackFrame.GetFileLineNumber(),
                    stackFrame.GetFileColumnNumber(),
                    stackFrame.GetMethod(),
                    Environment.NewLine,
                    stackFrame.GetFileName(),
                    e.Message));
            }
        }

        private static void GetRandFiles()
        {
            if (RAND_FILES_ON_WEB.IsNullOrEmpty() || RAND_FILES_ON_WEB.Count <= 0) return;

            var lastPatch = new List<RandFile>();

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "LastPatch.json"))) lastPatch = JsonSerializer.Deserialize<List<RandFile>>(File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "LastPatch.json")));

            RAND_FILES_ON_WEB.ForEach(file =>
            {
                try
                {
                    var fPath = file.Folder.IsNullOrEmpty() || file.Folder == file.Name
                        ? Path.Combine(Environment.CurrentDirectory, file.Name)
                        : Path.Combine(Environment.CurrentDirectory, file.Folder, file.Name);

                    var fileInfo = new FileInfo(fPath);
                    if (fileInfo.Exists && lastPatch!.Any(x => x.Name == file.Name && x.Version == file.Version)) return;
                    if (!CanUpdate()) return;

                    var downloadPath = file.Folder.IsNullOrEmpty() ? Path.Combine(RAND_FILES_ON_WEB_URL, file.Name) : Path.Combine(RAND_FILES_ON_WEB_URL, file.Folder, file.Name);
                    WClient.DownloadFile(new Uri(downloadPath), fPath);
                }
                catch (Exception e)
                {
                    var st = new StackTrace(e, true);
                    var stackFrame = st.GetFrame(0);

                    MessageBox.Show(string.Format(@"At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                        stackFrame.GetFileLineNumber(),
                        stackFrame.GetFileColumnNumber(),
                        stackFrame.GetMethod(),
                        Environment.NewLine,
                        stackFrame.GetFileName(),
                        e.Message));
                }
            });

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "LastPatch.json"), JsonSerializer.Serialize(RAND_FILES_ON_WEB));
        }

        private void StartUpdate()
        {
            try
            {
                Task.Run(() => _downloadHandler.Update());
            }
            catch (Exception e)
            {
                var st = new StackTrace(e, true);
                var stackFrame = st.GetFrame(0);

                MessageBox.Show(string.Format(@"At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                    stackFrame.GetFileLineNumber(),
                    stackFrame.GetFileColumnNumber(),
                    stackFrame.GetMethod(),
                    Environment.NewLine,
                    stackFrame.GetFileName(),
                    e.Message));
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBrowser("NtConfig.exe");
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var stackFrame = st.GetFrame(0);

                MessageBox.Show(string.Format(@"At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                    stackFrame.GetFileLineNumber(),
                    stackFrame.GetFileColumnNumber(),
                    stackFrame.GetMethod(),
                    Environment.NewLine,
                    stackFrame.GetFileName(),
                    ex.Message));
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                OpenBrowser(BINARY_NAME + " EntwellNostaleClientLoadFromIni");
                //var acc = ACCOUNTS.FirstOrDefault(x => x.StartsWith(cmbAccounts.Text))?.Split('|');
                //if (acc != null) SendCredentials(acc[0], acc[1]);
                Application.Exit();
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var stackFrame = st.GetFrame(0);

                MessageBox.Show(string.Format(@"At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                    stackFrame.GetFileLineNumber(),
                    stackFrame.GetFileColumnNumber(),
                    stackFrame.GetMethod(),
                    Environment.NewLine,
                    stackFrame.GetFileName(),
                    ex.Message));
            }
        }

        private void BtnDiscord_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBrowser($@"discord://{DISCORD_URL_INVITE}");
                OpenBrowser($@"discord://{DISCORD_URL}");
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var stackFrame = st.GetFrame(0);

                MessageBox.Show(string.Format(@"At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                    stackFrame.GetFileLineNumber(),
                    stackFrame.GetFileColumnNumber(),
                    stackFrame.GetMethod(),
                    Environment.NewLine,
                    stackFrame.GetFileName(),
                    ex.Message));
            }
        }

        private void BtnGuide_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBrowser($@"discord://{GUIDE_URL_INVITE}");
                OpenBrowser($@"discord://{GUIDE_URL}");
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var stackFrame = st.GetFrame(0);

                MessageBox.Show(string.Format(@"At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                    stackFrame.GetFileLineNumber(),
                    stackFrame.GetFileColumnNumber(),
                    stackFrame.GetMethod(),
                    Environment.NewLine,
                    stackFrame.GetFileName(),
                    ex.Message));
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) { }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenBrowser(WEBSITE_URL);
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            new Accounts().ShowDialog();
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            if (_isFirstLoad)
            {
                _isFirstLoad = false;
                return;
            }

            cmbAccounts.Items.Clear();
            cmbAccounts.Items.AddRange(ACCOUNTS.Select(x => x.Split('|')[0]).ToArray());
            if (cmbAccounts.Items.Count > 0) cmbAccounts.SelectedIndex = 0;
        }
    }
}