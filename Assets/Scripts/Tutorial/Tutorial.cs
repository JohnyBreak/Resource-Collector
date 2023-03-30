using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TutorialConfig _config;

    private void Start()
    {
        _config.TutorialCompleteEvent += OnTutorialComplete;
        _config.StartTutorial();
    }

    private void OnTutorialComplete() 
    {
        Debug.Log("Tutorial completed");
        _config.TutorialCompleteEvent -= OnTutorialComplete;
    }


}
