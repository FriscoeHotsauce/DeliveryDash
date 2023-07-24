using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelController : MonoBehaviour
{
    //Dependencies
    public UpgradeHandler upgradeHandler;
    public TMP_Text maxSpeedText;

    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider rearLeft;
    public WheelCollider rearRight;

    public Transform frontLeftTransform;
    public Transform frontRightTransform;
    public Transform rearLeftTransform;
    public Transform rearRightTransform;

    public Rigidbody rigidBody;

    public float acceleration = 500f;
    public float firstGearAcceleration = 500f;
    public float secondGearAcceleration = 400f;
    public float thirdGearAcceleration = 300f;
    public float fourthGearAcceleration = 200f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    public float currentSpeed = 0f;
    public float maxSpeed = 5.5f;

    public bool allWheelDrive = false;
    public bool hasFallen = false;
    
    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    //Speedometer element(s)
    public Image spedometerImage;

    private void Start(){
        rigidBody = GetComponent<Rigidbody>();
        upgradeHandler = GameObject.FindGameObjectWithTag("UpgradeHandler").GetComponent<UpgradeHandler>();
        applyUpgrades();
    }

    private void FixedUpdate(){
        //calculate current velocity
        currentSpeed = Vector3.Magnitude(GetComponent<Rigidbody>().velocity);
        determineCurrentAccelerationGearCap();

        // Get forward and reverse inputs (should map to controllers)
        if(currentSpeed >= maxSpeed){
            currentAcceleration = 0f;
        } else {
            currentAcceleration = acceleration * Input.GetAxis("Vertical");
        }
        

        //get breaking input
        if(Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 1")){
            currentBreakingForce = breakingForce;
        } else {
            currentBreakingForce = 0f;
        }

        //Get steering input
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        applySteering();
        
        //Apply acceleration
        applyAcceleration();

        //apply breaking force
        applyBreakingForce();

        //rotate wheels
        updateWheel(frontLeft, frontLeftTransform);
        updateWheel(frontRight, frontRightTransform);
        updateWheel(rearLeft, rearLeftTransform);
        updateWheel(rearRight, rearRightTransform);


        updateSpedometer();
        evaluateHasFallen();
    }

    void determineCurrentAccelerationGearCap(){
        float secondGearThreshold = (maxSpeed * .25f);
        float thirdGearThreshold = (maxSpeed * .50f);
        float fourthGearThreshold = (maxSpeed * .75f);

        if(currentSpeed > fourthGearThreshold){
            acceleration = fourthGearAcceleration;
        } else if(currentSpeed > thirdGearThreshold){
            acceleration = thirdGearAcceleration;
        } else if(currentSpeed > secondGearThreshold){
            acceleration = secondGearAcceleration;
        } else if(currentSpeed > 0f){
            acceleration = firstGearAcceleration;
        } else {
            acceleration = 0f;
        }
    }

    void updateWheel(WheelCollider collider, Transform transform){
        //Get wheel collider state
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        
        //Set the transform
        transform.position = position;
        transform.rotation = rotation;
    }

    void applySteering(){
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
    }

    void applyAcceleration(){
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        //optionally add all wheel drive
        if(allWheelDrive){
            rearRight.motorTorque = currentAcceleration;
            rearLeft.motorTorque = currentAcceleration;
        }
    }

    void applyBreakingForce(){
        frontRight.brakeTorque = currentBreakingForce;
        frontLeft.brakeTorque = currentBreakingForce;
        rearLeft.brakeTorque = currentBreakingForce;
        rearRight.brakeTorque = currentBreakingForce;
    }

    public void applyUpgrades(){
        //acceleration
        firstGearAcceleration = upgradeHandler.getGearOneAcceleration();
        secondGearAcceleration = upgradeHandler.getGearTwoAcceleration();
        thirdGearAcceleration = upgradeHandler.getGearThreeAcceleration();
        fourthGearAcceleration = upgradeHandler.getGearFourAcceleration();
        //speed
        maxSpeed = upgradeHandler.getCurrentTopSpeed();
        maxTurnAngle = upgradeHandler.getCurrentTurnRadius();
        maxSpeedText.text = ""+Math.Round(maxSpeed*10f);

    }

    void updateSpedometer(){
        spedometerImage.fillAmount = currentSpeed / maxSpeed;
    }

    public void enableAllWheelDrive(){
        allWheelDrive = true;
    }

    void evaluateHasFallen(){
        if(gameObject.transform.rotation.z < 180){
            hasFallen = true;
        } else {
            hasFallen = false;
        }
    }

    public void setTopSpeed(float newTopSpeed){
        maxSpeed = newTopSpeed;
    }
}
