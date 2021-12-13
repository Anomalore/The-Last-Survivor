using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{

    private Rigidbody rb;
    private Vector2 input;
    private Vector2 rawInput;
    [SerializeField]private int baseSpeed = 0;
    [SerializeField]private int playerRotationSpeed = 0;
    [SerializeField] Camera cam = null;
    PlayerCam playerCam;
    [SerializeField] LayerMask floor;
    [SerializeField] Health health;
    [SerializeField]Gun playerGun;
    [SerializeField] private AnimController animationController;
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
    private bool toggleRun = false;
    private float runTimer;
    [SerializeField]private float runTimerReset;
    [SerializeField]private float returnToForwardDirectionSpeed;
    private float currentSpeed;

    void Awake()
    {  
        animationController = GetComponent<AnimController>();
        playerCam = cam.GetComponent<PlayerCam>();
        runTimer = runTimerReset;
        rb = gameObject.GetComponent<Rigidbody>();
        input = Vector2.zero;
        floor = LayerMask.GetMask("Floor");
        health = GetComponent<Health>();
        playerGun= GetComponentInChildren<Gun>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    public bool isRunning ()
    {
        return Input.GetKey(KeyCode.LeftControl) == true && input.y > 0;
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
                animationController.TriggerJumpAnimation();
                StartCoroutine(animationController.Jump(1f));
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
        CamF = cam.transform.forward;
        CamR = cam.transform.right;
        float inputCheck = input.magnitude;   

        if(StopAimingTimer > 0)
        {
            inputCheck = 0.0f;
            StopAimingTimer -= Time.deltaTime;
            LookDirection = CamF;
            LookDirection.y = 0;
            
            rb.MoveRotation(Quaternion.LookRotation(LookDirection));
        }


        if(RMBdown)
        {
            StopAimingTimer = StopAimingSetTime;
            inputCheck = 0;
            RMBdown = false;
        }
        

        if(StopAimingTimer <= 0)
        {   
            if(inputCheck > 0 )
            {
                LookDirection =  CamF; 
                LookDirection.y = 0;
            }
            
            if(LookDirection.magnitude > Mathf.Epsilon) rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookDirection),Time.deltaTime * playerRotationSpeed));
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

        CamF = cam.transform.forward;
        CamR = cam.transform.right;

        CamF.y = 0;
        CamR.y = 0;

        CamF = CamF.normalized;
        CamR = CamR.normalized;

        Vector3 positionToMoveTo = CamF * rawInput.y + CamR * rawInput.x;

        if(isToggleRun)
        {
            if(toggleRun == true)
            {
                currentSpeed = baseSpeed * runSpeedMultiplyer;
            }
            else
            {
                currentSpeed = baseSpeed;
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.LeftControl) && rawInput.y > 0)
            {
                currentSpeed = baseSpeed * runSpeedMultiplyer;
            }
            else
            {
                currentSpeed = baseSpeed;
            }
        }
            
        rb.velocity = new Vector3(positionToMoveTo.x , 0, positionToMoveTo.z).normalized * 10f * currentSpeed * Time.fixedDeltaTime + new Vector3(0, rb.velocity.y, 0);

        if(jump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce ,rb.velocity.z);
        }



        
        if(rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - 0.5f ,rb.velocity.z);
        }

        if(StopAimingTimer > 0)
        {
            animationController.MovementAnimationNoAim(input);
        }
        else
        {
            animationController.MovementAnimationAim(rawInput, input, runSpeedMultiplyer);
        }

        animationController.setMovementAnimationSpeed(currentSpeed);

    }


    private void GetInput()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    
}
