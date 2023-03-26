using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    [SerializeField] private InventoryConfig _inventory;
    [SerializeField] private InventoryItem _itemPrefab;
    [SerializeField] private Transform _itemsHolder;

    private Dictionary<ResourceTypeConfig, InventoryItem> _resourceItems;

    private void Awake()
    {
        _resourceItems = new Dictionary<ResourceTypeConfig, InventoryItem>();

        foreach (var res in _inventory.ResourceList.Resources)
        {
            InventoryItem item = Instantiate(_itemPrefab, _itemsHolder);
            _resourceItems.Add(res, item);
            item.gameObject.SetActive(false);
        }
    }

    private void Start()
    {

        _inventory.InventoryChangedEvent += OnInventoryChanged;
        _inventory.InitCanvasEvent += Init;
    }

    private void Init()
    {
        Debug.LogError("Init");

        foreach (var type in _inventory.ResourceByType)
        {
            var res = _inventory.ResourceList.Resources.Find(t => t.GetType() == type.Key);
            _resourceItems[res].Init(res.Icon, type.Value);
            _resourceItems[res].gameObject.SetActive(true);
        }
    }

    private void OnInventoryChanged(BaseResource res, int amount)
    {
        //if (_resourceItems.ContainsKey(res.Type) == false)
        //{
        //    InventoryItem item = Instantiate(_itemPrefab, _itemsHolder);
        //    item.Init(res.Type.Icon, 0);

        //    _resourceItems.Add(res.Type, item);
        //}

        if(_resourceItems[res.Config].gameObject.activeInHierarchy == false) 
        {
            _resourceItems[res.Config].Init(res.Config.Icon, amount);
            _resourceItems[res.Config].gameObject.SetActive(true);
            return;
        }
        _resourceItems[res.Config].SetAmount(amount);
    }

    private void OnDestroy()
    {
        _inventory.InventoryChangedEvent -= OnInventoryChanged; 
        _inventory.InitCanvasEvent -= Init;
    }
}
