using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache 
{
   static readonly Dictionary<Collider, IHit> CacheComponent = new Dictionary<Collider, IHit>();

    public static IHit GetHit(Collider coll)
    {
        if (!CacheComponent.ContainsKey(coll))
            CacheComponent.Add(coll, coll.GetComponent<IHit>());
        return CacheComponent[coll];

    }


    static readonly Dictionary<float, WaitForSeconds> CacheWaitforSenconds = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWaitForSeconds(float t)
    {
        if (!CacheWaitforSenconds.ContainsKey(t))
            CacheWaitforSenconds.Add(t, new WaitForSeconds(t));
        return CacheWaitforSenconds[t];
    }

   
}
