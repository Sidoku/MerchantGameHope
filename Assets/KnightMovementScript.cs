using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovementScript : MonoBehaviour
{
    public float xaxis;
    public float yaxis;
    Vector3 currentpos;
    // Start is called before the first frame update
    void Start()
    {
       currentpos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= 1.34f)
        {
            xaxis = 0f;
            yaxis = 0.001f;
        }

        //This is to rotate the character when the x value is -ve.
        if (xaxis <0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //this will move the char.
        currentpos = new Vector3(currentpos.x + xaxis, currentpos.y + yaxis, currentpos.z);
        transform.position = currentpos;

     





    }
}
