using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SerializationManager
{
    public static bool Save(object data, string name = "Save") 
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if (!Directory.Exists(Application.persistentDataPath + "/saves")) 
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
        string path = Application.persistentDataPath + "/saves/" + name + ".save";

        string json = JsonUtility.ToJson(data);
       /* using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);
        writer.Close();*/
        
        FileStream file = File.Create(path);

        formatter.Serialize(file, data);
        file.Close();
        return true;
    }

    public static object Load(string path) 
    {
        if (!File.Exists(path)) Save(new SaveData(), "Save"); //return null;

        BinaryFormatter formatter = GetBinaryFormatter();

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

    public static BinaryFormatter GetBinaryFormatter() 
    {
        return new BinaryFormatter();
    }
}
