using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;


public class GameManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public UpgradeHandler upgradeHandler;
    public ObjectiveManager objectiveManager;

    //cash
    public int cashOnHand = 0;
    public int cashBonus = 0;
    public int cashPerObjectiveMin = 15;
    public int cashPerObjectiveMax = 25;

    //time
    public float timeRemaining = 15f;
    public float timeBonusPerObjective = 0f;

    //packages
    public int packagesToDeliver = 10;

    //UI Elements
    public TMP_Text timerText;
    public TMP_Text maxSpeedText;
    public TMP_Text cashText;
    public TMP_Text packageText;
    public Transform cashAddSpawnerLocation;
    public Transform timeAddSpawnerLocation;
    public Transform cashAddPrefab;


    //prefixes
    public String packageTextPrefix = "Packages: ";
    public String cashTextPrefix = "Cash: $";

    public Random randy;

    // Start is called before the first frame update
    void Start()
    {
        //inject dependencies
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        upgradeHandler = GameObject.FindGameObjectWithTag("UpgradeHandler").GetComponent<UpgradeHandler>();
        objectiveManager = gameObject.GetComponent<ObjectiveManager>();

        //Grab initialization values
        cashOnHand = upgradeHandler.getAvailableCash();
        cashBonus = upgradeHandler.getCurrentCashBonus();
        timeBonusPerObjective = upgradeHandler.getCurrentTimeBonus();
        randy = new Random();
        packagesToDeliver = objectiveManager.getTotalDeliveryNodes();

        //Update UI elements
        updateCashText();
        updatePackageText();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        updateTimerText();
        if(timeRemaining < 0f){
            endDay();
        }
    }

    public void completeObjective(float timeToAdd){
        int cashGained = randy.Next(cashPerObjectiveMin, cashPerObjectiveMax) + cashBonus;
        cashOnHand += cashGained;
        upgradeHandler.setAvailableCash(cashOnHand);
        float timeAdded = timeToAdd + timeBonusPerObjective;
        timeRemaining += timeAdded;
        packagesToDeliver -= 1;
        updateCashText();
        updatePackageText();
        //Add indicator for cash add
        Transform cashAddObject = Instantiate(cashAddPrefab, cashAddSpawnerLocation);
        cashAddObject.GetComponent<TMP_Text>().text = "+ $"+cashGained;
        //Add indicator for time add
        Transform timeAddObject = Instantiate(cashAddPrefab, timeAddSpawnerLocation);
        timeAddObject.GetComponent<TMP_Text>().text = "+ "+timeAdded+"s";
    
    }

    private void updateTimerText(){
        timerText.text = String.Format("{0:.00}", Math.Round(timeRemaining, 2));
    }

    private void updateCashText(){
        cashText.text = cashTextPrefix + cashOnHand;
    }

    private void updatePackageText(){
        packageText.text = packageTextPrefix + packagesToDeliver;
    }

    public void endDay(){
        sceneLoader.loadUpgradesScene();
    }

    //Only use on the first objective, to give some buffer based on how far away it is from the player
    public void addTime(float timeToAdd){
        timeRemaining += timeToAdd;
    }
}
