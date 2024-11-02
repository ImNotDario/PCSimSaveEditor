namespace PCSimSaveEditor
{
    partial class fmmenu
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
            clabelid = new System.Windows.Forms.Label();
            ID = new System.Windows.Forms.TextBox();
            filelist = new System.Windows.Forms.ListBox();
            filecontenttextbox = new System.Windows.Forms.RichTextBox();
            clabelosoox = new System.Windows.Forms.Label();
            hiddencheckbox = new System.Windows.Forms.CheckBox();
            picviewer = new System.Windows.Forms.PictureBox();
            addfilebutton = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            passwdbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)picviewer).BeginInit();
            SuspendLayout();
            // 
            // clabelid
            // 
            clabelid.AutoSize = true;
            clabelid.Location = new System.Drawing.Point(12, 9);
            clabelid.Name = "clabelid";
            clabelid.Size = new System.Drawing.Size(68, 15);
            clabelid.TabIndex = 0;
            clabelid.Text = "Selected ID:";
            // 
            // ID
            // 
            ID.Location = new System.Drawing.Point(86, 6);
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Size = new System.Drawing.Size(395, 23);
            ID.TabIndex = 1;
            ID.Text = "0";
            // 
            // filelist
            // 
            filelist.FormattingEnabled = true;
            filelist.ItemHeight = 15;
            filelist.Location = new System.Drawing.Point(12, 35);
            filelist.Name = "filelist";
            filelist.Size = new System.Drawing.Size(138, 244);
            filelist.TabIndex = 2;
            filelist.SelectedIndexChanged += filelist_SelectedIndexChanged;
            // 
            // filecontenttextbox
            // 
            filecontenttextbox.Location = new System.Drawing.Point(156, 35);
            filecontenttextbox.Name = "filecontenttextbox";
            filecontenttextbox.Size = new System.Drawing.Size(325, 274);
            filecontenttextbox.TabIndex = 3;
            filecontenttextbox.Text = "";
            filecontenttextbox.TextChanged += filecontenttextbox_TextChanged;
            // 
            // clabelosoox
            // 
            clabelosoox.AutoSize = true;
            clabelosoox.Location = new System.Drawing.Point(12, 312);
            clabelosoox.Name = "clabelosoox";
            clabelosoox.Size = new System.Drawing.Size(263, 15);
            clabelosoox.TabIndex = 4;
            clabelosoox.Text = "Changes are automatically saved when modified";
            // 
            // hiddencheckbox
            // 
            hiddencheckbox.AutoSize = true;
            hiddencheckbox.Location = new System.Drawing.Point(487, 35);
            hiddencheckbox.Name = "hiddencheckbox";
            hiddencheckbox.Size = new System.Drawing.Size(65, 19);
            hiddencheckbox.TabIndex = 5;
            hiddencheckbox.Text = "Hidden";
            hiddencheckbox.UseVisualStyleBackColor = true;
            hiddencheckbox.CheckedChanged += hiddencheckbox_CheckedChanged;
            // 
            // picviewer
            // 
            picviewer.Location = new System.Drawing.Point(508, 181);
            picviewer.Name = "picviewer";
            picviewer.Size = new System.Drawing.Size(128, 128);
            picviewer.TabIndex = 6;
            picviewer.TabStop = false;
            // 
            // addfilebutton
            // 
            addfilebutton.Location = new System.Drawing.Point(12, 286);
            addfilebutton.Name = "addfilebutton";
            addfilebutton.Size = new System.Drawing.Size(68, 23);
            addfilebutton.TabIndex = 7;
            addfilebutton.Text = "Add file";
            addfilebutton.UseVisualStyleBackColor = true;
            addfilebutton.Click += addfilebutton_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(79, 286);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(71, 23);
            button1.TabIndex = 8;
            button1.Text = "Delete file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(492, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 15);
            label1.TabIndex = 9;
            label1.Text = "Password";
            // 
            // passwdbox
            // 
            passwdbox.Location = new System.Drawing.Point(555, 3);
            passwdbox.Name = "passwdbox";
            passwdbox.Size = new System.Drawing.Size(100, 23);
            passwdbox.TabIndex = 10;
            passwdbox.TextChanged += passwdbox_TextChanged;
            // 
            // fmmenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(660, 332);
            Controls.Add(passwdbox);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(addfilebutton);
            Controls.Add(picviewer);
            Controls.Add(hiddencheckbox);
            Controls.Add(clabelosoox);
            Controls.Add(filecontenttextbox);
            Controls.Add(filelist);
            Controls.Add(ID);
            Controls.Add(clabelid);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmmenu";
            Text = "File Manager - PCSim";
            Load += fmmenu_Load;
            ((System.ComponentModel.ISupportInitialize)picviewer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label clabelid;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.ListBox filelist;
        private System.Windows.Forms.RichTextBox filecontenttextbox;
        private System.Windows.Forms.Label clabelosoox;
        private System.Windows.Forms.CheckBox hiddencheckbox;
        private System.Windows.Forms.PictureBox picviewer;
        private System.Windows.Forms.Button addfilebutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwdbox;
    }
}