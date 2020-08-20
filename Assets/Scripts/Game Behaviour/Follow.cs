using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    private Vector3 offset;
    private void Awake() 
    {
        offset = transform.position;
    }
    void FixedUpdate()
    {
        transform.position = followObject.transform.position + offset;
    }

}
