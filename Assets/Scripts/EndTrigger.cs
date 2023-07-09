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
        StaticVariables.score = finalScore;
        _sceneLoader.Load();
    }
}
