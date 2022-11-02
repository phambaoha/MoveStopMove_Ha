using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : CharacterController
{
    private IState<BotController> currentState;
    public void ChangeState(IState<BotController> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        Debug.Log(state);

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

}
