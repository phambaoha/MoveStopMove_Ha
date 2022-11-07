using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : CharacterController
{
    [SerializeField]
    NavMeshAgent navMeshAgent;

    public new Transform TF;

    PlayerController player;

    [SerializeField]
    List<GameObject> listTarget = new List<GameObject>();

    Transform targerNearest;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        AddAllTarget();

        ChangeState(new IdleState());
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
            targerNearest = GetClosestEnemy(listTarget).transform;
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
        if (targerNearest != null)
            navMeshAgent.SetDestination(targerNearest.position);

    }

    IEnumerator IDelayDestroy()
    {
        yield return new WaitForSeconds(2f);

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
    GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject potentialTarget in enemies)
        {
            if (potentialTarget != null)
            {
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }

        }

        return bestTarget;
    }


    public override void OnInit()
    {
        base.OnInit();
       
    }

    public override void OnDespawn()
    {
        base.OnDespawn();

    }


}
