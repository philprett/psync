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
        /// <summary>
        /// This is out single data store object where everything is saved.
        /// </summary>
        private DataStore db;

        public FolderSyncsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialise the control.
        /// Do not do this in the onload event as it will break the Visual Studio Designer
        /// </summary>
        public void Init()
        {
            db = DataStore.Current;
            RefreshControl();
        }

        /// <summary>
        /// Provides the custom drawing of the listbox.
        /// Requires the listbox to have the DrawMode property set to OwnerDrawFixed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Performs an update on the control to refresh all data
        /// </summary>
        private void RefreshControl()
        {
            lstFolderSyncs.Items.Clear();
            foreach (FolderSync f in db.GetFolderSyncs().OrderBy(f => f.Name))
            {
                lstFolderSyncs.Items.Add(f);
            }
            RefreshButtons();
        }
        
        /// <summary>
        /// Makes sure the buttons are enabled depending on the selected items in the listbox
        /// </summary>
        private void RefreshButtons()
        {
            butAdd.Enabled = true;
            butEdit.Enabled = lstFolderSyncs.SelectedIndex >= 0;
            butDelete.Enabled = lstFolderSyncs.SelectedIndex >= 0;
            butGo.Enabled = lstFolderSyncs.SelectedIndex >= 0;
        }

        /// <summary>
        /// Make sure that the buttons are refreshed when something in the listbox has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFolderSyncs_Click(object sender, EventArgs e)
        {
            RefreshButtons();
        }

        /// <summary>
        /// Add a new FolderSync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAdd_Click(object sender, EventArgs e)
        {
            FormFolderSyncDetails f = new FormFolderSyncDetails(new FolderSync());
            if (f.ShowDialog() == DialogResult.OK)
            {
                db.SaveFolderSync(f.FolderSync);
                RefreshControl();
            }
        }

        /// <summary>
        /// Edit the selected FolderSync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Delete the selected FolderSync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butDelete_Click(object sender, EventArgs e)
        {
            if (lstFolderSyncs.SelectedItem != null)
            {
                FolderSync folderSync = (FolderSync)lstFolderSyncs.SelectedItem;
                if (MessageBox.Show("Do you really want to remove this folder sync?", "Confirmation required", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
