using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<BotController>
{
    float timer;
    public void OnEnter(BotController t)
    {
      
        t.ThrowAttack();
    }

    public void OnExecute(BotController t)
    {

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(BotController t)
    {

    }
 
}
