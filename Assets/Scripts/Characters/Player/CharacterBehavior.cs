using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{

    private Rigidbody rb;
    private Vector2 input;
    private Vector2 rawInput;
    [SerializeField]private int speed = 0;
    [SerializeField]private int playerRotationSpeed = 0;
    [SerializeField] Camera cam = null;
    PlayerCam playerCam;
    [SerializeField] LayerMask floor;
    [SerializeField] Health health;
    [SerializeField]Gun playerGun;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce;

    [Header("Tweaking")]
    [SerializeField] float StopAimingTimer = 0.0f;
    [SerializeField] float StopAimingSetTime;
    [SerializeField]private float runSpeedMultiplyer;
    [SerializeReference]private bool isToggleRun;
    private float distToGround;
    private bool jump;
    private bool RMBdown;
    Vector3 LookDirection;
    Vector3 CamF,CamR;
    float slerpTimer = default;
    private bool toggleRun = false;
    private float runTimer;
    [SerializeField]private float runTimerReset;

    void Awake()
    {
        playerCam = cam.GetComponent<PlayerCam>();
        runTimer = runTimerReset;
        slerpTimer = 0.0f;
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
            GetInput();
            LookAt();

            if(Input.GetMouseButtonDown(0))
            {
                RMBdown = true;
            }  

            if(Input.GetButtonDown("Jump") && IsGrounded())
            {
                jump = true;
            }
            if(IsGrounded() == false)
            {
                jump = false;
            }
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                toggleRun = !toggleRun;
            }

            if(rawInput.magnitude == 0)
            {
                if(runTimer <=0) toggleRun = false;
                else runTimer -= Time.deltaTime;
            }
            else
            {
                runTimer = runTimerReset;
            }

            if(Input.GetMouseButtonDown(0) && playerGun._canShoot)
            {
                playerGun.ShootBullet();
            }

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
            LookDirection = CamF;
            LookDirection.y = 0;
            slerpTimer += Time.deltaTime;
            if (slerpTimer <= StopAimingTimer/2)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookDirection), Time.deltaTime * 75f);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(LookDirection);
            }
        }


        if(RMBdown)
        {
            slerpTimer = 0.0f;
            StopAimingTimer = StopAimingSetTime;
            inputCheck = 0;
            RMBdown = false;
        }
        

        if(StopAimingTimer <= 0)
        {   
            if(inputCheck > 0 )
            {
                LookDirection = input.y * CamF + input.x * CamR; 
                LookDirection.y = 0;
            }
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookDirection),Time.deltaTime * playerRotationSpeed);
        } 




    }

    void FixedUpdate()
    {
        if (health.getHealth() > 0)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        Vector3 movePosition;

        CamF = cam.transform.forward;
        CamR = cam.transform.right;

        CamF.y = 0;
        CamR.y = 0;

        CamF = CamF.normalized;
        CamR = CamR.normalized;

        if(jump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce ,rb.velocity.z);
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - 0.5f ,rb.velocity.z);
        }

        Vector3 positionToMoveTo = CamF * input.y + CamR * input.x;

        if(isToggleRun)
        {
            if(toggleRun == true)
            {
                movePosition = (positionToMoveTo * speed * Time.fixedDeltaTime * runSpeedMultiplyer);
            }
            else
            {
                movePosition = (positionToMoveTo * speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.LeftControl) && input.y >= 0)
            {
                movePosition =  (positionToMoveTo * speed * Time.fixedDeltaTime * runSpeedMultiplyer);
            }
            else
            {
                movePosition = (positionToMoveTo * speed * Time.fixedDeltaTime);
            }
        }

        rb.MovePosition((Vector3)transform.position + movePosition);


        if(animator != null)
        {
            animator.SetFloat("VelX", input.x);
            animator.SetFloat("VelY", input.y);
        }


    }


    private void GetInput()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    
}
