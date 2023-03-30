using UnityEngine;
using TMPro;

public class SpotLabel : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    private Transform _camTransform;

    private void Awake()
    {
        _camTransform = Camera.main.transform;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetText(int current, int needed) 
    {
        _text.text = $"{current} / {needed}";
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camTransform.position);
    }

}
