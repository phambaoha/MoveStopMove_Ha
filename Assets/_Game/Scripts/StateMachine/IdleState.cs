using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<BotController>
{
    float ramdomTime;
    float timer;
    public void OnEnter(BotController t)
    {
        t.StopMoving();
        timer = 0;
        ramdomTime = Random.Range(0f, 1f);
    }

    public void OnExecute(BotController t)
    {
        timer += Time.deltaTime;
        if (timer > ramdomTime)
        {
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(BotController t)
    {
       
    }

}
