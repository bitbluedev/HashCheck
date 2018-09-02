using System.IO;

namespace HashCheck.code
{
    public class HashWriter
    {
        StreamWriter file;
        private readonly string outputFile;

        public HashWriter(string outputFile)
        {
            this.outputFile = outputFile;
        }

        public void OpenFileForWrite()
        {
            file = File.CreateText(outputFile);
        }

        public void CloseFile()
        {
            if (file == null)
            {
                return;
            }
            file.Flush();
            file.Close();
        }

        internal void WriteResultLine(HashedFileSystemItem hashedFileSystemItem)
        {
            string hash = hashedFileSystemItem.Hash;
            
            if (string.IsNullOrEmpty(hash))
            {
                hash = "null";
            }

            file.WriteLine(hashedFileSystemItem.name + "*" + hashedFileSystemItem.type + "*" + hash);
        }
    }
}
