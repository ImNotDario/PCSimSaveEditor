namespace PCSimDecrypt
{
    partial class originalUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            decryptOpen = new System.Windows.Forms.Button();
            pathText = new System.Windows.Forms.TextBox();
            savecontent = new System.Windows.Forms.RichTextBox();
            openRaw = new System.Windows.Forms.Button();
            encryptSavePc = new System.Windows.Forms.Button();
            saveTxt = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 306);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(159, 15);
            label1.TabIndex = 0;
            label1.Text = "Made with <3 by N2O4, 2023";
            // 
            // decryptOpen
            // 
            decryptOpen.Location = new System.Drawing.Point(13, 12);
            decryptOpen.Name = "decryptOpen";
            decryptOpen.Size = new System.Drawing.Size(160, 43);
            decryptOpen.TabIndex = 1;
            decryptOpen.Text = "Decrypt and open .pc";
            decryptOpen.UseVisualStyleBackColor = true;
            decryptOpen.Click += decryptOpen_Click;
            // 
            // pathText
            // 
            pathText.Location = new System.Drawing.Point(179, 12);
            pathText.Name = "pathText";
            pathText.ReadOnly = true;
            pathText.Size = new System.Drawing.Size(510, 23);
            pathText.TabIndex = 2;
            // 
            // savecontent
            // 
            savecontent.Location = new System.Drawing.Point(179, 41);
            savecontent.Name = "savecontent";
            savecontent.Size = new System.Drawing.Size(510, 259);
            savecontent.TabIndex = 4;
            savecontent.Text = "";
            // 
            // openRaw
            // 
            openRaw.Location = new System.Drawing.Point(13, 61);
            openRaw.Name = "openRaw";
            openRaw.Size = new System.Drawing.Size(160, 43);
            openRaw.TabIndex = 5;
            openRaw.Text = "Open raw (.txt)";
            openRaw.UseVisualStyleBackColor = true;
            openRaw.Click += openRaw_Click;
            // 
            // encryptSavePc
            // 
            encryptSavePc.Location = new System.Drawing.Point(12, 257);
            encryptSavePc.Name = "encryptSavePc";
            encryptSavePc.Size = new System.Drawing.Size(161, 43);
            encryptSavePc.TabIndex = 6;
            encryptSavePc.Text = "Encrypt and save (.pc)";
            encryptSavePc.UseVisualStyleBackColor = true;
            encryptSavePc.Click += encryptSavePc_Click;
            // 
            // saveTxt
            // 
            saveTxt.Location = new System.Drawing.Point(12, 212);
            saveTxt.Name = "saveTxt";
            saveTxt.Size = new System.Drawing.Size(161, 39);
            saveTxt.TabIndex = 8;
            saveTxt.Text = "Save unencrypted (.txt)";
            saveTxt.UseVisualStyleBackColor = true;
            saveTxt.Click += saveTxt_Click;
            // 
            // originalUI
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(697, 325);
            Controls.Add(saveTxt);
            Controls.Add(encryptSavePc);
            Controls.Add(openRaw);
            Controls.Add(savecontent);
            Controls.Add(pathText);
            Controls.Add(decryptOpen);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "originalUI";
            Text = "N2O4's PCSim Save Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button decryptOpen;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.RichTextBox savecontent;
        private System.Windows.Forms.Button openRaw;
        private System.Windows.Forms.Button encryptSavePc;
        private System.Windows.Forms.Button saveTxt;
    }
}
