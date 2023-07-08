using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class LeverController : MonoBehaviour
{
    public GameObject BridgeObject;

<<<<<<< Updated upstream
    //public HingeJoint2D bridgeJoint;
=======
    HingeJoint2D bridgeJoint;

    JointMotor2D tempMotor;
>>>>>>> Stashed changes

    bool isBridgeOpen = false;
    void Start()
    {
<<<<<<< Updated upstream
        //bridgeJoint = BridgeObject.GetComponent<HingeJoint2D>();
       // bridgeJoint.useMotor = true;
=======
        bridgeJoint = BridgeObject.GetComponent<HingeJoint2D>();
        bridgeJoint.useMotor = true;
        tempMotor.motorSpeed = 0f;
        tempMotor.maxMotorTorque = 10000f;
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

<<<<<<< Updated upstream
        //var motor = bridgeJoint.motor;

=======
>>>>>>> Stashed changes
        Debug.Log(collision.gameObject.name.ToString());
        if (collision.gameObject.name.ToString().Equals("PF Player"))
        {
            Debug.Log("This works");
            if (isBridgeOpen)
            {
<<<<<<< Updated upstream
                BridgeObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
=======
                tempMotor = bridgeJoint.motor;
                tempMotor.motorSpeed = -20f;
                tempMotor.maxMotorTorque = 10000f;
                Debug.Log("The current motor speed" + bridgeJoint.motor.motorSpeed);
>>>>>>> Stashed changes
                isBridgeOpen = false;
            }
            else
            {
<<<<<<< Updated upstream
                BridgeObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
=======
                tempMotor = bridgeJoint.motor;
                tempMotor.motorSpeed = 20f;
                tempMotor.maxMotorTorque = 10000f;
                Debug.Log("The current motor speed" + bridgeJoint.motor.motorSpeed);
                isBridgeOpen = false;
>>>>>>> Stashed changes
                isBridgeOpen = true;
            }
        }
    }

    private void Update()
    {
<<<<<<< Updated upstream
        //motor.motorSpeed = 20.0f;
    }

    private void CloseBridge(JointMotor2D motor) 
    { 
        //motor.motorSpeed = -20.0f;
    }
    
=======
        bridgeJoint.motor = tempMotor;
    }
>>>>>>> Stashed changes
}
