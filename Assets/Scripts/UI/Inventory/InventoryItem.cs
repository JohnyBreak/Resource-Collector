using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private Image _icon;

    public void Init(Sprite icon, int amount) 
    {
        _icon.sprite = icon;
        SetAmount(amount);
    }

    public void SetAmount(int amount) 
    {
        _amountText.text = amount.ToString();
    }
}
