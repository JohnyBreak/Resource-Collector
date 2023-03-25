using UnityEngine;

public class SaveLoader : MonoBehaviour
{
    [SerializeField] SaveScriptable _save;

    private void Awake()
    {
        _save.Load();
    }
}
