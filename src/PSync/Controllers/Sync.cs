using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Controllers
{
    public class Sync
    {
        public string Folder1 { get; set; }
        public string Folder2 { get; set; }
        public string RelPath { get; set; }

        public Sync()
        {
            Folder1 = string.Empty;
            Folder2 = string.Empty;
            RelPath = string.Empty;
        }

        public void Analyse()
        {

        }

        public void Sync()
        {

        }
    }
}
