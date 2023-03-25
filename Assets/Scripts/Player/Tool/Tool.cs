using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Tool : MonoBehaviour, IExtracting
{
    [SerializeField] private LayerMask _mask;
    private Collider _collider;

    void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        ToggleCollider(false); 
        GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _mask) != 0)
        {
            if (other.TryGetComponent<IExtractable>(out var resourceObject)) resourceObject.Extract();
        }
    }

    public void ToggleCollider(bool value)
    {
        if(isActiveAndEnabled) _collider.enabled = value;
    }

}
