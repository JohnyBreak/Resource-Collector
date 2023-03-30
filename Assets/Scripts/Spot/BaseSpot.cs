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
        _label.SetText(_inResCount + (_recyclingCount * Config.InCount), Config.InCount);
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
        _label.SetText(_inResCount + (_recyclingCount * Config.InCount), Config.InCount);
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
            _recyclingCount--;

            _label.SetText(_inResCount + (_recyclingCount * Config.InCount), Config.InCount);

            yield return new WaitForSeconds(Config.RecyclingTime);

            //drop new res
            //_landArea.GetLandPosition();
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
