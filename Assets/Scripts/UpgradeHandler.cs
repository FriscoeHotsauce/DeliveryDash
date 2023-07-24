using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeHandler : MonoBehaviour
{

    public int availableCash = 0;
    public bool firstDay = true;

    //Upgrade booleans
    //One Time upgrades
    public bool allWheelDrive = false;
    public bool campsite = false;
    public bool pirateZone = false;

    //Top Speed Upgrades
    public float defaultTopSpeed = 6.5f;
    public int defaultTopSpeedDisplay = 65;
    public bool topSpeedOne = false;
    public float topSpeedOneValue = 7.5f;
    public int topSpeedDisplayValueOne = 75;
    public bool topSpeedTwo = false;
    public float topSpeedTwoValue = 8.5f;
    public int topSpeedDisplayValueTwo = 85;
    public bool topSpeedThree = false;
    public float topSpeedThreeValue = 9.5f;
    public int topSpeedDisplayValueThree = 95;

    //Acceleration Upgrades
    public bool accelerationOne = false;
    public bool accelerationTwo = false;
    public bool accelerationThree = false;

    //Turn Radius Upgrades
    public float defaultTurnRadius = 15f;
    public bool turnRadiusOne = false;
    public float turnRadiusOneValue = 17.5f;
    public bool turnRadiusTwo = false;
    public float turnRadiusTwoValue = 20f;
    public bool turnRadiusThree = false;
    public float turnRadiusThreeValue = 22.5f;


    //Cash Bonus Upgrades
    public bool cashBonusOne = false;
    public int cashBonusOneValue = 5;
    public bool cashBonusTwo = false;
    public int cashBonusTwoValue = 12;
    public bool cashBonusThree = false;
    public int cashBonusThreeValue = 19;

    //Time Delivery Bonus Upgrades
    public bool timeDeliveryBonusOne = false;
    public float timeDeliveryBonusOneValue = 5.0f;
    public bool timeDeliveryBonusTwo = false;
    public float timeDeliveryBonusTwoValue = 9.0f;
    public bool timeDeliveryBonusThree = false;
    public float timeDeliveryBonusThreeValue = 12.0f;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    public void purchaseTopSpeedOne(){
        topSpeedOne = true;
    }

    public void purchaseTopSpeedTwo(){
        topSpeedTwo = true;
    }

    public void setAvailableCash(int cash){
        availableCash = cash;
    }

    public int getAvailableCash(){
        return availableCash;
    }

    public int getCurrentCashBonus(){
        if(cashBonusThree){
            return cashBonusThreeValue;
        } else if(cashBonusTwo){
            return cashBonusTwoValue;
        } else if(cashBonusOne){
            return cashBonusOneValue;
        } else {
            return 0;
        }
    }

    public float getCurrentTimeBonus(){
        if(timeDeliveryBonusThree){
            return timeDeliveryBonusThreeValue;
        } else if(timeDeliveryBonusTwo){
            return timeDeliveryBonusTwoValue;
        } else if(timeDeliveryBonusOne){
            return timeDeliveryBonusOneValue;
        } else {
            return 0.0f;
        }
    }

    public float getCurrentTopSpeed(){
        if(topSpeedThree){
            return topSpeedThreeValue;
        } else if(topSpeedTwo){
            return topSpeedTwoValue;
        } else if(topSpeedOne){
            return topSpeedOneValue;
        } else {
            return defaultTopSpeed;
        }
    }

    public int getCurrentTopSpeedDisplayValue(){
        if(topSpeedThree){
            return topSpeedDisplayValueThree;
        } else if(topSpeedTwo){
            return topSpeedDisplayValueTwo;
        } else if(topSpeedOne){
            return topSpeedDisplayValueOne;
        } else {
            return defaultTopSpeedDisplay;
        }
    }

    public float getCurrentTurnRadius(){
        if(turnRadiusThree){
            return turnRadiusThreeValue;
        } else if(turnRadiusTwo){
            return turnRadiusTwoValue;
        } else if(turnRadiusOne){
            return turnRadiusOneValue;
        } else {
            return defaultTurnRadius;
        }
    }
    /*
        Default gear acceleration:
        firstGearAcceleration = 500f;
        public float secondGearAcceleration = 400f;
        public float thirdGearAcceleration = 300f;
        fourthGearAcceleration = 200f;
    */

    public float getGearOneAcceleration(){
        if(accelerationThree){
            return 875f;
        } else if(accelerationTwo){
            return 750f;
        } else if(accelerationOne){
            return 625f;
        } else {
            return 500f;
        }
    }

    public float getGearTwoAcceleration(){
        if(accelerationThree){
            return 700f;
        } else if(accelerationTwo){
            return 600f;
        } else if(accelerationOne){
            return 500f;
        } else {
            return 400f;
        }
    }

    public float getGearThreeAcceleration(){
        if(accelerationThree){
            return 525f;
        } else if(accelerationTwo){
            return 450f;
        } else if(accelerationOne){
            return 375f;
        } else {
            return 300f;
        }
    }

    public float getGearFourAcceleration(){
        if(accelerationThree){
            return 350f;
        } else if(accelerationTwo){
            return 300f;
        } else if(accelerationOne){
            return 250f;
        } else {
            return 200f;
        }
    }

    
}
