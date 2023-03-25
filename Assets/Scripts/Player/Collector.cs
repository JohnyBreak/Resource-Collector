
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Transform _blockHolder;
    [SerializeField] private LayerMask _Mask;
    [SerializeField] private float _checkRadius = 1;

    private Stack _stack;

    private void Awake()
    {
        _stack = GetComponentInParent<Stack>();
        StartCoroutine(FindTargetsWithDelay(0.2f));
    }

    private IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Check();
        }
    }

    
    private void Check()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, _checkRadius, _Mask);
        if (colls.Length < 1) return;

        foreach (var item in colls)
        {
            //if(item.TryGetComponent<WheatBlock>(out var block)) 
            //{
            //    if (_stack.CanTake == false) return;
            //    Debug.Log("take");
            //    block.Collect();
            //    _stack.AddBlock(block);
            //}
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _checkRadius);
    }
}
