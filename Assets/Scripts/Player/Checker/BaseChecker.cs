using System.Collections;
using UnityEngine;

public abstract class BaseChecker : MonoBehaviour
{
    [SerializeField] protected LayerMask _Mask;
    [SerializeField] protected float _checkRadius = 1;
    [SerializeField] protected float _checkInterval = 0.2f;
    [SerializeField] protected Color _gizmoColor;

    protected virtual void Awake()
    {
        StartCoroutine(FindTargetsWithDelay(_checkInterval));
    }

    protected IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Check();
        }
    }

    protected abstract void Check();

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireSphere(transform.position, _checkRadius);
    }
}
