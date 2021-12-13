using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState = null;

    public void setState(State state){
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = state;
        Debug.ClearDeveloperConsole();

          if(currentState != null)
        {
            currentState.Start();
        }
    }
}