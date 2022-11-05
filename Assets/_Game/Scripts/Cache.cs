using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache 
{
   static Dictionary<Collider, IHit> CacheComponent = new Dictionary<Collider, IHit>();

    public static IHit GetHit(Collider coll)
    {
        if (!CacheComponent.ContainsKey(coll))
            CacheComponent.Add(coll, coll.GetComponent<IHit>());
        return CacheComponent[coll];

    }
   
   
}
