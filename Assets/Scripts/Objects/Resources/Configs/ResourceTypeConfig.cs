using UnityEngine;

[CreateAssetMenu(fileName = "ResourceTypeConfig", menuName = "Resources/ResourceTypeConfig")]
public class ResourceTypeConfig : ScriptableObject
{
    public Sprite Icon;

    public float JumpPower = 2f;
    public int JumpCount = 1;
    public float JumpDuration = 0.5f;

}
