using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingSpot : BaseSpot
{
    [SerializeField] protected Transform _spawnPoint;
    [SerializeField] protected LandArea _landArea;

    private int _inResCount = 0;
    private int _recyclingCount = 0;
    private bool _isRecycling = false;
    private RecyclingSpotConfig _config;
    
    private void Awake()
    {
        _config = (RecyclingSpotConfig)Config;

        RecyclingSpotLabel label = (RecyclingSpotLabel)_label;

        label.Init(Config.ResourceIn.Config.Icon,
            _config.ResourceOut.Config.Icon,
            _config.InCount,
            _config.OutCount);
    }

    public override void IncreaseResource()
    {
        _inResCount++;
        if (_inResCount == _config.InCount)
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
            yield return new WaitForSeconds(_config.RecyclingTime);
            _recyclingCount--;
            _label.SetText(_recyclingCount);
            //drop new res
            Spawner.SpawnResource(_config.ResourceOut, _spawnPoint.position, 1, CallbackResourceDrop);
        }
        //stop
        _isRecycling = false;
    }

    private void CallbackResourceDrop(BaseResource res)
    {
        res.Drop(_landArea.GetLandPosition());
    }
}
