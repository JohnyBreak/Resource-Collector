using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory")]
public class InventoryConfig : ScriptableObject
{
    public Action<BaseResource, int> InventoryChangedEvent;
    public Action InitCanvasEvent;

    public ResourceListConfig ResourceList;
    public Dictionary<Type, int> ResourceByType;

    public void AddResource(BaseResource res, int amount = 1) 
    {
        if (ResourceByType.ContainsKey(res.Type.GetType()) == false)
        {

            ResourceByType.Add(res.Type.GetType(), 0);
        }

        ResourceByType[res.Type.GetType()] += amount;

        InventoryChangedEvent?.Invoke(res, ResourceByType[res.Type.GetType()]);
    }

    public void RemoveResource(BaseResource res, int amount = 1)
    {
        //todo
    }

    public void InitCanvas() 
    {
        InitCanvasEvent?.Invoke();
    }
}
