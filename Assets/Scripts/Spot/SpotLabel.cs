using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpotLabel : MonoBehaviour
{
    [SerializeField] private Image _inIMG;
    [SerializeField] private Image _outIMG;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _inText;
    [SerializeField] private TextMeshProUGUI _outText;

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

    public void Init(Sprite inSprite, Sprite outSprite, int current, int needed) 
    {
        _inIMG.sprite = inSprite;
        _outIMG.sprite = outSprite;

        _inText.text = current.ToString();
        _outText.text = needed.ToString();
        SetText(0);
    }

    public void SetText(int current) 
    {
        string s = (current > 0) ? $"Preparing {current}" : "";
        _infoText.text = s;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camTransform.position);
    }

}
