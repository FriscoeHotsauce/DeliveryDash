using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Zone { Residential, Campsite, Pirate }

public class ObjectiveCompleter : MonoBehaviour
{

    public ObjectiveManager objectiveManager;
    public SphereCollider sphereCollider;
    public ParticleSystem particleSystem;
    public Zone zone = Zone.Residential;

    void Start(){
        objectiveManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ObjectiveManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter(){
        objectiveManager.completeDeliveryNode(gameObject);
        particleSystem.Stop();
        sphereCollider.enabled = false;
    }

    public void enableThings(){
        sphereCollider.enabled = true;
        particleSystem.Play();
        GameObject.FindGameObjectWithTag("ObjectivePointer").GetComponent<NextObjectiveLooker>().updateNextObjective(transform);
    }
}
