using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    [SerializeField]
    List<BotController> bot = new List<BotController>();
    PlayerController player;
    Vector3 pos;


    private void Awake()
    {

        player = FindObjectOfType<PlayerController>();

    }

    private void Start()
    {
        InvokeRepeating(nameof(CheckDistanceWithPlayer), 0, 10f);
    }


    void CheckDistanceWithPlayer()
    {
        for (int i = 0; i < bot.Count ; i++)
        {
            pos = RandomNavmeshLocation();

            if (Vector3.Distance(pos, player.TF.position) >= 15f)
            {

                SimplePool.Spawn<BotController>(bot[i], pos, transform.rotation).OnInit();  
            }

          
        }

    }



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



}
