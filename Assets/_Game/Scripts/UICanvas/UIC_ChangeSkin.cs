using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIC_ChangeSkin : UICanvas
{
    PlayerController player;
    [SerializeField]
    List<Button> ListBtnChangeSkin;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        ChangeHatType();
    }
    public void BackToMainMenu()
    {
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
    }

    public void ChangeHatType()
    {
        foreach (Button btn in ListBtnChangeSkin)
        {
            btn.onClick.AddListener( () => Change(btn.GetComponent<BtnEnumHat>().hatType));
        }
    }
    public void Change(HatType hatType)
    {
        player.ChangeHat(hatType);
    }
  
}
