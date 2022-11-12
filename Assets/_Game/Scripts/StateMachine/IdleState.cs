using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<BotController>
{

    public void OnEnter(BotController t)
    {
        t.StopMoving();

    }

    public void OnExecute(BotController t)
    {

        t.ChangeState(new PatrolState());

    }

    public void OnExit(BotController t)
    {

    }

}
