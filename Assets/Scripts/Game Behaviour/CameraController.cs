using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject followObject;

    [SerializeField] private float desiredDistance;
    [SerializeField] float minClamp;
    [SerializeField] float maxClamp;
    Vector3 direction;

    private float xInput, yInput;
    Ray ray;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        direction = transform.forward;
    }

    private void Update() 
    {
        GetInput();
    }

    private void GetInput()
    {
        xInput = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * 360;
        yInput = -Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * 360;    
    }

    void FixedUpdate()
    {

        Vector3 desiredPosition;
        
        Quaternion q = Quaternion.AngleAxis(xInput, transform.up);
        Quaternion w = Quaternion.AngleAxis(yInput, transform.right);

        float angleDifference = Vector3.Angle(w * direction, Vector3.up);
        
        if(maxClamp > angleDifference && angleDifference > minClamp)
        {
            direction = w * q * direction;
        }
        else
        {
            direction = q * direction;
        }

        ray = new Ray(followObject.transform.position, -direction);

        bool wallInWay = Physics.Raycast(ray, out RaycastHit hit, desiredDistance);

        if(wallInWay)
        {
            desiredPosition = ray.origin + ray.direction.normalized * hit.distance;
            transform.position = desiredPosition;
        }
        else
        {
            desiredPosition =  ray.origin + ray.direction.normalized * desiredDistance;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, 1f);
        }

        
        transform.LookAt(followObject.transform);
    }

    private Vector3 GetNearClipPlaneHalfExtents()
    {
        float ratio = Camera.main.pixelWidth / Camera.main.pixelHeight;
        Vector3[] frustumCorners = new Vector3[4];
        Camera.main.CalculateFrustumCorners(new Rect(0, 0, 1, 1), Camera.main.nearClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);

        Vector2 min = frustumCorners[0];
        Vector2 max = frustumCorners[0];
        for (int i = 1; i < 4; i++)
        {
            min.x = Mathf.Min(min.x, frustumCorners[i].x);
            min.y = Mathf.Min(min.y, frustumCorners[i].y);
            max.x = Mathf.Max(max.x, frustumCorners[i].x);
            max.y = Mathf.Max(max.y, frustumCorners[i].y);
        }

        // Note the very small z-value since boxcast doesn't take a plane, it takes a box
        // This can be adjusted if you need more tolerance
        return new Vector3((max.x - min.x) / 2.0f, (max.y - min.y) / 2.0f, 0.01f);
    }
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle<90 || angle>270)// if angle in the critic region...
        {       
            if (angle>180) angle -= 360;  // convert all angles to -180..+180
            if (max>180) max -= 360;
            if (min>180) min -= 360;
        } 

        angle = Mathf.Clamp(angle, min, max);
        if (angle<0) angle += 360;  // if angle negative, convert to 0..360
        return angle;
    }


}
