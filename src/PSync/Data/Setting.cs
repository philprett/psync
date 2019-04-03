using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Data
{
    /// <summary>
    /// Maintains a setting for the running of the system
    /// </summary>
    internal class Setting
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
        /// The value
        /// </summary>
        public string Value { get; set; }

        public Setting()
        {
            ID.SetRandom();
            Name = string.Empty;
            Value = string.Empty;
        }

    }
}
