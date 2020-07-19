using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField]private Rigidbody rb;
    [SerializeField]private GameObject gunObject;
    [SerializeField]private float speed = 2.0f;
    [SerializeField]private float lifeDuration = 2.0f;
    [SerializeField]private float lifeTimer;
    [SerializeField]private int damage;
    
    public int _damage{get{return damage;} set{damage = value;}}
    
    void Start()
    {
        lifeTimer = lifeDuration;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        rb.velocity = transform.forward * speed;
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Hittable")
        {   
            other.GetComponent<Health>().damage(5);
            Destroy(this.gameObject);
        }
    }
}
