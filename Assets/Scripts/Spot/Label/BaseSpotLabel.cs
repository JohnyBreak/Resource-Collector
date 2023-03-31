using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class BaseSpotLabel : MonoBehaviour
{
    [SerializeField] protected Image _inIMG;
    [SerializeField] protected TextMeshProUGUI _inText;
    
    protected Transform _camTransform;

    protected virtual void Awake()
    {
        _camTransform = Camera.main.transform;
    }
    public abstract void SetText(int current);

    protected virtual void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camTransform.position);
    }

}
