using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSync.classes;

namespace PSync.controls
{
    public partial class FolderSyncsControl : UserControl
    {
        private DataStore db;
        public FolderSyncsControl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            db = DataStore.Current;
            RefreshControl();
        }

        private void FolderSyncsControl_Load(object sender, EventArgs e)
        {
        }

        private void lstFolderSyncs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            ListBox lb = (ListBox)sender;
            FolderSync folderSync = (FolderSync)lb.Items[e.Index];
            string text = folderSync.Name;

            e.DrawBackground();

            Graphics g = e.Graphics;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                g.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }
            else
            {
                g.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
            }
            g.DrawString(text, e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void RefreshControl()
        {
            lstFolderSyncs.Items.Clear();
            foreach (FolderSync f in db.GetFolderSyncs().OrderBy(f => f.Name))
            {
                lstFolderSyncs.Items.Add(f);
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            FormFolderSyncDetails f = new FormFolderSyncDetails(new FolderSync());
            if (f.ShowDialog() == DialogResult.OK)
            {
                db.SaveFolderSync(f.FolderSync);
                RefreshControl();
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (lstFolderSyncs.SelectedItem != null)
            {
                FolderSync folderSync = (FolderSync)lstFolderSyncs.SelectedItem;
                FormFolderSyncDetails f = new FormFolderSyncDetails(folderSync);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    db.SaveFolderSync(f.FolderSync);
                    RefreshControl();
                }
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (lstFolderSyncs.SelectedItem != null)
            {
                FolderSync folderSync = (FolderSync)lstFolderSyncs.SelectedItem;
                if (MessageBox.Show("Do you really want to remove this folder sync?","Confirmation required", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.DeleteFolderSync(folderSync);
                    RefreshControl();
                }
            }
        }

        private void butGo_Click(object sender, EventArgs e)
        {

        }

    }
}
