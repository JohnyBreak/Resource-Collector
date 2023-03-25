using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : BaseChecker
{
    private Inventory _inventory;

    protected override void Awake()
    {
        base.Awake();

        transform.parent.TryGetComponent(out _inventory);
    }

    protected override void Check()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, _checkRadius, _Mask);
        if (colls.Length < 1) return;

        foreach (var item in colls)
        {
            if (item.TryGetComponent<ICollectable>(out var collectable))
            {
                collectable.Collect();
                if (_inventory != null) _inventory.AddResource((BaseResource)collectable);
            }
        }
    }
}
