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
        InvokeRepeating(nameof(CheckDistanceWithPlayer), 1, 10f);
    }


    void CheckDistanceWithPlayer()
    {
        for (int i = 0; i < bot.Count ; i++)
        {
            if (Vector3.Distance(pos, player.TF.position) >= 12f)
            {

                SimplePool.Spawn<BotController>(bot[i], pos, transform.rotation);
                pos = RandomNavmeshLocation();
            }
            else
            {
                pos = RandomNavmeshLocation();
            }
        }

    }



    public Vector3 RandomNavmeshLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 30;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        for (int i = 0; ; i++)
        {
            if (NavMesh.SamplePosition(randomDirection, out hit, 30, 1))
            {
                finalPosition = hit.position;
                break;
            }
        }

        return finalPosition;
    }



}
