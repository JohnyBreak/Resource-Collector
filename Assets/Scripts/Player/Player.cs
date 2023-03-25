using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    private PlayerAnimator _playerAnim;

    private void Awake()
    {
        _playerAnim = GetComponent<PlayerAnimator>();
    }

    public void StartExtract(ResourceObject extractable) 
    {
        _playerAnim.StartExtracting(extractable);
    }

    public void StopExtract()
    {
        _playerAnim.StopExtracting();
    }
}
