using System.Collections;
using UnityEngine;

public class Idle : State 
{

    Quaternion newRotationNew = Quaternion.identity;
    public override void Start()
    {
        character._Timer = 0;
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

    public override void FixedUpdate()
    {
        character.transform.rotation = Quaternion.Lerp(character.transform.rotation, aimlessLook(), 0.1f);
        return;
    }

    private Quaternion aimlessLook()
    {
        Quaternion newRotationOld;
        Vector3 newEulerRotation;
        
        character._Timer += Time.deltaTime;
        if(character._Timer >= Random.Range(3, 10))
        {
            
            newRotationOld = Random.rotation;
            newEulerRotation = newRotationOld.eulerAngles;
            newEulerRotation.x = 0;
            newEulerRotation.z = 0;
            newRotationNew = Quaternion.Euler(newEulerRotation);   
            character._Timer = 0.0f;         
        }
        return newRotationNew;
    }

    public Idle (EnemyBehavior character) : base (character)
    {
        
    }
}