using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected CharacterController control;
    protected Vector3 move = Vector3.zero;

    public float moveSpeed = 3f;
    public float turnSpeed = 90f;
    public float jumpSpeed = 5f;

    protected bool jump;

    protected Vector3 gravity = Vector3.zero;

    public virtual void Start()
    {
        control = GetComponent<CharacterController>();

        if(!control){
            Debug.LogError("Unit.Start() " + name + " has no CharacterController!");
            enabled = false;
        }
    }

    public virtual void Update()
    {
        move *= moveSpeed;

        if(!control.isGrounded){
            gravity += Physics.gravity * Time.deltaTime;
        }
        else{
            gravity = Vector3.zero;

            if(jump){
                gravity.y = jumpSpeed;
                jump = false;
            }
        }

        //move += gravity;
        control.Move(move * Time.deltaTime);
    }
}
