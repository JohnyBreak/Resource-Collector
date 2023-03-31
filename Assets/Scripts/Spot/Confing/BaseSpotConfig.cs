using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpotConfig : ScriptableObject
{
    [Header("In")]
    public BaseResource ResourceIn;
    public int InCount;
}
