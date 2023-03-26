using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceObject : MonoBehaviour, IExtractable
{
    public ResourceObjectConfig Config;
    [SerializeField] protected ResourceSpawner _spawner;
    [SerializeField] protected Transform _spawnPosition;
    [SerializeField] protected LandArea _landArea;

    protected int _hitCount = 0;

    protected Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public virtual void Extract()
    {
        _spawner.SpawnResource(Config.ResourcePrefab, _spawnPosition.position, Config.ResourcePerHitCount, DropResourceCallback);

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
        _collider.enabled = false;

        yield return new WaitForSeconds(Config.RecoveryTime);

        _collider.enabled = true;
        _hitCount = 0;
    }
}
