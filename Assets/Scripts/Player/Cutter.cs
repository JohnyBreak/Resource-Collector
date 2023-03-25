using UnityEngine;

public class Cutter : MonoBehaviour
{
    //[SerializeField] private Scythe _scythe;
    //[SerializeField] 
    private PlayerAnimator _playerAnim;

    void Awake()
    {
        _playerAnim = GetComponent<PlayerAnimator>();

        _playerAnim.ToggleCutLayerEvent += ToggleCutter;
       // _playerAnim.ToggleCutColliderEvent += _scythe.ToggleCollider;

        ToggleCutter(false);
    }

    private void ToggleCutter(bool value)
    {
       // _scythe.gameObject.SetActive(value);
    }

    private void OnDestroy()
    {
        _playerAnim.ToggleCutLayerEvent -= ToggleCutter;

       // _playerAnim.ToggleCutColliderEvent -= _scythe.ToggleCollider;
    }
}
