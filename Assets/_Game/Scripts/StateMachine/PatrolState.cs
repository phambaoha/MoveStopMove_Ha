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
        randomTime = Random.Range(1f, 4f);
    }

    public void OnExecute(BotController t)
    {
        if(GameManager.Instance.IsState(GameState.GamePlay))
        {
            if (t != null && !t.isDead)
            {
                if (t.IsTargetInRange(t.TF.position, t.radiusRangeAttack, Constants.TAG_PLAYER, Constants.TAG_BOT))
                {

                    t.ChangeState(new AttackState());

                }
                else
                {

                    timer += Time.deltaTime;
                    if (timer >= randomTime)
                    {
                        t.ChangeState(new IdleState());

                    }
                    else
                        t.Moving();

                }
            }
        }
        else
        {
            t.StopMoving();
        }
       
       
      

    }
    public void OnExit(BotController t)
    {

    }
}



