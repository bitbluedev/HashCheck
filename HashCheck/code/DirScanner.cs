using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace HashCheck.code
{
    public class DirScanner
    {
        public string RootDir { get; set; }
        public List<FileSystemItem> Result { get; } = new List<FileSystemItem>();
        public bool Finished { get; private set; }
        public bool IsBusy { get { return backgroundWorker.IsBusy; } }

        public event DirScannerEventHandler OnFinished;
        public event DirScannerEventHandler OnProgressChanged;

        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private readonly ManualResetEvent manualResetEvent = new ManualResetEvent(true);

        public void Start()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        public void Pause()
        {
            OnProgressChanged?.Invoke(this, "Scan paused.");
            manualResetEvent.Reset();
        }

        public void Resume()
        {
            OnProgressChanged?.Invoke(this, "Scan resumed.");
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

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Finished = ScanDirectory();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message;
            if (e.Cancelled)
            {
                message = "Scan cancelled.";
            }
            else
            {
                message = "Scan finished: " + Result.Count + " element(s) found.";
            }

            OnFinished?.Invoke(this, message);
        }

        private bool ScanDirectory()
        {
            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(RootDir);

            Queue<DirectoryInfo> todo = new Queue<DirectoryInfo>();
            todo.Enqueue(rootDirectoryInfo);

            Queue<FileSystemItem> allDirectoties = new Queue<FileSystemItem>();

            // get all directories
            while (0 < todo.Count)
            {
                manualResetEvent.WaitOne();
                if (backgroundWorker.CancellationPending)
                {
                    return false;
                }

                DirectoryInfo directoryInfo = todo.Dequeue();
                OnProgressChanged?.Invoke(this, directoryInfo.FullName);
                DirectoryInfo[] childDirectories;
                try
                {
                    childDirectories = directoryInfo.GetDirectories();
                    allDirectoties.Enqueue(new FileSystemItem(directoryInfo.FullName, FileSystemItemType.Directory, FileSystemItemAccess.Default));
                }
                catch (UnauthorizedAccessException)
                {
                    allDirectoties.Enqueue(new FileSystemItem(directoryInfo.FullName, FileSystemItemType.Directory, FileSystemItemAccess.Denied));
                    continue;
                }

                foreach (var childDirectory in childDirectories)
                {
                    manualResetEvent.WaitOne();
                    if (backgroundWorker.CancellationPending)
                    {
                        return false;
                    }

                    todo.Enqueue(childDirectory);
                }
            }

            // get all files
            foreach (var directory in allDirectoties)
            {
                manualResetEvent.WaitOne();
                if (backgroundWorker.CancellationPending)
                {
                    return false;
                }

                OnProgressChanged?.Invoke(this, directory.name);

                Result.Add(directory);

                if (FileSystemItemAccess.Default != directory.access)
                {
                    continue;
                }

                FileInfo[] fileInfos;
                fileInfos = new DirectoryInfo(directory.name).GetFiles();

                foreach (var fileInfo in fileInfos)
                {
                    manualResetEvent.WaitOne();
                    if (backgroundWorker.CancellationPending)
                    {
                        return false;
                    }

                    Result.Add(new FileSystemItem(fileInfo.FullName, FileSystemItemType.File, FileSystemItemAccess.Default));
                }
            }

            OnProgressChanged?.Invoke(this, "sorting");
            Result.Sort(new FileSystemItemComparer());

            return true;
        }
    }
}
