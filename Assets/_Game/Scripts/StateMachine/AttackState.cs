using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<BotController>
{
    float timer;
    public void OnEnter(BotController t)
    {

        timer = 0;
        t.ThrowAttack();
    }

    public void OnExecute(BotController t)
    {

        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
           
            t.ChangeState(new PatrolState());
            
        }
    }

    public void OnExit(BotController t)
    {

    }
 
}
