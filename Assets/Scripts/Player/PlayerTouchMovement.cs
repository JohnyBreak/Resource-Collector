using UnityEngine.AI;
using UnityEngine;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerTouchMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private NavMeshAgent _agent;
    private PlayerAnimator _anim;
    private bool _canMove = true;

    public Vector3 PlayerCameraRelativeDirection => GetCameraRelativeMoveDirection();

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _anim = GetComponentInChildren<PlayerAnimator>();
    }

    private void OnStopPlayer() 
    {
        _canMove = false;
    }

    private void OnResumePlayer()
    {
        _canMove = true;
    }

    private void Update()
    {
        _anim.SetMove(_joystick.Direction.magnitude);
        if (!_canMove) return;
        if (_joystick.Direction == Vector2.zero) return;
        Vector3 movement = _agent.speed * Time.deltaTime * new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);

        transform.LookAt(transform.position + movement, Vector3.up);
        _agent.Move(movement);
    }

    private Vector3 GetCameraRelativeMoveDirection()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 forwardCameraRelativeMovement = cameraForward * _joystick.Direction.y;
        Vector3 rightCameraRelativeMovement = cameraRight * _joystick.Direction.x;
        Vector3 cameraRelativeMovement = forwardCameraRelativeMovement + rightCameraRelativeMovement;

        Debug.DrawRay(transform.position, cameraRelativeMovement, Color.black);
        return cameraRelativeMovement;
    }
}
