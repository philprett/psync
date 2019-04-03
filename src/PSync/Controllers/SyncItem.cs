using PSync.Data;
using PSync.LongFilenames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Controllers
{
    class SyncItem
    {
        public string Path1 { get; set; }
        public string Path2 { get; set; }
        public SyncItemType ItemType { get; set; }
        public SyncActions Action { get; set; }

        public SyncItem(string path1, string path2, SyncItemType itemType)
        {
            Path1 = path1;
            Path2 = path2;
            ItemType = itemType;
            Action = SyncActions.None;
        }

        public void UpdateAction()
        {
            if (ItemType == SyncItemType.File)
            {
                DateTime realModified1 = LongFile.Exists(Path1) ? LongFile.GetLastWriteTime(Path1) : DateTime.MinValue;
                DateTime realModified2 = LongFile.Exists(Path2) ? LongFile.GetLastWriteTime(Path2) : DateTime.MinValue;
                SyncedFile past1 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path1);
                SyncedFile past2 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path2);
            }
        }
    }
}
