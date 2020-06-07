using System;
using System.Collections;
using UnityEngine;

public class Chase : State 
{
    public override void Start()
    {
        Debug.Log("Chasing");
    }

    public override void Update()
    {
        if(getDistanceFromPlayer() > character._sightRange)
        {
            character.setState(new Idle(character));
        }
    }

     private float getDistanceFromPlayer()
    {
        return Vector3.Distance(character.transform.position, character._player.position);
    }
    public Chase (EnemyBehavior character) : base (character){
        
    }
}