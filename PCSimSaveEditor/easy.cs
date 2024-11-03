using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PCSimSaveEditor
{
    public partial class easy : Form
    {
        private Size manuf_Unloaded = new Size(605, 102);
        private Size manuf_Loaded;
        private static int xorkey = 129;
        private string contents = "";
        public static JObject meta = new JObject();
        public static JObject scene = new JObject();
        private List<string> passwdl = new List<string>();
        private Point message_h = new Point(12, 502);
        private Point message_s = new Point(618, 9);
        public easy()
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
        private void easy_Load(object sender, EventArgs e)
        {
            manuf_Loaded = this.Size;
            this.Size = manuf_Unloaded;
        }
        private void Open_Click(object sender, EventArgs e)
        {
            meta = new JObject();
            scene = new JObject();
            passwdl = new List<string>();
            contents = "";
            listadded.Items.Clear();
            passwdlist.Items.Clear();
            OpenFileDialog jx = new OpenFileDialog();
            jx.Filter = "PCSim Save file (*.pc)|*.pc|All files (*.*)|*.*";
            jx.FilterIndex = 0;
            jx.InitialDirectory = ".";
            jx.RestoreDirectory = true;

            if (jx.ShowDialog() == DialogResult.OK)
            {
                string path = jx.FileName;

                try
                {
                    byte[] fileBytes = File.ReadAllBytes(path);
                    string fileContents = Encoding.UTF8.GetString(fileBytes);
                    string xorredContents = Xor(fileContents, xorkey);
                    contents = xorredContents;
                    this.Size = manuf_Loaded;
                    var lines = xorredContents.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lines.Length > 0)
                    {
                        meta = JObject.Parse(lines[0]);
                    }
                    if (lines.Length > 1)
                    {
                        scene = JObject.Parse(string.Join("\n", lines.Skip(1)));
                    }
                    cl_versiontextbox.Text = meta["version"]?.ToString() ?? "?";
                    if (cl_versiontextbox.Text.StartsWith("1.7"))
                    {
                        noticelabel.Location = message_s;
                    } 
                    else
                    {
                        noticelabel.Location = message_h;
                    }
                    savenametextbox.Text = meta["roomName"]?.ToString() ?? "Unknown";
                    moneyvalue.Value = meta["coin"].Value<int?>() ?? 0;
                    string roomtype = "";
                    int input = meta["room"].Value<int?>() ?? 0;
                    switch (input)
                    {
                        case 0:
                            roomtype = "Medium";
                            break;
                        case 1:
                            roomtype = "Large";
                            break;
                        case 2:
                            roomtype = "Double Storey";
                            break;
                        case 3:
                            roomtype = "Factory";
                            break;
                        default:
                            roomtype = "Unknown"; // Default for values outside 0-3
                            break;
                    }
                    roomtypecombobox.Text = roomtype;
                    gravitycheckbox.Checked = meta["gravity"].Value<bool?>() ?? true;
                    hardcorecheckbox.Checked = meta["hardcore"].Value<bool?>() ?? false;
                    playtimevalue.Value = meta["playtime"].Value<decimal>();
                    tempvalue.DecimalPlaces = 2;
                    tempvalue.Value = meta["temperature"].Value<decimal>();
                    acvalue.Checked = meta["ac"].Value<bool?>() ?? false;
                    lightvalue.Checked = meta["light"].Value<bool?>() ?? true;
                    signaturevalue.Text = meta["sign"]?.ToString() ?? "";
                    xvalue.Value = scene["playerData"]["x"].Value<decimal>();
                    yvalue.Value = scene["playerData"]["y"].Value<decimal>();
                    zvalue.Value = scene["playerData"]["z"].Value<decimal>();
                    rxvalue.Value = scene["playerData"]["rx"].Value<decimal>();
                    ryvalue.Value = scene["playerData"]["ry"].Value<decimal>();
                    if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
                    {
                        foreach (var item in itemDataArray)
                        {
                            string spawnId = item["spawnId"]?.ToString();
                            string password = item["data"]["password"]?.ToString();

                            if (!string.IsNullOrEmpty(spawnId) &&
                                (spawnId.Contains("HDD") || spawnId.Contains("SSD")) &&
                                !string.IsNullOrEmpty(password))
                            {
                                passwdl.Add(password);
                                passwdlist.Items.Add(password);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            meta["version"] = cl_versiontextbox.Text;
            meta["roomName"] = savenametextbox.Text;
            meta["coin"] = (int)moneyvalue.Value;
            switch (roomtypecombobox.Text)
            {
                case "Medium":
                    meta["room"] = 0;
                    break;
                case "Large":
                    meta["room"] = 1;
                    break;
                case "Double Storey":
                    meta["room"] = 2;
                    break;
                case "Factory":
                    meta["room"] = 3;
                    break;
                default:
                    meta["room"] = 0;
                    break;
            }

            meta["gravity"] = gravitycheckbox.Checked;
            meta["hardcore"] = hardcorecheckbox.Checked;
            meta["playtime"] = playtimevalue.Value;
            meta["temperature"] = tempvalue.Value;
            meta["ac"] = acvalue.Checked;
            meta["light"] = lightvalue.Checked;
            meta["sign"] = signaturevalue.Text;
            scene["playerData"]["x"] = xvalue.Value;
            scene["playerData"]["y"] = yvalue.Value;
            scene["playerData"]["z"] = zvalue.Value;
            scene["playerData"]["rx"] = rxvalue.Value;
            scene["playerData"]["ry"] = ryvalue.Value;
        }

        private void exportpc_Click(object sender, EventArgs e)
        {
            string metaJson = meta.ToString(Formatting.None);
            string sceneJson = scene.ToString(Formatting.None);
            string combinedContents = $"{metaJson}\n{sceneJson}";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PCSim Save file (*.pc)|*.pc|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                string xorredContents = Xor(combinedContents, xorkey);
                File.WriteAllText(path, xorredContents);

                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            this.Close();
        }

        private void exportastxt_Click(object sender, EventArgs e)
        {
            string metaJson = meta.ToString(Formatting.None);
            string sceneJson = scene.ToString(Formatting.None);
            string combinedContents = $"{metaJson}\n{sceneJson}";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                File.WriteAllText(path, combinedContents);

                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            this.Close();
        }
        private void randomizebutton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomValue = random.Next(-2147483647, 2147483647);
            idvalue.Value = randomValue;
        }

        private void Insertbtn_Click(object sender, EventArgs e)
        {
            JObject add = new JObject
            {
                ["spawnId"] = spawnidvalue.SelectedItem.ToString(),
                ["id"] = (int)idvalue.Value,
                ["pos"] = new JObject
                {
                    ["x"] = xpvalue.Value,
                    ["y"] = ypvalue.Value,
                    ["z"] = zpvalue.Value
                },
                ["rot"] = new JObject
                {
                    ["x"] = xrvalue.Value,
                    ["y"] = yrvalue.Value,
                    ["z"] = zrvalue.Value,
                    ["w"] = wrvalue.Value
                },
                ["data"] = new JObject()
                {
                    ["damaged"] = damagedvalue.Checked,
                    ["glue"] = gluedvalue.Checked,
                },
            };
            ((JArray)scene["itemData"]).Add(add);
        }

        private void installosallpc_Click(object sender, EventArgs e)
        {
            if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
            {
                foreach (var item in itemDataArray)
                {
                    string spawnId = item["spawnId"]?.ToString();
                    bool setOS = true;
                    if (!string.IsNullOrEmpty(spawnId) &&
                        (spawnId.Contains("HDD") || spawnId.Contains("SSD")))
                    {
                        if (item["data"]?["files"] != null && item["data"]["files"] is JArray filesDataArray)
                        {
                            foreach (var file in filesDataArray)
                            {
                                if ((file["path"]?.ToString() == "System/boot.bin") && (file["content"]?.ToString() == "pcos"))
                                {
                                    setOS = false;
                                    break;
                                }
                            }
                        }

                        if (setOS)
                        {
                            JObject carray = new JObject
                            {
                                ["path"] = "System/boot.bin",
                                ["content"] = "pcos",
                                ["hidden"] = true,
                                ["size"] = 60000,
                                ["StorageSize"] = 60000,
                            };
                            if (item["data"] == null)
                            {
                                item["data"] = new JObject();
                            }
                            if (item["data"]["files"] == null)
                            {
                                item["data"]["files"] = new JArray();
                            }
                            ((JArray)item["data"]["files"]).Add(carray);
                            listadded.Items.Add(item["id"].Value<int>().ToString());
                        }
                    }
                }
            }
        }

        private void openfm_Click(object sender, EventArgs e)
        {
            filemanager fxn = new filemanager();
            fxn.Show();
            this.Hide();
            fxn.FormClosed += (s, args) => this.Show();
        }

        private void spawnidvalue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void tempvalue_ValueChanged(object sender, EventArgs e) { }
    }
}
