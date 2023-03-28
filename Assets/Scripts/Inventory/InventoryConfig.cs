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
    //public Dictionary<ResourceTypeConfig, int> Resources;

    public void AddResource(BaseResource res, int amount = 1) 
    {
        if (ResourceByType.ContainsKey(res.Config.GetType()) == false)
        {

            ResourceByType.Add(res.Config.GetType(), 0);
            //Resources.Add(res.Config, 0);
        }

        ResourceByType[res.Config.GetType()] += amount;
        //Resources[res.Config] += amount;

        InventoryChangedEvent?.Invoke(res, ResourceByType[res.Config.GetType()]);
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
