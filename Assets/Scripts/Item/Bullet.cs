using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField]private Rigidbody rb;
    [SerializeField]private GameObject gunObject;
    [SerializeField]private float speed;
    [SerializeField]private float lifeDuration = 2.0f;
    [SerializeField]private float lifeTimer;
    [SerializeField]private int damage;
    private Vector3 CamerasPosition;
    private Vector3 direction;
    public int _damage{get{return damage;} set{damage = value;}}
    public Vector3 _Direction{get{return direction;} set{direction = value;}}

    
    void Start()
    {
        gunObject = GameObject.FindGameObjectWithTag("Gun");
        lifeTimer = lifeDuration;
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() 
    {


        rb.MovePosition((transform.position + direction * Time.fixedDeltaTime * speed));
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
        else if(other.tag == "Enviroment")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
