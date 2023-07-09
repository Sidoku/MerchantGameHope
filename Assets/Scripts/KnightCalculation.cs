using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KnightCalculation : MonoBehaviour
{
    [SerializeField] private Image knightFill;

    [SerializeField] private float time;
    [SerializeField] private float timerDuration;
    [SerializeField] private SceneLoader sceneLoader;

    private float _fillCalc;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        _fillCalc = time / timerDuration;
        knightFill.fillAmount = _fillCalc;

        if (time >= timerDuration)
        {
            sceneLoader.Load();
        }
    }
}
