using System;
using System.Windows.Forms;
using NostaleLauncher.Classes;
using NostaleLauncher.Forms;

namespace NostaleLauncher
{
    public static class App
    {
        /// <summary>
        ///     Current State of the Patcher
        /// </summary>
        private static Globals.PatcherStates _currentState;

        public static Globals.PatcherStates CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                OnStateChanged(new EventsAndArgs.StateChangedEventArgs
                {
                    State = value
                });
            }
        }

        /// <summary>
        ///     Event vor State-Changes
        /// </summary>
        public static event EventHandler<EventsAndArgs.StateChangedEventArgs> StateChanged;

        private static void OnStateChanged(EventsAndArgs.StateChangedEventArgs args) { StateChanged?.Invoke(null, args); }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}