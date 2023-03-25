using UnityEditor;
using UnityEngine;

public class SaveMenu_Editor : MonoBehaviour
{
    private static string _savePath = Application.persistentDataPath + "/saves/Save.save";
    private static string _saveFolderPath = Application.persistentDataPath + "/saves/";

    [MenuItem("Save Menu/DeleteSave")]
    public static void DeleteSave() 
    {
        if (System.IO.File.Exists(_savePath) == false) return;

        System.IO.File.Delete(_savePath);

    }

    [MenuItem("Save Menu/OpenSaveFolder")]
    public static void OpenSaveFolder()
    {
        Application.OpenURL(_saveFolderPath);
    }
}
