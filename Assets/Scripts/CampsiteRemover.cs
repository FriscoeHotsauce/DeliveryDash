using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampsiteRemover : MonoBehaviour
{
    public UpgradeHandler upgradeHandler;

    // Start is called before the first frame update
    void Start()
    {
        upgradeHandler = GameObject.FindGameObjectWithTag("UpgradeHandler").GetComponent<UpgradeHandler>();
        if(upgradeHandler.campsite){
            Destroy(gameObject);
        }
    }
}
