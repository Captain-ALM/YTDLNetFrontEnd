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
using com.captainalm.YTDLNetFrontEnd.util;

namespace com.captainalm.YTDLNetFrontEnd
{
    public partial class Main : Form
    {
        private MonitorableProcess theProcess;

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
            textBoxSaveDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            textBoxOutput.AppendText("Starting: " + ProductName + " : " + ProductVersion + Environment.NewLine);
            textBoxOutput.AppendText("Copyright: (C) " + this.CompanyName + " : BSD-3-Clause License" + Environment.NewLine);
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerMain.IsBusy) backgroundWorkerMain.RunWorkerAsync(BWArg.Go);

        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerMain.IsBusy) backgroundWorkerMain.RunWorkerAsync(BWArg.Install);
        }

        private void buttonSaveTo_Click(object sender, EventArgs e)
        {
            folderBrowserDialogMain.SelectedPath = Environment.CurrentDirectory;
            if (folderBrowserDialogMain.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Environment.CurrentDirectory = folderBrowserDialogMain.SelectedPath;
                textBoxSaveDir.Text = folderBrowserDialogMain.SelectedPath;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void setEnableButtons(bool value)
        {
            this.Invoke(new Action(() =>
            {
                buttonExit.Enabled = value;
                buttonInstall.Enabled = value;
                buttonGo.Enabled = value;
            }));
        }

        private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            switch ((BWArg)e.Argument)
            {
                case BWArg.Install:
                    setEnableButtons(false);

                    using (var locpro =
                    YTDL.executeInstall((YTDL.getInstalled() != ApplicationType.Unavailable) ? YTDL.getInstalled() :
                    (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) ? ApplicationType.YoutubeDL : ApplicationType.YT_DLP),
                    YTDL.getInstalled() != ApplicationType.Unavailable))
                    {
                        locpro.addOuputReceiver(new OutputReceiverTextbox(textBoxOutput));
                        locpro.addErrorReceiver(new OutputReaderPrefixed(textBoxOutput, "Error: "));
                        try
                        {
                            locpro.start();
                            locpro.waitForExit();
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action(() =>
                            {
                                textBoxOutput.AppendText("Could not start python, is python installed?" + Environment.NewLine
                                    + ex.GetType().FullName + " : " + ex.Message + Environment.NewLine);
                            }));
                        }
                    }

                    if (YTDL.getInstalled() != ApplicationType.Unavailable)
                    {
                        this.Invoke(new Action(() =>
                        {
                            buttonGo.Enabled = true;
                            buttonInstall.Text = "Update";
                        }));
                    }

                    setEnableButtons(true);
                    break;
                case BWArg.Go:
                    setEnableButtons(false);

                    if (theProcess != null)
                    {
                        if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift)) theProcess.kill();
                        theProcess.waitForExit();
                        theProcess.close();
                    }

                    var theTarget = "";

                    this.Invoke(new Action(() =>
                        {
                            theTarget = textBoxEntry.Text;
                            textBoxEntry.Text = "";
                            textBoxOutput.AppendText("Downloading: " + theTarget + Environment.NewLine);
                        }));

                    theProcess = YTDL.executeApplication(theTarget);
                    if (theProcess != null)
                    {
                        theProcess.addOuputReceiver(new OutputReceiverTextbox(textBoxOutput));
                        theProcess.addErrorReceiver(new OutputReaderPrefixed(textBoxOutput, "Error: "));
                        try
                        {
                            theProcess.start();
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action(() =>
                            {
                                textBoxOutput.AppendText("Could not start python, is python and the downloader installed?" + Environment.NewLine
                                    + ex.GetType().FullName + " : " + ex.Message + Environment.NewLine);
                            }));
                        }
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            textBoxOutput.AppendText("Could not start python, is python and the downloader installed?" + Environment.NewLine);
                        }));
                    }

                    setEnableButtons(true);
                    break;
                default:
                    break;
            }
        }

        private enum BWArg
        {
            Install,
            Go
        }
    }
}
