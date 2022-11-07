using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomBotInNavMesh : MonoBehaviour
{
    public Vector3 RandomNavmeshLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 30;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, 30, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private void Awake()
    {
        print(RandomNavmeshLocation());
    }







}
