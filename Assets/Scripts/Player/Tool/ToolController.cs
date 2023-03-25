using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ToolController : MonoBehaviour
{
    [SerializeField] private List<ToolResourcePair> _toolPairs;

    private PlayerAnimator _playerAnim;

    private Tool _currentTool;

    void Awake()
    {
        _playerAnim = GetComponent<PlayerAnimator>();

        DisableTools();

        _currentTool = _toolPairs[0].Tool;

        _playerAnim.ToggleExtractingLayerEvent += ToggleTool;
        _playerAnim.ToggleToolColliderEvent += ToggleCurrentCollider;// _currentTool.ToggleCollider;

        ToggleTool(false);
    }

    private void ToggleTool(bool value, ResourceObjectConfig type = null)
    {
        DisableTools();
        if (type != null) 
        {
            GetTool(type).gameObject.SetActive(value);
        }
    }

    private void OnDestroy()
    {
        _playerAnim.ToggleExtractingLayerEvent -= ToggleTool;

        _playerAnim.ToggleToolColliderEvent -= ToggleCurrentCollider;// _currentTool.ToggleCollider;
    }

    private void DisableTools() 
    {
        foreach (var item in _toolPairs)
        {
            item.Tool.gameObject.SetActive(false);
        }
    }

    private void ToggleCurrentCollider(bool value) 
    {
        _currentTool.ToggleCollider(value);
    }

    private Tool GetTool(ResourceObjectConfig resourceType) 
    {
        foreach (var item in _toolPairs)
        {
            if (item.ResourceType == resourceType)
            {
                _currentTool = item.Tool;
                break;
            }
        }

        return _currentTool;
    }
}

[System.Serializable]
public class ToolResourcePair
{
    public Tool Tool;
    public ResourceObjectConfig ResourceType;
}