using HashCheck.code;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HashCheck
{
    public partial class MainForm : Form
    {
        private DirScanner dirScanner;
        private Hasher hasher;

        private bool windowClosing = false;

        public MainForm()
        {
            InitializeComponent();
        }

        // UI event handlers

        private void SelectRootDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (Directory.Exists(rootDirectoryTextBox.Text))
            {
                folderBrowserDialog.SelectedPath = rootDirectoryTextBox.Text;
            }

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                rootDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(rootDirectoryTextBox.Text))
            {
                appStatus.Text = "Root directory doesn't exist.";
                return;
            }

            scanButton.Enabled = false;
            pauseButton.Enabled = true;
            cancelButton.Enabled = true;
            hashButton.Enabled = false;
            diffButton.Enabled = false;

            dirScanner = new DirScanner();
            dirScanner.RootDir = rootDirectoryTextBox.Text;
            dirScanner.OnFinished += DirScanner_OnFinished;
            dirScanner.OnProgressChanged += DirScanner_OnProgressChanged;
            dirScanner.Start();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            pauseButton.Enabled = false;
            resumeButton.Enabled = true;

            dirScanner.Pause();
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            pauseButton.Enabled = true;
            resumeButton.Enabled = false;

            dirScanner.Resume();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            dirScanner.Stop();
        }

        private void HashButton_Click(object sender, EventArgs e)
        {
            scanButton.Enabled = false;
            hashButton.Enabled = false;
            pauseHashButton.Enabled = true;
            cancelHashButton.Enabled = true;
            diffButton.Enabled = false;

            outputButton.Enabled = false;
            outputFileTextBox.Enabled = false;

            RemoveHashFileFromResults();

            hasher = new Hasher(dirScanner.Result);
            hasher.OutputFile = outputFileTextBox.Text;
            hasher.OnFinished += Hasher_OnFinished;
            hasher.OnProgressChanged += Hasher_OnProgressChanged;
            hasher.Start();
        }

        private void RemoveHashFileFromResults()
        {
            var hashFileSearchList = (from result in dirScanner.Result
                        where result.name == outputFileTextBox.Text && result.type == FileSystemItemType.File
                        select result).ToList();
            if (0 < hashFileSearchList.Count)
            {
                FileSystemItem hashFile = hashFileSearchList.First();
                dirScanner.Result.Remove(hashFile);
            }
        }

        private void PauseHashButton_Click(object sender, EventArgs e)
        {
            pauseHashButton.Enabled = false;
            resumeHashButton.Enabled = true;

            hasher.Pause();
        }

        private void ResumeHashButton_Click(object sender, EventArgs e)
        {
            pauseHashButton.Enabled = true;
            resumeHashButton.Enabled = false;

            hasher.Resume();
        }

        private void CancelHashButton_Click(object sender, EventArgs e)
        {
            hasher.Stop();
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                outputFileTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void Hash1FileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                hash1FileTextbox.Text = openFileDialog.FileName;
            }
        }

        private void Hash2FileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                hash2FileTextbox.Text = openFileDialog.FileName;
            }
        }

        private void DiffButton_Click(object sender, EventArgs e)
        {
            DiffForm diffForm = new DiffForm(hash1FileTextbox.Text, hash2FileTextbox.Text);
            diffForm.ShowDialog();
        }

        private void OutputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (outputCheckBox.Checked)
            {
                hash1FileTextbox.Text = outputFileTextBox.Text;
                hash1FileTextbox.Enabled = false;
                hash1FileButton.Enabled = false;
            }
            else
            {
                hash1FileTextbox.Enabled = true;
                hash1FileButton.Enabled = true;
            }
        }

        private void OutputFileTextBox_TextChanged(object sender, EventArgs e)
        {
            if (outputCheckBox.Checked)
            {
                hash1FileTextbox.Text = outputFileTextBox.Text;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!windowClosing)
            {
                if (dirScanner != null && dirScanner.IsBusy)
                {
                    e.Cancel = true;
                    windowClosing = true;
                    dirScanner.Stop();
                    return;
                }
                if (hasher != null && hasher.IsBusy)
                {
                    e.Cancel = true;
                    windowClosing = true;
                    hasher.Stop();
                    return;
                }
            }
        }

        // Workers' event handlers

        private void DirScanner_OnProgressChanged(DirScanner sender, string message)
        {
            base.Invoke((Action)delegate
            {
                appStatus.Text = message;
            });
        }

        private void DirScanner_OnFinished(DirScanner sender, string message)
        {
            appStatus.Text = message;

            scanButton.Enabled = true;
            pauseButton.Enabled = false;
            resumeButton.Enabled = false;
            cancelButton.Enabled = false;
            diffButton.Enabled = true;

            if (sender.Finished)
            {
                hashButton.Enabled = true;
            }

            if (windowClosing)
            {
                Close();
            }
        }

        private void Hasher_OnProgressChanged(Hasher sender, string message)
        {
            base.Invoke((Action)delegate
            {
                appStatus.Text = message;
            });
        }

        private void Hasher_OnFinished(Hasher sender, string message)
        {
            appStatus.Text = message;

            scanButton.Enabled = true;
            hashButton.Enabled = true;
            pauseHashButton.Enabled = false;
            resumeHashButton.Enabled = false;
            cancelHashButton.Enabled = false;

            diffButton.Enabled = true;

            outputButton.Enabled = true;
            outputFileTextBox.Enabled = true;

            if (windowClosing)
            {
                Close();
            }
        }
    }
}
