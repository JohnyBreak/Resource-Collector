using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject, IScriptableTransform
{
    [HideInInspector] public Transform PlayerTrasform;
}
