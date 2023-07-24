using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateRemover : MonoBehaviour
{
    public UpgradeHandler upgradeHandler;

    // Start is called before the first frame update
    void Start()
    {
        upgradeHandler = GameObject.FindGameObjectWithTag("UpgradeHandler").GetComponent<UpgradeHandler>();
        if(upgradeHandler.pirateZone){
            Destroy(gameObject);
        }
    }
}
