using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform lookTarget;
    public Transform cameraPositionTarget;
    public float smoothSpeed = 0.125f;
    public Vector3 cameraOffset;


    void FixedUpdate(){
        Vector3 desiredPosition = cameraPositionTarget.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(lookTarget);
    }
}
