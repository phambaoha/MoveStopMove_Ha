using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    [HideInInspector]
    public PlayerController player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
}
