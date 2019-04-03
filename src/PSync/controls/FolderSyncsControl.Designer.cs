namespace PSync.controls
{
    partial class FolderSyncsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lstFolderSyncs = new System.Windows.Forms.ListBox();
            this.butGo = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Folder Syncs";
            // 
            // lstFolderSyncs
            // 
            this.lstFolderSyncs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFolderSyncs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstFolderSyncs.FormattingEnabled = true;
            this.lstFolderSyncs.Location = new System.Drawing.Point(7, 19);
            this.lstFolderSyncs.Name = "lstFolderSyncs";
            this.lstFolderSyncs.Size = new System.Drawing.Size(138, 160);
            this.lstFolderSyncs.TabIndex = 6;
            this.lstFolderSyncs.Click += new System.EventHandler(this.lstFolderSyncs_Click);
            this.lstFolderSyncs.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstFolderSyncs_DrawItem);
            this.lstFolderSyncs.SelectedIndexChanged += new System.EventHandler(this.lstFolderSyncs_SelectedIndexChanged);
            // 
            // butGo
            // 
            this.butGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butGo.Image = global::PSync.Properties.Resources.arrow_right;
            this.butGo.Location = new System.Drawing.Point(115, 189);
            this.butGo.Name = "butGo";
            this.butGo.Size = new System.Drawing.Size(30, 30);
            this.butGo.TabIndex = 11;
            this.butGo.UseVisualStyleBackColor = true;
            this.butGo.Click += new System.EventHandler(this.butGo_Click);
            // 
            // butDelete
            // 
            this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDelete.Image = global::PSync.Properties.Resources.delete;
            this.butDelete.Location = new System.Drawing.Point(79, 189);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(30, 30);
            this.butDelete.TabIndex = 10;
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butEdit
            // 
            this.butEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butEdit.Image = global::PSync.Properties.Resources.pencil;
            this.butEdit.Location = new System.Drawing.Point(43, 189);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(30, 30);
            this.butEdit.TabIndex = 9;
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butAdd
            // 
            this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAdd.Image = global::PSync.Properties.Resources.add;
            this.butAdd.Location = new System.Drawing.Point(7, 189);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(30, 30);
            this.butAdd.TabIndex = 8;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // FolderSyncsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.butGo);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstFolderSyncs);
            this.MinimumSize = new System.Drawing.Size(155, 229);
            this.Name = "FolderSyncsControl";
            this.Size = new System.Drawing.Size(155, 229);
            this.Load += new System.EventHandler(this.FolderSyncsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butGo;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstFolderSyncs;
    }
}
