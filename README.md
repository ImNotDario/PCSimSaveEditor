# PC Simulator Save Editor

A user-friendly tool for editing PC simulator save files, built on a fork of N2O4's original save editor. This application allows users to easily manage and modify save data, providing both basic and advanced features for an enhanced gaming experience.

## Features

- **User-Friendly Interface**: Simplified navigation and controls for editing save files.
- **Save File Management**: Open, edit, and save `.pc` files with ease.
- **XOR Encryption/Decryption**: Handles save files with built-in XOR encryption for security.
- **Dynamic Data Manipulation**: Edit various parameters such as room type, player data, and environmental settings.
- **Password Extraction**: Retrieve and manage passwords associated with saved items.
- **OS Installation Automation**: Automatically installs the operating system on all applicable items within the save.
- **Random ID Generation**: Quickly generate random IDs for new items.
- **File Export Options**: Save edited data in various formats, including the original save file format and plain text.

### How does it work?

.pc files are encrypted using **XOR**. The key is **Int 129 or Hex 0x81**
The output is a json file. Or is it?
Its actually **2** json objects.
The first one (the first line) is **metadata** json.
Example:
```json
{"version":"1.8.0","roomName":"PC SHOP by k6ur6shh2 V8","coin":42601,"room":2,"gravity":true,"hardcore":false,"playtime":40990.0625,"temperature":6.515275955200195,"ac":true,"light":true,"sign":""}
```
The second one (the second line on) is **scene data** json.
Example:
```json
{"playerData": {"x": 0, "y": 0, "z": 0, "rx": 0, "ry": 0}, "itemData": [...], "scene": {}}
```
**Scene is always set to an empty object!**
playerData contains player position and camera rotation.
itemData is an array containing items.
The items are JSON Objects 
Example:
```json
{"spawnId": "Pillow", "id": 2958187, "pos": {"x": 0, "y": 0, "z": 0}, "rot": {"x": 0, "y": 0, "z": 0, "w": 0}, "data": {"damaged": false, "glue": false}}
```
spawnId is the item name. https://pcsimdecrypt.rf.gd/secret.htm has a short list of items that are unobtainable. the save editor has a dropdown box that contains all spawnIds.  
id is any signed integer (-2147483647 to 2147483647).  
pos is Vector3 position.  
rot is Quaterion rotation (i dont understand quaterions).  
data is an JSON Object.  
Currently default data is `{"damaged": false, "glue": false}`.  
Nobody understands what glue is for.  

## Installation
Check releases tab or compile it using VS 2022 with .NET5.0 and WinForms.
