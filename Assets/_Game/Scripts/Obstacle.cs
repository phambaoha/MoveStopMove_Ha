using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : FindPlayer
{
    [SerializeField]
    Transform TF;

    [SerializeField] Renderer meshRen;

    public float distanceToPlayer;


    private void Start()
    {
        InvokeRepeating(nameof(HideObtackles), 0, 0.1f);
    }

    void HideObtackles()
    {
        if (Vector3.Distance(TF.position, player.transform.position) <= distanceToPlayer)
        {

            SetAlphaMaterial(0.5f);
        }
        else
        {
            SetAlphaMaterial(1f);
        }
    }

    public void SetAlphaMaterial(float alpha)
    {

        var matTemp = meshRen.material;
        Color col = matTemp.color;
        col.a = alpha;
        matTemp.color = col;
        meshRen.material = matTemp;
    }


  
}


