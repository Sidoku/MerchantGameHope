using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTimingController : MonoBehaviour
{

    public GameObject FireNapalm;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 currPosition;
    public float delay;

    //private bool dirRight = true;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        currPosition = FireNapalm.transform.position;
        startPosition = currPosition - new Vector3(0,2,0);
        endPosition = currPosition + new Vector3(0,2,0);

        
    }

    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(DelayStart(delay));
        FireNapalm.transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time * speed + delay, 1.0f));
    }

    IEnumerator DelayStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        
    }
}
