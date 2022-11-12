using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManagers : Singleton<LevelManagers>
{
    [SerializeField]
    List<Level> levels = new List<Level>();



    [SerializeField]
    int TotalBotAmount;

    [SerializeField]
    BotController bot;

    [SerializeField]
    Transform poolOfBot;

    PlayerController player;
    Vector3 pos;

    Level curentLevel;



    private void Awake()
    {

        player = FindObjectOfType<PlayerController>();

    }
    void Start()
    {
        LoadLevel(1);
        OnInit();

        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);

        Time.timeScale = 0;

        InvokeRepeating(nameof(SpawnBotOnNavMesh), 1, 1f);
    }

    private void Update()
    {
       
        if (player.isDead)
        {
            UIManager.Instance.OpenUI(UIID.UIC_Fail);

        }

        if (TotalBotAmount <= 0)
        {

            UIManager.Instance.OpenUI(UIID.UIC_Victory);
        }

    }

    public int GetBotAmount()
    {
        return TotalBotAmount;
    }

    // tong so bot trong mot level
    public void SetTotalBotAmount()
    {
        this.TotalBotAmount--;
    }



    



    // spawn bot
    void SpawnBotOnNavMesh()
    {
        pos = RandomNavmeshLocation();

        if (Vector3.Distance(pos, player.TF.position) >= 20f)
        {

            SimplePool.Spawn<BotController>(bot, pos, transform.rotation).OnInit();
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
        curentLevel = Instantiate(levels[indexLevel - 1]);
    }

    public void RetryLevel()
    {
        LoadLevel(1);
        OnDespawn();
        OnInit();

    }

    public void OnInit()
    {
        player.TF.position = Vector3.one;
        player.gameObject.SetActive(true);
        player.isDead = false;
        poolOfBot.gameObject.SetActive(true);

       
    }

    public void OnDespawn()
    {
     

         
    }

    public void OnStart()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        Time.timeScale = 1;

    }

    public void OnFinish()
    {
        GameManager.Instance.ChangeState(GameState.Finish);
    }
}
