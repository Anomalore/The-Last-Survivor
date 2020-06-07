using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : StateMachine
{
    void Start()
    {
        setState(new Idle(this));
    }

    void Update()
    {
        currentState.Update();
    }
}
