using System.Collections;
using UnityEngine;

public class WheatChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _Mask;
    [SerializeField] private float _checkRadius = 1;

    private Player _player;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
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
        if (colls.Length < 1)
        {
            _player.StopCutting();
            return;
        }

        _player.StartCutting();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _checkRadius);
    }
}
