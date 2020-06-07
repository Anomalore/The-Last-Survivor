using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState;

    public void setState(State state){
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = state;

          if(currentState != null)
        {
            currentState.Start();
        }
    }
}