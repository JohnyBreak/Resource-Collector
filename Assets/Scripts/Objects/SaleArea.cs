using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SaleArea : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 2;
    [SerializeField] private float _jumpDuration = 0.5f;
    [SerializeField] private float _pauseBetweenBlockSale = 0.7f;

    [SerializeField] private Transform _finishPoint;

    //private SaleManager _saleManager;
    private Coroutine _sellRoutine;
    private Stack _currentStack;
    private ObjectPool _wheatPool;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent<Stack>(out var stack)) 
    //    {
    //        _currentStack = stack;
    //        if(_currentStack.IsNotEmpty) StartSell();
    //    }
    //}

    //private void StartSell() 
    //{
    //    if (_sellRoutine != null) StopSell();
    //    _sellRoutine = StartCoroutine(SellRoutine());
    //}

    //private IEnumerator SellRoutine() 
    //{
    //    while (_currentStack.IsNotEmpty)
    //    {
    //        var block = _currentStack.GetBlockForSale();

    //        block.transform.DOJump(_finishPoint.position, _jumpPower, 1, _jumpDuration).SetEase(Ease.OutQuad);
    //        block.transform.DOScale(0f, 0.3f).SetDelay(_jumpDuration)
    //            .SetEase(Ease.OutBack).OnComplete(() => SendSalePosition(block));//SendSalePosition());
    //        ;
    //        yield return new WaitForSeconds(_pauseBetweenBlockSale);
    //    }
    //    StopSell();
    //}

    private void StopSell()
    {
        StopCoroutine(_sellRoutine);
        _sellRoutine = null;
        _currentStack = null;
    }

    //private void SendSalePosition(WheatBlock block)    
    //{
    //    _saleManager.OnBlockSale(_finishPoint.position, block.Price);
    //    _wheatPool.DisableObject(block.gameObject);
    //}

    private void OnTriggerExit(Collider other)
    {
        if(_sellRoutine != null) StopSell();
    }
}
