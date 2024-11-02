using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCSimDecrypt
{
    public partial class originalUI : Form
    {
        public originalUI()
        {
            InitializeComponent();
        }
        private string Xor(string s, int key)
        {
            char[] result = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = (char)(s[i] ^ key); // XOR each character with the key
            }
            return new string(result); // Convert the char array back to a string
        }
        private void decryptOpen_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fContent = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = ".";
                ofd.Filter = "PCSim Save file (*.pc)|*.pc|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    var fstream = ofd.OpenFile();
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        fContent = sr.ReadToEnd();
                    }
                }
            }
            fContent = Xor(fContent, 129);
            pathText.Text = filePath;
            savecontent.Text = fContent;
        }

        private void openRaw_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fContent = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = ".";
                ofd.Filter = "PCSim Save file (*.pc)|*.pc|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    var fstream = ofd.OpenFile();
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        fContent = sr.ReadToEnd();
                    }
                }
            }
            pathText.Text = filePath;
            savecontent.Text = fContent;
        }

        private void saveTxt_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.InitialDirectory = ".";
                save.Filter = "Text File (*.txt)|*.txt|All files (*.*)|*.*";
                save.FilterIndex = 1;
                save.RestoreDirectory = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    filePath = save.FileName;
                    using (StreamWriter sr = new StreamWriter(filePath))
                    {
                        sr.Write(savecontent.Text);
                    }
                }
            }
        }

        private void encryptSavePc_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.InitialDirectory = ".";
                save.Filter = "PCSim Save file (*.pc)|*.pc|All files (*.*)|*.*";
                save.FilterIndex = 1;
                save.RestoreDirectory = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    filePath = save.FileName;
                    using (StreamWriter sr = new StreamWriter(filePath))
                    {
                        sr.Write(Xor(savecontent.Text, 129));
                    }
                }
            }
        }
    }
}
