using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public Dictionary<Type, int> ResourcesByType;

    //public Dictionary<ResourceTypeConfig, int> Resources;

    public SaveData()
    {
        ResourcesByType = new Dictionary<Type, int>();
        //Resources = new Dictionary<ResourceTypeConfig, int>();
    }
}
