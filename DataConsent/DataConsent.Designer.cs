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
            this.oFD_addfile = new System.Windows.Forms.OpenFileDialog();
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
            // 
            // DataConsent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.l_files);
            this.Controls.Add(this.b_addfile);
            this.Controls.Add(this.b_verify);
            this.Name = "DataConsent";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_verify;
        private System.Windows.Forms.Button b_addfile;
        private System.Windows.Forms.ListView l_files;
        private System.Windows.Forms.OpenFileDialog oFD_addfile;
    }
}

