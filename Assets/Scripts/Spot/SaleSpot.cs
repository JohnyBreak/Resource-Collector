using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleSpot : BaseSpot
{
    private int _inResCount = 0;
    private SaleSpotConfig _config;

    private void Awake()
    {
        _config = (SaleSpotConfig)Config;
           SaleSpotLabel label = (SaleSpotLabel)_label;
        label.Init(_config.ResourceIn.Config.Icon, _config.InCount);
        _config = (SaleSpotConfig)Config;
    }

    public override void IncreaseResource()
    {
        _inResCount++;
        _label.SetText(_inResCount);
        if (_inResCount == _config.InCount) 
        {
            Debug.Log("Build the bridge");
        }
    }
}
