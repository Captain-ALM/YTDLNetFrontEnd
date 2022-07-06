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
            this.textBoxEntry = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.backgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
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
            this.tableLayoutPanelMain.Controls.Add(this.textBoxOutput, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonInstall, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonExit, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(284, 161);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelEntry
            // 
            this.tableLayoutPanelEntry.ColumnCount = 2;
            this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanelEntry, 2);
            this.tableLayoutPanelEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelEntry.Controls.Add(this.textBoxEntry, 0, 0);
            this.tableLayoutPanelEntry.Controls.Add(this.buttonGo, 1, 0);
            this.tableLayoutPanelEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEntry.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelEntry.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelEntry.Name = "tableLayoutPanelEntry";
            this.tableLayoutPanelEntry.RowCount = 1;
            this.tableLayoutPanelEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelEntry.Size = new System.Drawing.Size(284, 24);
            this.tableLayoutPanelEntry.TabIndex = 0;
            // 
            // textBoxEntry
            // 
            this.textBoxEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEntry.Location = new System.Drawing.Point(0, 2);
            this.textBoxEntry.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxEntry.Name = "textBoxEntry";
            this.textBoxEntry.Size = new System.Drawing.Size(227, 20);
            this.textBoxEntry.TabIndex = 0;
            // 
            // buttonGo
            // 
            this.buttonGo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGo.Location = new System.Drawing.Point(227, 0);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(57, 24);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "Go!";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // textBoxOutput
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxOutput, 2);
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(1, 49);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(282, 111);
            this.textBoxOutput.TabIndex = 3;
            this.textBoxOutput.WordWrap = false;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInstall.Location = new System.Drawing.Point(0, 24);
            this.buttonInstall.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(142, 24);
            this.buttonInstall.TabIndex = 1;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(142, 24);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(142, 24);
            this.buttonExit.TabIndex = 2;
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
    }
}

