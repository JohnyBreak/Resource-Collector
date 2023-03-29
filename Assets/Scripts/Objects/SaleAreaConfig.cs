using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaleAreaConfig", menuName = "ScriptableObjects/Spot/SaleAreaConfig")]
public class SaleAreaConfig : ScriptableObject
{
    public float JumpPower = 2;
    public float JumpDuration = 0.5f;
    public float PauseBetweenBlockSale = 0.7f;
    public float FlyInInterval;
}
