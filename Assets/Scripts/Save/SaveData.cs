using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int MoneyAmount;
    public int BlocksAmount;
    public Dictionary<Type, int> Resources;

    public SaveData()
    {
        Resources = new Dictionary<Type, int>();
    }
}
