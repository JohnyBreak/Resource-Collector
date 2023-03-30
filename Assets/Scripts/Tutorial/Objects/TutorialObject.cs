using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : MonoBehaviour
{
    public Action DistanceReachedEvent;

    [SerializeField] private TutorialObjectConfig _config;
    private float _stopDistance;

    void Awake()
    {
        _config.Object = this;
    }

    public void StartCheckDistance(Transform target, float distance) 
    {
        StartCoroutine(CheckDistanceRoutine(target, distance));
    }

    private IEnumerator CheckDistanceRoutine(Transform target, float distance) 
    {
        _stopDistance = distance;
        
        while (CheckTargetDistance(target))
        {
            yield return null;
        }

        DistanceReachedEvent?.Invoke();
    }

    private bool CheckTargetDistance(Transform target)
    {
        var distance = (((target.position.x - transform.position.x) * (target.position.x - transform.position.x)) +
            ((target.position.y - transform.position.y) * (target.position.y - transform.position.y)) +
            ((target.position.z - transform.position.z) * (target.position.z - transform.position.z)));
        if (distance > _stopDistance)
        {
            return true;
        }

        return false;
    }

    private void OnDestroy()
    {
        _config.Object = null;
    }
}
