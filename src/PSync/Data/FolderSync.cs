using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Data
{
    /// <summary>
    /// Maintains a pair of folder to be synchronised.
    /// </summary>
    public class FolderSync
    {
        /// <summary>
        /// The id of the object
        /// </summary>
        [Key]
        public long ID { get; set; }

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
        public string Excludes { get; set; }

        [NotMapped]
        public List<string> ExcludesList { get { return Excludes.Split(new[] { '|' }).ToList(); } set { Excludes = string.Join("|", value); } }

        /// <summary>
        /// The last time the folder was synced
        /// </summary>
        public DateTime LastSync { get; set; }

        /// <summary>
        /// Constructor for a new pair
        /// </summary>
        public FolderSync()
        {
            ID.SetRandom();
            Name = string.Empty;
            Folder1 = string.Empty;
            Folder2 = string.Empty;
            Excludes = string.Empty;
            LastSync = DateTime.MinValue;
        }
    }
}
