using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObjectChecker : BaseChecker
{
    private Player _player;
    private bool _isExtracting = false;

    protected override void Awake()
    {
        _player = GetComponentInParent<Player>();
        // get player script for extracting

        base.Awake();
    }

    protected override void Check()
    {

        Collider[] colls = Physics.OverlapSphere(transform.position, _checkRadius, _Mask);
        if (colls.Length < 1)
        {
            // stop extract
            if(_isExtracting) _player.StopExtract();

            _isExtracting = false;

            return;
        }
        // start extract
        if (!_isExtracting) 
        {
            _player.StartExtract(colls[0].GetComponent<ResourceObject>());
            _isExtracting = true;
        }
    }
}
