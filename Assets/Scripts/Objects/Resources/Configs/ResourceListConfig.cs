using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceListConfig", menuName = "ScriptableObjects/Resources/ResourceListConfig")]
public class ResourceListConfig : ScriptableObject
{
    [Header("Do not change the order of the elements, it is used in the save file")]
    public List<ResourceTypeConfig> Resources;
}
