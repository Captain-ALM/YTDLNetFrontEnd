using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace com.captainalm.YTDLNetFrontEnd.util
{
    public class MonitorableProcess : IDisposable
    {
        protected ProcessStartInfo startInfo;
        protected Process representation;
        protected List<IProcessOuputReceiver> outputReceivers = new List<IProcessOuputReceiver>();
        protected List<IProcessOuputReceiver> errorReceivers = new List<IProcessOuputReceiver>();
        protected bool closed = false;

        private object inputSLock = new object();
        private object outputSLock = new object();
        private object processSLock = new object();

        public MonitorableProcess(ProcessStartInfo startInfo, bool redirectInput = false)
        {
            this.startInfo = startInfo;
            this.startInfo.UseShellExecute = false;
            this.startInfo.RedirectStandardInput = redirectInput;
        }

        public void addOuputReceiver(IProcessOuputReceiver processOuput)
        {
            lock (outputSLock)
            {
                lock (processSLock)
                {
                    if (representation == null) startInfo.RedirectStandardOutput = true;
                }
                outputReceivers.Add(processOuput);
            }
        }

        public void removeOutputReceiver(IProcessOuputReceiver processOuput)
        {
            lock (outputSLock)
            {
                outputReceivers.Remove(processOuput);
            }
        }

        public void addErrorReceiver(IProcessOuputReceiver processError)
        {
            lock (outputSLock)
            {
                lock (processSLock)
                {
                    if (representation == null) startInfo.RedirectStandardError = true;
                }
                errorReceivers.Add(processError);
            }
        }

        public void removeErrorReceiver(IProcessOuputReceiver processError)
        {
            lock (outputSLock)
            {
                errorReceivers.Remove(processError);
            }
        }

        public void writeData(string inputData)
        {
            lock (processSLock)
            {
                if (!startInfo.RedirectStandardInput || representation == null || closed || representation.HasExited) return;
                lock (inputSLock)
                {
                    representation.StandardInput.Write(inputData);
                }
            }
        }

        public Process start()
        {
            if (closed) return null;
            lock (processSLock)
            {
                representation = Process.Start(startInfo);
                if (startInfo.RedirectStandardOutput)
                {
                    representation.BeginOutputReadLine();
                    representation.OutputDataReceived += representation_OutputDataReceived;
                }
                if (startInfo.RedirectStandardError)
                {
                    representation.BeginErrorReadLine();
                    representation.ErrorDataReceived += representation_ErrorDataReceived;
                }
                representation.Exited += representation_Exited;
                representation.EnableRaisingEvents = true;
                if (startInfo.RedirectStandardInput) representation.StandardInput.AutoFlush = true;
            }
            return representation;
        }

        void representation_Exited(object sender, EventArgs e)
        {
            try
            {
                representation.CancelOutputRead();
            }
            catch (InvalidOperationException ex)
            {
            }
            try
            {
                representation.CancelErrorRead();
            }
            catch (InvalidOperationException ex)
            {
            }
        }

        protected void representation_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            foreach (var c in outputReceivers) if (e.Data != null && !e.Data.Equals("")) lock (outputSLock) c.receiveData(e.Data);
        }

        void representation_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            foreach (var c in errorReceivers) if (e.Data != null && !e.Data.Equals("")) lock (outputSLock) c.receiveData(e.Data);
        }

        public void waitForExit()
        {
            if (representation == null || closed) return;
            if (!representation.HasExited) representation.WaitForExit();
        }

        void IDisposable.Dispose()
        {
            close();
        }

        public void close()
        {
            if (representation == null || closed) return;
            closed = true;
            waitForExit();
            if (representation != null && startInfo.RedirectStandardInput) representation.StandardInput.Close();
            representation.Close();
        }

        public void kill()
        {
            if (representation != null && !closed && !representation.HasExited) representation.Kill();
        }
    }
}
