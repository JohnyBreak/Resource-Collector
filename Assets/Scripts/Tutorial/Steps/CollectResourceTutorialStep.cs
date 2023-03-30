using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectResourceTutorialStep", menuName = "ScriptableObjects/Tutorial/TutorialStep/CollectResourceTutorialStep")]
public class CollectResourceTutorialStep : BaseTutorialStep
{
    [SerializeField] private InventoryConfig _inventory;
    [SerializeField] private BaseResource _requiredResource;
    [SerializeField, Min(0)] private int _requiredCount;
    [SerializeField] private ToggleTutorialCanvasStep _canvasStep;

    public override void CompleteStep()
    {
        _inventory.InventoryChangedEvent -= OnResourceAmountChanged;

        _canvasStep.CompleteStep();

        _tutorialConfig.CompleteStep(this);
    }

    public override void StartStep(TutorialConfig tutorialConfig)
    {
        _canvasStep.StartStep($"Collect {_requiredCount} {_requiredResource.Config.Name}");

        _tutorialConfig = tutorialConfig;

        _inventory.InventoryChangedEvent += OnResourceAmountChanged;
    }

    private void OnResourceAmountChanged(BaseResource res, int amount) 
    {
        if (res.Config != _requiredResource.Config) return;

        if (amount < _requiredCount) return;

        CompleteStep();
    }

}
