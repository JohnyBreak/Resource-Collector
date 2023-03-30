using UnityEngine;

[CreateAssetMenu(fileName = "ToggleTutorialArrowStep"
    , menuName = "ScriptableObjects/Tutorial/TutorialStep/ToggleTutorialArrowStep")]
public class ToggleTutorialArrowStep : BaseTutorialStep
{
    [SerializeField] private TutorialArrowConfig _arrowConfig;

    public override void CompleteStep()
    {
        _arrowConfig.ArrowObject.ToggleObject(false);
    }

    public override void StartStep(TutorialConfig tutorialConfig)
    {
    }

    public void StartStep(MoveToObjectTutorialStep parentStep)
    {
        _arrowConfig.ArrowObject.SetTarget(parentStep.Target);
        _arrowConfig.ArrowObject.ToggleObject(true);
    }
}
