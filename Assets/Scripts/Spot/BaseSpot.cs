using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpot : MonoBehaviour
{
    public SpotConfig Config;
    public InventoryConfig Inventory;

    private int _inResCount = 0;

    internal void TakeResource(BaseResource res)
    {
        _inResCount++;
    }
}
