using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceObject : MonoBehaviour, IExtractable
{
    [SerializeField] protected ResourceObjectConfig _config;
    [SerializeField] protected Transform _spawnPosition;

    public virtual void Extract()
    {
        Instantiate(_config.ResourcePrefab, _spawnPosition.position, Quaternion.identity)
               .Drop(_spawnPosition.position - Vector3.forward * 2);
    }
}
