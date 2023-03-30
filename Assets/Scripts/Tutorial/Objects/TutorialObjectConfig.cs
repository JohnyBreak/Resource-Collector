using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TutorialObjectConfig", menuName = "ScriptableObjects/Tutorial/TutorialObjectConfig")]
public class TutorialObjectConfig : ScriptableObject
{
    [HideInInspector] public TutorialObject Object;
    public string Name;
}
