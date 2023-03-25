using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [HideInInspector] public SaveData SaveData;

    private void Awake()
    {
        Load();
    }

    public void Load() 
    {
        SaveData = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");
        if (SaveData == null) SaveData = new SaveData();
    }

    public void Save() 
    {
        SerializationManager.Save(SaveData);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        Save();
    //    }

    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        Load();
    //    }

    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        Debug.LogError(SaveData.MoneyAmount);
    //    }
    //}
}
