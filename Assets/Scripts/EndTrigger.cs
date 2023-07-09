using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] Inventory _inventory;
    private float finalScore;
    [SerializeField] SceneLoader _sceneLoader;
    private void OnTriggerEnter2D(Collider2D col)
    {
        finalScore = _inventory.FinalScore();
        Debug.Log("final score: " + finalScore);
        StaticVariables.score = finalScore;
        Debug.Log("Final Score: " + StaticVariables.score);
        _sceneLoader.Load();
    }
}
