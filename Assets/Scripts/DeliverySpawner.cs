using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class DeliverySpawner : MonoBehaviour
{
    public Transform instantiationPoint;
    public List<Transform> residentialPackages;
    public List<Transform> piratePackages;
    public List<Transform> campsitePackages;
    private Random randy;

    // Start is called before the first frame update
    void Start()
    {
        randy = new Random();
    }

    public void spawnPackage(Zone zone){
        int packagePrefabIndex = 0;
        Transform instantiated = null;
        switch(zone){
            case Zone.Residential:
                packagePrefabIndex = randy.Next(0, residentialPackages.Count);
                instantiated = Instantiate(residentialPackages[packagePrefabIndex], instantiationPoint.position, instantiationPoint.rotation);
                break;
            case Zone.Pirate:
                packagePrefabIndex = randy.Next(0, piratePackages.Count);
                instantiated = Instantiate(piratePackages[packagePrefabIndex], instantiationPoint.position, instantiationPoint.rotation);
                break;
            case Zone.Campsite:
                packagePrefabIndex = randy.Next(0, campsitePackages.Count);
                instantiated = Instantiate(campsitePackages[packagePrefabIndex], instantiationPoint.position, instantiationPoint.rotation);
                break;
        }
    }
}
