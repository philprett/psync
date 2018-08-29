namespace PSync
{
    partial class FormFolderSyncDetails
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFolderSyncDetails));
            this.label5 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butAddExclude = new System.Windows.Forms.Button();
            this.butEditExclude = new System.Windows.Forms.Button();
            this.butDeleteExclude = new System.Windows.Forms.Button();
            this.lstExcludes = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butBrowse2 = new System.Windows.Forms.Button();
            this.butBrowse1 = new System.Windows.Forms.Button();
            this.txtExclude = new System.Windows.Forms.TextBox();
            this.txtFolder2 = new System.Windows.Forms.TextBox();
            this.txtFolder1 = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butExcludeBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Exclude";
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.Image = global::PSync.Properties.Resources.cancel;
            this.butCancel.Location = new System.Drawing.Point(207, 241);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(30, 30);
            this.butCancel.TabIndex = 13;
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butSave.Image = global::PSync.Properties.Resources.disk;
            this.butSave.Location = new System.Drawing.Point(122, 241);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(30, 30);
            this.butSave.TabIndex = 12;
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butAddExclude
            // 
            this.butAddExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddExclude.Image = global::PSync.Properties.Resources.add;
            this.butAddExclude.Location = new System.Drawing.Point(250, 202);
            this.butAddExclude.Name = "butAddExclude";
            this.butAddExclude.Size = new System.Drawing.Size(30, 30);
            this.butAddExclude.TabIndex = 9;
            this.butAddExclude.UseVisualStyleBackColor = true;
            this.butAddExclude.Click += new System.EventHandler(this.butAddExclude_Click);
            // 
            // butEditExclude
            // 
            this.butEditExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butEditExclude.Image = global::PSync.Properties.Resources.pencil;
            this.butEditExclude.Location = new System.Drawing.Point(286, 202);
            this.butEditExclude.Name = "butEditExclude";
            this.butEditExclude.Size = new System.Drawing.Size(30, 30);
            this.butEditExclude.TabIndex = 10;
            this.butEditExclude.UseVisualStyleBackColor = true;
            this.butEditExclude.Click += new System.EventHandler(this.butEditExclude_Click);
            // 
            // butDeleteExclude
            // 
            this.butDeleteExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteExclude.Image = global::PSync.Properties.Resources.delete;
            this.butDeleteExclude.Location = new System.Drawing.Point(322, 202);
            this.butDeleteExclude.Name = "butDeleteExclude";
            this.butDeleteExclude.Size = new System.Drawing.Size(30, 30);
            this.butDeleteExclude.TabIndex = 11;
            this.butDeleteExclude.UseVisualStyleBackColor = true;
            this.butDeleteExclude.Click += new System.EventHandler(this.butDeleteExclude_Click);
            // 
            // lstExcludes
            // 
            this.lstExcludes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstExcludes.FormattingEnabled = true;
            this.lstExcludes.Location = new System.Drawing.Point(64, 110);
            this.lstExcludes.Name = "lstExcludes";
            this.lstExcludes.Size = new System.Drawing.Size(288, 69);
            this.lstExcludes.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Excludes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Folder 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Folder 1";
            // 
            // butBrowse2
            // 
            this.butBrowse2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrowse2.Image = global::PSync.Properties.Resources.zoom;
            this.butBrowse2.Location = new System.Drawing.Point(322, 70);
            this.butBrowse2.Name = "butBrowse2";
            this.butBrowse2.Size = new System.Drawing.Size(30, 30);
            this.butBrowse2.TabIndex = 5;
            this.butBrowse2.UseVisualStyleBackColor = true;
            this.butBrowse2.Click += new System.EventHandler(this.butBrowse2_Click);
            // 
            // butBrowse1
            // 
            this.butBrowse1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrowse1.Image = global::PSync.Properties.Resources.zoom;
            this.butBrowse1.Location = new System.Drawing.Point(322, 35);
            this.butBrowse1.Name = "butBrowse1";
            this.butBrowse1.Size = new System.Drawing.Size(30, 30);
            this.butBrowse1.TabIndex = 3;
            this.butBrowse1.UseVisualStyleBackColor = true;
            this.butBrowse1.Click += new System.EventHandler(this.butBrowse1_Click);
            // 
            // txtExclude
            // 
            this.txtExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExclude.Location = new System.Drawing.Point(64, 208);
            this.txtExclude.Name = "txtExclude";
            this.txtExclude.Size = new System.Drawing.Size(145, 20);
            this.txtExclude.TabIndex = 7;
            // 
            // txtFolder2
            // 
            this.txtFolder2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder2.Location = new System.Drawing.Point(64, 76);
            this.txtFolder2.Name = "txtFolder2";
            this.txtFolder2.Size = new System.Drawing.Size(252, 20);
            this.txtFolder2.TabIndex = 4;
            // 
            // txtFolder1
            // 
            this.txtFolder1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder1.Location = new System.Drawing.Point(64, 41);
            this.txtFolder1.Name = "txtFolder1";
            this.txtFolder1.Size = new System.Drawing.Size(252, 20);
            this.txtFolder1.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(64, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(288, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // butExcludeBrowse
            // 
            this.butExcludeBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butExcludeBrowse.Image = global::PSync.Properties.Resources.zoom;
            this.butExcludeBrowse.Location = new System.Drawing.Point(215, 202);
            this.butExcludeBrowse.Name = "butExcludeBrowse";
            this.butExcludeBrowse.Size = new System.Drawing.Size(30, 30);
            this.butExcludeBrowse.TabIndex = 8;
            this.butExcludeBrowse.UseVisualStyleBackColor = true;
            this.butExcludeBrowse.Click += new System.EventHandler(this.butExcludeBrowse_Click);
            // 
            // FormFolderSyncDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 283);
            this.Controls.Add(this.butExcludeBrowse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butAddExclude);
            this.Controls.Add(this.butEditExclude);
            this.Controls.Add(this.butDeleteExclude);
            this.Controls.Add(this.lstExcludes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butBrowse2);
            this.Controls.Add(this.butBrowse1);
            this.Controls.Add(this.txtExclude);
            this.Controls.Add(this.txtFolder2);
            this.Controls.Add(this.txtFolder1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(380, 322);
            this.Name = "FormFolderSyncDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Sync Details";
            this.Load += new System.EventHandler(this.FormFolderSyncDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butAddExclude;
        private System.Windows.Forms.Button butEditExclude;
        private System.Windows.Forms.Button butDeleteExclude;
        private System.Windows.Forms.ListBox lstExcludes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butBrowse2;
        private System.Windows.Forms.Button butBrowse1;
        private System.Windows.Forms.TextBox txtExclude;
        private System.Windows.Forms.TextBox txtFolder2;
        private System.Windows.Forms.TextBox txtFolder1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butExcludeBrowse;
    }
}