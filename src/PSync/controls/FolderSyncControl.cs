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
using PSync.Controllers.Sync;

namespace PSync.controls
{
    public partial class FolderSyncControl : UserControl
    {
        private FolderSync folderSync;
        private Sync sync;

        public FolderSyncControl(FolderSync folderSync)
        {
            InitializeComponent();
            this.folderSync = folderSync;
        }

        private void FolderSyncControl_Load(object sender, EventArgs e)
        {
            txtFolder1.Text = folderSync.Folder1;
            txtFolder2.Text = folderSync.Folder2;
            sync = new Sync() { Folder1 = folderSync.Folder1, Folder2 = folderSync.Folder2 };
        }

        private void butAnalyse_Click(object sender, EventArgs e)
        {
            sync.Analyse();

            Grid.Rows.Clear();
            foreach (SyncItem item in sync.SyncItems)
            {
                if (item.Action == SyncActions.None) continue;

                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                cell1.Value = item.Path1.Substring(folderSync.Folder1.Length + 1);
                row.Cells.Add(cell1);

                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                if (item.ItemType == SyncItemType.Folder) cell2.Value = string.Empty;
                else if (item.LastModified1.Equals(DateTime.MinValue)) cell2.Value = string.Empty;
                else cell2.Value = item.LastModified1.ToString("dd.MM.yyyy HH:mm:ss");
                row.Cells.Add(cell2);

                DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                if (item.Action == SyncActions.CopyFrom1To2) cell3.Value = ">>>";
                else if (item.Action == SyncActions.CopyFrom2To1) cell3.Value = "<<<";
                else if (item.Action == SyncActions.Delete1) cell3.Value = "<XXX";
                else if (item.Action == SyncActions.Delete2) cell3.Value = "XXX>";
                else if (item.Action == SyncActions.DeleteBoth) cell3.Value = "XXX";
                else cell3.Value = "";
                row.Cells.Add(cell3);

                DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell();
                if (item.ItemType == SyncItemType.Folder) cell4.Value = string.Empty;
                else if (item.LastModified2.Equals(DateTime.MinValue)) cell4.Value = string.Empty;
                else cell4.Value = item.LastModified2.ToString("dd.MM.yyyy HH:mm:ss");
                row.Cells.Add(cell4);

                Grid.Rows.Add(row);
            }
        }

        private void butSync_Click(object sender, EventArgs e)
        {
            foreach (SyncItem item in sync.SyncItems)
            {
                item.DoAction();
            }
        }
    }
}
