using AdminPanel.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using static AdminPanel.Classes.Extensions;

namespace AdminPanel.Forms
{
    public partial class Main : Form
    {
        private readonly FolderBrowserDialog _dialog = new();

        public Main()
        {
            InitializeComponent();
        }

        public static JsonSerializerOptions JsonOptions { get; } = new JsonSerializerOptions { WriteIndented = true };

        private void Form1_Load(object sender, EventArgs e)
        {
            _dialog.Description = @"News-File on Server";
            if (_dialog.ShowDialog() != DialogResult.OK) return;
            if (!File.Exists(Path.Combine(_dialog.SelectedPath, "NewsFile.json"))) return;

            var news = JsonSerializer.Deserialize<NewsFile>(File.ReadAllBytes(Path.Combine(_dialog.SelectedPath, "NewsFile.json")), JsonOptions);
            txtEventLink.Text = news.EventLink;
            txtEventText.Text = news.EventText;
            txtNews.Text = news.News;
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                var fileGuid = Guid.NewGuid();
                var oldRandFiles = new List<RandFile>();
                var oldFiles = new List<NosFile>();

                //RandFiles
                _dialog.Description = @"Rand-Files on Server";
                if (_dialog.ShowDialog() != DialogResult.OK) return;

                if (File.Exists(Path.Combine(_dialog.SelectedPath, "RandFiles.json")))
                {
                    oldRandFiles = JsonSerializer.Deserialize<List<RandFile>>(File.ReadAllBytes(Path.Combine(_dialog.SelectedPath, "RandFiles.json")).AsSpan());
                    File.Delete(Path.Combine(_dialog.SelectedPath, "RandFiles.json"));
                }

                var randFiles = DirSearch(_dialog.SelectedPath).Select(file => new FileInfo(file)).Select(fileInfo =>
                    new RandFile
                    {
                        Name = fileInfo.Name,
                        Size = fileInfo.Length,
                        CreationTimeUtc = fileInfo.CreationTimeUtc.ToString(),
                        Folder = fileInfo.Directory.FullName == _dialog.SelectedPath ? "" : fileInfo.FullName.Split('\\').Last(),
                        Version = oldRandFiles.Any(x =>
                            x.Name == fileInfo.Name && x.CreationTimeUtc == fileInfo.CreationTimeUtc.ToString())
                            ? oldRandFiles.First(x => x.Name == fileInfo.Name).Version
                            : fileGuid
                    }).ToList();

                File.WriteAllText(Path.Combine(_dialog.SelectedPath, "RandFiles.json"), JsonSerializer.Serialize(randFiles, JsonOptions));


                //NosFiles
                _dialog.Description = @"Nos-File on Server";
                if (_dialog.ShowDialog() != DialogResult.OK) return;

                if (File.Exists(Path.Combine(_dialog.SelectedPath, "NosFiles.json")))
                {
                    oldFiles = JsonSerializer.Deserialize<List<NosFile>>(File.ReadAllBytes(Path.Combine(_dialog.SelectedPath, "NosFiles.json")).AsSpan());
                }

                var nosFiles = Directory.GetFiles(_dialog.SelectedPath, "*.NOS").Select(file => new FileInfo(file))
                    .Select(fileInfo =>
                        new NosFile
                        {
                            Name = fileInfo.Name,
                            Size = fileInfo.Length,
                            CreationTimeUtc = fileInfo.CreationTimeUtc.ToString(),
                            Version = oldFiles!.Any(x =>
                                x.Name == fileInfo.Name && x.CreationTimeUtc == fileInfo.CreationTimeUtc.ToString())
                                ? oldFiles.First(x => x.Name == fileInfo.Name).Version
                                : fileGuid
                        }).ToList();


                File.WriteAllText(Path.Combine(_dialog.SelectedPath, "NosFiles.json"), JsonSerializer.Serialize(nosFiles, JsonOptions));

                //News File
                _dialog.Description = @"News-File on Server";
                if (_dialog.ShowDialog() != DialogResult.OK) return;
                var jsonNewsFile = JsonSerializer.Serialize(new NewsFile
                {
                    EventText = txtEventText.Text,
                    EventLink = txtEventLink.Text,
                    News = txtNews.Text
                }, JsonOptions);
                File.WriteAllText(Path.Combine(_dialog.SelectedPath, "NewsFile.json"), jsonNewsFile);

                MessageBox.Show(@"Finished");
            }
            catch (Exception exception)
            {
                var st = new StackTrace(exception, true);
                var stackFrame = st.GetFrame(0);

                MessageBox.Show(string.Format(@"At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                        stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(),
                        stackFrame.GetMethod(), Environment.NewLine, stackFrame.GetFileName(),
                        exception.Message));
                throw;
            }
        }
    }
}