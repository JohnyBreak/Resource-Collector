using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private Image _icon;

    private int _increaseHash = Animator.StringToHash("Increase");
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Init(Sprite icon, int amount) 
    {
        _icon.sprite = icon;
        SetAmount(amount);
    }

    public void SetAmount(int amount)
    {
        _amountText.text = amount.ToString();
        _anim.SetTrigger(_increaseHash);
    }
}
