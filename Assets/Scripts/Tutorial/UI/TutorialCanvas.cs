using TMPro;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    [SerializeField] private TutorialCanvasConfig _config;
    [SerializeField] private GameObject TextHolder;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _config.Canvas = this;
        ToggleObject(false);
    }

    public void SetText(string s)
    {
        _text.text = s;
    }

    public void ToggleObject(bool enabled) 
    {
        TextHolder.SetActive(enabled);
    }

    private void OnDestroy()
    {
        _config.Canvas = null;
    }
}
