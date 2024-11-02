namespace PCSimSaveEditor
{
    partial class InputDialog
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
            OKButton = new System.Windows.Forms.Button();
            clabel = new System.Windows.Forms.Label();
            ctextbox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // OKButton
            // 
            OKButton.Location = new System.Drawing.Point(98, 61);
            OKButton.Name = "OKButton";
            OKButton.Size = new System.Drawing.Size(75, 23);
            OKButton.TabIndex = 0;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += buttonOK_Click;
            // 
            // clabel
            // 
            clabel.AutoSize = true;
            clabel.Location = new System.Drawing.Point(12, 9);
            clabel.Name = "clabel";
            clabel.Size = new System.Drawing.Size(18, 15);
            clabel.TabIndex = 1;
            clabel.Text = "vs";
            // 
            // ctextbox
            // 
            ctextbox.Location = new System.Drawing.Point(12, 32);
            ctextbox.Name = "ctextbox";
            ctextbox.Size = new System.Drawing.Size(254, 23);
            ctextbox.TabIndex = 2;
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(278, 96);
            Controls.Add(ctextbox);
            Controls.Add(clabel);
            Controls.Add(OKButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Name = "InputDialog";
            Text = "Input Dialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label clabel;
        private System.Windows.Forms.TextBox ctextbox;
    }
}