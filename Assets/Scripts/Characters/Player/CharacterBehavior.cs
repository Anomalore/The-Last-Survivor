using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{

    private Rigidbody rb;
    private Vector2 input;
    [SerializeField]private int speed = 0;
    [SerializeField] Camera cam = null;
    [SerializeField] LayerMask floor;
    [SerializeField] float cameraRayLength = 100f;
    [SerializeField] Health health;
    [SerializeField]Gun playerGun;
    [SerializeField] private float sensitivity;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce;

    [Header("Tweaking")]
    [SerializeField] float StopAimingTimer = 0.0f;
    private float distToGround;
    private bool jump;
    Vector3 LookDirection;
    

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        input = Vector2.zero;
        floor = LayerMask.GetMask("Floor");
        health = GetComponent<Health>();
        playerGun= GetComponentInChildren<Gun>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update() 
    {  
        if(health.getHealth() > 0)
        {
            if(Input.GetButtonDown("Jump") && IsGrounded())
            {
                jump = true;
            }
            if(IsGrounded() == false)
            {
                jump = false;
            }

            GetInput();
            if(Input.GetMouseButtonDown(0) && playerGun._canShoot)
            {
                playerGun.ShootBullet();
            }
        }

        if (health.getHealth() > 0)
        {
            LookAt();
        }
    }

    private bool IsGrounded()  
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void LookAt()
    {
        Vector3 CamF = cam.transform.forward;
        Vector3 CamR = cam.transform.right;
        float inputCheck = input.magnitude;   
        
        if(StopAimingTimer > 0)
        {
            inputCheck = 0.0f;
            StopAimingTimer -= Time.deltaTime;
        }


        if(Input.GetMouseButtonDown(0))
        {
            StopAimingTimer = 1.0f;
            inputCheck = 0;
            LookDirection = CamF;
            LookDirection.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookDirection), Time.deltaTime * speed);
            return;
        }
        

        if(inputCheck > 0 && StopAimingTimer <= 0)
        {   
            LookDirection = input.y * CamF + input.x * CamR; 
            LookDirection.y = 0;
        } 

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookDirection), Time.deltaTime * speed);

    }

    void FixedUpdate()
    {
        Move(); 
    }

    private void Move()
    {
        Vector3 CamF = cam.transform.forward;
        Vector3 CamR = cam.transform.right;

        CamF.y = 0;
        CamR.y = 0;

        CamF = CamF.normalized;
        CamR = CamR.normalized;

        Vector3 positionToMoveTo = CamF * input.y + CamR * input.x;
        rb.MovePosition((Vector3)transform.position + (positionToMoveTo * speed * Time.fixedDeltaTime));

        animator.SetFloat("VelX", input.x);
        animator.SetFloat("VelY", input.y);

        if(jump && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce ,rb.velocity.z);
        }
    }


    private void GetInput()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
