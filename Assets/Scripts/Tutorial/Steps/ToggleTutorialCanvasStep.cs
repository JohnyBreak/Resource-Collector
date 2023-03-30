using UnityEngine;

[CreateAssetMenu(fileName = "ToggleTutorialCanvasStep"
    , menuName = "ScriptableObjects/Tutorial/TutorialStep/ToggleTutorialCanvasStep")]
public class ToggleTutorialCanvasStep : BaseTutorialStep
{
    [SerializeField] private TutorialCanvasConfig _canvasConfig;

    public override void CompleteStep()
    {
        _canvasConfig.Canvas.ToggleObject(false);
    }

    public override void StartStep(TutorialConfig tutorialConfig)
    {
    }

    public  void StartStep(string tutorText)
    {
        _canvasConfig.Canvas.SetText(tutorText);
        _canvasConfig.Canvas.ToggleObject(true);
    }
}
