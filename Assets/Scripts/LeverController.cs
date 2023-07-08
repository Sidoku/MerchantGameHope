using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class LeverController : MonoBehaviour
{
    public GameObject BridgeObject;

    HingeJoint2D bridgeJoint;

    JointMotor2D tempMotor;

    bool isBridgeOpen = false;
    void Start()
    {
        bridgeJoint = BridgeObject.GetComponent<HingeJoint2D>();
        bridgeJoint.useMotor = true;
        tempMotor.motorSpeed = 0f;
        tempMotor.maxMotorTorque = 10000f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.ToString().Equals("PF Player"))
        {

            if (isBridgeOpen)
            {
                tempMotor = bridgeJoint.motor;
                tempMotor.motorSpeed = -20f;
                tempMotor.maxMotorTorque = 10000f;
                isBridgeOpen = false;
            }
            else
            {
                tempMotor = bridgeJoint.motor;
                tempMotor.motorSpeed = 20f;
                tempMotor.maxMotorTorque = 10000f;
                isBridgeOpen = false;
                isBridgeOpen = true;
            }
        }
    }

    private void Update()
    {
        bridgeJoint.motor = tempMotor;
    }
}
