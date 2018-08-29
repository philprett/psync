using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.classes
{
    /// <summary>
    /// Maintains a pair of folder to be synchronised.
    /// </summary>
    public class FolderSync
    {
        /// <summary>
        /// The id of the object
        /// </summary>
        public Guid ID { get; set; }
        
        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The first folder in the pair.
        /// </summary>
        public string Folder1 { get; set; }

        /// <summary>
        /// The second folder in the pair
        /// </summary>
        public string Folder2 { get; set; }

        /// <summary>
        /// List of strings which are used to specify paths to be excluded
        /// </summary>
        public List<string> Excludes { get; set; }

        /// <summary>
        /// Constructor for a new pair
        /// </summary>
        public FolderSync()
        {
            ID = Guid.NewGuid();
            Name = string.Empty;
            Folder1 = string.Empty;
            Folder2 = string.Empty;
            Excludes = new List<string>();
        }

        /// <summary>
        /// Constructor for a pair out of the database.
        /// </summary>
        /// <param name="row"></param>
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
