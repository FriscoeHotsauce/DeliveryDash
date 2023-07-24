using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelfAfterTime : MonoBehaviour
{

    public float timeToLive = .25f;

    private float instantiationTime;
    // Start is called before the first frame update
    void Start()
    {
        instantiationTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > instantiationTime + timeToLive){
            Destroy(gameObject);
        }
        
    }
}
