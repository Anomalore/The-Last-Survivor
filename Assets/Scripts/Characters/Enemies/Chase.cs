using System;
using System.Collections;
using UnityEngine;

public class Chase : State 
{
    private Vector3 EnemyToCharacter;
    private Quaternion newRotation;
    public override void Start()
    {
        
    }

    public override void Update()
    {

        if (getDistanceFromPlayer() < character._stopDistance)
        {
            character.setState(new Attack(character));
        }

        if (getDistanceFromPlayer() > character._sightRange)
        {
            character.setState(new Idle(character));
        }

        MakeCalculations();
    }

    void MakeCalculations()
    {
        EnemyToCharacter = character.transform.position - character._player.position;

        EnemyToCharacter.y = 0;

        newRotation = Quaternion.LookRotation(EnemyToCharacter);
    }

    private void ChasePlayer()
    {
        character._agent.MoveRotation(Quaternion.Lerp(character.transform.rotation, newRotation, 0.2f));
        character._agent.MovePosition(character.transform.position - (EnemyToCharacter * Time.fixedDeltaTime * character._ChaseSpeed));
    }

    private float getDistanceFromPlayer()
    {
        return Vector3.Distance(character.transform.position, character._player.position);
    }

    public override void FixedUpdate()
    {
        ChasePlayer();
    }

    public Chase (EnemyBehavior character) : base (character)
    {
        
    }
}