using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace IdleShutdown
{
    static class NamedPipeUtils
    {
        public static void SendTimerStart(string pipeName, double minutes)
        {
            using (NamedPipeClientStream pipeClient  = new NamedPipeClientStream(".", pipeName, PipeDirection.Out))
            {
	            StreamWriter writer = new StreamWriter(pipeClient);
	
	            pipeClient.Connect();
	            writer.Write(minutes.ToString("r"));
	            writer.Flush();

                pipeClient.WaitForPipeDrain();
                pipeClient.Close();
            }
        }
    }
}
