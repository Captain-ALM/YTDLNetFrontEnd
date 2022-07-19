namespace com.captainalm.YTDLNetFrontEnd
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelEntry = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxExtraArgs = new System.Windows.Forms.TextBox();
            this.buttonSaveTo = new System.Windows.Forms.Button();
            this.textBoxSaveDir = new System.Windows.Forms.TextBox();
            this.textBoxEntry = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.labelExtraArgs = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.backgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialogMain = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelEntry, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxOutput, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.buttonInstall, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonExit, 1, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(284, 161);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelEntry
            // 
            this.tableLayoutPanelEntry.ColumnCount = 2;
            this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanelEntry, 2);
            this.tableLayoutPanelEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelEntry.Controls.Add(this.textBoxExtraArgs, 0, 2);
            this.tableLayoutPanelEntry.Controls.Add(this.buttonSaveTo, 1, 1);
            this.tableLayoutPanelEntry.Controls.Add(this.textBoxSaveDir, 0, 1);
            this.tableLayoutPanelEntry.Controls.Add(this.textBoxEntry, 0, 0);
            this.tableLayoutPanelEntry.Controls.Add(this.buttonGo, 1, 0);
            this.tableLayoutPanelEntry.Controls.Add(this.labelExtraArgs, 1, 2);
            this.tableLayoutPanelEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEntry.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelEntry.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelEntry.Name = "tableLayoutPanelEntry";
            this.tableLayoutPanelEntry.RowCount = 3;
            this.tableLayoutPanelMain.SetRowSpan(this.tableLayoutPanelEntry, 3);
            this.tableLayoutPanelEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelEntry.Size = new System.Drawing.Size(284, 60);
            this.tableLayoutPanelEntry.TabIndex = 0;
            // 
            // textBoxExtraArgs
            // 
            this.textBoxExtraArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExtraArgs.Location = new System.Drawing.Point(0, 39);
            this.textBoxExtraArgs.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxExtraArgs.Name = "textBoxExtraArgs";
            this.textBoxExtraArgs.Size = new System.Drawing.Size(213, 20);
            this.textBoxExtraArgs.TabIndex = 4;
            // 
            // buttonSaveTo
            // 
            this.buttonSaveTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveTo.Location = new System.Drawing.Point(213, 19);
            this.buttonSaveTo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSaveTo.Name = "buttonSaveTo";
            this.buttonSaveTo.Size = new System.Drawing.Size(71, 20);
            this.buttonSaveTo.TabIndex = 3;
            this.buttonSaveTo.Text = "Save To...";
            this.buttonSaveTo.UseVisualStyleBackColor = true;
            this.buttonSaveTo.Click += new System.EventHandler(this.buttonSaveTo_Click);
            // 
            // textBoxSaveDir
            // 
            this.textBoxSaveDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSaveDir.Location = new System.Drawing.Point(0, 19);
            this.textBoxSaveDir.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSaveDir.Name = "textBoxSaveDir";
            this.textBoxSaveDir.Size = new System.Drawing.Size(213, 20);
            this.textBoxSaveDir.TabIndex = 2;
            // 
            // textBoxEntry
            // 
            this.textBoxEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEntry.Location = new System.Drawing.Point(0, 0);
            this.textBoxEntry.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxEntry.Name = "textBoxEntry";
            this.textBoxEntry.Size = new System.Drawing.Size(213, 20);
            this.textBoxEntry.TabIndex = 0;
            // 
            // buttonGo
            // 
            this.buttonGo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGo.Location = new System.Drawing.Point(213, 0);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(71, 19);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "Go!";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // labelExtraArgs
            // 
            this.labelExtraArgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExtraArgs.Location = new System.Drawing.Point(216, 39);
            this.labelExtraArgs.Name = "labelExtraArgs";
            this.labelExtraArgs.Size = new System.Drawing.Size(65, 21);
            this.labelExtraArgs.TabIndex = 5;
            this.labelExtraArgs.Text = ": Extra Args";
            this.labelExtraArgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOutput
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxOutput, 2);
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(1, 81);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(282, 79);
            this.textBoxOutput.TabIndex = 4;
            this.textBoxOutput.WordWrap = false;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInstall.Location = new System.Drawing.Point(0, 60);
            this.buttonInstall.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(142, 20);
            this.buttonInstall.TabIndex = 2;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(142, 60);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(142, 20);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // backgroundWorkerMain
            // 
            this.backgroundWorkerMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMain_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "YT-DL Front End";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelEntry.ResumeLayout(false);
            this.tableLayoutPanelEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEntry;
        private System.Windows.Forms.TextBox textBoxEntry;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonExit;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMain;
        private System.Windows.Forms.TextBox textBoxSaveDir;
        private System.Windows.Forms.Button buttonSaveTo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogMain;
        private System.Windows.Forms.TextBox textBoxExtraArgs;
        private System.Windows.Forms.Label labelExtraArgs;
    }
}

