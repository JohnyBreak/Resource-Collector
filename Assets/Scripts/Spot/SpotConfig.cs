using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "SpotConfig", menuName = "ScriptableObjects/Spot/SpotConfig")]
public class SpotConfig : ScriptableObject
{
    [Header("In")]
    public BaseResource ResourceIn;
    public int InCount;

    [Space(10)]
    [Header("Out")]
    public BaseResource ResourceOut;
    public int OutCount;

    [Space(10)]
    [Header("Time settings")]
    public float RecyclingTime;
}
