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
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PCSimSaveEditor
{
    public partial class easy : Form {
        private Size manuf_Unloaded = new Size(605, 102);
        private Size manuf_Loaded;
        private static int xorkey = 129;
        private string contents = "";
        private Random rndm = new Random();
        public static JObject meta = new JObject();
        public static JObject scene = new JObject();
        private List<string> passwdl = new List<string>();
        private Point message_h = new Point(12, 502);
        private Point message_s = new Point(618, 9);
        private int destruction_level = 10;
        private string latestPCSim = "1.8.0";
        public easy() {
            InitializeComponent();
        }

        private int generateId() {
            int id = rndm.Next(-2147483647, 2147483647);
            return id;
        }
        private JObject createItem(string spawnId, double x, double y, double z, double rx, double ry, double rz, double rw) {
            int id = generateId();
            JObject item = new JObject();
            item["spawnId"] = spawnId;
            item["id"] = id;
            JObject pos = new JObject();
            pos["x"] = x;
            pos["y"] = y;
            pos["z"] = z;
            JObject rot = new JObject();
            rot["x"] = rx;
            rot["y"] = ry;
            rot["z"] = rz;
            rot["w"] = rw;
            JObject data = new JObject();
            data["damaged"] = false;
            data["glue"] = false;
            item["pos"] = pos;
            item["rot"] = rot;
            item["data"] = data;
            JArray itemData = (JArray)scene["itemData"];
            return item;
        }
        private int createOPMiner(float x, float y, float z) {
            JArray itemData = (JArray)scene["itemData"];
            JObject temp_miner = createItem("Miner", x, y, z, 0, 0.707, 0, 0.707);
            itemData.Add(temp_miner);
            JObject itx = createItem("Mini_ITX", x + 1.4, y - 1.084, z + 0.291, 0, -0.707, 0, 0.707);
            // itemData.Add(itx); // comment out if monitorId
            JObject temp_cpu = createItem("CPU i9-12900K", x + 1.661, y - 1.011374, z + 0.301, 0, 0, 0, 0);
            itemData.Add(temp_cpu);
            JObject temp_cooler = createItem("Cooler(RGB)", x + 1.638897, y - 0.450748, z + 0.298, 0, 0, 0, 0);
            itemData.Add(temp_cooler);
            JObject temp_RAM1 = createItem("RAM 32GB(RGB)", x + 1.509, y - 0.843, z - 0.559, 0.707, 0, 0, 0.707);
            itemData.Add(temp_RAM1);
            JObject temp_RAM0 = createItem("RAM 32GB(RGB)", x + 1.509, y - 0.843, z - 0.456, 0.707, 0, 0, 0.707);
            itemData.Add(temp_RAM0);
            JObject storagemedium = createItem("SSD 128GB", x - 1.747, y - 0.961, z - 0.916, 0, 0.707, 0, 0.707);
            JObject temp_PSU1 = createItem("PSU 2kW", x - 1.703, y - 0.69996, z + 0.7, 0, 0, 0, 0);
            itemData.Add(temp_PSU1);
            JObject temp_PSU0 = createItem("PSU 2kW", x - 0.341, y - 0.69996, z + 0.7, 0, 0, 0, 0);
            itemData.Add(temp_PSU0);
            JObject temp_GPU0 = createItem("RTX3080Ti", x + 2.147, y + 0.36, z + 0.006, 0.5, 0.5, 0.5, 0.5);
            itemData.Add(temp_GPU0);
            JObject temp_GPU1 = createItem("RTX3080Ti", x + 1.523, y + 0.36, z + 0.006, 0.5, 0.5, 0.5, 0.5);
            itemData.Add(temp_GPU1);
            JObject temp_GPU2 = createItem("RTX3080Ti", x + 0.904, y + 0.36, z + 0.006, 0.5, 0.5, 0.5, 0.5);
            itemData.Add(temp_GPU2);
            JObject temp_GPU3 = createItem("RTX3080Ti", x + 0.284, y + 0.36, z + 0.006, 0.5, 0.5, 0.5, 0.5);
            itemData.Add(temp_GPU3);
            JObject temp_GPU4 = createItem("RTX3080Ti", x - 0.334, y + 0.36, z + 0.006, 0.5, 0.5, 0.5, 0.5);
            itemData.Add(temp_GPU4);
            JObject temp_GPU5 = createItem("RTX3080Ti", x - 0.957, y + 0.36, z + 0.006, 0.5, 0.5, 0.5, 0.5);
            itemData.Add(temp_GPU5);
            JObject temp_GPU6 = createItem("RTX3080Ti", x - 1.577, y + 0.36, z + 0.006, 0.5, 0.5, 0.5, 0.5);
            itemData.Add(temp_GPU6);
            JObject temp_GPU7 = createItem("RTX3080Ti", x - 2.2, y + 0.36, z + 0.006, 0.5, 0.5, 0.5, 0.5);
            itemData.Add(temp_GPU7);
            storagemedium["data"]["storageName"] = "Miner";
            storagemedium["data"]["password"] = "";
            JArray files = new JArray();
            JObject OSFile = new JObject();
            OSFile["path"] = "System/boot.bin";
            OSFile["content"] = "pcos";
            OSFile["hidden"] = true;
            OSFile["size"] = 60000;
            OSFile["StorageSize"] = 60000;
            files.Add(OSFile);
            JObject EZMining = new JObject();
            EZMining["path"] = "EZ Mining.exe";
            EZMining["content"] = "";
            EZMining["hidden"] = false;
            EZMining["size"] = 673;
            EZMining["StorageSize"] = 673;
            files.Add(EZMining);
            JObject watermark = new JObject();
            watermark["path"] = "README.txt";
            watermark["content"] = "<b>This Miner was made with zegs32's save editor.</b>\n<size=30><color=lime>Read more at https://github.com/ImNotDario/PCSimSaveEditor/tree/release-009</color></size>";
            watermark["hidden"] = false;
            watermark["size"] = 129;
            watermark["StorageSize"] = 129;
            files.Add(watermark);
            JObject notepad = new JObject();
            notepad["path"] = "Text Editor.exe";
            notepad["content"] = "";
            notepad["hidden"] = false;
            notepad["size"] = 264;
            notepad["StorageSize"] = 264;
            files.Add(notepad);
            JObject appinst = new JObject();
            appinst["path"] = "App Downloader.exe";
            appinst["content"] = "";
            appinst["hidden"] = false;
            appinst["size"] = 432;
            appinst["StorageSize"] = 432;
            files.Add(appinst);
            storagemedium["data"]["files"] = files;
            storagemedium["data"]["uptime"] = 0.0;
            storagemedium["data"]["health"] = 100;
            storagemedium["data"]["damaged"] = false;
            itemData.Add(storagemedium);
            itx["data"]["monitorId"] = (int)monitorId.Value;
            itemData.Add(itx);
            return (int)storagemedium["id"];
        }

        private string Xor(string s, int key) {
            char[] result = new char[s.Length];
            for (int i = 0; i < s.Length; i++) {
                result[i] = (char)(s[i] ^ key); // XOR each character with the key
            }
            return new string(result); // Convert the char array back to a string
        }
        private void easy_Load(object sender, EventArgs e) {
            manuf_Loaded = this.Size;
            this.Size = manuf_Unloaded;
        }
        private void Open_Click(object sender, EventArgs e) {
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

            if (jx.ShowDialog() == DialogResult.OK) {
                string path = jx.FileName;

                try {
                    byte[] fileBytes = File.ReadAllBytes(path);
                    string fileContents = Encoding.UTF8.GetString(fileBytes);
                    string xorredContents = Xor(fileContents, xorkey);
                    contents = xorredContents;
                    this.Size = manuf_Loaded;
                    var lines = xorredContents.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lines.Length > 0) {
                        meta = JObject.Parse(lines[0]);
                    }
                    if (lines.Length > 1) {
                        scene = JObject.Parse(string.Join("\n", lines.Skip(1)));
                    }
                    cl_versiontextbox.Text = meta["version"]?.ToString() ?? "?";
                    if (cl_versiontextbox.Text.StartsWith("1.7")) {
                        noticelabel.Location = message_s;
                    } else {
                        noticelabel.Location = message_h;
                    }
                    savenametextbox.Text = meta["roomName"]?.ToString() ?? "Unknown";
                    moneyvalue.Value = meta["coin"].Value<int?>() ?? 0;
                    string roomtype = "";
                    int input = meta["room"].Value<int?>() ?? 0;
                    switch (input) {
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
                    if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray) {
                        foreach (var item in itemDataArray) {
                            string spawnId = item["spawnId"]?.ToString();
                            string password = item["data"]["password"]?.ToString();

                            if (!string.IsNullOrEmpty(spawnId) &&
                                (spawnId.Contains("HDD") || spawnId.Contains("SSD")) &&
                                !string.IsNullOrEmpty(password)) {
                                passwdl.Add(password);
                                passwdlist.Items.Add(password);
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void savebutton_Click(object sender, EventArgs e) {
            meta["version"] = cl_versiontextbox.Text;
            meta["roomName"] = savenametextbox.Text;
            meta["coin"] = (int)moneyvalue.Value;
            switch (roomtypecombobox.Text) {
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

        private void exportpc_Click(object sender, EventArgs e) {
            string metaJson = meta.ToString(Formatting.None);
            string sceneJson = scene.ToString(Formatting.None);
            string combinedContents = $"{metaJson}\n{sceneJson}";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PCSim Save file (*.pc)|*.pc|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string path = saveFileDialog.FileName;
                string xorredContents = Xor(combinedContents, xorkey);
                File.WriteAllText(path, xorredContents);

                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            this.Close();
        }

        private void exportastxt_Click(object sender, EventArgs e) {
            string metaJson = meta.ToString(Formatting.None);
            string sceneJson = scene.ToString(Formatting.None);
            string combinedContents = $"{metaJson}\n{sceneJson}";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string path = saveFileDialog.FileName;
                File.WriteAllText(path, combinedContents);

                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            this.Close();
        }
        private void randomizebutton_Click(object sender, EventArgs e) {
            int randomValue = rndm.Next(-2147483647, 2147483647);
            idvalue.Value = randomValue;
        }

        private void Insertbtn_Click(object sender, EventArgs e) {
            JObject add = new JObject {
                ["spawnId"] = spawnidvalue.Text.ToString(),
                ["id"] = (int)idvalue.Value,
                ["pos"] = new JObject {
                    ["x"] = xpvalue.Value,
                    ["y"] = ypvalue.Value,
                    ["z"] = zpvalue.Value
                },
                ["rot"] = new JObject {
                    ["x"] = xrvalue.Value,
                    ["y"] = yrvalue.Value,
                    ["z"] = zrvalue.Value,
                    ["w"] = wrvalue.Value
                },
                ["data"] = new JObject() {
                    ["damaged"] = damagedvalue.Checked,
                    ["glue"] = gluedvalue.Checked,
                },
            };
            ((JArray)scene["itemData"]).Add(add);
        }

        private void installosallpc_Click(object sender, EventArgs e) {
            if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray) {
                foreach (var item in itemDataArray) {
                    string spawnId = item["spawnId"]?.ToString();
                    bool setOS = true;
                    if (!string.IsNullOrEmpty(spawnId) &&
                        (spawnId.Contains("HDD") || spawnId.Contains("SSD"))) {
                        if (item["data"]?["files"] != null && item["data"]["files"] is JArray filesDataArray) {
                            foreach (var file in filesDataArray) {
                                if ((file["path"]?.ToString() == "System/boot.bin") && (file["content"]?.ToString() == "pcos")) {
                                    setOS = false;
                                    break;
                                }
                            }
                        }

                        if (setOS) {
                            JObject carray = new JObject {
                                ["path"] = "System/boot.bin",
                                ["content"] = "pcos",
                                ["hidden"] = true,
                                ["size"] = 60000,
                                ["StorageSize"] = 60000,
                            };
                            if (item["data"] == null) {
                                item["data"] = new JObject();
                            }
                            if (item["data"]["files"] == null) {
                                item["data"]["files"] = new JArray();
                            }
                            ((JArray)item["data"]["files"]).Add(carray);
                            listadded.Items.Add(item["id"].Value<int>().ToString());
                        }
                    }
                }
            }
        }

        private void openfm_Click(object sender, EventArgs e) {
            filemanager fxn = new filemanager();
            fxn.Show();
            this.Hide();
            fxn.FormClosed += (s, args) => this.Show();
        }

        private void spawnidvalue_SelectedIndexChanged(object sender, EventArgs e) { }
        private void tempvalue_ValueChanged(object sender, EventArgs e) { }
        private string GetTimestamp() {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        }
        private void DestroyBtn_Click(object sender, EventArgs e) {
            Random rnd = new Random(Convert.ToInt32(GetTimestamp()));
            JArray itdata = (JArray?)scene["itemData"] ?? new JArray();
            int lenitdata = itdata.Count;
            List<int> todelete = new List<int>();
            int totalToDestroy = (int)(lenitdata * (destruction_level / 100.0));
            while (todelete.Count < totalToDestroy && todelete.Count < lenitdata) {
                int index = rnd.Next(0, lenitdata);
                if (!todelete.Contains(index)) {
                    todelete.Add(index);
                }
            }
            foreach (var index in todelete.OrderByDescending(i => i)) {
                itdata.RemoveAt(index);
            }
            scene["itemData"] = itdata;
        }
        private void dslevel_Scroll(object sender, EventArgs e) {
            destruction_level = (dslevel.Value) * 10;
            dselevel.Text = "Destruction level: " + (dslevel.Value).ToString() + "/10";
            DestroyBtn.Text = "Destroy " + destruction_level.ToString() + "%";
        }

        private void scripting_Click(object sender, EventArgs e) {
            scripting a = new scripting();
            a.FormClosed += (s, args) => this.Show();
            a.Show();
            this.Hide();
        }

        private void spawnopminer_Click(object sender, EventArgs e) {
            int id = createOPMiner((float)xpvalue.Value, (float)ypvalue.Value, (float)zpvalue.Value);
            remId.Text = id.ToString("X8");
        }

        private void Newsave_Click(object sender, EventArgs e) {
            meta = new JObject();
            meta["version"] = latestPCSim;
            meta["roomName"] = "New save";
            meta["coin"] = 2000;
            meta["room"] = 0;
            meta["gravity"] = true;
            meta["hardcore"] = false;
            meta["playtime"] = 0.0;
            meta["temperature"] = 20.0;
            meta["ac"] = false;
            meta["light"] = true;
            meta["sign"] = "";
            scene = new JObject();
            scene["playerData"] = new JObject();
            scene["playerData"]["x"] = 0.0;
            scene["playerData"]["y"] = 0.0;
            scene["playerData"]["z"] = 0.0;
            scene["playerData"]["rx"] = 0.0;
            scene["playerData"]["ry"] = 0.0;
            scene["itemData"] = new JArray();
            scene["scene"] = new JObject();
            string metaJson = meta.ToString(Formatting.None);
            string sceneJson = scene.ToString(Formatting.None);
            contents = $"{metaJson}\n{sceneJson}";
            string xorredContents = contents;
            var lines = xorredContents.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 0) {
                meta = JObject.Parse(lines[0]);
            }
            if (lines.Length > 1) {
                scene = JObject.Parse(string.Join("\n", lines.Skip(1)));
            }
            cl_versiontextbox.Text = meta["version"]?.ToString() ?? "?";
            if (cl_versiontextbox.Text.StartsWith("1.7")) {
                noticelabel.Location = message_s;
            } else {
                noticelabel.Location = message_h;
            }
            savenametextbox.Text = meta["roomName"]?.ToString() ?? "Unknown";
            moneyvalue.Value = meta["coin"].Value<int?>() ?? 0;
            string roomtype = "";
            int input = meta["room"].Value<int?>() ?? 0;
            switch (input) {
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
            this.Size = manuf_Loaded;
            tempvalue.Value = meta["temperature"].Value<decimal>();
            acvalue.Checked = meta["ac"].Value<bool?>() ?? false;
            lightvalue.Checked = meta["light"].Value<bool?>() ?? true;
            signaturevalue.Text = meta["sign"]?.ToString() ?? "";
            xvalue.Value = scene["playerData"]["x"].Value<decimal>();
            yvalue.Value = scene["playerData"]["y"].Value<decimal>();
            zvalue.Value = scene["playerData"]["z"].Value<decimal>();
            rxvalue.Value = scene["playerData"]["rx"].Value<decimal>();
            ryvalue.Value = scene["playerData"]["ry"].Value<decimal>();
            if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray) {
                foreach (var item in itemDataArray) {
                    string spawnId = item["spawnId"]?.ToString();
                    string password = item["data"]["password"]?.ToString();

                    if (!string.IsNullOrEmpty(spawnId) &&
                        (spawnId.Contains("HDD") || spawnId.Contains("SSD")) &&
                        !string.IsNullOrEmpty(password)) {
                        passwdl.Add(password);
                        passwdlist.Items.Add(password);
                    }
                }
            }
        }
    }
}
