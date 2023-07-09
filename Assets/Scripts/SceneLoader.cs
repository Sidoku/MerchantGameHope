using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private int sceneNumber;
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
}