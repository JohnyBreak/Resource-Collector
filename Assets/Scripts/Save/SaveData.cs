using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public Dictionary<Type, int> ResourcesByType;

    public SaveData()
    {
        ResourcesByType = new Dictionary<Type, int>();
    }
}
