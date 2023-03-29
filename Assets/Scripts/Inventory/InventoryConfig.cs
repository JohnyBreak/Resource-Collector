using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory/Inventory")]
public class InventoryConfig : ScriptableObject
{
    public Action<BaseResource, int> InventoryChangedEvent;
    public Action InitCanvasEvent;

    [SerializeField] private ResourceSpawner _spawner;
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

    public List<BaseResource> GetAllResourcesByType(BaseResource res)
    {
        List<BaseResource> tempList = new List<BaseResource>();
        int amount = ResourceByType[res.Config.GetType()];

        for (int i = 0; i < amount; i++)
        {
            var item = _spawner.Pool.GetPooledObject(res, true);

            tempList.Add(item);
        }
        
        ResourceByType[res.Config.GetType()] = 0;
        InventoryChangedEvent?.Invoke(res, ResourceByType[res.Config.GetType()]);

        return tempList;
    }

    public bool CheckResourceAvailability(BaseResource res) 
    {
        return ResourceByType[res.Config.GetType()] > 0;
    }


    public void InitCanvas() 
    {
        InitCanvasEvent?.Invoke();
    }
}
