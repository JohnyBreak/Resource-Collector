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

    public Dictionary<int, int> ResourceByIndex;
    //public Dictionary<ResourceTypeConfig, int> Resources;

    public void AddResource(BaseResource res, int amount = 1) 
    {
        if (ResourceByIndex.ContainsKey(GetResourceIndex(res)) == false)
        {

            ResourceByIndex.Add(GetResourceIndex(res), 0);
            //Resources.Add(res.Config, 0);
        }

        ResourceByIndex[GetResourceIndex(res)] += amount;
        //Resources[res.Config] += amount;

        InventoryChangedEvent?.Invoke(res, ResourceByIndex[GetResourceIndex(res)]);
    }

    private void RemoveResource(BaseResource res, int amount = 1)
    {
        ResourceByIndex[GetResourceIndex(res)] -= amount;
        Debug.Log(ResourceByIndex[GetResourceIndex(res)]);
        InventoryChangedEvent?.Invoke(res, ResourceByIndex[GetResourceIndex(res)]);
    }

    public List<BaseResource> GetAllResourcesByType(BaseResource res)
    {
        List<BaseResource> tempList = new List<BaseResource>();
        int amount = ResourceByIndex[GetResourceIndex(res)];

        for (int i = 0; i < amount; i++)
        {
            var item = _spawner.Pool.GetPooledObject(res, true);

            tempList.Add(item);
        }

        RemoveResource(res, amount);

        return tempList;
    }

    public bool CheckResourceAvailability(BaseResource res) 
    {
        return ResourceByIndex[GetResourceIndex(res)] > 0;
    }

    private int GetResourceIndex(BaseResource res) 
    {
        foreach (var resource in ResourceList.Resources)
        {
            if (resource == res.Config) 
            {
                return ResourceList.Resources.IndexOf(resource);
            }
        }

        return 0;
    }

    public void InitCanvas() 
    {
        InitCanvasEvent?.Invoke();
    }
}
