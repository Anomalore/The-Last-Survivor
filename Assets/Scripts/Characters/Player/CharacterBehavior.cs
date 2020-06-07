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
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        input = Vector2.zero;
        floor = LayerMask.GetMask("Floor");
    }

    private void Update() 
    {
        GetInput();
    }

    private void LookAt()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit, cameraRayLength, floor))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0.0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            GameObject PlayerMesh = gameObject.transform.GetChild(0).gameObject;
            PlayerMesh.transform.rotation = newRotation;
        }


    }

    void FixedUpdate()
    {
        Vector3 positionToMoveTo = new Vector3(input.x, 0.0f, input.y);
        rb.MovePosition((Vector3)transform.position + (positionToMoveTo * speed * Time.fixedDeltaTime));
        LookAt();
    }

    private void GetInput()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
