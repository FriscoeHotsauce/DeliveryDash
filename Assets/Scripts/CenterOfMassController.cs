using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassController : MonoBehaviour
{

    public Vector3 centerOfMass;

    // Start is called before the first frame update
    void Start()
    {
        centerOfMass = GetComponent<Rigidbody>().centerOfMass;
    }
}
