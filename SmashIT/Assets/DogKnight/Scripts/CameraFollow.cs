using UnityEngine;

public class CameraFollow : MonoBehaviour{

    public Transform target;
    public float smoothSpeed = 0.125f;
    Vector3 offset;

    public float RotationSpeed = 5.0f;

    void Start(){
        offset = transform.position - target.position;
    }

    void LateUpdate(){
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
        offset = camTurnAngle * offset;

        Vector3 newPos = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothSpeed);
        
        //transform.position = target.position + offset;
        transform.LookAt(target);
    }
}