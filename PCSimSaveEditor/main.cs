using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCSimSaveEditor;

namespace PCSimDecrypt
{
    public partial class main : Form
    {
        private JObject metadata = new JObject();
        private JObject scene = new JObject();
        public main()
        {
            InitializeComponent();
        }
        private string TimeFormat(int t)
        {
            // Calculate days, hours, minutes, and seconds
            int days = t / 86400; // 86400 seconds in a day
            t %= 86400; // Remaining seconds after calculating days
            int hours = t / 3600; // 3600 seconds in an hour
            t %= 3600; // Remaining seconds after calculating hours
            int minutes = t / 60; // 60 seconds in a minute
            int seconds = t % 60; // Remaining seconds

            // Use a list to collect the formatted parts
            List<string> parts = new List<string>();

            // Add non-zero components to the list
            if (days > 0) parts.Add($"{days}d");
            if (hours > 0) parts.Add($"{hours}h");
            if (minutes > 0) parts.Add($"{minutes}m");
            if (seconds > 0 || parts.Count == 0) // Include seconds if it's zero and no other parts are present
                parts.Add($"{seconds}s");

            // Join the parts with a space and return
            return string.Join(" ", parts);
        }

        private void setStrings(JObject s)
        {
            if (s != null)
            {
                lsavename.Text = "Save Name: " + s["roomName"]?.ToString() ?? "unknown";
                lsavemoney.Text = "Save Money: " + (s["coin"]?.Value<int>() ?? 0).ToString() + "$"; // convert to int somehow
                saveVer.Text = "Save Version: " + s["version"]?.ToString() ?? "unknown";
                lsaveroom.Text = "Save Room: " + (s["room"]?.Value<int>() ?? -1).ToString();
                lplaytime.Text = "Save Playtime: " + TimeFormat(s["playtime"]?.Value<int>() ?? 0);
            }
        }
        private void setAllToUnknown()
        {
            lsavename.Text = "Save Name: unknown";
            lsavemoney.Text = "Save Money: nan$";
            saveVer.Text = "Save Version: unknown";
            lsaveroom.Text = "Save Room: -1";
            lplaytime.Text = "Save Playtime: 0s";
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
            metadata = new JObject();
            scene = new JObject();
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
                    using (StreamReader sr = new StreamReader(ofd.OpenFile()))
                    {
                        fContent = sr.ReadToEnd();
                    }
                }
            }

            // Decode content using XOR
            fContent = Xor(fContent, 129);

            // Split content by lines
            var lines = fContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Ensure we have at least two lines for metadata and scene
            if (lines.Length >= 2)
            {
                try
                {
                    // Parse the first line as JSON for metadata
                    metadata = JsonConvert.DeserializeObject<JObject>(lines[0]);

                    // Parse remaining lines as JSON for scene data
                    var sceneJson = string.Join("\n", lines.Skip(1));
                    scene = JsonConvert.DeserializeObject<JObject>(sceneJson);

                    // Update save version information
                    setStrings(metadata);
                }
                catch (JsonException)
                {
                    // Handle JSON parsing errors
                    metadata = null; // Set to null or initialize
                    scene = null; // Set to null or initialize
                    setAllToUnknown();
                }
            }
            else
            {
                metadata = null; // Set to null
                scene = null; // Set to null
                setAllToUnknown();
            }

            // Update UI components with the results
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
                ofd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    using (StreamReader sr = new StreamReader(ofd.OpenFile()))
                    {
                        fContent = sr.ReadToEnd();
                    }
                }
            }

            // Split content by lines
            var lines = fContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Ensure we have at least two lines for metadata and scene
            if (lines.Length >= 2)
            {
                try
                {
                    // Parse the first line as JSON for metadata
                    metadata = JsonConvert.DeserializeObject<JObject>(lines[0]);

                    // Parse remaining lines as JSON for scene data
                    var sceneJson = string.Join("\n", lines.Skip(1));
                    scene = JsonConvert.DeserializeObject<JObject>(sceneJson);
                    setStrings(metadata);

                }
                catch (JsonException)
                {
                    // Handle JSON parsing errors
                    metadata = null; // Set to null or you can use JObject.Parse("{}") to initialize
                    scene = null; // Set to null or you can use JObject.Parse("{}") to initialize
                    setAllToUnknown();
                }
            }
            else
            {
                metadata = null; // Set to null
                scene = null; // Set to null
                setAllToUnknown();
            }

            // Update UI components
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
        private void originalUIGoTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // make it so originalUI form shows up instead of main
            originalUI fn = new originalUI();
            fn.Show();
            this.Hide();
            fn.FormClosed += (s, args) => this.Close();
        }
        private void bottomText_MouseDown(object sender, MouseEventArgs e)
        {
            bottomText.Text = "Coded by zegs32, og by N2O4, zdenek99000 - bug report";
            this.Text = "zegs32's PCSim Save Editor";
        }
        private void bottomText_MouseUp(object sender, MouseEventArgs e)
        {
            bottomText.Text = "Made with <3 by N2O4, 2023, improved by zegs32, zdenek99000 - bug report";
            this.Text = "N2O4's PCSim Save Editor";
        }

        private void LinkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            easy fn = new easy();
            fn.Show();
            this.Hide();
            fn.FormClosed += (s, args) => this.Show();
        }

        private void pcsimdecryptrfgd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = "https://pcsimdecrypt.rf.gd";
            Process.Start(new ProcessStartInfo(target) { UseShellExecute = true });
        }
    }
}
