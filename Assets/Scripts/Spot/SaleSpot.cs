using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleSpot : BaseSpot
{
    [SerializeField] private SaleArea _saleArea;

    private int _inResCount = 0;
    private SaleSpotConfig _config;

    private void Awake()
    {
        _config = (SaleSpotConfig)Config;
        _saleArea.SetNeededCount(_config.InCount);

        SaleSpotLabel label = (SaleSpotLabel)_label;
        label.Init(_config.ResourceIn.Config.Icon, _config.InCount);
    }

    public override void IncreaseResource()
    {
        _inResCount++;
        _label.SetText(_inResCount);
        if (_inResCount == _config.InCount) 
        {
            _config.AfterSale.Object.BuildingMission.Build();
        }
    }
}
