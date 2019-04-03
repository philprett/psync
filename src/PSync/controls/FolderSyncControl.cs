using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSync.Data;

namespace PSync.controls
{
    public partial class FolderSyncControl : UserControl
    {
        private FolderSync folderSync;

        public FolderSyncControl(FolderSync folderSync)
        {
            InitializeComponent();
            this.folderSync = folderSync;
        }

        private void FolderSyncControl_Load(object sender, EventArgs e)
        {
            txtFolder1.Text = folderSync.Folder1;
            txtFolder2.Text = folderSync.Folder2;
        }

        private void butAnalyse_Click(object sender, EventArgs e)
        {

        }
    }
}
