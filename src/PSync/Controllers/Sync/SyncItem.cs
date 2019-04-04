using PSync.Data;
using PSync.LongFilenames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Controllers.Sync
{
    public class SyncItem
    {
        public string Path1 { get; set; }
        public string Path2 { get; set; }
        public DateTime LastModified1 { get; set; }
        public DateTime LastModified2 { get; set; }
        public SyncItemType ItemType { get; set; }
        public SyncActions Action { get; set; }
        public SyncItemStatus Status { get; set; }

        public SyncItem(string path1, string path2, SyncItemType itemType)
        {
            Path1 = path1;
            Path2 = path2;
            LastModified1 = DateTime.MinValue;
            LastModified2 = DateTime.MinValue;
            ItemType = itemType;
            Action = GetAction();
            Status = SyncItemStatus.NoActionRequired;
        }

        public SyncActions GetAction()
        {
            if (ItemType == SyncItemType.File)
            {
                bool exists1 = LongFile.Exists(Path1);
                bool exists2 = LongFile.Exists(Path2);
                LastModified1 = exists1 ? LongFile.GetLastWriteTime(Path1) : DateTime.MinValue;
                LastModified2 = exists2 ? LongFile.GetLastWriteTime(Path2) : DateTime.MinValue;
                SyncedFile past1 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path1);
                SyncedFile past2 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path2);

                if (!exists1 && !exists2)
                {
                    return SyncActions.None;
                }
                else if (exists1 && !exists2)
                {
                    if (past1 != null && past2 != null)
                    {
                        // File 2 has been deleted
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.Delete1;
                    }
                    else
                    {
                        // File 1 is new
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.CopyFrom1To2;
                    }
                }
                else if (!exists1 && exists2)
                {
                    if (past1 != null && past2 != null)
                    {
                        // File 1 has been deleted
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.Delete2;
                    }
                    else
                    {
                        // File 2 is new
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.CopyFrom2To1;
                    }
                }
                else if (exists1 && exists2)
                {
                    int comp = LastModified1.CompareTo(LastModified2);
                    int newest = comp > 0 ? 1 : comp < 0 ? 2 : 0;
                    bool changed1 = past1 == null || !LastModified1.Equals(past1.LastModified);
                    bool changed2 = past2 == null || !LastModified2.Equals(past2.LastModified);

                    if (changed1 && changed2)
                    {
                        if (newest == 1) return SyncActions.CopyFrom1To2;
                        if (newest == 2) return SyncActions.CopyFrom2To1;
                        return SyncActions.None;
                    }
                    else if (changed1 && !changed2)
                    {
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.CopyFrom1To2;
                    }
                    else if (!changed1 && changed2)
                    {
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.CopyFrom2To1;
                    }
                    else if (!changed1 && !changed2)
                    {
                        return SyncActions.None;
                    }
                }
            }
            else if (ItemType == SyncItemType.Folder)
            {
                bool exists1 = LongDirectory.Exists(Path1);
                bool exists2 = LongDirectory.Exists(Path2);
                SyncedFile past1 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path1);
                SyncedFile past2 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path2);

                if (!exists1 && !exists2)
                {
                    if (past1 != null || past2 != null)
                    {
                        return SyncActions.None;
                    }
                    else
                    {
                        return SyncActions.None;
                    }
                }
                else if (exists1 && exists2)
                {
                    return SyncActions.None;
                }
                else if (exists1 && !exists2)
                {
                    if (past2 != null)
                    {
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.Delete1;
                    }
                    else
                    {
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.CopyFrom1To2;
                    }
                }
                else if (!exists1 && exists2)
                {
                    if (past1 != null)
                    {
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.Delete2;
                    }
                    else
                    {
                        Status = SyncItemStatus.ActionPending;
                        return SyncActions.CopyFrom2To1;
                    }
                }
            }
            return SyncActions.None;
        }

        public void DoAction()
        {
            try
            {
                if (ItemType == SyncItemType.Folder)
                {
                    SyncedFile past1 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path1);
                    SyncedFile past2 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path2);

                    if (Action == SyncActions.CopyFrom1To2)
                    {
                        if (!LongDirectory.Exists(Path2)) LongDirectory.CreateDirectory(Path2);
                        if (past1 == null) MainDbContext.DB.SyncedFiles.Add(new SyncedFile() { LastModified = DateTime.MinValue, Path = Path1 });
                        if (past2 == null) MainDbContext.DB.SyncedFiles.Add(new SyncedFile() { LastModified = DateTime.MinValue, Path = Path2 });
                        Status = SyncItemStatus.ActionOK;
                    }
                    else if (Action == SyncActions.CopyFrom2To1)
                    {
                        if (!LongDirectory.Exists(Path1)) LongDirectory.CreateDirectory(Path1);
                        if (past1 == null) MainDbContext.DB.SyncedFiles.Add(new SyncedFile() { LastModified = DateTime.MinValue, Path = Path1 });
                        if (past2 == null) MainDbContext.DB.SyncedFiles.Add(new SyncedFile() { LastModified = DateTime.MinValue, Path = Path2 });
                        Status = SyncItemStatus.ActionOK;
                    }
                    else if (Action == SyncActions.Delete1 || Action == SyncActions.Delete2 || Action == SyncActions.DeleteBoth)
                    {
                        if (LongDirectory.Exists(Path1)) LongDirectory.Delete(Path1, true);
                        if (LongDirectory.Exists(Path2)) LongDirectory.Delete(Path2, true);
                        if (past1 != null) MainDbContext.DB.SyncedFiles.Remove(past1);
                        if (past2 != null) MainDbContext.DB.SyncedFiles.Remove(past2);
                        Status = SyncItemStatus.ActionOK;
                    }
                }
                else if (ItemType == SyncItemType.File)
                {
                    SyncedFile past1 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path1);
                    SyncedFile past2 = MainDbContext.DB.SyncedFiles.FirstOrDefault(f => f.Path == Path2);

                    if (Action == SyncActions.CopyFrom1To2)
                    {
                        LongFile.Copy(Path1, Path2);
                        DateTime lastModified = LongFile.GetLastWriteTime(Path1);

                        if (past1 == null)
                        {
                            past1 = new SyncedFile() { LastModified = lastModified, Path = Path1 };
                            MainDbContext.DB.SyncedFiles.Add(past1);
                        }
                        else if (!lastModified.Equals(past1.LastModified))
                        {
                            past1.LastModified = lastModified;
                        }

                        if (past2 == null)
                        {
                            past2 = new SyncedFile() { LastModified = lastModified, Path = Path2 };
                            MainDbContext.DB.SyncedFiles.Add(past2);
                        }
                        else if (!lastModified.Equals(past2.LastModified))
                        {
                            past2.LastModified = lastModified;
                        }
                        Status = SyncItemStatus.ActionOK;
                    }
                    else if (Action == SyncActions.CopyFrom2To1)
                    {
                        LongFile.Copy(Path2, Path1);
                        DateTime lastModified = LongFile.GetLastWriteTime(Path2);

                        if (past1 == null)
                        {
                            past1 = new SyncedFile() { LastModified = lastModified, Path = Path1 };
                            MainDbContext.DB.SyncedFiles.Add(past1);
                        }
                        else if (!lastModified.Equals(past1.LastModified))
                        {
                            past1.LastModified = lastModified;
                        }

                        if (past2 == null)
                        {
                            past2 = new SyncedFile() { LastModified = lastModified, Path = Path2 };
                            MainDbContext.DB.SyncedFiles.Add(past2);
                        }
                        else if (!lastModified.Equals(past2.LastModified))
                        {
                            past2.LastModified = lastModified;
                        }
                        Status = SyncItemStatus.ActionOK;
                    }
                    else if (Action == SyncActions.Delete1)
                    {
                        if (LongFile.Exists(Path1)) LongFile.Delete(Path1);
                        if (past1 != null)
                        {
                            MainDbContext.DB.SyncedFiles.Remove(past1);
                        }

                        if (past2 != null)
                        {
                            MainDbContext.DB.SyncedFiles.Remove(past2);
                        }
                        Status = SyncItemStatus.ActionOK;
                    }
                    else if (Action == SyncActions.Delete2)
                    {
                        if (LongFile.Exists(Path2)) LongFile.Delete(Path2);
                        if (past1 != null)
                        {
                            MainDbContext.DB.SyncedFiles.Remove(past1);
                        }

                        if (past2 != null)
                        {
                            MainDbContext.DB.SyncedFiles.Remove(past2);
                        }
                        Status = SyncItemStatus.ActionOK;
                    }
                    else if (Action == SyncActions.DeleteBoth)
                    {
                        if (LongFile.Exists(Path1)) LongFile.Delete(Path1);
                        if (LongFile.Exists(Path2)) LongFile.Delete(Path2);
                        if (past1 != null)
                        {
                            MainDbContext.DB.SyncedFiles.Remove(past1);
                        }
                        if (past2 != null)
                        {
                            MainDbContext.DB.SyncedFiles.Remove(past2);
                        }
                        Status = SyncItemStatus.ActionOK;
                    }
                }
                MainDbContext.DB.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO What to do when a copy/delete doesnt work?
            }
        }
    }
}
