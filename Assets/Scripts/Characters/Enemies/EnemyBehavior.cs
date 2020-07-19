using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : StateMachine
{

    [SerializeField]private float sightRange;
    [SerializeField]private int AttackDamage;
    [SerializeField]private Transform player;
    [SerializeField]private float stopDistance;
    [SerializeField]private Rigidbody agent;
    [SerializeField]private float ChaseSpeed;
    [SerializeField] Health health;

    [SerializeField]private float Timer = 0;


    public float _sightRange{get{return sightRange;} set{sightRange = value;}}
    public Transform _player{get{return player;} set{player = value;}}
    public Rigidbody _agent{get{return agent;} set{agent = value;}}
    public float _stopDistance{get{return stopDistance;} set{stopDistance = value;}}
    public float _ChaseSpeed{get{return ChaseSpeed;} set{ChaseSpeed = value;}}
    public float _Timer{get{return Timer;} set{Timer = value;}}
    public int _AttackDamage{get{return AttackDamage;} set{AttackDamage = value;}}
    
    void Awake()
    {
        agent = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<Health>();
        setState(new Idle(this));
    }

    void Update()
    {   
        if(health.getHealth() <= 0)
        {
            Destroy(this.gameObject);
        }
        if(currentState == null) return;
        currentState.Update();
    }

    void FixedUpdate()
    {
        if(currentState == null) return;
        currentState.FixedUpdate();
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


}
