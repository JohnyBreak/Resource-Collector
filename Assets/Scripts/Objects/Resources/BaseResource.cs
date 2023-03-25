using UnityEngine;
using DG.Tweening;

public abstract class BaseResource : MonoBehaviour, ICollectable
{
    [SerializeField] protected float _jumpPower = 2f;
    [SerializeField] protected int _jumpCount = 1;
    [SerializeField] protected float _jumpDuration = 0.5f;

    public virtual void Drop(Vector3 endPos)
    {
        transform.DOJump(endPos, _jumpPower, _jumpCount, _jumpDuration).SetEase(Ease.OutQuad);
    }

    public abstract void Collect();
}
