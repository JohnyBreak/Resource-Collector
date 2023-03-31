using DG.Tweening;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleTo;
    [SerializeField] private float _duration = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        transform.DOScale(_scaleTo, _duration).SetEase(Ease.OutBack);
    }
}
