using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextObjectiveLooker : MonoBehaviour
{
    public Transform lookTarget;
    public Transform positionTarget;
    public float smoothSpeed = 0.125f;

    void FixedUpdate(){
        Vector3 desiredPosition = positionTarget.position; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(lookTarget);
    }

    public void updateNextObjective(Transform nextOjbective){
        lookTarget = nextOjbective;
    }

}

