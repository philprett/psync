using PSync.controls;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            folderSyncsControl.Init();
            folderSyncsControl.FolderSyncSelected += new controls.FolderSyncsControl.FolderSyncSelectedHandler(folderSyncsControl_onFolderSyncSelected);
        }

        private void folderSyncsControl_onFolderSyncSelected(object sender, controls.FolderSyncsControl.FolderSyncSelectedEventArgs e)
        {
            foreach (Control c in splitContainer1.Panel2.Controls)
            {
                splitContainer1.Panel2.Controls.Remove(c);
            }
            FolderSyncControl co = new controls.FolderSyncControl(e.FolderSync);
            splitContainer1.Panel2.Controls.Add(co);
            //co.Left = 5;
            //co.Top = 5;
            //co.Width = splitContainer1.Panel2.Width - 10;
            //co.Height = splitContainer1.Panel2.Height - 10;
            //co.Anchor = AnchorStyles.Left & AnchorStyles.Right & AnchorStyles.Top & AnchorStyles.Bottom;
            co.Dock = DockStyle.Fill;
        }

    }
}
