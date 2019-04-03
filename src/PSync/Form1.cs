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
            splitContainer1.Panel2.Controls.Add(new controls.FolderSyncControl(e.FolderSync));
        }

    }
}
