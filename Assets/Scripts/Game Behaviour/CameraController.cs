using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float desiredDistance, minDistance;
    [SerializeField] private float distance;
    [SerializeField]private float smooth;
    private Vector3 dollyDir;
    Vector3 direction;
    Ray ray;
    Vector3 desiredPos;

    private void Start() 
    {
        desiredDistance = Vector3.Distance(transform.position, transform.parent.position);
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
        Cursor.lockState = CursorLockMode.Locked;
        direction = transform.forward;
    }

    private void Update() 
    {
        desiredPos = transform.parent.TransformPoint(dollyDir * desiredDistance);
        RaycastHit hit;
        ray = new Ray(transform.parent.position, -transform.parent.position + desiredPos);

        if(Physics.Raycast(ray, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.9f) ,minDistance, desiredDistance);
        }
        else
        {
            distance = desiredDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        
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
   
    private void OnDrawGizmos() 
    {
        Gizmos.DrawSphere(desiredPos, 0.2f);
        Gizmos.DrawRay(ray);
    }

}
