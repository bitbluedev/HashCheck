namespace HashCheck.code
{
    public class HashedFileSystemItem : FileSystemItem
    {
        public string Hash { get; }
        public HashedFileSystemItem(string name, FileSystemItemType type, FileSystemItemAccess access, string hash) : base(name, type, access)
        {
            Hash = hash;
        }

        public HashedFileSystemItem(FileSystemItem fileSystemItem, string hash) : base(fileSystemItem.name, fileSystemItem.type, fileSystemItem.access)
        {
            Hash = hash;
        }
    }
}
