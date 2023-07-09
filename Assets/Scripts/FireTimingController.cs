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

    private bool isActive;

    public float timer, interval = 2f;

    //private bool dirRight = true;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        currPosition = FireNapalm.transform.position;
        startPosition = currPosition - new Vector3(0,2,0);
        endPosition = currPosition + new Vector3(0,2,0);

        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            FireNapalm.GetComponent<Collider2D>().enabled = isActive;
            if(isActive )
            {
                FireNapalm.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            }
            else
            {
                FireNapalm.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            }
            isActive = !isActive;
            timer = 0;
        }
        // StartCoroutine(DelayStart(delay));
        //FireNapalm.transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time * speed + delay, 1.0f));
    }

    IEnumerator DelayStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        
    }
}
