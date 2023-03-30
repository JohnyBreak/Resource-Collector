using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTutorialStep : ScriptableObject
{
    protected TutorialConfig _tutorialConfig;

    public abstract void StartStep(TutorialConfig tutorialConfig);
    public abstract void CompleteStep();
}
