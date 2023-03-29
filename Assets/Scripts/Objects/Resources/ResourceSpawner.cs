using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceSpawner", menuName = "ScriptableObjects/Resources/ResourceSpawner")]
public class ResourceSpawner : ScriptableObject
{
    public ObjectPool Pool;

    private Queue<ResourceSpawnQueueElement> _resQueue = new Queue<ResourceSpawnQueueElement>();

    public void SpawnResource(BaseResource resourse, Vector3 spawnPosition, int count = 1, Action<BaseResource> action = null) 
    {
        _resQueue.Enqueue(new ResourceSpawnQueueElement(resourse, spawnPosition, count, action));

        while (_resQueue.Count > 0)
        {
            var queueElement = _resQueue.Dequeue();
            for (int i = 0; i < queueElement.Count; i++)
            {

                var res = Pool.GetPooledObject(queueElement.Resource, true);//Instantiate(queueElement.Resource, queueElement.SpawnPosition, Quaternion.identity);
                res.transform.position = queueElement.SpawnPosition;

                if (queueElement.Callback != null) queueElement.Callback.Invoke(res);
            }
        }
    }
}

[System.Serializable]
public class ResourceSpawnQueueElement
{
    public BaseResource Resource;
    public Vector3 SpawnPosition;
    public int Count;
    public Action<BaseResource> Callback;

    public ResourceSpawnQueueElement(BaseResource resourse, Vector3 spawnPosition, int count, Action<BaseResource> action)
    {
        Resource = resourse;
        SpawnPosition = spawnPosition;
        Count = count;
        Callback = action;
    }
}
