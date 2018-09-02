namespace HashCheck
{
    partial class MainForm
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
            this.scanButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.appStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.hashButton = new System.Windows.Forms.Button();
            this.pauseHashButton = new System.Windows.Forms.Button();
            this.resumeHashButton = new System.Windows.Forms.Button();
            this.cancelHashButton = new System.Windows.Forms.Button();
            this.selectRootDirButton = new System.Windows.Forms.Button();
            this.rootDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.hash1FileButton = new System.Windows.Forms.Button();
            this.hash2FileButton = new System.Windows.Forms.Button();
            this.hash1FileTextbox = new System.Windows.Forms.TextBox();
            this.hash2FileTextbox = new System.Windows.Forms.TextBox();
            this.diffButton = new System.Windows.Forms.Button();
            this.outputCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(12, 41);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(130, 23);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Scan DIR: Start";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(12, 70);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(120, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause Scan";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.Enabled = false;
            this.resumeButton.Location = new System.Drawing.Point(12, 99);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(120, 23);
            this.resumeButton.TabIndex = 2;
            this.resumeButton.Text = "Resume Scan";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(12, 128);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel Scan";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.appStatus});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 20);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 15);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // appStatus
            // 
            this.appStatus.Name = "appStatus";
            this.appStatus.Size = new System.Drawing.Size(12, 15);
            this.appStatus.Text = "-";
            // 
            // hashButton
            // 
            this.hashButton.Enabled = false;
            this.hashButton.Location = new System.Drawing.Point(12, 186);
            this.hashButton.Name = "hashButton";
            this.hashButton.Size = new System.Drawing.Size(120, 23);
            this.hashButton.TabIndex = 7;
            this.hashButton.Text = "Hash files";
            this.hashButton.UseVisualStyleBackColor = true;
            this.hashButton.Click += new System.EventHandler(this.HashButton_Click);
            // 
            // pauseHashButton
            // 
            this.pauseHashButton.Enabled = false;
            this.pauseHashButton.Location = new System.Drawing.Point(12, 215);
            this.pauseHashButton.Name = "pauseHashButton";
            this.pauseHashButton.Size = new System.Drawing.Size(120, 23);
            this.pauseHashButton.TabIndex = 8;
            this.pauseHashButton.Text = "Pause Hash";
            this.pauseHashButton.UseVisualStyleBackColor = true;
            this.pauseHashButton.Click += new System.EventHandler(this.PauseHashButton_Click);
            // 
            // resumeHashButton
            // 
            this.resumeHashButton.Enabled = false;
            this.resumeHashButton.Location = new System.Drawing.Point(12, 244);
            this.resumeHashButton.Name = "resumeHashButton";
            this.resumeHashButton.Size = new System.Drawing.Size(120, 23);
            this.resumeHashButton.TabIndex = 9;
            this.resumeHashButton.Text = "Resume Hash";
            this.resumeHashButton.UseVisualStyleBackColor = true;
            this.resumeHashButton.Click += new System.EventHandler(this.ResumeHashButton_Click);
            // 
            // cancelHashButton
            // 
            this.cancelHashButton.Enabled = false;
            this.cancelHashButton.Location = new System.Drawing.Point(12, 273);
            this.cancelHashButton.Name = "cancelHashButton";
            this.cancelHashButton.Size = new System.Drawing.Size(120, 23);
            this.cancelHashButton.TabIndex = 10;
            this.cancelHashButton.Text = "Cancel Hash";
            this.cancelHashButton.UseVisualStyleBackColor = true;
            this.cancelHashButton.Click += new System.EventHandler(this.CancelHashButton_Click);
            // 
            // selectRootDirButton
            // 
            this.selectRootDirButton.Location = new System.Drawing.Point(12, 12);
            this.selectRootDirButton.Name = "selectRootDirButton";
            this.selectRootDirButton.Size = new System.Drawing.Size(130, 23);
            this.selectRootDirButton.TabIndex = 11;
            this.selectRootDirButton.Text = "Root Directory:";
            this.selectRootDirButton.UseVisualStyleBackColor = true;
            this.selectRootDirButton.Click += new System.EventHandler(this.SelectRootDirButton_Click);
            // 
            // rootDirectoryTextBox
            // 
            this.rootDirectoryTextBox.Location = new System.Drawing.Point(148, 14);
            this.rootDirectoryTextBox.Name = "rootDirectoryTextBox";
            this.rootDirectoryTextBox.Size = new System.Drawing.Size(550, 20);
            this.rootDirectoryTextBox.TabIndex = 12;
            this.rootDirectoryTextBox.Text = "D:\\";
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(12, 157);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(130, 23);
            this.outputButton.TabIndex = 13;
            this.outputButton.Text = "Output file:";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Location = new System.Drawing.Point(148, 159);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.Size = new System.Drawing.Size(550, 20);
            this.outputFileTextBox.TabIndex = 14;
            this.outputFileTextBox.Text = "D:\\hash.txt";
            this.outputFileTextBox.TextChanged += new System.EventHandler(this.OutputFileTextBox_TextChanged);
            // 
            // hash1FileButton
            // 
            this.hash1FileButton.Location = new System.Drawing.Point(12, 302);
            this.hash1FileButton.Name = "hash1FileButton";
            this.hash1FileButton.Size = new System.Drawing.Size(130, 23);
            this.hash1FileButton.TabIndex = 15;
            this.hash1FileButton.Text = "First hash file";
            this.hash1FileButton.UseVisualStyleBackColor = true;
            this.hash1FileButton.Click += new System.EventHandler(this.Hash1FileButton_Click);
            // 
            // hash2FileButton
            // 
            this.hash2FileButton.Location = new System.Drawing.Point(12, 331);
            this.hash2FileButton.Name = "hash2FileButton";
            this.hash2FileButton.Size = new System.Drawing.Size(130, 23);
            this.hash2FileButton.TabIndex = 16;
            this.hash2FileButton.Text = "Second hash file";
            this.hash2FileButton.UseVisualStyleBackColor = true;
            this.hash2FileButton.Click += new System.EventHandler(this.Hash2FileButton_Click);
            // 
            // hash1FileTextbox
            // 
            this.hash1FileTextbox.Location = new System.Drawing.Point(148, 304);
            this.hash1FileTextbox.Name = "hash1FileTextbox";
            this.hash1FileTextbox.Size = new System.Drawing.Size(550, 20);
            this.hash1FileTextbox.TabIndex = 17;
            // 
            // hash2FileTextbox
            // 
            this.hash2FileTextbox.Location = new System.Drawing.Point(148, 333);
            this.hash2FileTextbox.Name = "hash2FileTextbox";
            this.hash2FileTextbox.Size = new System.Drawing.Size(550, 20);
            this.hash2FileTextbox.TabIndex = 18;
            // 
            // diffButton
            // 
            this.diffButton.Location = new System.Drawing.Point(12, 360);
            this.diffButton.Name = "diffButton";
            this.diffButton.Size = new System.Drawing.Size(120, 23);
            this.diffButton.TabIndex = 19;
            this.diffButton.Text = "Diff tool";
            this.diffButton.UseVisualStyleBackColor = true;
            this.diffButton.Click += new System.EventHandler(this.DiffButton_Click);
            // 
            // outputCheckBox
            // 
            this.outputCheckBox.AutoSize = true;
            this.outputCheckBox.Location = new System.Drawing.Point(704, 306);
            this.outputCheckBox.Name = "outputCheckBox";
            this.outputCheckBox.Size = new System.Drawing.Size(78, 17);
            this.outputCheckBox.TabIndex = 20;
            this.outputCheckBox.Text = "Use output";
            this.outputCheckBox.UseVisualStyleBackColor = true;
            this.outputCheckBox.CheckedChanged += new System.EventHandler(this.OutputCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.outputCheckBox);
            this.Controls.Add(this.diffButton);
            this.Controls.Add(this.hash2FileTextbox);
            this.Controls.Add(this.hash1FileTextbox);
            this.Controls.Add(this.hash2FileButton);
            this.Controls.Add(this.hash1FileButton);
            this.Controls.Add(this.outputFileTextBox);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.rootDirectoryTextBox);
            this.Controls.Add(this.selectRootDirButton);
            this.Controls.Add(this.cancelHashButton);
            this.Controls.Add(this.resumeHashButton);
            this.Controls.Add(this.pauseHashButton);
            this.Controls.Add(this.hashButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.scanButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "HashCheck";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel appStatus;
        private System.Windows.Forms.Button hashButton;
        private System.Windows.Forms.Button pauseHashButton;
        private System.Windows.Forms.Button resumeHashButton;
        private System.Windows.Forms.Button cancelHashButton;
        private System.Windows.Forms.Button selectRootDirButton;
        private System.Windows.Forms.TextBox rootDirectoryTextBox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.Button hash1FileButton;
        private System.Windows.Forms.Button hash2FileButton;
        private System.Windows.Forms.TextBox hash1FileTextbox;
        private System.Windows.Forms.TextBox hash2FileTextbox;
        private System.Windows.Forms.Button diffButton;
        private System.Windows.Forms.CheckBox outputCheckBox;
    }
}

