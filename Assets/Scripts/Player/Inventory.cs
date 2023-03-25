using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Type, int> _resources;

    private void Awake()
    {
        _resources = new Dictionary<Type, int>();
    }

    public void AddResource(BaseResource res, int amount = 1) 
    {
        if (_resources.ContainsKey(res.GetType()) == false) _resources.Add(res.GetType(), 0);

        _resources[res.GetType()] += amount;
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
