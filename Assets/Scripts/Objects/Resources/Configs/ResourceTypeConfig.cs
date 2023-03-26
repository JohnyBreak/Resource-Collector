using UnityEngine;

public abstract class ResourceTypeConfig : ScriptableObject
{
    public Sprite Icon;

    public float JumpPower = 2f;
    public int JumpCount = 1;
    public float JumpDuration = 0.5f;

}
