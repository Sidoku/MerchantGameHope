using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string sceneChoice1;
    [SerializeField] private string sceneChoice2;
    [SerializeField] private int sceneNumber;
    [SerializeField] private bool durationBased;
    [SerializeField] private float sceneDuration;
    [SerializeField] private float currentTimer;

    private void Update()
    {
        if (!durationBased) return;
        currentTimer += Time.deltaTime;
        if (currentTimer > sceneDuration)
        {
            LoadAfterDuration();
        }
    }

    public void Load()
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }

    public void LoadFail(string scene)
    {
        if(scene != null)
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void LoadAfterDuration()
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }

    public void ChoiceLoader()
    {
        if (StaticVariables.score >= 7)
        {
            SceneManager.LoadScene(sceneChoice1);
        }
        else if (StaticVariables.score >= 0)
        {
            SceneManager.LoadScene(sceneChoice2);
        }
    }
}
