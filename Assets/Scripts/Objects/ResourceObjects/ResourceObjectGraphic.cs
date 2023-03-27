using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ResourceObjectGraphic : MonoBehaviour
{
    private Animator _anim;
    private ResourceObject _resourceObject;

    private int _devastateHash = Animator.StringToHash("Devastate");
    private int _recoverHash = Animator.StringToHash("Recover");
    private int _hitHash = Animator.StringToHash("Hit");
    void Awake()
    {
        _resourceObject = GetComponentInParent<ResourceObject>();

        _resourceObject.HitEvent += OnHit;
        _resourceObject.RecoverEvent += OnRecover;
        _resourceObject.DevastateEvent += OnDevastate;

        _anim = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        _resourceObject.HitEvent -= OnHit;
        _resourceObject.RecoverEvent -= OnRecover;
        _resourceObject.DevastateEvent -= OnDevastate;
    }

    private void OnHit()
    {
        _anim.SetTrigger(_hitHash);
    }

    private void OnDevastate() 
    {
        _anim.SetTrigger(_devastateHash);
    }

    private void OnRecover()
    {
        _anim.SetTrigger(_recoverHash);
    }

}
