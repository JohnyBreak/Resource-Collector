using UnityEngine;

public class TutorialWorldArrow : MonoBehaviour
{
    [SerializeField] private TutorialArrowConfig Config;
    [SerializeField] private GameObject _arrow;
    //[SerializeField]
    private Transform _target;
    [SerializeField] private Transform _player;
    [SerializeField] private float _arrowYPos = 0.7f;
    [SerializeField] private float _distanceFromPlayer = 2f;
    [SerializeField] private float _hideDistance = 1f;

    private void Awake()
    {
        Config.ArrowObject = this;
        ToggleObject(false);
    }

    public void ToggleObject(bool enabled) 
    {
        gameObject.SetActive(enabled);
    }

    public void SetTarget(Transform t) 
    {
        _target = t;
    }

    void LateUpdate()
    {
        Vector3 direction = _target.position - _player.position;
        Vector3 lookAtPoint = _target.position;

        if (direction.magnitude < _hideDistance)
        {
            _arrow.SetActive(false);
        }
        else 
        {
            _arrow.SetActive(true);
        }

        lookAtPoint.y = _arrowYPos;

        transform.LookAt(lookAtPoint);
        transform.position = _player.position + (direction.normalized * _distanceFromPlayer) + Vector3.up * _arrowYPos;

    }

    private void OnDestroy()
    {
        Config.ArrowObject = null;
    }

}
