namespace PCSimSaveEditor
{
    partial class filemanager
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
            title = new System.Windows.Forms.Label();
            medialist = new System.Windows.Forms.ListBox();
            checkshowusbdrives = new System.Windows.Forms.CheckBox();
            editbutton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Location = new System.Drawing.Point(12, 9);
            title.Name = "title";
            title.Size = new System.Drawing.Size(119, 15);
            title.TabIndex = 0;
            title.Text = "Select an media form";
            // 
            // medialist
            // 
            medialist.FormattingEnabled = true;
            medialist.ItemHeight = 15;
            medialist.Location = new System.Drawing.Point(12, 27);
            medialist.Name = "medialist";
            medialist.Size = new System.Drawing.Size(284, 259);
            medialist.TabIndex = 1;
            medialist.SelectedIndexChanged += medialist_SelectedIndexChanged;
            // 
            // checkshowusbdrives
            // 
            checkshowusbdrives.AutoSize = true;
            checkshowusbdrives.Location = new System.Drawing.Point(12, 295);
            checkshowusbdrives.Name = "checkshowusbdrives";
            checkshowusbdrives.Size = new System.Drawing.Size(114, 19);
            checkshowusbdrives.TabIndex = 2;
            checkshowusbdrives.Text = "Show USB Drives";
            checkshowusbdrives.UseVisualStyleBackColor = true;
            checkshowusbdrives.CheckedChanged += checkshowusbdrives_CheckedChanged;
            // 
            // editbutton
            // 
            editbutton.Enabled = false;
            editbutton.Location = new System.Drawing.Point(221, 292);
            editbutton.Name = "editbutton";
            editbutton.Size = new System.Drawing.Size(75, 23);
            editbutton.TabIndex = 3;
            editbutton.Text = "Edit";
            editbutton.UseVisualStyleBackColor = true;
            editbutton.Click += editbutton_Click;
            // 
            // filemanager
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(308, 324);
            Controls.Add(editbutton);
            Controls.Add(checkshowusbdrives);
            Controls.Add(medialist);
            Controls.Add(title);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "filemanager";
            Text = "File Manager - PCSim";
            Load += filemanager_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ListBox medialist;
        private System.Windows.Forms.CheckBox checkshowusbdrives;
        private System.Windows.Forms.Button editbutton;
    }
}