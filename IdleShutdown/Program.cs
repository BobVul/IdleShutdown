using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace IdleShutdown
{
    static class Program
    {
        private const string MUTEX_NAME = "IdleShutdownMutex";
        private const string NAMED_PIPE_NAME = "IdleShutdownPipe";

        private static Mutex instanceMutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            double initialDelay = 5;
            bool persistent = false;
            bool showHelp = false;
            OptionSet options = new OptionSet()
            {
                { "t|time=|m|minutes=",
                    "The number of minutes to wait before shutdown. Fractional values are accepted.\n" +
                    "Defaults to 5 if no value is provided.\n" +
                    "Has no effect if this is a persistent instance.",
                    (double t) => initialDelay = t },
                { "p|persistent",
                    "Start an instance that sits in the background waiting for notification from another instance.\n" +
                    "See issue #1 on GitHub for details.", (p) => persistent = p != null },
                { "?|h|help", "Show this help.", (h) => showHelp = h != null }
            };
            
            options.Parse(args);
            
            if (showHelp)
            {
                // why does Mono.Options apparently not include a way to get descriptions as a string?
                using (StringWriter writer = new StringWriter())
                {
                    options.WriteOptionDescriptions(writer);
                    MessageBox.Show(writer.ToString());
                }
                return;
            }

            bool hasMutex;
            try
            {
                instanceMutex = new Mutex(false, @"Global\" + MUTEX_NAME);
                hasMutex = instanceMutex.WaitOne(0);
            }
            catch (AbandonedMutexException)
            {
                hasMutex = true;
            }

            if (persistent && !hasMutex)
            {
                MessageBox.Show("A persistent instance can only be started when no other instances are running.");
                return;
            }

            if (!persistent)
            {
                if (!hasMutex)
                {
                    NamedPipeUtils.SendTimerStart(NAMED_PIPE_NAME, initialDelay);
                }
                else
                {
                    // we only use the mutex for checking if persistent exists
                    // otherwise, allow multiple non-persistent instances by releasing the mutex *before* timer starts
                    instanceMutex.ReleaseMutex();

                    MainForm form = new MainForm();
                    form.InitialDelay = TimeSpan.FromMinutes(initialDelay);
                    form.ExitOnAbort = true;
                    form.StartShutdownTimer();
                    Application.Run(form);
                }
            }
            else
            {
                MainForm form = new MainForm();
                form.ExitOnAbort = false;
                NamedPipeListener listener = new NamedPipeListener(NAMED_PIPE_NAME, form);
                listener.StartListener();
                // force the creation of a handle
                IntPtr temp = form.Handle;
                Application.Run();

                // for persistent instances release the mutex *after* it's finished/closed
                instanceMutex.ReleaseMutex();
            }
        }
    }
}
