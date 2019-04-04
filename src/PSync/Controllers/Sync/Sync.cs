using PSync.LongFilenames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Controllers.Sync
{
    public class Sync
    {
        public string Folder1 { get; set; }
        public string Folder2 { get; set; }
        public List<SyncItem> SyncItems { get; set; }

        public Sync()
        {
            Folder1 = string.Empty;
            Folder2 = string.Empty;
            SyncItems = new List<SyncItem>();
        }

        public void Analyse()
        {
            SyncItems = new List<SyncItem>();
            AnalyseFolder(Folder1, Folder2);
        }

        private void AnalyseFolder(string folder1, string folder2)
        {
            string[] files1 = !LongDirectory.Exists(folder1) ? new string[] { } : LongDirectory.GetFiles(folder1).Select(f => LongFile.GetName(f)).ToArray();
            string[] files2 = !LongDirectory.Exists(folder2) ? new string[] { } : LongDirectory.GetFiles(folder2).Select(f => LongFile.GetName(f)).ToArray();
            foreach (string file1 in files1)
            {
                SyncItems.Add(new SyncItem(LongFile.Combine(folder1, file1), LongFile.Combine(folder2, file1), SyncItemType.File));
            }
            foreach (string file2 in files2)
            {
                if (files1.FirstOrDefault(f => f == file2) == null)
                {
                    SyncItems.Add(new SyncItem(LongFile.Combine(folder1, file2), LongFile.Combine(folder2, file2), SyncItemType.File));
                }
            }

            string[] subs1 = !LongDirectory.Exists(folder1) ? new string[] { } : LongDirectory.GetDirectories(folder1).Select(f => LongDirectory.GetName(f)).ToArray();
            string[] subs2 = !LongDirectory.Exists(folder2) ? new string[] { } : LongDirectory.GetDirectories(folder2).Select(f => LongDirectory.GetName(f)).ToArray();
            foreach (string sub1 in subs1)
            {
                string fullSub1 = LongDirectory.Combine(folder1, sub1);
                string fullSub2 = LongDirectory.Combine(folder2, sub1);
                SyncItems.Add(new SyncItem(fullSub1, fullSub2, SyncItemType.Folder));
                AnalyseFolder(fullSub1, fullSub2);
            }
            foreach (string sub2 in subs2)
            {
                if (subs1.FirstOrDefault(f => f == sub2) == null)
                {
                    string fullSub1 = LongDirectory.Combine(folder1, sub2);
                    string fullSub2 = LongDirectory.Combine(folder2, sub2);
                    SyncItems.Add(new SyncItem(fullSub1, fullSub2, SyncItemType.Folder));
                    AnalyseFolder(fullSub1, fullSub2);
                }
            }
        }

        public void PerformSync()
        {

        }
    }
}
