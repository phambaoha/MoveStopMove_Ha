using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<BotController>
{
    float randomTime;
    float timer;

    public void OnEnter(BotController t)
    {
        timer = 0;
        randomTime = Random.Range(2f, 5f);
    }

    public void OnExecute(BotController t)
    {

        if (t.IsTargetInRange(t.transform.position, t.radiusRangeAttack, Constants.TAG_PLAYER,Constants.TAG_BOT))
        {
        
            t.ChangeState(new AttackState());
          
        }
        else
        {
           
            timer += Time.deltaTime;
            if (timer < randomTime)
            {
                t.Moving();

            }
            else
                t.ChangeState(new IdleState());
        }





    }
    public void OnExit(BotController t)
    {

    }
}



