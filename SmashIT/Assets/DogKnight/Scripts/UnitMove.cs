using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : Unit
{
    
    public override void Start()
    {
        
        base.Start();
    }

    public override void Update()
    {

        //move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //move.Normalize();

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        camF.y = 0f; camF.Normalize();
        camR.y = 0f; camR.Normalize();

        move = (camF * vert) + (camR * horiz);
            
        
        if(Input.GetKeyDown(KeyCode.Space) && control.isGrounded){
            jump = true;
        }

        base.Update();
    }
}
