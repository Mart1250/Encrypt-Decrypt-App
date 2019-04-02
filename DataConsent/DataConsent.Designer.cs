namespace DataConsent
{
    partial class DataConsent
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
            this.b_verify = new System.Windows.Forms.Button();
            this.b_addfile = new System.Windows.Forms.Button();
            this.l_files = new System.Windows.Forms.ListView();
            this.oFD_loadfile = new System.Windows.Forms.OpenFileDialog();
            this.b_savelist = new System.Windows.Forms.Button();
            this.b_loadlist = new System.Windows.Forms.Button();
            this.b_decrypt = new System.Windows.Forms.Button();
            this.sFD_savefile = new System.Windows.Forms.SaveFileDialog();
            this.b_connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_verify
            // 
            this.b_verify.Location = new System.Drawing.Point(12, 12);
            this.b_verify.Name = "b_verify";
            this.b_verify.Size = new System.Drawing.Size(75, 23);
            this.b_verify.TabIndex = 0;
            this.b_verify.Text = "Verify";
            this.b_verify.UseVisualStyleBackColor = true;
            this.b_verify.Click += new System.EventHandler(this.b_verify_Click);
            // 
            // b_addfile
            // 
            this.b_addfile.Location = new System.Drawing.Point(93, 12);
            this.b_addfile.Name = "b_addfile";
            this.b_addfile.Size = new System.Drawing.Size(75, 23);
            this.b_addfile.TabIndex = 2;
            this.b_addfile.Text = "Add File";
            this.b_addfile.UseVisualStyleBackColor = true;
            this.b_addfile.Click += new System.EventHandler(this.b_addfile_Click);
            // 
            // l_files
            // 
            this.l_files.Location = new System.Drawing.Point(12, 41);
            this.l_files.Name = "l_files";
            this.l_files.Size = new System.Drawing.Size(156, 397);
            this.l_files.TabIndex = 3;
            this.l_files.UseCompatibleStateImageBehavior = false;
            this.l_files.View = System.Windows.Forms.View.Details;
            this.l_files.SelectedIndexChanged += new System.EventHandler(this.l_files_SelectedIndexChanged);
            // 
            // b_savelist
            // 
            this.b_savelist.Location = new System.Drawing.Point(175, 11);
            this.b_savelist.Name = "b_savelist";
            this.b_savelist.Size = new System.Drawing.Size(75, 23);
            this.b_savelist.TabIndex = 4;
            this.b_savelist.Text = "Save List";
            this.b_savelist.UseVisualStyleBackColor = true;
            this.b_savelist.Click += new System.EventHandler(this.b_savelist_Click);
            // 
            // b_loadlist
            // 
            this.b_loadlist.Location = new System.Drawing.Point(257, 11);
            this.b_loadlist.Name = "b_loadlist";
            this.b_loadlist.Size = new System.Drawing.Size(75, 23);
            this.b_loadlist.TabIndex = 5;
            this.b_loadlist.Text = "Load List";
            this.b_loadlist.UseVisualStyleBackColor = true;
            this.b_loadlist.Click += new System.EventHandler(this.b_loadlist_Click);
            // 
            // b_decrypt
            // 
            this.b_decrypt.Location = new System.Drawing.Point(338, 11);
            this.b_decrypt.Name = "b_decrypt";
            this.b_decrypt.Size = new System.Drawing.Size(75, 23);
            this.b_decrypt.TabIndex = 6;
            this.b_decrypt.Text = "Decrypt";
            this.b_decrypt.UseVisualStyleBackColor = true;
            this.b_decrypt.Click += new System.EventHandler(this.b_decrypt_Click);
            // 
            // b_connect
            // 
            this.b_connect.Location = new System.Drawing.Point(419, 11);
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(75, 23);
            this.b_connect.TabIndex = 7;
            this.b_connect.Text = "Connect";
            this.b_connect.UseVisualStyleBackColor = true;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // DataConsent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.b_connect);
            this.Controls.Add(this.b_decrypt);
            this.Controls.Add(this.b_loadlist);
            this.Controls.Add(this.b_savelist);
            this.Controls.Add(this.l_files);
            this.Controls.Add(this.b_addfile);
            this.Controls.Add(this.b_verify);
            this.Name = "DataConsent";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DataConsent_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_verify;
        private System.Windows.Forms.Button b_addfile;
        private System.Windows.Forms.ListView l_files;
        private System.Windows.Forms.OpenFileDialog oFD_loadfile;
        private System.Windows.Forms.Button b_savelist;
        private System.Windows.Forms.Button b_loadlist;
        private System.Windows.Forms.Button b_decrypt;
        private System.Windows.Forms.SaveFileDialog sFD_savefile;
        private System.Windows.Forms.Button b_connect;
    }
}

