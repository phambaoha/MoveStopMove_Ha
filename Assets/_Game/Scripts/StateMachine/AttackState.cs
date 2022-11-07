using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<BotController>
{
    float timer;
    public void OnEnter(BotController t)
    {
        t.ThrowAttack();
        timer = 0;
       
    }

    public void OnExecute(BotController t)
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            t.ChangeState(new IdleState());
        }
    }

    public void OnExit(BotController t)
    {

    }
 
}
