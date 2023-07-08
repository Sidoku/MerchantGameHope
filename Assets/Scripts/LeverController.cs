using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject BridgeObject;

    //public HingeJoint2D bridgeJoint;

    bool isBridgeOpen = false;
    void Start()
    {
        //bridgeJoint = BridgeObject.GetComponent<HingeJoint2D>();
       // bridgeJoint.useMotor = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //var motor = bridgeJoint.motor;

        Debug.Log(collision.gameObject.name.ToString());
        if (collision.gameObject.name.ToString().Equals("PF Player"))
        {
            Debug.Log("This works");
            if (isBridgeOpen)
            {
                BridgeObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                isBridgeOpen = false;
            }
            else
            {
                BridgeObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                isBridgeOpen = true;
            }
        }
    }

    private void OpenBridge(JointMotor2D motor)
    {
        //motor.motorSpeed = 20.0f;
    }

    private void CloseBridge(JointMotor2D motor) 
    { 
        //motor.motorSpeed = -20.0f;
    }
    
}
