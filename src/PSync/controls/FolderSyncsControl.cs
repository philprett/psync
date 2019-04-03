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
    public partial class FolderSyncsControl : UserControl
    {
        public class FolderSyncSelectedEventArgs { public FolderSync FolderSync { get; set; } public FolderSyncSelectedEventArgs() { FolderSync = null; } }
        public delegate void FolderSyncSelectedHandler(object sender, FolderSyncSelectedEventArgs e);

        public FolderSyncSelectedHandler FolderSyncSelected;

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
            foreach (FolderSync f in MainDbContext.DB.FolderSyncs.OrderBy(f => f.Name))
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
                MainDbContext.DB.FolderSyncs.Add(f.FolderSync);
                MainDbContext.DB.SaveChanges();
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
                    MainDbContext.DB.SaveChanges();
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
                    MainDbContext.DB.FolderSyncs.Remove(folderSync);
                    MainDbContext.DB.SaveChanges();
                    RefreshControl();
                }
            }
        }

        private void butGo_Click(object sender, EventArgs e)
        {
            if (lstFolderSyncs.SelectedItem != null)
            {
                FolderSync folderSync = (FolderSync)lstFolderSyncs.SelectedItem;
                if (FolderSyncSelected != null)
                {
                    FolderSyncSelected(this, new FolderSyncSelectedEventArgs() { FolderSync = folderSync });
                }
            }
        }

        private void FolderSyncsControl_Load(object sender, EventArgs e)
        {

        }

        private void lstFolderSyncs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFolderSyncs.SelectedItem != null)
            {
                FolderSync folderSync = (FolderSync)lstFolderSyncs.SelectedItem;
                if (FolderSyncSelected != null)
                {
                    FolderSyncSelected(this, new FolderSyncSelectedEventArgs() { FolderSync = folderSync });
                }
            }
        }
    }
}
