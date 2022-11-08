using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : CharacterController
{
    [SerializeField]
    NavMeshAgent navMeshAgent;

    //public new Transform TF;

    PlayerController player;

    [SerializeField]
    List<GameObject> listTarget = new List<GameObject>();

    GameObject targerNearest;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();

      
    }

    private void Update()
    {
        if (isDead)
        {
            ChangeAnim(Constants.TAG_ANIM_DEAD);
            StartCoroutine(IDelayDestroy());
            
            return;
        }

        if (currentState != null)
        {
            currentState.OnExecute(this);
        }

        if (listTarget.Count > 0)
        {
            targerNearest = GetClosestEnemy(listTarget);
        }



    }


    public void StopMoving()
    {
        ChangeAnim(Constants.TAG_ANIM_IDLE);
        navMeshAgent.SetDestination(TF.position);

    }

    public void Moving()
    {
        ChangeAnim(Constants.TAG_ANIM_RUN);

      //  if (targerNearest.activeSelf )
            navMeshAgent.SetDestination(targerNearest.transform.position);

    }

    IEnumerator IDelayDestroy()
    {
        yield return Cache.GetWaitForSeconds(2f);

        OnDespawn();

    }

    public override void ThrowAttack()
    {

        base.ThrowAttack();

        navMeshAgent.SetDestination(TF.position);

    }

    private IState<BotController> currentState;
    public void ChangeState(IState<BotController> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

       

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    // them cac doi tuong co tren scene hien tai
    void AddAllTarget()
    {
      

        foreach (GameObject go in GameObject.FindGameObjectsWithTag(Constants.TAG_BOT))
        {
            if (go.Equals(this.gameObject))
                continue;

            listTarget.Add(go);
        }


     listTarget.Add(player.gameObject);
      
    }



    // tim tartget gan nhat
    GameObject GetClosestEnemy(List<GameObject> target)
    {
        GameObject bestTarget = player.gameObject;
       // float closestDistanceSqr = Mathf.Infinity;
      //  Vector3 currentPosition = TF.position;

        foreach (GameObject potentialTarget in target)
        {
            if (potentialTarget != null && potentialTarget.activeSelf)
            {
              //  Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
              //  float dSqrToTarget = directionToTarget.sqrMagnitude;
               // if (dSqrToTarget < closestDistanceSqr)
              //  {
                  //  closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;

                break;
              //  }
            }

        }

        return bestTarget;
    }


    public override void OnInit()
    {
        base.OnInit();

        isDead = false;

        AddAllTarget();

        ChangeState(new IdleState());

    }

    public override void OnDespawn()
    {
        base.OnDespawn();

    }


}
