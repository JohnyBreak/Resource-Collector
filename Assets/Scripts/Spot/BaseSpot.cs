using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpot : MonoBehaviour
{
    [Header("Settings")]
    public SpotConfig Config;
    public ResourceSpawner Spawner;
    public InventoryConfig Inventory;

    [Space(10)]
    [Header("Variables")]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private LandArea _landArea;
    [SerializeField] private SpotLabel _label;

    private int _inResCount = 0;
    private int _recyclingCount = 0;
    private bool _isRecycling = false;

    private void Awake()
    {
        _label.Init(Config.ResourceIn.Config.Icon,
            Config.ResourceOut.Config.Icon,
            Config.InCount,
            Config.OutCount);
    }

    public void IncreaseResource()
    {
        _inResCount++;
        if (_inResCount == Config.InCount) 
        {
            _inResCount = 0;
               _recyclingCount++;
            if (!_isRecycling) StartRecycling();
        }
        _label.SetText(_recyclingCount);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.S)) StartRecycling();
    //    if (Input.GetKeyDown(KeyCode.A)) _recyclingCount++;
    //}

    private void StartRecycling()
    {
        //start
        _isRecycling = true;
        StartCoroutine(RecyclingRoutine());
    }

    private IEnumerator RecyclingRoutine() 
    {
        while (_recyclingCount > 0)
        {
            yield return new WaitForSeconds(Config.RecyclingTime);
            _recyclingCount--;
            _label.SetText(_recyclingCount);
            //drop new res
            Spawner.SpawnResource(Config.ResourceOut, _spawnPoint.position, 1, CallbackResourceDrop);
        }
        //stop
        _isRecycling = false;
    }

    private void CallbackResourceDrop(BaseResource res) 
    {
        res.Drop(_landArea.GetLandPosition());
    }
}
