using System;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace HashCheck.code
{
    public class DiffReader
    {
        public string File1 { get; set; }
        public string File2 { get; set; }
        public string OutputFile { get; set; }
        public bool Finished { get; set; }
        public bool IsBusy { get { return backgroundWorker.IsBusy; } }
        public bool WriteOutputToFile { get; set; }

        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private readonly ManualResetEvent manualResetEvent = new ManualResetEvent(true);
        private StreamWriter output;
        private string errorMessage;

        public event DiffReaderEventHandler OnProgressChanged;
        public event DiffReaderEventHandler OnFinished;

        public void Start()
        {
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();

        }

        public void Pause()
        {
            manualResetEvent.Reset();
        }

        public void Resume()
        {
            manualResetEvent.Set();
        }

        public void Stop()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
                manualResetEvent.Set();
            }
        }

        private bool Diff()
        {
            if (!File.Exists(File1))
            {
                errorMessage = "Error: " + File1 + " doesn't exist.";
                return false;
            }
            if (!File.Exists(File2))
            {
                errorMessage = "Error: " + File2 + " doesn't exist.";
                return false;
            }
            if (WriteOutputToFile)
            {
                try
                {
                    output = File.CreateText(OutputFile);
                }
                catch (Exception ex)
                {
                    errorMessage = "Error opening output file " + OutputFile + ": " + ex.Message;
                    return false;
                }
            }
            StreamReader A = new StreamReader(File1);
            StreamReader B = new StreamReader(File2);

            string lineA = A.ReadLine();
            string lineB = B.ReadLine();
            bool finished = false;
            FileSystemItemComparer fileSystemItemComparer = new FileSystemItemComparer();
            while (!finished)
            {
                if (backgroundWorker.CancellationPending)
                {
                    break;
                }
                manualResetEvent.WaitOne();
                if (lineA == null)
                {
                    finished = RollOutLines(B, File1, lineB);
                    break;
                }
                if (lineB == null)
                {
                    finished = RollOutLines(A, File2, lineA);
                    break;
                }
                if (!finished)
                {
                    HashedFileSystemItem hashedFileSystemItemA = ParseItemFromString(lineA);
                    if (hashedFileSystemItemA == null)
                    {
                        errorMessage = "Could not parse line, aborting.";
                        OnProgressChanged?.Invoke(this, "Could not parse line: " + lineA);
                        break;
                    }
                    HashedFileSystemItem hashedFileSystemItemB = ParseItemFromString(lineB);
                    if (hashedFileSystemItemB == null)
                    {
                        errorMessage = "Could not parse line, aborting.";
                        OnProgressChanged?.Invoke(this, "Could not parse line: " + lineB);
                        break;
                    }
                    int cmpResult = fileSystemItemComparer.Compare(hashedFileSystemItemA, hashedFileSystemItemB);
                    if (cmpResult == -1)
                    {
                        ReportMissingItem(hashedFileSystemItemA, File2);
                        lineA = A.ReadLine();
                        continue;
                    }
                    if (cmpResult == 1)
                    {
                        ReportMissingItem(hashedFileSystemItemB, File1);
                        lineB = B.ReadLine();
                        continue;
                    }
                    if (hashedFileSystemItemA.Hash == hashedFileSystemItemB.Hash)
                    {
                        ReportMatch(hashedFileSystemItemA.name);
                    }
                    else
                    {
                        ReportDiff(hashedFileSystemItemA, hashedFileSystemItemB);
                    }
                    lineA = A.ReadLine();
                    lineB = B.ReadLine();
                }
            }

            A.Close();
            B.Close();
            if (WriteOutputToFile)
            {
                output.Flush();
                output.Close();
            }
            return finished;
        }

        private void ReportDiff(HashedFileSystemItem hashedFileSystemItemA, HashedFileSystemItem hashedFileSystemItemB)
        {
            string result = hashedFileSystemItemA.name + "," + hashedFileSystemItemA.type + ",HASH_MISMATCH," + 
                File1 + "," + hashedFileSystemItemA.Hash + "," + 
                File2 + "," + hashedFileSystemItemB.Hash;
            if (WriteOutputToFile)
            {
                output.WriteLine(result);
            }
            string message =
                "Hash check failed : " + hashedFileSystemItemA.name + "(" + hashedFileSystemItemA.type + ")" + " : " + "\n" +
                File1 + " : " + hashedFileSystemItemA.Hash + "\n" +
                File2 + " : " + hashedFileSystemItemB.Hash;
            OnProgressChanged?.Invoke(this, message);
        }

        private void ReportMatch(string name)
        {
            OnProgressChanged?.Invoke(this, name + " : PASSED");
        }

        private void ReportMissingItem(HashedFileSystemItem hashedFileSystemItemA, string file)
        {
            string result = hashedFileSystemItemA.name + "," + hashedFileSystemItemA.type + ",MISSING_FROM," + file;
            if (WriteOutputToFile)
            {
                output.WriteLine(result);
            }
            OnProgressChanged?.Invoke(this, hashedFileSystemItemA.name + "(" + hashedFileSystemItemA.type + ")" + " missing from " + file);
        }

        private bool RollOutLines(StreamReader stream, string file, string lastLine)
        {
            string line = lastLine;
            if (line == null)
            {
                line = stream.ReadLine();
            }
            while (line != null)
            {
                if (backgroundWorker.CancellationPending)
                {
                    return false;
                }
                manualResetEvent.WaitOne();
                HashedFileSystemItem hashedFileSystemItem = ParseItemFromString(line);
                ReportMissingItem(hashedFileSystemItem, file);
                line = stream.ReadLine();
            };
            return true;
        }

        private HashedFileSystemItem ParseItemFromString(string line)
        {
            string[] parts = line.Split('*');
            if (parts.Length != 3)
            {
                return null;
            }
            return new HashedFileSystemItem(parts[0], ParseType(parts[1]), FileSystemItemAccess.Default, parts[2]);
        }

        private FileSystemItemType ParseType(string type)
        {
            return "Directory".Equals(type) ? FileSystemItemType.Directory : FileSystemItemType.File;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Finished = Diff();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message;
            if (errorMessage != null)
            {
                message = errorMessage;
            }
            else if (e.Cancelled)
            {
                message = "Diff cancelled.";
            }
            else
            {
                message = "Diff finished.";
            }
            OnFinished?.Invoke(this, message);
        }
    }
}