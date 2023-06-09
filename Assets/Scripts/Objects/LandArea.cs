using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandArea : MonoBehaviour
{
    [SerializeField] protected float _maxRadius = 1;
    [SerializeField] protected Color _gizmoColor;


    public Vector3 GetLandPosition() 
    {
        var point = Random.insideUnitCircle.normalized * _maxRadius;
        var pos = transform.position + new Vector3(point.x, transform.position.y, point.y);
        return pos;
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireSphere(transform.position, _maxRadius);
    }
}
