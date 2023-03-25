using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickStopper : MonoBehaviour
{
    //private BuyCanvas _buyCanvas;
    [SerializeField] private GameObject _go;

    //[Inject]
    //private void Construct(BuyCanvas buyCanvas)
    //{
    //    _buyCanvas = buyCanvas;

    //}

    void Start()
    {
        //_buyCanvas.OpenScreenEvent += OnShowBuyMenu;
        //_buyCanvas.HideScreenEvent += OnHideBuyMenu;
    }

    private void OnShowBuyMenu()
    {
        _go.SetActive(false);
    }
    private void OnHideBuyMenu()
    {
        _go.SetActive(true);
    }

    private void OnDestroy()
    {

        //_buyCanvas.HideScreenEvent -= OnHideBuyMenu;
        //_buyCanvas.OpenScreenEvent -= OnShowBuyMenu;
    }
}
