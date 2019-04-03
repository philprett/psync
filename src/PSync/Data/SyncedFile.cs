using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Data
{
    public class SyncedFile
    {
        public long ID { get; set; }
        public string Path { get; set; }
        public DateTime LastModified { get; set; }

        public SyncedFile()
        {
            ID.SetRandom();
            Path = string.Empty;
            LastModified = DateTime.MinValue;
        }

    }
}
