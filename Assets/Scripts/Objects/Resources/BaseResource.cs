using UnityEngine;
using DG.Tweening;

public class BaseResource : MonoBehaviour, ICollectable
{
    public ResourceTypeConfig Config;
    protected Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public virtual void Drop(Vector3 endPos, bool enableCollider = true)
    {
        _collider.enabled = false;
        transform.DOJump(endPos, Config.JumpPower, Config.JumpCount, Config.JumpDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(()=> _collider.enabled = enableCollider);
    }

    public virtual void Collect() 
    {
        gameObject.SetActive(false);
    }
}
