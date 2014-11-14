using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;

namespace IdleShutdown
{
    class NamedPipeListener
    {
        private string pipeName;
        private MainForm shutdownForm;

        public NamedPipeListener(string pipeName, MainForm shutdownForm)
        {
            this.pipeName = pipeName;
            this.shutdownForm = shutdownForm;
        }

        public void StartListener()
        {
            Thread listenerThread = new Thread(() =>
            {
                using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Message))
                {
                    StreamReader reader = new StreamReader(pipeServer);

                    while (true)
                    {
                        try
                        {
                            pipeServer.WaitForConnection();
                            string message = reader.ReadToEnd();
                            double minutes;
                            if (Double.TryParse(message, out minutes))
                            {
                                shutdownForm.Invoke((Action)(() =>
                                {
                                    shutdownForm.InitialDelay = TimeSpan.FromMinutes(minutes);
                                    shutdownForm.StartShutdownTimer();
                                }));
                            }

                        }
                        finally
                        {
                            // apparently a disconnect is required even if it's not connected
                            // else "pipe is broken"
                            //if (pipeServer.IsConnected)
                                pipeServer.Disconnect();
                        }
                    }
                }
            });

            listenerThread.IsBackground = true;
            listenerThread.Start();
        }
    }
}
