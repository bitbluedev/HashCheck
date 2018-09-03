namespace HashCheck
{
    partial class DiffForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.cancelDiffButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.diffStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.diffFileButton = new System.Windows.Forms.Button();
            this.diffFileTextBox = new System.Windows.Forms.TextBox();
            this.diffRichTextBox = new System.Windows.Forms.RichTextBox();
            this.firstHashButton = new System.Windows.Forms.Button();
            this.secondHashButton = new System.Windows.Forms.Button();
            this.file1TextBox = new System.Windows.Forms.TextBox();
            this.file2TextBox = new System.Windows.Forms.TextBox();
            this.noFileCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(12, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(120, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(138, 12);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(120, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.Enabled = false;
            this.resumeButton.Location = new System.Drawing.Point(264, 12);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(120, 23);
            this.resumeButton.TabIndex = 2;
            this.resumeButton.Text = "Resume";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // cancelDiffButton
            // 
            this.cancelDiffButton.Enabled = false;
            this.cancelDiffButton.Location = new System.Drawing.Point(390, 12);
            this.cancelDiffButton.Name = "cancelDiffButton";
            this.cancelDiffButton.Size = new System.Drawing.Size(120, 23);
            this.cancelDiffButton.TabIndex = 3;
            this.cancelDiffButton.Text = "Stop";
            this.cancelDiffButton.UseVisualStyleBackColor = true;
            this.cancelDiffButton.Click += new System.EventHandler(this.CancelDiffButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.diffStatusLabel});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 394);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(781, 20);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 15);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // diffStatusLabel
            // 
            this.diffStatusLabel.Name = "diffStatusLabel";
            this.diffStatusLabel.Size = new System.Drawing.Size(12, 15);
            this.diffStatusLabel.Text = "-";
            // 
            // diffFileButton
            // 
            this.diffFileButton.Location = new System.Drawing.Point(12, 99);
            this.diffFileButton.Name = "diffFileButton";
            this.diffFileButton.Size = new System.Drawing.Size(130, 23);
            this.diffFileButton.TabIndex = 10;
            this.diffFileButton.Text = "Diff output file:";
            this.diffFileButton.UseVisualStyleBackColor = true;
            this.diffFileButton.Click += new System.EventHandler(this.DiffFileButton_Click);
            // 
            // diffFileTextBox
            // 
            this.diffFileTextBox.Location = new System.Drawing.Point(148, 101);
            this.diffFileTextBox.Name = "diffFileTextBox";
            this.diffFileTextBox.Size = new System.Drawing.Size(550, 20);
            this.diffFileTextBox.TabIndex = 11;
            this.diffFileTextBox.TextChanged += new System.EventHandler(this.DiffFileTextBox_TextChanged);
            // 
            // diffRichTextBox
            // 
            this.diffRichTextBox.Location = new System.Drawing.Point(12, 128);
            this.diffRichTextBox.Name = "diffRichTextBox";
            this.diffRichTextBox.Size = new System.Drawing.Size(757, 229);
            this.diffRichTextBox.TabIndex = 4;
            this.diffRichTextBox.Text = "";
            this.diffRichTextBox.WordWrap = false;
            // 
            // firstHashButton
            // 
            this.firstHashButton.Location = new System.Drawing.Point(12, 41);
            this.firstHashButton.Name = "firstHashButton";
            this.firstHashButton.Size = new System.Drawing.Size(130, 23);
            this.firstHashButton.TabIndex = 12;
            this.firstHashButton.Text = "First Hash";
            this.firstHashButton.UseVisualStyleBackColor = true;
            this.firstHashButton.Click += new System.EventHandler(this.FirstHashButton_Click);
            // 
            // secondHashButton
            // 
            this.secondHashButton.Location = new System.Drawing.Point(12, 70);
            this.secondHashButton.Name = "secondHashButton";
            this.secondHashButton.Size = new System.Drawing.Size(130, 23);
            this.secondHashButton.TabIndex = 13;
            this.secondHashButton.Text = "Second Hash";
            this.secondHashButton.UseVisualStyleBackColor = true;
            this.secondHashButton.Click += new System.EventHandler(this.SecondHashButton_Click);
            // 
            // file1TextBox
            // 
            this.file1TextBox.Location = new System.Drawing.Point(148, 43);
            this.file1TextBox.Name = "file1TextBox";
            this.file1TextBox.Size = new System.Drawing.Size(550, 20);
            this.file1TextBox.TabIndex = 14;
            this.file1TextBox.TextChanged += new System.EventHandler(this.File1TextBox_TextChanged);
            // 
            // file2TextBox
            // 
            this.file2TextBox.Location = new System.Drawing.Point(148, 72);
            this.file2TextBox.Name = "file2TextBox";
            this.file2TextBox.Size = new System.Drawing.Size(550, 20);
            this.file2TextBox.TabIndex = 15;
            this.file2TextBox.TextChanged += new System.EventHandler(this.File2TextBox_TextChanged);
            // 
            // noFileCheckBox
            // 
            this.noFileCheckBox.AutoSize = true;
            this.noFileCheckBox.Location = new System.Drawing.Point(704, 103);
            this.noFileCheckBox.Name = "noFileCheckBox";
            this.noFileCheckBox.Size = new System.Drawing.Size(56, 17);
            this.noFileCheckBox.TabIndex = 16;
            this.noFileCheckBox.Text = "No file";
            this.noFileCheckBox.UseVisualStyleBackColor = true;
            this.noFileCheckBox.CheckedChanged += new System.EventHandler(this.NoFileCheckBox_CheckedChanged);
            // 
            // DiffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 414);
            this.Controls.Add(this.noFileCheckBox);
            this.Controls.Add(this.file2TextBox);
            this.Controls.Add(this.file1TextBox);
            this.Controls.Add(this.secondHashButton);
            this.Controls.Add(this.firstHashButton);
            this.Controls.Add(this.diffFileTextBox);
            this.Controls.Add(this.diffFileButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.diffRichTextBox);
            this.Controls.Add(this.cancelDiffButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DiffForm";
            this.Text = "DiffForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiffForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button cancelDiffButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel diffStatusLabel;
        private System.Windows.Forms.Button diffFileButton;
        private System.Windows.Forms.TextBox diffFileTextBox;
        private System.Windows.Forms.RichTextBox diffRichTextBox;
        private System.Windows.Forms.Button firstHashButton;
        private System.Windows.Forms.Button secondHashButton;
        private System.Windows.Forms.TextBox file1TextBox;
        private System.Windows.Forms.TextBox file2TextBox;
        private System.Windows.Forms.CheckBox noFileCheckBox;
    }
}