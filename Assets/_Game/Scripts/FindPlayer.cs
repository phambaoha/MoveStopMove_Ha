using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
   public PlayerController player;
    private void Awake()
    {

        player = FindObjectOfType<PlayerController>();
    }
}
