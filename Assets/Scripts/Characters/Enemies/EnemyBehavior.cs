using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : StateMachine
{

    [SerializeField]private float sightRange;
    [SerializeField]private Transform player;

    public float _sightRange{get{return sightRange;} set{sightRange = value;}}
    public Transform _player{get{return player;} set{player = value;}}
    
    void Awake()
    {
        setState(new Idle(this));
    }

    void Update()
    {
        if(currentState == null) return;
        currentState.Update();
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
