using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveToObjectTutorialStep", menuName = "ScriptableObjects/Tutorial/TutorialStep/MoveToObjectTutorialStep")]
public class MoveToObjectTutorialStep : BaseTutorialStep
{
    [SerializeField] private PlayerConfig _player;
    [SerializeField] private TutorialObjectConfig _destinationObjectConfig;
    [SerializeField] private float _stopDistance;
    [SerializeField] private ToggleTutorialArrowStep _arrowStep;
    [SerializeField] private ToggleTutorialCanvasStep _canvasStep;

    public Transform Target => _destinationObjectConfig.Object.transform;

    public override void CompleteStep()
    {
        _destinationObjectConfig.Object.DistanceReachedEvent -= StopCheckDistance;
        
        _arrowStep.CompleteStep();
        _canvasStep.CompleteStep();


        _tutorialConfig.CompleteStep(this);

    }

    public override void StartStep(TutorialConfig tutorialConfig)
    {
        _arrowStep.StartStep(this);
        _canvasStep.StartStep($"Move to {_destinationObjectConfig.Name}");

        _tutorialConfig = tutorialConfig;
        _destinationObjectConfig.Object.DistanceReachedEvent += StopCheckDistance;
        _destinationObjectConfig.Object.StartCheckDistance(_player.PlayerTrasform, _stopDistance);
    }

    private void StopCheckDistance() 
    {
        CompleteStep();
    }
}
