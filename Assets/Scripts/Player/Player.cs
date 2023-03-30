using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;
    private PlayerAnimator _playerAnim;

    private void Awake()
    {
        _config.PlayerTrasform = transform;
        _playerAnim = GetComponent<PlayerAnimator>();
    }

    public void StartExtract(ResourceObjectConfig type) 
    {
        _playerAnim.StartExtracting(type);
    }

    public void StopExtract()
    {
        _playerAnim.StopExtracting();
    }

    private void OnDestroy()
    {
        _config.PlayerTrasform = null;
    }
}
