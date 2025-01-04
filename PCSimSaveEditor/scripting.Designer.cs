namespace PCSimSaveEditor {
    partial class scripting {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            warninglbl = new System.Windows.Forms.Label();
            scriptbox = new System.Windows.Forms.RichTextBox();
            execute = new System.Windows.Forms.Button();
            paramlbl = new System.Windows.Forms.Label();
            parameter = new System.Windows.Forms.TextBox();
            outlbl = new System.Windows.Forms.Label();
            outputlist = new System.Windows.Forms.ListBox();
            SuspendLayout();
            // 
            // warninglbl
            // 
            warninglbl.AutoSize = true;
            warninglbl.Location = new System.Drawing.Point(4, 5);
            warninglbl.Name = "warninglbl";
            warninglbl.Size = new System.Drawing.Size(378, 15);
            warninglbl.TabIndex = 0;
            warninglbl.Text = "WARNING: Lua scripts may damage your system! Use at your own risk!";
            // 
            // scriptbox
            // 
            scriptbox.Location = new System.Drawing.Point(4, 23);
            scriptbox.Name = "scriptbox";
            scriptbox.Size = new System.Drawing.Size(378, 274);
            scriptbox.TabIndex = 1;
            scriptbox.Text = "";
            // 
            // execute
            // 
            execute.Location = new System.Drawing.Point(388, 251);
            execute.Name = "execute";
            execute.Size = new System.Drawing.Size(127, 46);
            execute.TabIndex = 2;
            execute.Text = "Execute";
            execute.UseVisualStyleBackColor = true;
            execute.Click += execute_Click;
            // 
            // paramlbl
            // 
            paramlbl.AutoSize = true;
            paramlbl.Location = new System.Drawing.Point(388, 204);
            paramlbl.Name = "paramlbl";
            paramlbl.Size = new System.Drawing.Size(99, 15);
            paramlbl.TabIndex = 3;
            paramlbl.Text = "Parameter (prov):";
            // 
            // parameter
            // 
            parameter.Location = new System.Drawing.Point(388, 222);
            parameter.Name = "parameter";
            parameter.Size = new System.Drawing.Size(127, 23);
            parameter.TabIndex = 4;
            // 
            // outlbl
            // 
            outlbl.AutoSize = true;
            outlbl.Location = new System.Drawing.Point(521, 5);
            outlbl.Name = "outlbl";
            outlbl.Size = new System.Drawing.Size(45, 15);
            outlbl.TabIndex = 5;
            outlbl.Text = "Output";
            // 
            // outputlist
            // 
            outputlist.FormattingEnabled = true;
            outputlist.ItemHeight = 15;
            outputlist.Location = new System.Drawing.Point(521, 23);
            outputlist.Name = "outputlist";
            outputlist.Size = new System.Drawing.Size(437, 274);
            outputlist.TabIndex = 6;
            // 
            // scripting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(961, 301);
            Controls.Add(outputlist);
            Controls.Add(outlbl);
            Controls.Add(parameter);
            Controls.Add(paramlbl);
            Controls.Add(execute);
            Controls.Add(scriptbox);
            Controls.Add(warninglbl);
            Name = "scripting";
            Text = "Scripting";
            Load += scripting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label warninglbl;
        private System.Windows.Forms.RichTextBox scriptbox;
        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.Label paramlbl;
        private System.Windows.Forms.TextBox parameter;
        private System.Windows.Forms.Label outlbl;
        private System.Windows.Forms.ListBox outputlist;
    }
}
