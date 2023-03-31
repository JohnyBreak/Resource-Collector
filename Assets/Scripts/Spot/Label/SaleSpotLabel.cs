using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleSpotLabel : BaseSpotLabel
{
    private int _needed;

    public void Init(Sprite inSprite, int needed)
    {
        _needed = needed;
        _inIMG.sprite = inSprite;

        SetText(0);
    }

    public override void SetText(int current)
    {
        _inText.text = $"{current} / {_needed}";
    }
}
