using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolResourcesConfig", menuName = "ScriptableObjects/Tools/ToolResourcesConfig", order = 0)]
public class ToolResourcesConfig : ScriptableObject
{
    public List<ToolResourcePair> ToolPairs;
}

[System.Serializable]
public class ToolResourcePair
{
    public ToolConfig Tool;
    public ResourceObjectConfig ResourceType;
}