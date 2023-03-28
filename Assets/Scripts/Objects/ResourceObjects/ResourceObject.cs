using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ResourceObject : MonoBehaviour, IExtractable
{
    public ResourceObjectConfig Config;
    public Action HitEvent;
    public Action RecoverEvent;
    public Action DevastateEvent;

    [SerializeField] protected ResourceSpawner _spawner;
    [SerializeField] protected Transform _spawnPosition;
    [SerializeField] protected LandArea _landArea;

    protected int _hitCount = 0;

    protected Collider _collider;
    protected NavMeshObstacle _navMeshObstacle;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _collider = GetComponent<Collider>();
    }

    public virtual void Extract()
    {
        _spawner.SpawnResource(Config.ResourcePrefab, _spawnPosition.position, Config.ResourcePerHitCount, DropResourceCallback);

        HitEvent?.Invoke();

        _hitCount++;

        if (_hitCount >= Config.HitCountBeforeDevastation) 
        {
            StartCoroutine(RecoveryRoutine());
        }

        //Instantiate(Config.ResourcePrefab, _spawnPosition.position, Quaternion.identity)
        //       .Drop(_spawnPosition.position - Vector3.forward * 2);
    }

    public void DropResourceCallback(BaseResource res) 
    {
        res.Drop(_landArea.GetLandPosition());
    }

    protected IEnumerator RecoveryRoutine() 
    {
        _navMeshObstacle.enabled = false;
        _collider.enabled = false;
        //devastate

        DevastateEvent?.Invoke();

        yield return new WaitForSeconds(Config.RecoveryTime);
        //recover
        
        RecoverEvent?.Invoke();

        _navMeshObstacle.enabled = true;
        _collider.enabled = true;
        _hitCount = 0;
    }
}
