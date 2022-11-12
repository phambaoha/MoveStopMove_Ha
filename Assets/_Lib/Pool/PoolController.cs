﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoolController : Singleton<PoolController>
{
    [Header("Pool")]
    public PoolAmount[] Pool;




    public void Awake()
    {
        for (int i = 0; i < Pool.Length; i++)
        {
            SimplePool.Preload(Pool[i].prefab, Pool[i].amount, Pool[i].root, Pool[i].collect, Pool[i].clamp);
        }


    }
     //  public NavMeshData[] navMeshData;
    // NavMesh.RemoveAllNavMeshData();
    //  NavMesh.AddNavMeshData(navMeshData[0]);
}


