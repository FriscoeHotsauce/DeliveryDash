using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDelagate : MonoBehaviour
{

    public SceneLoader sceneLoader;
    public UpgradeHandler upgradeHandler;
    public TMP_Text currentCashText;
    public int availableCash = 0;

    //AWD button
    public Button awdButton;

    //Speed Buttons
    public Button speedButtonOne;
    public Button speedButtonTwo;
    public Button speedButtonThree;
    public TMP_Text topSpeedText;

    //Acceleration Buttons
    public Button accelerationButtonOne;
    public Button accelerationButtonTwo;
    public Button accelerationButtonThree;

    //Turn Radius
    public Button turnRadiusButtonOne;
    public Button turnRadiusButtonTwo;
    public Button turnRadiusButtonThree;
    public TMP_Text turnRadiusText;

    //Zone Buttons
    public Button campsiteButton;
    public Button piratesButton;

    //Cash Buttons
    public Button cashButtonOne;
    public Button cashButtonTwo;
    public Button cashButtonThree;
    public TMP_Text cashBonusText;

    //Time Buttons
    public Button timeButtonOne;
    public Button timeButtonTwo;
    public Button timeButtonThree;
    public TMP_Text timeBonusText;
    

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        upgradeHandler = GameObject.FindGameObjectWithTag("UpgradeHandler").GetComponent<UpgradeHandler>();
        availableCash = upgradeHandler.getAvailableCash();
        evaluateButtons();
        updateCashText();
        updateCashBonusText();
        updateTimeBonusText();
    }

    public void evaluateButtons(){

        //awd button
        awdButton.interactable = evalCost(awdButton) && !upgradeHandler.allWheelDrive;

        //speedButtons
        speedButtonOne.interactable = evalCost(speedButtonOne) && !upgradeHandler.topSpeedOne;
        speedButtonTwo.interactable = evalCost(speedButtonTwo) && upgradeHandler.topSpeedOne && !upgradeHandler.topSpeedTwo;
        speedButtonThree.interactable = evalCost(speedButtonThree) && upgradeHandler.topSpeedTwo && !upgradeHandler.topSpeedThree;

        //acceleration buttons
        accelerationButtonOne.interactable = evalCost(accelerationButtonOne) && !upgradeHandler.accelerationOne;
        accelerationButtonTwo.interactable = evalCost(accelerationButtonTwo) && upgradeHandler.accelerationOne && !upgradeHandler.accelerationTwo;
        accelerationButtonThree.interactable = evalCost(accelerationButtonThree) && upgradeHandler.accelerationTwo && !upgradeHandler.accelerationThree;

        //turn radius buttons
        turnRadiusButtonOne.interactable = evalCost(turnRadiusButtonOne) && !upgradeHandler.turnRadiusOne;
        turnRadiusButtonTwo.interactable = evalCost(turnRadiusButtonTwo) && upgradeHandler.turnRadiusOne && !upgradeHandler.turnRadiusTwo;
        turnRadiusButtonThree.interactable = evalCost(turnRadiusButtonThree) && upgradeHandler.turnRadiusTwo && !upgradeHandler.turnRadiusThree;

        //Location buttons
        campsiteButton.interactable = evalCost(campsiteButton) && !upgradeHandler.campsite;
        piratesButton.interactable = evalCost(piratesButton) && !upgradeHandler.pirateZone;

        //Cash buttons
        cashButtonOne.interactable = evalCost(cashButtonOne) && !upgradeHandler.cashBonusOne;
        cashButtonTwo.interactable = evalCost(cashButtonTwo) && upgradeHandler.cashBonusOne && !upgradeHandler.cashBonusTwo;
        cashButtonThree.interactable = evalCost(cashButtonThree) && upgradeHandler.cashBonusTwo && !upgradeHandler.cashBonusThree;

        //Time buttons
        timeButtonOne.interactable = evalCost(timeButtonOne) && !upgradeHandler.timeDeliveryBonusOne;
        timeButtonTwo.interactable = evalCost(timeButtonTwo) && upgradeHandler.timeDeliveryBonusOne && !upgradeHandler.timeDeliveryBonusTwo;
        timeButtonThree.interactable = evalCost(timeButtonThree) && upgradeHandler.timeDeliveryBonusTwo && !upgradeHandler.timeDeliveryBonusThree;

    }


    public bool evalCost(Button button){
        return button.GetComponent<UpgradeCost>().getCost() <= availableCash;
    }

    //----- AWD -----
    public void buyAllWheelDrive(){
        upgradeHandler.allWheelDrive = true;
        deductAndEvaluate(awdButton.GetComponent<UpgradeCost>().getCost());
    }


    //----- Speed -----
    public void buySpeedOne(){
        upgradeHandler.topSpeedOne = true;
        deductAndEvaluate(speedButtonOne.GetComponent<UpgradeCost>().getCost());
    }

    public void buySpeedTwo(){
        upgradeHandler.topSpeedTwo = true;
        deductAndEvaluate(speedButtonTwo.GetComponent<UpgradeCost>().getCost());
    }

    public void buySpeedThree(){
        upgradeHandler.topSpeedThree = true;
        deductAndEvaluate(speedButtonThree.GetComponent<UpgradeCost>().getCost());
    }

    //----- Acceleration -----
    public void buyAccelerationOne(){
        upgradeHandler.accelerationOne = true;
        deductAndEvaluate(accelerationButtonOne.GetComponent<UpgradeCost>().getCost());
    }

    public void buyAccelerationTwo(){
        upgradeHandler.accelerationTwo = true;
        deductAndEvaluate(accelerationButtonTwo.GetComponent<UpgradeCost>().getCost());
    }

    public void buyAccelerationThree(){
        upgradeHandler.accelerationThree = true;
        deductAndEvaluate(accelerationButtonThree.GetComponent<UpgradeCost>().getCost());
    }

    //----- Turn Radius -----
    public void buyTurnRadiusOne(){
        upgradeHandler.turnRadiusOne = true;
        deductAndEvaluate(turnRadiusButtonOne.GetComponent<UpgradeCost>().getCost());
    }

    public void buyTurnRadiusTwo(){
        upgradeHandler.turnRadiusTwo = true;
        deductAndEvaluate(turnRadiusButtonTwo.GetComponent<UpgradeCost>().getCost());
    }

    public void buyTurnRadiusThree(){
        upgradeHandler.turnRadiusThree = true;
        deductAndEvaluate(turnRadiusButtonThree.GetComponent<UpgradeCost>().getCost());
    }

    //----- Locations -----
    public void buyCampsite(){
        upgradeHandler.campsite = true;
        deductAndEvaluate(campsiteButton.GetComponent<UpgradeCost>().getCost());
    }

    public void buyPirates(){
        upgradeHandler.pirateZone = true;
        deductAndEvaluate(piratesButton.GetComponent<UpgradeCost>().getCost());
    }

    //----- Cash -----
    public void updateCashBonusText(){
        cashBonusText.text = "Current Cash Bonus: $"+ upgradeHandler.getCurrentCashBonus() +"\n(per delivery)";
    }

    public void buyCashBonusOne(){
        upgradeHandler.cashBonusOne = true;
        deductAndEvaluate(cashButtonOne.GetComponent<UpgradeCost>().getCost());
        updateCashBonusText();
    }

    public void buyCashBonusTwo(){
        upgradeHandler.cashBonusTwo = true;
        deductAndEvaluate(cashButtonTwo.GetComponent<UpgradeCost>().getCost());
        updateCashBonusText();
    }

    public void buyCashBonusThree(){
        upgradeHandler.cashBonusThree = true;
        deductAndEvaluate(cashButtonThree.GetComponent<UpgradeCost>().getCost());
        updateCashBonusText();
    }

    //----- Time -----
    public void updateTimeBonusText(){
        timeBonusText.text = "Current Time Bonus: " + upgradeHandler.getCurrentTimeBonus() +"s";
    }
    
    public void buyTimeBonusOne(){
        upgradeHandler.timeDeliveryBonusOne = true;
        deductAndEvaluate(timeButtonOne.GetComponent<UpgradeCost>().getCost());
        updateTimeBonusText();
    }

    public void buyTimeBonusTwo(){
        upgradeHandler.timeDeliveryBonusTwo = true;
        deductAndEvaluate(timeButtonTwo.GetComponent<UpgradeCost>().getCost());
        updateTimeBonusText();
    }

    public void buyTimeBonusThree(){
        upgradeHandler.timeDeliveryBonusThree = true;
        deductAndEvaluate(timeButtonThree.GetComponent<UpgradeCost>().getCost());
        updateTimeBonusText();
    }



    public void deductAndEvaluate(int cost){
        availableCash -= cost;
        evaluateButtons();
        updateCashText();
    }

    public void updateCashText(){
        currentCashText.text = "Cash:\n$" + availableCash;
    }

    public void endUpgrades(){
        upgradeHandler.setAvailableCash(availableCash);
        sceneLoader.loadMainScene();
    }

    public void endGame(){
        sceneLoader.exitGame();
    }
}
