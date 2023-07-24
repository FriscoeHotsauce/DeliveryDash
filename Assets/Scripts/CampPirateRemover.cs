using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampPirateRemover : MonoBehaviour
{
    public UpgradeHandler upgradeHandler;

    // Start is called before the first frame update
    void Start()
    {
        upgradeHandler = GameObject.FindGameObjectWithTag("UpgradeHandler").GetComponent<UpgradeHandler>();
        if(upgradeHandler.campsite && upgradeHandler.pirateZone){
            Destroy(gameObject);
        }
    }
}
