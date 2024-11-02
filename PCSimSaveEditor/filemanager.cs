using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PCSimSaveEditor
{
    public partial class filemanager : Form
    {
        private bool showUSB = false;
        private JObject scene = new JObject();
        public static int selectedId = -2147483647;

        public filemanager()
        {
            InitializeComponent();
        }

        public void filemanager_Load(object sender, EventArgs e)
        {
            scene = easy.scene;
            medialist.Items.Clear();
            populatemedialist();
            UpdateEditButtonState();
        }

        private void populatemedialist()
        {
            if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray)
            {
                foreach (var item in itemDataArray)
                {
                    string spawnId = item["spawnId"]?.ToString();
                    bool addToMediaList = false;

                    if (!string.IsNullOrEmpty(spawnId) && (spawnId.Contains("HDD") || spawnId.Contains("SSD")))
                    {
                        addToMediaList = true;
                    }
                    if (checkshowusbdrives.Checked && !string.IsNullOrEmpty(spawnId) && spawnId.Contains("FlashDrive"))
                    {
                        addToMediaList = true;
                    }
                    if (addToMediaList)
                    {
                        medialist.Items.Add(item["id"]?.ToString());
                    }
                }
            }
            UpdateEditButtonState();
        }

        private void checkshowusbdrives_CheckedChanged(object sender, EventArgs e)
        {
            showUSB = checkshowusbdrives.Checked;
            medialist.Items.Clear();
            populatemedialist();
        }

        private void medialist_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEditButtonState();
        }

        private void UpdateEditButtonState()
        {
            editbutton.Enabled = medialist.SelectedItem != null;
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            if (medialist.SelectedItem != null)
            {
                selectedId = Convert.ToInt32(medialist.SelectedItem.ToString());
            }
            fmmenu x = new fmmenu();
            x.FormClosed += (s, args) => this.Show();
            x.Show();
            this.Hide();
        }
    }

}
