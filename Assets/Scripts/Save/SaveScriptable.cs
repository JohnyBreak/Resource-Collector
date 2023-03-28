using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "SaveScriptable", menuName = "Save/SaveScriptable")]
public class SaveScriptable : ScriptableObject
{
    [HideInInspector] public SaveData SaveData;

    private void OnEnable()
    {
        Load();
    }

    public void Load()
    {
        //Debug.LogError("load");
        SaveData = (SaveData)Load(Application.persistentDataPath + "/saves/Save.save");
    }

    public void Save()
    {
        Save(SaveData);
    }

    #region Work With File
    private bool Save(object data, string name = "Save")
    {
        BinaryFormatter formatter = new BinaryFormatter();

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
        string path = Application.persistentDataPath + "/saves/" + name + ".save";

        FileStream file = File.Create(path);

        formatter.Serialize(file, data);
        file.Close();
        return true;
    }

    private object Load(string path)
    {
        if (!File.Exists(path))
        {
            //Debug.LogError("Creating new save");
            Save(new SaveData(), "Save");
        }
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);
        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogError($"Failed to load file at {path}");
            file.Close();
            return null;
        }
    }

    // for test

    //public static bool Save(object data, string name = "Save")
    //{
    //    string path = Application.persistentDataPath + "/saves/" + name + ".save";
    //    string jsonString = JsonUtility.ToJson(data);

    //    File.WriteAllText(path, jsonString);
    //    return true;
    //}
    //public static object Load(string path)
    //{
    //    if (!File.Exists(path))
    //    {
    //        //Debug.LogError("Creating new save");
    //        Save(new SaveData(), "Save");
    //    }

    //    //string path = Application.persistentDataPath + "/saves/" + name + ".save";
    //    if (File.Exists(path))
    //    {
    //        // Read the entire file and save its contents.
    //        string fileContents = File.ReadAllText(path);

    //        // Deserialize the JSON data 
    //        //  into a pattern matching the GameData class.
    //        return JsonUtility.FromJson<SaveData>(fileContents);
    //    }

    //    return null;
    //}
    #endregion
}

[Serializable]
public class BinarySerializableData
{
    public Dictionary<string, object> properties;

    public BinarySerializableData(ScriptableObject obj)
    {
        properties = new Dictionary<string, object>();

        Type T = obj.GetType();
        foreach (FieldInfo field in T.GetFields())
        {
            properties[field.Name] = field.GetValue(obj);
        }
    }

}