using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<GameObject> _pooledObjects;
    [SerializeField] private int _countToPreLoad = 30;

    private List<Vector3> _lastPositions = new List<Vector3>();
    public List<GameObject> PooledObjects => _pooledObjects;
    public List<Vector3> LastPositions => _lastPositions;

    private void Awake()
    {
        _pooledObjects = new List<GameObject>();
        for (int i = 0; i < _countToPreLoad; i++)
        {
            CreateObject();
        }
    }

    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy) 
            {
                _pooledObjects[i].transform.SetParent(null);
                return _pooledObjects[i];
            }
        }

        CreateObject();
        GameObject obj = _pooledObjects[_pooledObjects.Count-1];
        obj.transform.SetParent(null);
        return obj;
    }

    private void CreateObject() 
    {
        GameObject obj = Instantiate(_prefab, transform);
        obj.SetActive(false);
        _lastPositions.Add(obj.transform.position);
        _pooledObjects.Add(obj);
    }

    public void DisableObject(GameObject obj) 
    {
        obj.transform.SetParent(transform);
        obj.SetActive(false);
    }
}
