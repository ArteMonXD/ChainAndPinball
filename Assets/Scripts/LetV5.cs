using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetV5 : MonoBehaviour
{
    [SerializeField] private HingeJoint hingleJoint;
    [SerializeField] private float speedABS = 100f;
    [SerializeField] private float timePeriods = 0.5f;
    private float currentTimer;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = speedABS;
        ApplySpeed();
    }
    private void Update()
    {
        Periods();
    }
    private void Periods()
    {
        if (currentTimer < timePeriods)
        {
            currentTimer += Time.deltaTime;
        }
        else
        {
            SwitchSpeed();
            currentTimer = 0f;
        }
    }
    private void SwitchSpeed()
    {
        if(currentSpeed > 0)
        {
            currentSpeed = -speedABS;
        }
        else if (currentSpeed < 0)
        {
            currentSpeed = speedABS;
        }
        ApplySpeed();
    }
    private void ApplySpeed()
    { 
        JointMotor jM = hingleJoint.motor;
        jM.targetVelocity = currentSpeed;
        hingleJoint.motor = jM;
    }
}
