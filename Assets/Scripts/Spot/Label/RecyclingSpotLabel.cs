using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecyclingSpotLabel : BaseSpotLabel
{
    [SerializeField] protected Image _outIMG;
    [SerializeField] protected TextMeshProUGUI _outText;
    [SerializeField] protected TextMeshProUGUI _infoText;

    public void Init(Sprite inSprite, Sprite outSprite, int current, int needed)
    {
        _inIMG.sprite = inSprite;
        _outIMG.sprite = outSprite;

        _inText.text = current.ToString();
        _outText.text = needed.ToString();
        SetText(0);
    }

    public override void SetText(int current)
    {
        string s = (current > 0) ? $"Preparing {current}" : "";
        _infoText.text = s;
    }

}
