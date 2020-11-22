using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected CharacterController control;
    protected Transform m_Transform;
    protected Animator m_Animator;
    protected Rigidbody m_Rigidbody;
    protected Vector3 move = Vector3.zero;

    public float moveSpeed = 3f;
    public float turnSpeed = 90f;
    public float jumpSpeed = 5f;
    public Transform cam;

    protected bool jump;

    protected Vector3 gravity = Vector3.zero;

    public virtual void Start()
    {
        control = GetComponent<CharacterController>();
        m_Transform = GetComponent<Transform>();
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();

        if(!control){
            Debug.LogError("Unit.Start() " + name + " has no CharacterController!");
            enabled = false;
        }
    }

    public virtual void Update()
    {

        bool hasHorizontalInput = !Mathf.Approximately(Input.GetAxis("Horizontal"), 0f);
        bool hasVerticalInput = !Mathf.Approximately(Input.GetAxis("Vertical"), 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("isWalking", isWalking);
        
        move = move * moveSpeed;

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

        Vector3 angles = cam.rotation.eulerAngles;
        
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) m_Transform.eulerAngles = new Vector3(0.0f, angles.y + 45, 0.0f);
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) m_Transform.eulerAngles = new Vector3(0.0f, angles.y + 135, 0.0f);
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) m_Transform.eulerAngles = new Vector3(0.0f, angles.y + 225, 0.0f);
        else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) m_Transform.eulerAngles = new Vector3(0.0f, angles.y + 315, 0.0f);
        else if(Input.GetKey(KeyCode.W)) m_Transform.eulerAngles = new Vector3(0.0f, angles.y, 0.0f);
        else if(Input.GetKey(KeyCode.D)) m_Transform.eulerAngles = new Vector3(0.0f, angles.y + 90, 0.0f);
        else if(Input.GetKey(KeyCode.S)) m_Transform.eulerAngles = new Vector3(0.0f, angles.y + 180, 0.0f);
        else if(Input.GetKey(KeyCode.A)) m_Transform.eulerAngles = new Vector3(0.0f, angles.y + 270, 0.0f);
        move += gravity;
        //transform.Translate(move * Time.deltaTime);
        control.Move(move * Time.deltaTime);
        //m_Rigidbody.MovePosition(m_Rigidbody.position + move * m_Animator.deltaPosition.magnitude);
    }
}

