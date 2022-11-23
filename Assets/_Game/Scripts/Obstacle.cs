using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : FindPlayer
{
    

    [SerializeField]
    Transform TF;

    [SerializeField] Renderer meshRen;

    private void Start()
    {
        InvokeRepeating(nameof(HideObtackles), 0, 0.5f);
    }

    void HideObtackles()
    {
        if (Vector3.Distance(TF.position, player.transform.position) <= 7)
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


