using UnityEngine;

[CreateAssetMenu(fileName = "ResourceObjectConfig", menuName = "Resources/ResourceObjectConfig")]
public class ResourceObjectConfig : ScriptableObject
{
    public BaseResource ResourcePrefab;
    public float RecoveryTime = 10f;
    public int ResourcePerHitCount = 1;
    public int HitCountBeforeDevastation = 5;
}
