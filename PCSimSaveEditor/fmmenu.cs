using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace PCSimSaveEditor
{
    public partial class fmmenu : Form
    {
        private int selid = 0;
        private JObject scene = new JObject();
        private JArray selfiles = new JArray();
        private JObject currentfile = new JObject();
        private string currentpath = string.Empty;
        public fmmenu()
        {
            InitializeComponent();
        }
        private void fmmenu_Load(object sender, EventArgs e)
        {
            selid = filemanager.selectedId;
            filelist.Items.Clear();
            ID.Text = selid.ToString();
            scene = easy.scene;
            selfiles = new JArray();
            passwdbox.Text = string.Empty;
            if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
            {
                foreach (var item in itemDataArray)
                {
                    if (item["id"]?.Value<int>() == selid)
                    {
                        passwdbox.Text = item["data"]["password"].ToString();
                        if (item["data"] != null && item["data"]["files"] is JArray filesArray)
                        {
                            foreach (var file in filesArray)
                            {
                                filelist.Items.Add(file["path"]?.ToString());
                            }
                            selfiles = filesArray;
                        }
                        break;
                    }
                }
            }
        }
        private void clistindexchanged()
        {
            if (filelist.SelectedItem != null)
            {
                var s = filelist.SelectedItem.ToString();
                currentfile = null;

                foreach (var file in selfiles)
                {
                    var fileObj = file as JObject;

                    if (fileObj != null && fileObj["path"]?.ToString() == s)
                    {
                        currentfile = fileObj;
                        currentpath = fileObj["path"]?.ToString() ?? string.Empty;
                        break;
                    }
                }
                if (currentfile != null)
                {
                    if (currentfile["path"].ToString().EndsWith(".pic"))
                    {
                        try
                        {
                            string base64String = currentfile["content"].ToString();
                            byte[] imageBytes = Convert.FromBase64String(base64String);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                Image originalImage = Image.FromStream(ms);
                                Bitmap upscaled = new Bitmap(256, 256);
                                using (Graphics g = Graphics.FromImage(upscaled))
                                {
                                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                                    g.DrawImage(originalImage, 0, 0, 128, 128);
                                }
                                picviewer.Image = upscaled;
                                filecontenttextbox.Text = currentfile["content"]?.ToString();
                            }
                        }
                        catch
                        {
                            picviewer.Image = null;
                            filecontenttextbox.Text = currentfile["content"]?.ToString();
                        }
                    } // if its a .mov then use animations
                    else
                    {
                        picviewer.Image = null;
                        filecontenttextbox.Text = currentfile["content"]?.ToString();
                    }
                    hiddencheckbox.Checked = currentfile["hidden"]?.Value<bool>() ?? false;
                }
            }
        }

        private void filelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            clistindexchanged();
        }

        private void filecontenttextbox_TextChanged(object sender, EventArgs e)
        {
            if (currentfile != null)
            {
                currentfile["content"] = filecontenttextbox.Text;

                // Optionally: Update the scene if needed (if it doesn't automatically reflect)
                if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
                {
                    foreach (var item in itemDataArray)
                    {
                        if (item["id"]?.Value<int>() == selid && item["data"] != null && item["data"]["files"] is JArray filesArray)
                        {
                            // Find the specific file entry to update
                            foreach (var file in filesArray)
                            {
                                if (file["path"]?.ToString() == currentpath)
                                {
                                    file["content"] = currentfile["content"];
                                    file["size"] = currentfile["content"].ToString().Length;
                                    file["StorageSize"] = currentfile["content"].ToString().Length;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void hiddencheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentfile != null)
            {
                currentfile["hidden"] = hiddencheckbox.Checked;
                if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
                {
                    foreach (var item in itemDataArray)
                    {
                        if (item["id"]?.Value<int>() == selid && item["data"] != null && item["data"]["files"] is JArray filesArray)
                        {
                            foreach (var file in filesArray)
                            {
                                if (file["path"]?.ToString() == currentpath)
                                {
                                    file["hidden"] = currentfile["hidden"];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void addfilebutton_Click(object sender, EventArgs e)
        {
            using (InputDialog xb = new InputDialog("File name? "))
            {
                if (xb.ShowDialog() == DialogResult.OK)
                {
                    string userInput = xb.InputText;
                    // new file
                    JObject file = new JObject
                    {
                        ["path"] = userInput,
                        ["content"] = "",
                        ["size"] = 0,
                        ["StorageSize"] = 0,
                        ["hidden"] = false,
                    };
                    if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
                    {
                        foreach (var item in itemDataArray)
                        {
                            if (item["id"]?.Value<int>() == selid && item["data"] != null && item["data"]["files"] is JArray filesArray)
                            {
                                bool exists = false;
                                foreach (var fil in filesArray)
                                {
                                    if (fil["path"].ToString() == userInput)
                                    {
                                        exists = true;
                                        break;
                                    }
                                }
                                if (!exists)
                                {
                                    filesArray.Add(file);
                                    fmmenu_Load(this, EventArgs.Empty);
                                }

                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // do same as addfile but delete file that has the same path
            if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
            {
                foreach (var item in itemDataArray)
                {
                    if (item["id"]?.Value<int>() == selid && item["data"] != null && item["data"]["files"] is JArray filesArray)
                    {
                        List<JToken> gb = new List<JToken>();
                        foreach (var fil in filesArray)
                        {
                            if (fil["path"].ToString() == filelist.SelectedItem.ToString())
                            {
                                gb.Add(fil);
                                break;
                            }
                        }
                        foreach (var fil in gb)
                        {
                            filesArray.Remove(fil);
                        }
                    }
                }
            }
            fmmenu_Load(this, EventArgs.Empty);
        }

        private void passwdbox_TextChanged(object sender, EventArgs e)
        {
            if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
            {
                foreach (var item in itemDataArray)
                {
                    if (item["id"]?.Value<int>() == selid)
                    {
                        item["data"]["password"] = passwdbox.Text;
                    }
                }
            }
        }
    }
}