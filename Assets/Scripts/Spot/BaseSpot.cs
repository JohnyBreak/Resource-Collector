using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpot : MonoBehaviour
{
    [Header("Settings")]
    public BaseSpotConfig Config;
    public ResourceSpawner Spawner;
    public InventoryConfig Inventory;

    [Space(10)]
    [Header("Variables")]

    [SerializeField] protected BaseSpotLabel _label;

    public abstract void IncreaseResource();
}
