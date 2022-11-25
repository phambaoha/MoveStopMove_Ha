using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoolController : Singleton<PoolController>
{
    [Header("Pool")]
    public PoolAmount[] Pool;

    [Header("Partical Pool")]
    public ParticleAmount[] ParticalPool;

    public void Awake()
    {
        for (int i = 0; i < Pool.Length; i++)
        {
            SimplePool.Preload(Pool[i].prefab, Pool[i].amount, Pool[i].root, Pool[i].collect, Pool[i].clamp);
        }

        for (int i = 0; i < ParticalPool.Length; i++)
        {
            ParticlePool.Preload(ParticalPool[i].prefab, ParticalPool[i].amount, ParticalPool[i].root);
        }


    }
     
}


