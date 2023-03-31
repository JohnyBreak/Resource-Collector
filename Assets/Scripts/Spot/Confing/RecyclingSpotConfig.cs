using UnityEngine;

[CreateAssetMenu(fileName = "RecyclingSpotConfig", menuName = "ScriptableObjects/Spot/RecyclingSpotConfig")]
public class RecyclingSpotConfig : BaseSpotConfig
{
    [Space(10)]
    [Header("Out")]
    public BaseResource ResourceOut;
    public int OutCount;

    [Space(10)]
    [Header("Time settings")]
    public float RecyclingTime;
}
