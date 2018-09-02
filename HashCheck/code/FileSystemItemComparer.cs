using System.Collections.Generic;

namespace HashCheck.code
{
    class FileSystemItemComparer : IComparer<FileSystemItem>
    {
        public int Compare(FileSystemItem x, FileSystemItem y)
        {
            int strCmp = string.Compare(x.name, y.name);
            if (strCmp != 0)
            {
                return strCmp;
            }

            if (x.type == y.type)
            {
                return 0;
            }
            return x.type == FileSystemItemType.Directory ? 1 : -1;
        }
    }
}
