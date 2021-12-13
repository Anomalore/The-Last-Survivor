using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : StateMachine
{

    [Header("Stats")]
    [SerializeField] private Health health;
    [SerializeField]private int AttackDamage;
    [SerializeField]private float ChaseSpeed;
    [SerializeField]private float sightRange;

    [Header("Tweaking")]
    [SerializeField]private Transform player;
    [SerializeField]private float stopDistance;
    [SerializeField]private Rigidbody agent;
    [Header("Debugging")]
    [SerializeField] private float timer = 0;

    [Header("Items to Drop")]
    [SerializeField] private GameObject[] droppables;


    public float _sightRange{get{return sightRange;} set{sightRange = value;}}
    public Transform _player{get{return player;} set{player = value;}}
    public Rigidbody _agent{get{return agent;} set{agent = value;}}
    public float _stopDistance{get{return stopDistance;} set{stopDistance = value;}}
    public float _ChaseSpeed{get{return ChaseSpeed;} set{ChaseSpeed = value;}}
    public float _timer{get{return timer;} set{timer = value;}}
    public int _AttackDamage{get{return AttackDamage;} set{AttackDamage = value;}}
    public GameObject[] _droppables{get{return droppables;} set{droppables = value;}}

    
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
            setState(new Die(this));
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
