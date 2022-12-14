using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManagers : Singleton<LevelManagers>
{
    [SerializeField]
    List<Level> levels = new List<Level>();

    Camera cam;

    [SerializeField]
    int totalBotAmount;

    [SerializeField]
    PlayerController player;

    Level curentLevel;
    public int TotalBotAmount { get => totalBotAmount; set => totalBotAmount = value; }
    public NavMeshData[] navMeshData;


    public int indexLevel;


    void Start()
    {

        UserData.Instance.OnInitData();

        indexLevel = UserData.Instance.Level;

        LoadLevel(indexLevel);

        OnInit();

        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);

        InvokeRepeating(nameof(SpawnBotOnNavMesh), 0, 1f);

    }

    Vector3 randomPos;

    // spawn bot
    void SpawnBotOnNavMesh()
    {
        if (TotalBotAmount < 0)
            return;


        if(GameManager.Instance.IsState(GameState.GamePlay))
        {

            randomPos = RandomNavmeshLocation();
     

            if ( Mathf.Abs(randomPos.x - player.TF.position.x ) >=10f  && Mathf.Abs(randomPos.z - player.TF.position.z) >= 10f)
            {

                SimplePool.Spawn<BotController>(PoolType.Bot, randomPos, transform.rotation).OnInit();
            }
        }


    }

    // random mot vi tri trong mesh
    public Vector3 RandomNavmeshLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 30;
        randomDirection += transform.position;
        Vector3 finalPosition;

        for (int i = 0; ; i++)
        {
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 30, 1))
            {
                finalPosition = hit.position;
                break;
            }
        }

        return finalPosition;
    }


    public void LoadLevel(int indexLevel)
    {
        if (curentLevel != null)
        {
            Destroy(curentLevel.gameObject);

        }
        NavMesh.RemoveAllNavMeshData();

        curentLevel = Instantiate(levels[indexLevel - 1]);

        NavMesh.AddNavMeshData(navMeshData[indexLevel-1]);


        TotalBotAmount = 5;

    }

    

    public void RetryLevel(int level)
    {
        LoadLevel(level);
        OnDespawn();
        OnInit();

    }

    public void OnInit()
    {
        totalBotAmount = 5;
        player.OnInit();
   
    }


    public void OnDespawn()
    {
        GameManager.Instance.ChangeState(GameState.Menu);
        SimplePool.CollectAll();
    }

    
}
