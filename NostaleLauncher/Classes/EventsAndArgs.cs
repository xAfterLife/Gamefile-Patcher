using System;

namespace NostaleLauncher.Classes
{
    public static class EventsAndArgs
    {
        public class FileErrorEventArgs : EventArgs
        {
            public string FileName { get; set; }
            public string ExceptionText { get; set; }
        }

        public class StateChangedEventArgs : EventArgs
        {
            public Globals.PatcherStates State { get; set; }
        }

        public class ProgressChangedEventArgs : EventArgs
        {
            public string FileName { get; set; }
        }
    }
}