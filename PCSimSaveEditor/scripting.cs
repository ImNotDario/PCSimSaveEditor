using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lua;
using Lua.Standard;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.AxHost;

namespace PCSimSaveEditor {
    public partial class scripting : Form {
        private LuaState luaexec = LuaState.Create();
        private JObject scene = new JObject();
        public scripting() {
            InitializeComponent();
            luaexec.OpenStandardLibraries();
            luaexec.Environment["wait"] = new LuaFunction(async (context, buffer, ct) => {
                var sec = context.GetArgument<double>(0);
                await Task.Delay(TimeSpan.FromSeconds(sec));
                return 0;
            });
            luaexec.Environment["additem"] = new LuaFunction((context, buffer, ct) => // additem(spawnId, id, x, y, z, rx, ry, rz, rw, damaged, glue)
            {
                string spawnid = context.GetArgument<string>(0);
                int id = Convert.ToInt32(context.GetArgument<double>(1));
                float x = context.GetArgument <float>(2);
                float y = context.GetArgument<float>(3);
                float z = context.GetArgument<float>(4);
                float rx = context.GetArgument<float>(5);
                float ry = context.GetArgument<float>(6);
                float rz = context.GetArgument<float>(7);
                float rw = context.GetArgument<float>(8);
                bool damaged = context.GetArgument<bool>(9);
                bool glue = context.GetArgument<bool>(10);
                JArray itdata = (JArray)(scene["itemData"] ?? new JArray());
                JObject newItem = new JObject();
                newItem["spawnId"] = spawnid;
                newItem["id"] = id;
                JObject newItemPos = new JObject();
                newItemPos["x"] = x;
                newItemPos["y"] = y;
                newItemPos["z"] = z;
                JObject newItemRot = new JObject();
                newItemRot["x"] = rx;
                newItemRot["y"] = ry;
                newItemRot["z"] = rz;
                newItemRot["w"] = rw;
                JObject newItemData = new JObject();
                newItemData["damaged"] = damaged;
                newItemData["glue"] = glue;
                newItem["pos"] = newItemPos;
                newItem["rot"] = newItemRot;
                newItem["data"] = newItemData;
                itdata.Add(newItem);
                scene["itemData"] = itdata;
                return new ValueTask<int>(0);
            });
            luaexec.Environment["setproperty"] = new LuaFunction((context, buffer, ct) => {
                int id = Convert.ToInt32(context.GetArgument<float>(0));
                string property = context.GetArgument<string>(1);
                LuaValue propvalue = context.GetArgument(2);
                JArray itemData = (JArray)scene["itemData"];
                foreach (var i in itemData) {
                    if ((int)(i["id"]) == id) {
                        // Handle different types of propvalue based on its type
                        if (propvalue.Type == LuaValueType.String) {
                            // Convert propvalue to string and assign it to the property
                            i["data"][property] = new JValue(propvalue.Read<string>());
                        } else if (propvalue.Type == LuaValueType.Number) {
                            // Convert propvalue to a number (double in C#) and assign it
                            i["data"][property] = new JValue(Convert.ToInt32(propvalue.Read<float>()));
                        } else if (propvalue.Type == LuaValueType.Boolean) {
                            // Convert propvalue to boolean and assign it
                            i["data"][property] = new JValue(propvalue.Read<bool>());
                        } else if (propvalue.Type == LuaValueType.Nil) {
                            // Assign null if LuaValue is Nil
                            i["data"][property] = null;
                        }
                    }
                }
                return new ValueTask<int>(0);
            });
            luaexec.Environment["removeitem"] = new LuaFunction((context, buffer, ct) => {
                int id = Convert.ToInt32(context.GetArgument<double>(0));
                JArray itdata = (JArray)(scene["itemData"] ?? new JArray());
                List<int> toremove = new List<int>();
                for (var i = 0; i < itdata.Count; i++) {
                    JObject item = (JObject)itdata[i];
                    int idr = (int?)item["id"] ?? -0;
                    if (idr == Convert.ToInt32(id)) {
                        toremove.Add(i);
                    }
                }
                for (int i = toremove.Count - 1; i >= 0; i--) {
                    itdata.RemoveAt(toremove[i]);
                }
                scene["itemData"] = itdata;
                return new ValueTask<int>(0);
            });
            luaexec.Environment["installosall"] = new LuaFunction((context, buffer, ct) => {
                JArray itemdata = (JArray)scene["itemData"];
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
                            }
                        }
                    }
                }
                return new ValueTask<int>(0);
            });
            luaexec.Environment["installappall"] = new LuaFunction((context, buffer, ct) => {
                string appname = context.GetArgument<string>(0);
                JArray itemdata = (JArray)scene["itemData"];
                if (scene["itemData"] != null && scene["itemData"] is JArray itemDataArray) {
                    foreach (var item in itemDataArray) {
                        string spawnId = item["spawnId"]?.ToString();
                        bool setOS = true;
                        if (!string.IsNullOrEmpty(spawnId) &&
                            (spawnId.Contains("HDD") || spawnId.Contains("SSD"))) {
                            if (item["data"]?["files"] != null && item["data"]["files"] is JArray filesDataArray) {
                                foreach (var file in filesDataArray) {
                                    if (file["path"]?.ToString() == appname + ".exe") {
                                        setOS = false;
                                        break;
                                    }
                                }
                            }

                            if (setOS) {
                                JObject carray = new JObject {
                                    ["path"] = appname + ".exe",
                                    ["content"] = "",
                                    ["hidden"] = false,
                                    ["size"] = 100,
                                    ["StorageSize"] = 100,
                                };
                                if (item["data"] == null) {
                                    item["data"] = new JObject();
                                }
                                if (item["data"]["files"] == null) {
                                    item["data"]["files"] = new JArray();
                                }
                                ((JArray)item["data"]["files"]).Add(carray);
                            }
                        }
                    }
                }
                return new ValueTask<int>(0);
            });
            luaexec.Environment["print"] = new LuaFunction((context, buffer, ct) => {
                string vxl = context.GetArgument<string>(0);
                outputlist.Items.Add(vxl);
                return new ValueTask<int>(0);
            });
            luaexec.Environment["getitems"] = new LuaTable();
        }
        // Convert Dictionary<string, object> to JObject
        public static JObject ConvertDictionaryToJObject(Dictionary<string, object> dict) {
            var jObject = new JObject();
            foreach (var kvp in dict) {
                if (kvp.Value is Dictionary<string, object> nestedDict) {
                    // If the value is a nested dictionary, recursively convert it to JObject
                    jObject[kvp.Key] = ConvertDictionaryToJObject(nestedDict);
                } else {
                    // Handle primitive types (string, int, bool) and add them directly to the JObject
                    jObject[kvp.Key] = JToken.FromObject(kvp.Value);
                }
            }
            return jObject;
        }
        private Dictionary<string, object> ConvertJObjectToDictionary(JObject jObject) {
            var dict = new Dictionary<string, object>();
            foreach (var property in jObject) {
                if (property.Value is JObject) {
                    // Recursively convert JObject to Dictionary
                    dict[property.Key] = ConvertJObjectToDictionary((JObject)property.Value);
                } else if (property.Value is JArray) {
                    // Convert JArray to a list of objects
                    var list = new List<object>();
                    foreach (var item in (JArray)property.Value) {
                        list.Add(item);
                    }
                    dict[property.Key] = list;
                } else {
                    // For simple types, just assign them directly
                    dict[property.Key] = property.Value.ToString();
                }
            }
            return dict;
        }
        // Convert Dictionary<string, object> to LuaTable
        public static LuaTable ConvertDictionaryToLuaTable(Dictionary<string, object> dict) {
            var luaTable = new LuaTable();
            foreach (var kvp in dict) {
                if (kvp.Value is Dictionary<string, object>) {
                    // Recursively convert nested dictionaries
                    luaTable[kvp.Key] = ConvertDictionaryToLuaTable((Dictionary<string, object>)kvp.Value);
                } else {
                    // Explicitly cast primitive types (string, int, bool) to LuaValue
                    if (kvp.Value is string) {
                        luaTable[kvp.Key] = (string)kvp.Value; // Cast string to LuaString
                    } else if (kvp.Value is int) {
                        luaTable[kvp.Key] = (float)kvp.Value; // Cast int to LuaInteger
                    } else if (kvp.Value is bool) {
                        luaTable[kvp.Key] = (bool)kvp.Value; // Cast bool to LuaBoolean
                    }
                }
            }
            return luaTable;
        }

        private void scripting_Load(object sender, EventArgs e) {
            scene = easy.scene;
        }
        private async void execute_Click(object sender, EventArgs e) {
            luaexec.Environment["prov"] = parameter.Text;
            outputlist.Items.Clear();
            LuaTable litemtable = new LuaTable();
            JArray itdata = (JArray)scene["itemData"];
            for (int i = 1; i < itdata.Count; i++) {
                litemtable[i] = ConvertDictionaryToLuaTable(ConvertJObjectToDictionary((JObject)itdata[i]));
            }
            luaexec.Environment["getitems"] = litemtable;
            try {
                string amx = new string("");
                foreach (string str in scriptbox.Lines) {
                    amx = amx + str + "\n";
                }
                var results = await luaexec.DoStringAsync(amx);
                MessageBox.Show("Successfully ran script!", "Finished");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Script error!!!");
            }
        }
    }
    
}
