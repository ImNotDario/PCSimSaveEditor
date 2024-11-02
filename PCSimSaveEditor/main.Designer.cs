namespace PCSimDecrypt
{
    partial class main
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
            bottomText = new System.Windows.Forms.Label();
            decryptOpen = new System.Windows.Forms.Button();
            pathText = new System.Windows.Forms.TextBox();
            savecontent = new System.Windows.Forms.RichTextBox();
            openRaw = new System.Windows.Forms.Button();
            encryptSavePc = new System.Windows.Forms.Button();
            saveTxt = new System.Windows.Forms.Button();
            originalUIGoTo = new System.Windows.Forms.LinkLabel();
            saveVer = new System.Windows.Forms.Label();
            lsavename = new System.Windows.Forms.Label();
            lsavemoney = new System.Windows.Forms.Label();
            lsaveroom = new System.Windows.Forms.Label();
            lplaytime = new System.Windows.Forms.Label();
            separatorX01 = new System.Windows.Forms.Label();
            LinkLabel12 = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            // 
            // bottomText
            // 
            bottomText.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            bottomText.AutoSize = true;
            bottomText.Location = new System.Drawing.Point(3, 306);
            bottomText.Name = "bottomText";
            bottomText.Size = new System.Drawing.Size(440, 15);
            bottomText.TabIndex = 0;
            bottomText.Text = "Made with <3 by N2O4, 2023, improved by zegs32, 2024, zdenek99000 - bug report";
            bottomText.MouseDown += bottomText_MouseDown;
            bottomText.MouseUp += bottomText_MouseUp;
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
            // originalUIGoTo
            // 
            originalUIGoTo.AutoSize = true;
            originalUIGoTo.Location = new System.Drawing.Point(599, 303);
            originalUIGoTo.Name = "originalUIGoTo";
            originalUIGoTo.Size = new System.Drawing.Size(90, 15);
            originalUIGoTo.TabIndex = 9;
            originalUIGoTo.TabStop = true;
            originalUIGoTo.Text = "Original Version";
            originalUIGoTo.LinkClicked += originalUIGoTo_LinkClicked;
            // 
            // saveVer
            // 
            saveVer.AutoSize = true;
            saveVer.Location = new System.Drawing.Point(13, 107);
            saveVer.Name = "saveVer";
            saveVer.Size = new System.Drawing.Size(128, 15);
            saveVer.TabIndex = 10;
            saveVer.Text = "Save Version: unknown";
            // 
            // lsavename
            // 
            lsavename.Location = new System.Drawing.Point(12, 167);
            lsavename.Name = "lsavename";
            lsavename.Size = new System.Drawing.Size(160, 32);
            lsavename.TabIndex = 11;
            lsavename.Text = "Save Name: unknown";
            // 
            // lsavemoney
            // 
            lsavemoney.AutoSize = true;
            lsavemoney.Location = new System.Drawing.Point(13, 122);
            lsavemoney.Name = "lsavemoney";
            lsavemoney.Size = new System.Drawing.Size(103, 15);
            lsavemoney.TabIndex = 12;
            lsavemoney.Text = "Save Money: nan$";
            // 
            // lsaveroom
            // 
            lsaveroom.AutoSize = true;
            lsaveroom.Location = new System.Drawing.Point(12, 137);
            lsaveroom.Name = "lsaveroom";
            lsaveroom.Size = new System.Drawing.Size(83, 15);
            lsaveroom.TabIndex = 13;
            lsaveroom.Text = "Save Room: -1";
            // 
            // lplaytime
            // 
            lplaytime.AutoSize = true;
            lplaytime.Location = new System.Drawing.Point(12, 152);
            lplaytime.Name = "lplaytime";
            lplaytime.Size = new System.Drawing.Size(97, 15);
            lplaytime.TabIndex = 14;
            lplaytime.Text = "Save Playtime: 0s";
            // 
            // separatorX01
            // 
            separatorX01.AutoSize = true;
            separatorX01.Location = new System.Drawing.Point(581, 303);
            separatorX01.Name = "separatorX01";
            separatorX01.Size = new System.Drawing.Size(12, 15);
            separatorX01.TabIndex = 16;
            separatorX01.Text = "-";
            // 
            // LinkLabel12
            // 
            LinkLabel12.AutoSize = true;
            LinkLabel12.Location = new System.Drawing.Point(491, 303);
            LinkLabel12.Name = "LinkLabel12";
            LinkLabel12.Size = new System.Drawing.Size(84, 15);
            LinkLabel12.TabIndex = 17;
            LinkLabel12.TabStop = true;
            LinkLabel12.Text = "Simple Version";
            LinkLabel12.LinkClicked += LinkLabel12_LinkClicked;
            // 
            // main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(697, 325);
            Controls.Add(LinkLabel12);
            Controls.Add(separatorX01);
            Controls.Add(lplaytime);
            Controls.Add(lsaveroom);
            Controls.Add(lsavemoney);
            Controls.Add(lsavename);
            Controls.Add(saveVer);
            Controls.Add(originalUIGoTo);
            Controls.Add(saveTxt);
            Controls.Add(encryptSavePc);
            Controls.Add(openRaw);
            Controls.Add(savecontent);
            Controls.Add(pathText);
            Controls.Add(decryptOpen);
            Controls.Add(bottomText);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "main";
            Text = "zegs32's PCSim Save Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label bottomText;
        private System.Windows.Forms.Button decryptOpen;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.RichTextBox savecontent;
        private System.Windows.Forms.Button openRaw;
        private System.Windows.Forms.Button encryptSavePc;
        private System.Windows.Forms.Button saveTxt;
        private System.Windows.Forms.LinkLabel originalUIGoTo;
        private System.Windows.Forms.Label saveVer;
        private System.Windows.Forms.Label lsavename;
        private System.Windows.Forms.Label lsavemoney;
        private System.Windows.Forms.Label lsaveroom;
        private System.Windows.Forms.Label lplaytime;
        private System.Windows.Forms.Label separatorX01;
        private System.Windows.Forms.LinkLabel LinkLabel12;
    }
}
