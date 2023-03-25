using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    public Action<bool> ToggleCutColliderEvent;
    public Action<bool> ToggleCutLayerEvent;

    [SerializeField] private float _layerWaightSmoothTime = 0.2f;

    private Animator _anim;
    private int _moveHash = Animator.StringToHash("Move");
    private int _isCuttingHash = Animator.StringToHash("IsCutting");
    private Coroutine _layerWeightRoutine;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void SetMove(float value) 
    {
        _anim.SetFloat(_moveHash, value);
    }

    public void StartCutting() 
    {
        ToggleCutLayerEvent?.Invoke(true);
        SetLayerWeight(1, 1);
    }

    public void StopCutting()
    {
        SetLayerWeight(1, 0);
        ToggleCutLayerEvent?.Invoke(false);
    }

    public void EnableCutCollider() 
    {
        ToggleCutColliderEvent?.Invoke(true);
    }

    public void DisableCutCollider()
    {
        ToggleCutColliderEvent?.Invoke(false);
    }

    private void SetLayerWeight(int layer, float weight) 
    {
        if (_layerWeightRoutine != null)
        {
            StopCoroutine(_layerWeightRoutine);
            _layerWeightRoutine = null;
        }
        _layerWeightRoutine = StartCoroutine(SmoothLayer(layer, weight));

    }

    private IEnumerator SmoothLayer(int layer, float end)
    {
        float weight = 0;
        float elapsedTime = 0;

        while (elapsedTime <= _layerWaightSmoothTime)
        {
            float start = _anim.GetLayerWeight(layer);
            weight = Mathf.Lerp(start, end, elapsedTime);
            _anim.SetLayerWeight(layer, weight);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _anim.SetLayerWeight(layer, end);
        _anim.SetBool(_isCuttingHash, (end == 1)? true : false);
    }

}
