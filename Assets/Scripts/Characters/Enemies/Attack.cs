using System;
using System.Collections;
using UnityEngine;

public class Attack : State 
{
    public override void Start()
    {
        character._timer = UnityEngine.Random.Range(1f,1.5f);
    }

    public override void Update()
    {
        lookAtPlayer();
        AttackPlayer();

        if (getDistanceFromPlayer() > character._stopDistance)
        {
            character.setState(new Chase(character));
        }
    }

    private void AttackPlayer()
    {
        character._timer += Time.deltaTime;
        if(character._timer >= 2)
        {
            character._timer = 0;
            character._player.GetComponent<Health>().damage(character._AttackDamage);
        }
    }

    private void lookAtPlayer()
    {
        Vector3 EnemyToCharacter = character.transform.position - character._player.position;

        EnemyToCharacter.y = 0;

        Quaternion newRotation = Quaternion.LookRotation(EnemyToCharacter);

        character.transform.rotation = Quaternion.Lerp(character.transform.rotation, newRotation, 0.2f);

    }

    private float getDistanceFromPlayer()
    {
        return Vector3.Distance(character.transform.position, character._player.position);
    }

    public override void FixedUpdate()
    {
        return;
    }

    public Attack (EnemyBehavior character) : base (character)
    {
        
    }
}