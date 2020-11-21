using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterPhysics : MonoBehaviour
{

    Vector3 moveVector;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    void Update()
    {

        moveVector = Vector3.zero;

        if (controller.isGrounded == false)
        {
            moveVector += Physics.gravity;
        }

        controller.Move(moveVector * Time.deltaTime);


    }

}