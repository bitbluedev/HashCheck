using HashCheck.code;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HashCheck
{
    public partial class DiffForm : Form
    {
        private DiffReader diffReader;
        private bool windowClosing = false;
        private List<string> diffPreview = new List<string>();

        public DiffForm(string file1, string file2)
        {
            InitializeComponent();

            file1TextBox.Text = file1;
            file2TextBox.Text = file2;
        }

        // UI event handlers

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(file1TextBox.Text) || string.IsNullOrEmpty(file2TextBox.Text))
            {
                diffStatusLabel.Text = "Input files are invalid.";
                return;
            }

            if (!noFileCheckBox.Checked && string.IsNullOrEmpty(diffFileTextBox.Text))
            {
                diffStatusLabel.Text = "Output file is invalid.";
                return;
            }

            diffPreview.Clear();

            startButton.Enabled = false;
            pauseButton.Enabled = true;
            cancelDiffButton.Enabled = true;
            firstHashButton.Enabled = false;
            secondHashButton.Enabled = false;
            diffFileButton.Enabled = false;
            diffFileTextBox.Enabled = false;
            noFileCheckBox.Enabled = false;

            diffStatusLabel.Text = "-";

            diffReader = new DiffReader();
            diffReader.File1 = file1TextBox.Text;
            diffReader.File2 = file2TextBox.Text;
            diffReader.WriteOutputToFile = !noFileCheckBox.Checked;
            diffReader.OnProgressChanged += DiffReader_OnProgressChanged;
            diffReader.OnFinished += DiffReader_OnFinished;
            diffReader.OutputFile = diffFileTextBox.Text;
            diffReader.Start();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            resumeButton.Enabled = true;
            pauseButton.Enabled = false;

            diffReader.Pause();
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            resumeButton.Enabled = false;
            pauseButton.Enabled = true;

            diffReader.Resume();
        }

        private void CancelDiffButton_Click(object sender, EventArgs e)
        {
            diffReader.Stop();
        }

        private void FirstHashButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                file1TextBox.Text = openFileDialog.FileName;
            }
        }

        private void SecondHashButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                file2TextBox.Text = openFileDialog.FileName;
            }
        }

        private void DiffFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                diffFileTextBox.Text = saveFileDialog.FileName;
                startButton.Enabled = true;
            }

        }

        private void NoFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noFileCheckBox.Checked && !string.IsNullOrEmpty(file1TextBox.Text) && !string.IsNullOrEmpty(file2TextBox.Text))
            {
                startButton.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(file1TextBox.Text) || string.IsNullOrEmpty(file2TextBox.Text) || string.IsNullOrEmpty(diffFileTextBox.Text))
                {
                    startButton.Enabled = false;
                }
            }
        }

        private void File1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(file1TextBox.Text))
            {
                startButton.Enabled = false;
                return;
            }
            if (string.IsNullOrEmpty(file2TextBox.Text) || (!noFileCheckBox.Checked && string.IsNullOrEmpty(diffFileTextBox.Text)))
            {
                startButton.Enabled = false;
                return;
            }
            startButton.Enabled = true;
        }

        private void File2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(file2TextBox.Text))
            {
                startButton.Enabled = false;
                return;
            }
            if (string.IsNullOrEmpty(file1TextBox.Text) || (!noFileCheckBox.Checked && string.IsNullOrEmpty(diffFileTextBox.Text)))
            {
                startButton.Enabled = false;
                return;
            }
            startButton.Enabled = true;
        }

        private void DiffFileTextBox_TextChanged(object sender, EventArgs e)
        {
            if (noFileCheckBox.Checked)
            {
                return;
            }
            if (string.IsNullOrEmpty(diffFileTextBox.Text) || string.IsNullOrEmpty(file1TextBox.Text) || string.IsNullOrEmpty(file2TextBox.Text))
            {
                startButton.Enabled = false;
                return;
            }
            startButton.Enabled = true;
        }

        private void DiffForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!windowClosing && diffReader != null && diffReader.IsBusy)
            {
                e.Cancel = true;
                diffReader.Stop();

                startButton.Enabled = false;
                pauseButton.Enabled = false;
                resumeButton.Enabled = false;
                cancelDiffButton.Enabled = false;
                windowClosing = true;
            }
        }

        // Worker event handlers

        private void DiffReader_OnFinished(DiffReader sender, string message)
        {
            base.Invoke((Action)delegate
            {
                startButton.Enabled = true;
                pauseButton.Enabled = false;
                resumeButton.Enabled = false;
                cancelDiffButton.Enabled = false;
                diffFileButton.Enabled = true;
                diffFileTextBox.Enabled = true;
                firstHashButton.Enabled = true;
                secondHashButton.Enabled = true;
                noFileCheckBox.Enabled = true;

                diffStatusLabel.Text = message;

                if (windowClosing)
                {
                    Close();
                }
            });
        }

        private void DiffReader_OnProgressChanged(DiffReader sender, string message)
        {
            base.Invoke((Action)delegate
            {
                diffPreview.Add(message);
                if (diffPreview.Count > 10)
                {
                    diffPreview.RemoveAt(0);
                }
                diffRichTextBox.Text = string.Join("\n", diffPreview.ToArray());
            });
        }
    }
}
