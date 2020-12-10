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
    Ray bulletRay;

    
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
        Vector3 lastPos = transform.position;

        transform.Translate((direction * Time.fixedDeltaTime * speed));

        Vector3 currentPos = transform.position;

        bulletRay = new Ray(lastPos, (currentPos - lastPos).normalized);

        RaycastHit[] hits = Physics.RaycastAll(bulletRay, (currentPos - lastPos).magnitude);

        foreach(RaycastHit hit in hits)
        {
            print("oof");
            if(hit.collider.tag == "Hittable")
            {   
                Health enemyHealth = hit.collider.gameObject.GetComponent<Health>();

            if(enemyHealth == null)
            {
                enemyHealth = hit.collider.gameObject.GetComponentInParent<Health>();
            }
                enemyHealth.damage(5);
                Destroy(this.gameObject);
            }
            else if(hit.collider.tag == "Enviroment")
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        print(lastPos + " " + currentPos);
    }
    
    private void OnDrawGizmos() 
    {
        Gizmos.DrawRay(bulletRay);
    }

}
