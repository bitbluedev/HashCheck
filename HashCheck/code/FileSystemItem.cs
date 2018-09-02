namespace HashCheck.code
{
    public class FileSystemItem
    {
        public string name { get; set; }
        public FileSystemItemType type { get; set; }
        public FileSystemItemAccess access { get; set; }

        public FileSystemItem(string name, FileSystemItemType type, FileSystemItemAccess access)
        {
            this.name = name;
            this.type = type;
            this.access = access;
        }
    }
}
