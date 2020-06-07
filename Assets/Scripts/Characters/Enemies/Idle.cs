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
        
    }

    public Idle (EnemyBehavior character) : base (character){
        
    }
}