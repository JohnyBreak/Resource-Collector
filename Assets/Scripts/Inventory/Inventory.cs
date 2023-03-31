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
        _inventory.ResourceByIndex = _save.SaveData.ResourcesByType;
        //_inventory.Resources = _save.SaveData.Resources;

        //foreach (var item in _inventory.Resources)
        //{
        //    Debug.Log($"{item.Key} {item.Value}");
        //}
        _inventory.InitCanvas();
    }

    public void AddResource(BaseResource res, int amount = 1) 
    {
        _inventory.AddResource(res, amount);

        _save.SaveData.ResourcesByType = _inventory.ResourceByIndex;

        //_save.SaveData.Resources = _inventory.Resources;

        _save.Save();

        //ClearConsole();

        //foreach (var item in _inventory.ResourceByType)
        //{
        //    Debug.Log($"{item.Key} {item.Value}");
        //}
    }

    public bool CheckResourceAvailability(BaseResource res)
    {
        return _inventory.CheckResourceAvailability(res);
    }

    public List<BaseResource> GetAllResourcesByType(BaseResource res, int count = 0)
    {
        if (count == 0) return GetAllResourcesByType(res);
        else return GetResourceByCount(res, count);
    }

    private List<BaseResource> GetAllResourcesByType(BaseResource res)
    {
        List<BaseResource> tempList = _inventory.GetAllResourcesByType(res);
        _save.SaveData.ResourcesByType = _inventory.ResourceByIndex;
        _save.Save();
        return tempList;
    }

    private List<BaseResource> GetResourceByCount(BaseResource res, int count)
    {
        List<BaseResource> tempList = _inventory.GetResourceByCount(res, count);

        _save.SaveData.ResourcesByType = _inventory.ResourceByIndex;
        _save.Save();
        return tempList;
    }


    //private void ClearConsole()
    //{
    //    Assembly assembly = Assembly.GetAssembly(typeof(SceneView));

    //    Type type = assembly.GetType("UnityEditor.LogEntries");
    //    MethodInfo method = type.GetMethod("Clear");
    //    method.Invoke(new object(), null);
    //}

}
