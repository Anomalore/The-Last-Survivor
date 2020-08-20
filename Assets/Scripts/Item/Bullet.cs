using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField]private Rigidbody rb;
    [SerializeField]private GameObject gunObject;
    [SerializeField]private float speed = 10.0f;
    [SerializeField]private float lifeDuration = 2.0f;
    [SerializeField]private float lifeTimer;
    [SerializeField]private int damage;
    private Vector3 bulletDirection;

    
    public int _damage{get{return damage;} set{damage = value;}}

    
    void Start()
    {
        gunObject = GameObject.FindGameObjectWithTag("Gun");
        lifeTimer = lifeDuration;
        rb = GetComponent<Rigidbody>();
        FindShootLocation();
    }
    


    void Update()
    {
        Vector3 moveDir = (bulletDirection - transform.position).normalized;

        rb.MovePosition(transform.position + (moveDir* speed * Time.deltaTime));
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FindShootLocation()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(gunObject.GetComponent<Gun>().cam.transform.position, gunObject.GetComponent<Gun>().cam.transform.forward, out hitInfo, gunObject.GetComponent<Gun>().range))
        {
            bulletDirection = hitInfo.point;
        }
        else
        {
            Vector3 point = gunObject.GetComponent<Gun>().cam.transform.position + (gunObject.GetComponent<Gun>().cam.transform.forward * gunObject.GetComponent<Gun>().range);
            bulletDirection = point;
        }


    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Hittable")
        {   
            Health enemyHealth = other.GetComponent<Health>();

            if(enemyHealth == null)
            {
                enemyHealth = other.GetComponentInParent<Health>();
            }
            enemyHealth.damage(5);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos() 
    {
    }
}
