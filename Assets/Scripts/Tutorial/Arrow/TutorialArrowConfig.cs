using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialArrowConfig"
, menuName = "ScriptableObjects/Tutorial/TutorialArrowConfig")]
public class TutorialArrowConfig : ScriptableObject
{
    [HideInInspector] public TutorialWorldArrow ArrowObject;
}
