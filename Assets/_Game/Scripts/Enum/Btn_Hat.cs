using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Hat : FindPlayer
{

    public HatType hatType;

    public bool unlocked = false;

    [SerializeField]
   public Image imageLock;

    [SerializeField]
    public Image imageSelected;

    public int Price;


}
