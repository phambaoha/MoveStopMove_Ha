using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : CharacterController
{

    NavMeshAgent navMeshAgent;
    public Transform TF;

    PlayerController player;

    [SerializeField]
    List<GameObject> listCharacter = new List<GameObject>();

    Transform targerNearest;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerController>();

        listCharacter.Add(player.gameObject);
        


    }
    
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(Constants.TAG_BOT))
        {
            if (go.Equals(this.gameObject))
                continue;

            listCharacter.Add(go);
        }

        ChangeState(new IdleState());
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }

        if(listCharacter.Count >0 )
        {
            targerNearest = GetClosestEnemy(listCharacter).transform;
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
        navMeshAgent.SetDestination(targerNearest.position);

    }

    public override void ThrowAttack()
    {
        base.ThrowAttack();
    }

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

    GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            if(potentialTarget!= null)
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

}
