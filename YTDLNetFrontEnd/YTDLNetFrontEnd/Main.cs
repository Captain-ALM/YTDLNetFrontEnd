using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace com.captainalm.YTDLNetFrontEnd
{
    public partial class Main : Form
    {
        private Process theProcess;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (YTDL.getInstalled() == ApplicationType.Unavailable)
            {
                buttonGo.Enabled = false;
            }
            else
            {
                buttonInstall.Text = "Update";
            }
            Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerMain.IsBusy) backgroundWorkerMain.RunWorkerAsync(BWArg.Go);
            
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerMain.IsBusy) backgroundWorkerMain.RunWorkerAsync(BWArg.Install);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            switch ((BWArg)e.Argument)
            {
                case BWArg.Install:
                     this.Invoke(new Action(() => {
                         buttonExit.Enabled = false;
                         buttonInstall.Enabled = false;
                     }));
                     
                     var loctxt = 
                     YTDL.executeInstall((YTDL.getInstalled() != ApplicationType.Unavailable) ? YTDL.getInstalled() :
                    (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) ? ApplicationType.YoutubeDL : ApplicationType.YT_DLP), 
                    YTDL.getInstalled() != ApplicationType.Unavailable) +
                     Environment.NewLine;
                     this.Invoke(new Action(() =>
                     {
                         textBoxOutput.Text += loctxt;
                     }));
                    if (YTDL.getInstalled() != ApplicationType.Unavailable)
                    {
                        this.Invoke(new Action(() =>
                        {
                            buttonGo.Enabled = true;
                            buttonInstall.Text = "Update";
                        }));
                    }
                    this.Invoke(new Action(() =>
                    {
                        buttonInstall.Enabled = true;
                        buttonExit.Enabled = true;
                    }));
                    break;
                case BWArg.Go:
                    this.Invoke(new Action(() =>
                    {
                        buttonExit.Enabled = false;
                        buttonGo.Enabled = false;
                    }));

                    if (theProcess != null)
                    {
                        if (!theProcess.HasExited) theProcess.WaitForExit();
                        theProcess.Close();
                    }

                    var theTarget = "";

                    this.Invoke(new Action(() =>
                        {
                            theTarget = textBoxEntry.Text;
                        }));

                    theProcess = YTDL.executeApplication(theTarget);
                    if (theProcess != null)
                    {
                        theProcess.BeginOutputReadLine();
                        theProcess.BeginErrorReadLine();
                        theProcess.OutputDataReceived += theProcess_OutputDataReceived;
                        theProcess.ErrorDataReceived += theProcess_ErrorDataReceived;
                        theProcess.Exited += theProcess_Exited;
                        theProcess.EnableRaisingEvents = true;
                        theProcess.WaitForExit();
                    }
                    this.Invoke(new Action(() =>
                    {
                        buttonGo.Enabled = true;
                        buttonExit.Enabled = true;
                    }));
                    break;
                default:
                    break;
            }
        }

        void theProcess_Exited(object sender, EventArgs e)
        {
            theProcess.CancelOutputRead();
            theProcess.CancelErrorRead();
        }

        void theProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data.Equals("")) return;
            this.Invoke(new Action(() =>
            {
                textBoxOutput.Text += "Error: " + e.Data + Environment.NewLine;
            }));
        }

        void theProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                textBoxOutput.Text += e.Data + Environment.NewLine;
            }));
        }

        private enum BWArg {
            Install,
            Go
        }
    }
}
