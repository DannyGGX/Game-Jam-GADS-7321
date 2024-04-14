using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;

public class LevelManager : Singleton<LevelManager>
{
    [field: SerializeField] public int maxLevelNumber { get; private set; } = 5;
    public int currentLevelNumber { get; private set; } = 1;
    
    private void OnEnable()
    {
        EventManager.onRestartLevel.Subscribe(RestartLevel);
        EventManager.onKillPlayer.Subscribe(RestartLevel);
        EventManager.onFinishLevel.Subscribe(GoToNextLevel);
    }

    private void OnDisable()
    {
        EventManager.onRestartLevel.Unsubscribe(RestartLevel);
        EventManager.onKillPlayer.Unsubscribe(RestartLevel);
        EventManager.onFinishLevel.Unsubscribe(GoToNextLevel);
    }

    private void GoToNextLevel()
    {
        StopAllCoroutines();
        StartCoroutine(WaitBeforeGoingToNextLevel());
    }
    
    private IEnumerator WaitBeforeGoingToNextLevel()
    {
        yield return new WaitForSeconds(3f);
        currentLevelNumber++;
        if (currentLevelNumber > maxLevelNumber)
        {
            SceneManagerScript.Instance.LoadScene(Scenes.MainMenu);
        }
        else
        {
            SceneManagerScript.Instance.LoadNextLevel();
        }
    }

    private void RestartLevel()
    {
        StopAllCoroutines();
        StartCoroutine(WaitBeforeRestartLevel());
    }

    private IEnumerator WaitBeforeRestartLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManagerScript.Instance.RestartCurrentScene();
    }
    
}