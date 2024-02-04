using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    public class CustomFileClassEntity
        {
            public string Name { get; set; }
            public string Directory { get; set; }
            public long SizeInBytes { get; set; }
            public DateTime CreationTime { get; set; }
            public DateTime LastAccessTime { get; set; }
            public DateTime LastWriteTime { get; set; }

            // Constructor to initialize properties based on a FileInfo instance
            public CustomFileClassEntity(FileInfo fileInfo)
            {
                Name = fileInfo.Name;
                Directory = fileInfo.DirectoryName;
                SizeInBytes = fileInfo.Length;
                CreationTime = fileInfo.CreationTime;
                LastAccessTime = fileInfo.LastAccessTime;
                LastWriteTime = fileInfo.LastWriteTime;
            }
        }
}
