using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.classes
{
    public class FolderSync
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Folder1 { get; set; }
        public string Folder2 { get; set; }
        public List<string> Excludes { get; set; }
        public FolderSync()
        {
            ID = Guid.NewGuid();
            Name = string.Empty;
            Folder1 = string.Empty;
            Folder2 = string.Empty;
            Excludes = new List<string>();
        }
        public FolderSync(DataRow row)
        {
            ID = new Guid((string)row["id"]);
            Name = (string)row["name"];
            Folder1 = (string)row["folder1"];
            Folder2 = (string)row["folder2"];
            Excludes = ((string)row["excludes"]).Split(new[] { '|' }).Where(e => !string.IsNullOrWhiteSpace(e)).ToList();
        }
    }
}
