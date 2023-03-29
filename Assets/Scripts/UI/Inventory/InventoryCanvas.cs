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
        _inventory.InventoryChangedEvent += OnInventoryChanged;
        _inventory.InitCanvasEvent += Init;

        _resourceItems = new Dictionary<ResourceTypeConfig, InventoryItem>();

        foreach (var res in _inventory.ResourceList.Resources)
        {
            InventoryItem item = Instantiate(_itemPrefab, _itemsHolder);
            _resourceItems.Add(res, item);
            item.gameObject.SetActive(false);
        }
    }

    private void Init()
    {
        foreach (var type in _inventory.ResourceByIndex)
        {
            if (type.Value < 1) continue;
            
               var res = _inventory.ResourceList.Resources
                .Find(t => _inventory.ResourceList.Resources.IndexOf(t) == type.Key);

            _resourceItems[res].Init(res.Icon, type.Value);
            _resourceItems[res].gameObject.SetActive(true);
        }
    }

    private void OnInventoryChanged(BaseResource res, int amount)
    {
        if (amount < 1)
        {
            _resourceItems[res.Config].gameObject.SetActive(false);
            return;
        }
        if (_resourceItems[res.Config].gameObject.activeInHierarchy == false) 
        {
            _resourceItems[res.Config].Init(res.Config.Icon, amount);
            _resourceItems[res.Config].transform.SetAsLastSibling();
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
