using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialConfig", menuName = "ScriptableObjects/Tutorial/TutorialConfig")]
public class TutorialConfig : ScriptableObject
{
    public Action TutorialCompleteEvent;
    public List<BaseTutorialStep> TutorialSteps;

    public void CompleteStep(BaseTutorialStep step) 
    {
        StartStepAfter(step);
    }

    private void StartStepAfter(BaseTutorialStep step) 
    {
        int index = TutorialSteps.FindIndex(s => s == step);

        if (index < TutorialSteps.Count - 1)
        {
            TutorialSteps[index + 1].StartStep(this);
        }
        else
        {
            TutorialCompleteEvent?.Invoke();
        }
    }

    public void StartTutorial()
    {
        TutorialSteps[0].StartStep(this);
    }

}
