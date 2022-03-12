using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using NostaleLauncher.Structs;
using static NostaleLauncher.Globals.PatcherStates;

namespace NostaleLauncher.Classes
{
    public sealed class DownloadHandler
    {
        public int MaxFiles;
        public event EventHandler<EventsAndArgs.ProgressChangedEventArgs> ProgressChanged;

        private void OnProgressChanged(EventsAndArgs.ProgressChangedEventArgs args) { ProgressChanged?.Invoke(this, args); }

        public event EventHandler<EventsAndArgs.FileErrorEventArgs> FileError;

        private void OnFileError(EventsAndArgs.FileErrorEventArgs args) { FileError?.Invoke(this, args); }

        public void Update()
        {
            try
            {
                if (Globals.FILES_ON_WEB.IsNullOrEmpty())
                {
                    App.CurrentState = JsonNotFound;
                    return;
                }

                MaxFiles = Globals.FILES_ON_WEB.Count;
                App.CurrentState = Updating;

                var lastPatch = new List<NosFile>();
                if (File.Exists(Path.Combine(Globals.NOS_DIRECTORY, "LastPatch.json")))
                    lastPatch = JsonSerializer.Deserialize<List<NosFile>>(File.ReadAllBytes(Path.Combine(Globals.NOS_DIRECTORY, "LastPatch.json")));

                Globals.FILES_ON_WEB.ForEach(file =>
                {
                    try
                    {
                        var fileInfo = new FileInfo(Path.Combine(Globals.NOS_DIRECTORY, file.Name));
                        if (fileInfo.Exists && lastPatch.Count(x => x.Name == file.Name && x.Version == file.Version) > 0) return;

                        if (!Globals.CanUpdate()) return;

                        Globals.WClient.DownloadFile(new Uri(Path.Combine(RES.FILES_ON_WEB_URL, file.Name)),
                            Path.Combine(Globals.NOS_DIRECTORY, file.Name));
                        OnProgressChanged(new EventsAndArgs.ProgressChangedEventArgs
                        {
                            FileName = file.Name
                        });
                    }
                    catch (Exception e)
                    {
                        OnFileError(new EventsAndArgs.FileErrorEventArgs
                        {
                            ExceptionText = e.Message,
                            FileName = file.Name
                        });
                    }
                });

                File.WriteAllText(Path.Combine(Globals.NOS_DIRECTORY, "LastPatch.json"),
                    JsonSerializer.Serialize(Globals.FILES_ON_WEB));
                App.CurrentState = Finished;
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
                        ex.Message),
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                App.CurrentState = Error;
            }
        }
    }
}