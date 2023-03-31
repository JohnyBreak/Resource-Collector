using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingMission : MonoBehaviour
{
    public UnityEvent BuildEvent;

    [SerializeField] BuildingMissionObject BuildingMissionObject;

    void Awake()
    {
        BuildingMissionObject.BuildingMission = this;
    }

    public void Build() 
    {
        Debug.Log("Build the bridge");
        BuildEvent?.Invoke();
    }
}
