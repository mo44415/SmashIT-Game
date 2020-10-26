using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : Unit
{
    float cameraRotX = 0f;
    public float cameraPitchMax = 45f;
    Animator m_Animator;
    
    public override void Start()
    {
        m_Animator = GetComponent<Animator>();
        base.Start();
    }

    public override void Update()
    {
        //transform.Rotate(0f, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0f);

        cameraRotX -= Input.GetAxis("Mouse Y");
        cameraRotX = Mathf.Clamp(cameraRotX, -cameraPitchMax, cameraPitchMax);

        Camera.main.transform.forward = transform.forward;
        //Camera.main.transform.Rotate(cameraRotX, 0f, 0f);

        move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        bool hasHorizontalInput = !Mathf.Approximately(Input.GetAxis("Horizontal"), 0f);
        bool hasVerticalInput = !Mathf.Approximately(Input.GetAxis("Vertical"), 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("isWalking", isWalking);

        move.Normalize();

        move = transform.TransformDirection(move);

        if(Input.GetKeyDown(KeyCode.Space) && control.isGrounded){
            jump = true;
        }
        base.Update();
    }
}
