using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void Start(){}
    public virtual void Exit(){} 

    public abstract void Update();

    public State(EnemyBehavior character){

    }
}
