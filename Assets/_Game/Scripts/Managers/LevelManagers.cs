using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManagers : Singleton<LevelManagers>
{
    [SerializeField]
    List<Level> levels = new List<Level>();



    [SerializeField]
    int totalBotAmount;

    [SerializeField]
    BotController bot;



    PlayerController player;





    Level curentLevel;


    public int TotalBotAmount { get => totalBotAmount; set => totalBotAmount = value; }

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

        InvokeRepeating(nameof(SpawnBotOnNavMesh), 0, 1f);

       
    }

    private void Update()
    {
        if (player.isDead)
        {
            UIManager.Instance.OpenUI(UIID.UIC_Fail);


        }
        else
        if (totalBotAmount <= 0)
        {
            UIManager.Instance.OpenUI(UIID.UIC_Victory);
        }

    }


    Vector3 randomPos;

    // spawn bot
    void SpawnBotOnNavMesh()
    {
        if (totalBotAmount <= 0)
            return;


       // int xCam = camera.ViewportToWorldPoint().x;
        randomPos = RandomNavmeshLocation();
      //  if (randomPos.x )

            if (Vector3.Distance(randomPos, player.TF.position) >= 20f)
            {

                SimplePool.Spawn<BotController>(bot, randomPos, transform.rotation).OnInit();
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
        player.gameObject.SetActive(true);
        player.TF.position = Vector3.one;        
        player.isDead = false;

    }

    public void OnDespawn()
    {

        SimplePool.CollectAll();
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
