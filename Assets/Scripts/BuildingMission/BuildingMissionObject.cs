using UnityEngine;

[CreateAssetMenu(fileName = "BuildingMissionObject", menuName = "ScriptableObjects/Missions/BuildMissions/BuildingMissionObject")]
public class BuildingMissionObject : ScriptableObject
{
    [HideInInspector] public BuildingMission BuildingMission;
}
