using PSync.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSync
{
    public partial class FormFolderSyncDetails : Form
    {
        /// <summary>
        /// The FolderSync to edit. 
        /// </summary>
        public FolderSync FolderSync { get; set; }

        public FormFolderSyncDetails(FolderSync folderSync = null)
        {
            InitializeComponent();
            FolderSync = folderSync != null ? folderSync : new FolderSync();
        }

        private void FormFolderSyncDetails_Load(object sender, EventArgs e)
        {
            txtName.Text = FolderSync.Name;
            txtFolder1.Text = FolderSync.Folder1;
            txtFolder2.Text = FolderSync.Folder2;
            lstExcludes.Items.Clear();
            foreach (var exc in FolderSync.Excludes)
            {
                lstExcludes.Items.Add(exc);
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            FolderSync.Name = txtName.Text;
            FolderSync.Folder1 = txtFolder1.Text;
            FolderSync.Folder2 = txtFolder2.Text;
            FolderSync.Excludes = new List<string>();
            foreach (string exc in lstExcludes.Items)
            {
                FolderSync.Excludes.Add(exc);
            }
            DialogResult = DialogResult.OK;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void butBrowse1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.SelectedPath = txtFolder1.Text;
            f.Description = "Please select the folder";
            f.ShowNewFolderButton = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtFolder1.Text = f.SelectedPath;
            }
        }

        private void butBrowse2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.SelectedPath = txtFolder2.Text;
            f.Description = "Please select the folder";
            f.ShowNewFolderButton = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtFolder2.Text = f.SelectedPath;
            }
        }
        private void butExcludeBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.SelectedPath = txtExclude.Text;
            f.Description = "Please select the folder to exclude";
            f.ShowNewFolderButton = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtExclude.Text = f.SelectedPath;
            }
        }

        private void butAddExclude_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtExclude.Text))
            {
                lstExcludes.Items.Add(txtExclude.Text);
            }
        }

        private void butEditExclude_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtExclude.Text))
            {
                if (lstExcludes.SelectedIndex >= 0)
                {
                    lstExcludes.Items[lstExcludes.SelectedIndex] = txtExclude.Text;
                }
            }
        }

        private void butDeleteExclude_Click(object sender, EventArgs e)
        {
            if (lstExcludes.SelectedIndex >= 0)
            {
                lstExcludes.Items.RemoveAt(lstExcludes.SelectedIndex);
            }
        }

    }
}
