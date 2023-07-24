using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ObjectiveManager : MonoBehaviour
{

    [SerializeField]
    public List<GameObject> deliveryNodes;
    public GameObject nextDeliveryNode;
    public GameManager gameManager;
    public DeliverySpawner deliverySpawner;
    public UpgradeHandler upgradeHandler;

    public float minDistanceToNextNode = 20f;

    // Start is called before the first frame update
    void Start()
    {
        upgradeHandler = GameObject.FindGameObjectWithTag("UpgradeHandler").GetComponent<UpgradeHandler>();
        deliverySpawner = GameObject.FindGameObjectWithTag("DeliverySpawner").GetComponent<DeliverySpawner>();
        if(deliverySpawner == null){
            Debug.Log("Couldn't find delivery spawner!");
        }
        gameManager = gameObject.GetComponent<GameManager>();
        deliveryNodes = filterNodes();
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distanceToNextObjective = selectNextObjective(playerPosition);
        float timeToAdd = (float) Math.Round(distanceToNextObjective / 10f, 0);
        //----- FIRST DAY BONUS -----
        if(upgradeHandler.firstDay){
            timeToAdd += 15f;
            upgradeHandler.firstDay = false;
        }
        gameManager.addTime(timeToAdd);
    }

    private List<GameObject> filterNodes(){
        List<GameObject> allNodes = new List<GameObject>(GameObject.FindGameObjectsWithTag("DeliveryNode"));
        List<GameObject> filteredNodes = new List<GameObject>();
        foreach(GameObject node in allNodes){
            Zone zone = node.GetComponent<ObjectiveCompleter>().zone;
            if(zone == Zone.Residential ||
                (zone == Zone.Campsite && upgradeHandler.campsite) ||
                (zone == Zone.Pirate && upgradeHandler.pirateZone)
            ){
                filteredNodes.Add(node);
            }
        }
        return filteredNodes;
    }
    

    public void completeDeliveryNode(GameObject completedObjective){
        deliveryNodes.Remove(completedObjective);
        deliverySpawner.spawnPackage(completedObjective.GetComponent<ObjectiveCompleter>().zone);

        if(deliveryNodes.Count > 0){
            Vector3 completedNodePosition = completedObjective.transform.position;
            float distanceToNextObjective = selectNextObjective(completedNodePosition);
            float timeToAdd = 1f + (float) Math.Round(distanceToNextObjective / 12f, 0) * 2f;
            gameManager.completeObjective(timeToAdd);
        } else {
            gameManager.completeObjective(0f);
            gameManager.endDay();
        }
        
    }

    public int getTotalDeliveryNodes(){
        return deliveryNodes.Count;
    }

    //I'd like this to be more robust and consider distance, but keep it simple for now
    private float selectNextObjective(Vector3 lastObjectivePosition){
        Random randy = new Random();
        int objectiveNodeIndex = randy.Next(0, deliveryNodes.Count);

        GameObject nextNode = deliveryNodes[objectiveNodeIndex];
        nextNode.GetComponent<ObjectiveCompleter>().enableThings();
        nextDeliveryNode = nextNode;
        float distanceToNextObjective = Vector3.Distance(nextDeliveryNode.transform.position, lastObjectivePosition);
        Debug.Log("Distance between objectives: "+distanceToNextObjective);
        return distanceToNextObjective;
    }
}
