using System;
using System.Collections;
using UnityEngine;

public class Idle : State 
{
    public override void Start()
    {
        Debug.Log("Idling");
    }

    public override void Update()
    {
        if(getDistanceFromPlayer() < character._sightRange)
        {
            character.setState(new Chase(character));
        }
    }

    private float getDistanceFromPlayer()
    {
        return Vector3.Distance(character.transform.position, character._player.position);
    }

    public Idle (EnemyBehavior character) : base (character){
        
    }
}