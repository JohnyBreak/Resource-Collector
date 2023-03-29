using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceListConfig", menuName = "ScriptableObjects/Resources/ResourceListConfig")]
public class ResourceListConfig : ScriptableObject
{
    public List<ResourceTypeConfig> Resources;
}
