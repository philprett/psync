namespace PSync.controls
{
    partial class FolderSyncControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolder1 = new System.Windows.Forms.TextBox();
            this.txtFolder2 = new System.Windows.Forms.TextBox();
            this.butAnalyse = new System.Windows.Forms.Button();
            this.butSync = new System.Windows.Forms.Button();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.PathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder1Modified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder2Modified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder 2";
            // 
            // txtFolder1
            // 
            this.txtFolder1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder1.Location = new System.Drawing.Point(54, 3);
            this.txtFolder1.Name = "txtFolder1";
            this.txtFolder1.ReadOnly = true;
            this.txtFolder1.Size = new System.Drawing.Size(718, 20);
            this.txtFolder1.TabIndex = 2;
            // 
            // txtFolder2
            // 
            this.txtFolder2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder2.Location = new System.Drawing.Point(54, 29);
            this.txtFolder2.Name = "txtFolder2";
            this.txtFolder2.ReadOnly = true;
            this.txtFolder2.Size = new System.Drawing.Size(718, 20);
            this.txtFolder2.TabIndex = 3;
            // 
            // butAnalyse
            // 
            this.butAnalyse.Location = new System.Drawing.Point(6, 55);
            this.butAnalyse.Name = "butAnalyse";
            this.butAnalyse.Size = new System.Drawing.Size(75, 23);
            this.butAnalyse.TabIndex = 4;
            this.butAnalyse.Text = "Analyse";
            this.butAnalyse.UseVisualStyleBackColor = true;
            this.butAnalyse.Click += new System.EventHandler(this.butAnalyse_Click);
            // 
            // butSync
            // 
            this.butSync.Location = new System.Drawing.Point(87, 55);
            this.butSync.Name = "butSync";
            this.butSync.Size = new System.Drawing.Size(75, 23);
            this.butSync.TabIndex = 5;
            this.butSync.Text = "Sync";
            this.butSync.UseVisualStyleBackColor = true;
            this.butSync.Click += new System.EventHandler(this.butSync_Click);
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToResizeRows = false;
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.BackgroundColor = System.Drawing.Color.White;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PathColumn,
            this.Folder1Modified,
            this.ActionColumn,
            this.Folder2Modified});
            this.Grid.Location = new System.Drawing.Point(6, 84);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersVisible = false;
            this.Grid.Size = new System.Drawing.Size(766, 310);
            this.Grid.TabIndex = 6;
            // 
            // PathColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PathColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.PathColumn.FillWeight = 31.91489F;
            this.PathColumn.HeaderText = "Path";
            this.PathColumn.Name = "PathColumn";
            this.PathColumn.ReadOnly = true;
            // 
            // Folder1Modified
            // 
            this.Folder1Modified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Folder1Modified.DefaultCellStyle = dataGridViewCellStyle10;
            this.Folder1Modified.HeaderText = "Folder 1";
            this.Folder1Modified.Name = "Folder1Modified";
            this.Folder1Modified.ReadOnly = true;
            this.Folder1Modified.Width = 110;
            // 
            // ActionColumn
            // 
            this.ActionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ActionColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.ActionColumn.HeaderText = "";
            this.ActionColumn.Name = "ActionColumn";
            this.ActionColumn.ReadOnly = true;
            this.ActionColumn.Width = 35;
            // 
            // Folder2Modified
            // 
            this.Folder2Modified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Folder2Modified.DefaultCellStyle = dataGridViewCellStyle12;
            this.Folder2Modified.FillWeight = 236.1702F;
            this.Folder2Modified.HeaderText = "Folder 2";
            this.Folder2Modified.Name = "Folder2Modified";
            this.Folder2Modified.ReadOnly = true;
            this.Folder2Modified.Width = 110;
            // 
            // FolderSyncControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.butSync);
            this.Controls.Add(this.butAnalyse);
            this.Controls.Add(this.txtFolder2);
            this.Controls.Add(this.txtFolder1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FolderSyncControl";
            this.Size = new System.Drawing.Size(775, 397);
            this.Load += new System.EventHandler(this.FolderSyncControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolder1;
        private System.Windows.Forms.TextBox txtFolder2;
        private System.Windows.Forms.Button butAnalyse;
        private System.Windows.Forms.Button butSync;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder1Modified;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder2Modified;
    }
}
