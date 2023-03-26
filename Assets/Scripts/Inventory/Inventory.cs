using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SaveScriptable _save;
    [SerializeField] private InventoryConfig _inventory;

    private void Start()
    {
        _inventory.ResourceByType = _save.SaveData.ResourcesByType;

        _inventory.InitCanvas();
    }

    public void AddResource(BaseResource res, int amount = 1) 
    {
        _inventory.AddResource(res, amount);

        _save.SaveData.ResourcesByType = _inventory.ResourceByType;

        _save.Save();

        //ClearConsole();

        //foreach (var item in _inventory.ResourceByType)
        //{
        //    Debug.Log($"{item.Key} {item.Value}");
        //}
    }

    public void RemoveResource(BaseResource res, int amount = 1)
    {
        // todo
    }

    //private void ClearConsole()
    //{
    //    Assembly assembly = Assembly.GetAssembly(typeof(SceneView));

    //    Type type = assembly.GetType("UnityEditor.LogEntries");
    //    MethodInfo method = type.GetMethod("Clear");
    //    method.Invoke(new object(), null);
    //}

}
