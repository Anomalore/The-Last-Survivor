using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{

    protected EnemyBehavior character;
    public virtual void Start(){}
    public virtual void Exit(){} 

    public abstract void Update();
    public abstract void FixedUpdate();

    public State(EnemyBehavior _character)
    {
        character = _character;
    }
}
