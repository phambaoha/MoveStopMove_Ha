using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : CharacterController
{
    [SerializeField]
    NavMeshAgent navMeshAgent;

    [SerializeField]
    Transform circleTarget;

    PlayerController player;

    List<GameObject> listTarget = new List<GameObject>();


    GameObject targerNearest;

    private void Awake()
    {
        circleTarget.gameObject.SetActive(false);

        player = FindObjectOfType<PlayerController>();

        listTarget.Add(player.gameObject);

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
        if (isDead)
            return;

        ChangeAnim(Constants.TAG_ANIM_RUN);

        // kiem tra doi tuong trong pool co dang active khong
        if (targerNearest.activeSelf)
            navMeshAgent.SetDestination(targerNearest.transform.position);

    }


    // anim die va despawn pool
    IEnumerator IDelayDestroy()
    {
        yield return Cache.GetWaitForSeconds(1.5f);
        OnDespawn();

    }

    public override void ThrowAttack()
    {
        base.ThrowAttack();

        TF.LookAt(targerNearest.transform);

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

        listTarget.Reverse();


    }



    // tim tartget gan nhat
    GameObject GetClosestEnemy(List<GameObject> target)
    {
        GameObject bestTarget = player.gameObject;


        // float closestDistanceSqr = Mathf.Infinity;
        //  Vector3 currentPosition = TF.position;

        if(Vector3.Distance(TF.position,bestTarget.transform.position) <= radiusRangeAttack)
        {
            circleTarget.gameObject.SetActive(true);
        }
        else
        {
            circleTarget.gameObject.SetActive(false);
        }

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

        this.radiusRangeAttack = Random.Range(4.5f, 7);

        AddAllTarget();

        ChangeHat((HatType)Random.Range(0, SObj_Skins.GetHatAmount));

        ChangeWeaponHand((WeaponOnHandType)(Random.Range(0, SObj_Weapon.WeaponHandAmount)));

        ChangeState(new IdleState());


    }
    //public override void ChangeHat(HatType hatType)
    //{
    //    base.ChangeHat(hatType);
    //}

    public override void OnDespawn()
    {
        if (weaponHand != null)
            Destroy(weaponHand.gameObject);
        if (hat != null)
            Destroy(hat.gameObject);

        SimplePool.Despawn(this);

    }


   
    public override void OnHit()
    {
        base.OnHit();

        // cap nhat so bot khi bot bi giet
        LevelManagers.Instance.TotalBotAmount--;

       


        // check win
        if (!player.isDead && LevelManagers.Instance.TotalBotAmount < 0)
        {
            SimplePool.CollectAll();

            GameManager.Instance.ChangeState(GameState.Menu);
            UIManager.Instance.OpenUI(UIID.UIC_Victory);
        }
    }

  

}
