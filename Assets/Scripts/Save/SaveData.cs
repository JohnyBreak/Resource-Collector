using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public Dictionary<int, int> ResourcesByType;

    //public Dictionary<ResourceTypeConfig, int> Resources;

    public SaveData()
    {
        ResourcesByType = new Dictionary<int, int>();
        //Resources = new Dictionary<ResourceTypeConfig, int>();
    }
}
