using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SaleArea : MonoBehaviour
{
    [SerializeField] private SaleAreaConfig _config;

    [SerializeField] private Transform _finishPoint;
    [SerializeField] private LandArea _landArea;

    private BaseSpot _spot;
    private Coroutine _flyRoutine;
    private List<BaseResource> _resources;

    private Inventory _playerInventory;
    private PlayerTouchMovement _playerMovement;
    private int _neededCount = 0;


    private void Awake()
    {
        _resources = new List<BaseResource>();
        _spot = GetComponentInParent<BaseSpot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _playerInventory))
        {
            _playerMovement = _playerInventory.GetComponent<PlayerTouchMovement>();
            _playerMovement.PlayerStopEvent += OnPlayerStop;
        }
    }

    public void SetNeededCount(int count) 
    {
        _neededCount = count;
    }


    private void OnPlayerStop()
    {
        if (_playerInventory.CheckResourceAvailability(_spot.Config.ResourceIn))
            StartFly(_playerInventory, _playerInventory.transform.position);
    }

    private void StartFly(Inventory inventory, Vector3 startPos)
    {
        StartCoroutine(AddRoutine(inventory, startPos));
    }

    private IEnumerator AddRoutine(Inventory inventory, Vector3 startPos) 
    {
        yield return null;

        _landArea.transform.position = startPos;

        var tempList = inventory.GetAllResourcesByType(_spot.Config.ResourceIn, _neededCount);

        foreach (var item in tempList)
        {
            item.transform.position = startPos;
            item.Drop(_landArea.GetLandPosition(), false);
        }

        foreach (var item in tempList)
        {
            _resources.Add(item);
        }

        float waitTime = _resources[0].Config.JumpDuration;

        yield return new WaitForSeconds(waitTime);

        if (_flyRoutine == null) _flyRoutine = StartCoroutine(FlyRoutine());
    }


    private IEnumerator FlyRoutine()
    {
        while (_resources.Count > 0)
        {
            var res = _resources[0];
            _resources.RemoveAt(0);

            res.transform.DOJump(_finishPoint.position, _config.JumpPower, 1, _config.JumpDuration).SetEase(Ease.OutQuad);
            res.transform.DOScale(0f, 0.3f).SetDelay(_config.JumpDuration)
                .SetEase(Ease.OutBack).OnComplete(() => ProvideResourceToSpot(res));
            
            yield return new WaitForSeconds(_config.JumpDuration);
        }
        _flyRoutine = null;
    }

    private void ProvideResourceToSpot(BaseResource res)
    {
        _spot.IncreaseResource();
        res.transform.localScale = Vector3.one;
        res.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        _playerInventory = null;
        _playerMovement.PlayerStopEvent -= OnPlayerStop;
        _playerMovement = null;
    }
}
