using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPool", menuName = "ScriptableObjects/ObjectPool")]
public class ObjectPool : ScriptableObject
{

    //[SerializeField] 
    private List<BaseResource> _pooledObjects;

    public List<BaseResource> PooledObjects => _pooledObjects;

    private void Awake()
    {

        //for (int i = 0; i < _countToPreLoad; i++)
        //{
        //    CreateObject();
        //}
    }

    private void OnEnable()
    {
        if (_pooledObjects != null) _pooledObjects.Clear();
        _pooledObjects = new List<BaseResource>();
    }

    public BaseResource GetPooledObject(BaseResource res, bool active = false)
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].gameObject.activeInHierarchy)
            {
               
                if (_pooledObjects[i].Config == res.Config)
                {
                    _pooledObjects[i].transform.SetParent(null);
                    _pooledObjects[i].gameObject.SetActive(active);
                    return _pooledObjects[i];
                }
            }
        }

        CreateObject(res);
        BaseResource obj = _pooledObjects[_pooledObjects.Count - 1];
        obj.transform.SetParent(null);
        obj.gameObject.SetActive(active);

        return obj;
    }

    private void CreateObject(BaseResource res)
    {
        BaseResource obj = Instantiate(res);//, transform);
        obj.gameObject.SetActive(false);
        _pooledObjects.Add(obj);
    }

    public void DisableObject(BaseResource res)
    {
        //obj.transform.SetParent(transform);
        res.gameObject.SetActive(false);
    }
}
