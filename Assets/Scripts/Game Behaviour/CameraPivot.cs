using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{

    [SerializeField] private Transform followObject;
    private float xInput, yInput;
    [SerializeField] private float Sensetivity;
    [SerializeField] private float minClamp;
    [SerializeField] private float maxClamp;
    private float thisRotX, thisRotY;
    [SerializeField] private float cameraMoveSpeed;

    void Start()
    {
        Vector3 thisRot;
        thisRot = transform.localRotation.eulerAngles;
        thisRotX = thisRot.x;
        thisRotY = thisRot.y;
    }

    void Update()
    {
        GetInput();

        thisRotY += xInput * Sensetivity * Time.deltaTime;
        thisRotX += yInput * Sensetivity * Time.deltaTime;

        thisRotX = Mathf.Clamp(thisRotX, minClamp, maxClamp);

        Quaternion localRot = Quaternion.Euler(thisRotX, thisRotY, 0);
        transform.localRotation = localRot;
    }

    private void LateUpdate() 
    {
        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, followObject.position, step);    
    }

        private void GetInput()
    {
        xInput = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * 360;
        yInput = -Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * 360;    
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
