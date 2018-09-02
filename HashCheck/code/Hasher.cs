using HashCheck.code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace HashCheck
{
    public class Hasher
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private readonly ManualResetEvent manualResetEvent = new ManualResetEvent(true);

        private HashWriter hashWriter;

        private readonly List<FileSystemItem> fileSystemItems;

        public string OutputFile { get; set; }
        public bool IsBusy { get { return backgroundWorker.IsBusy; } }

        public event HasherEventHandler OnFinished;
        public event HasherEventHandler OnProgressChanged;

        public Hasher(List<FileSystemItem> fileSystemItems)
        {
            this.fileSystemItems = fileSystemItems;
        }

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

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            hashWriter = new HashWriter(this.OutputFile);
            try
            {
                hashWriter.OpenFileForWrite();
            }
            catch (Exception)
            {
                OnProgressChanged?.Invoke(this, "Error writing output file: " + OutputFile);
                return;
            }

            bool finished = HashFiles();

            if (backgroundWorker.CancellationPending)
            {
                hashWriter.CloseFile();
                e.Cancel = true;
                return;
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message;
            if (e.Cancelled)
            {
                message = "Hash cancelled.";
            }
            else
            {
                message = "Hash finished.";
            }
            OnFinished?.Invoke(this, message);
        }

        bool HashFiles()
        {
            foreach (var fileSystemItem in fileSystemItems)
            {
                OnProgressChanged?.Invoke(this, fileSystemItem.name);
                manualResetEvent.WaitOne();
                if (backgroundWorker.CancellationPending)
                {
                    return false;
                }

                if (fileSystemItem.type == FileSystemItemType.Directory || FileSystemItemAccess.Default != fileSystemItem.access)
                {
                    hashWriter.WriteResultLine(new HashedFileSystemItem(fileSystemItem, hash: null));
                }
                else
                {
                    if (!HashAndAddToResult(fileSystemItem))
                    {
                        return false;
                    }
                }
            }

            hashWriter.CloseFile();
            return true;
        }

        private bool HashAndAddToResult(FileSystemItem fileSystemItem)
        {
            const int chunkSize = 65536;
            StringBuilder sb = new StringBuilder();
            FileStream file;

            try
            {
                file = File.OpenRead(fileSystemItem.name);
            }
            catch (Exception)
            {
                fileSystemItem.access = FileSystemItemAccess.Denied;
                hashWriter.WriteResultLine(new HashedFileSystemItem(fileSystemItem, null));
                return true;
            }

            int bytesRead;
            var buffer = new byte[chunkSize];
            while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (bytesRead < chunkSize)
                {
                    Array.Clear(buffer, bytesRead, chunkSize - bytesRead);
                }
                manualResetEvent.WaitOne();
                if (backgroundWorker.CancellationPending)
                {
                    file.Close();
                    return false;
                }

                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                {
                    byte[] sha1hash = sha1.ComputeHash(buffer); // 160 bit = 20 byte
                    string hashFragment = ToHex(sha1hash);
                    sb.Append(hashFragment);
                    sb.Append("-");
                }
            }
            file.Close();

            string fullHash = sb.Length > 0 ? sb.ToString(0, sb.Length - 1) : sb.ToString();
            hashWriter.WriteResultLine(new HashedFileSystemItem(fileSystemItem, fullHash));
            return true;
        }

        private string ToHex(byte[] buffer)
        {
            char[] hexaletters = new char[40];
            for (int i = 0; i < 20; i++)
            {
                byte b = buffer[i];
                byte high = (byte)(b / 16);
                byte low = (byte)(b % 16);
                hexaletters[2 * i] = HasherLookupTable.HexChar[high];
                hexaletters[2 * i + 1] = HasherLookupTable.HexChar[low];
            }

            string hex = new string(hexaletters);
            return hex;
        }
    }
}