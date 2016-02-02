namespace Rnet
{
    partial class View
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
            this.tvStorage = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStorageName = new System.Windows.Forms.Label();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tvStorage
            // 
            this.tvStorage.Location = new System.Drawing.Point(0, 0);
            this.tvStorage.Name = "tvStorage";
            this.tvStorage.Size = new System.Drawing.Size(312, 594);
            this.tvStorage.TabIndex = 0;
            this.tvStorage.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStorage_NodeMouseClick);
            this.tvStorage.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStorage_NodeMouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(521, 524);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblStorageName
            // 
            this.lblStorageName.AutoSize = true;
            this.lblStorageName.Location = new System.Drawing.Point(332, 34);
            this.lblStorageName.Name = "lblStorageName";
            this.lblStorageName.Size = new System.Drawing.Size(35, 13);
            this.lblStorageName.TabIndex = 2;
            this.lblStorageName.Text = "label1";
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(388, 0);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(225, 290);
            this.lbFiles.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Files:";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 592);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.lblStorageName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tvStorage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(1100, 100);
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvStorage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStorageName;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Label label1;

    }
}