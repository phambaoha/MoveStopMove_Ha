using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIC_ChangeWeapon : UICanvas
{
    [SerializeField]
    RawImage imageWeapon;
    [SerializeField]
    List<Sprite> weaponSprite;
    int index = 0;

   

    public TextMeshProUGUI nameWeapon;

    [SerializeField]
    WeaponOnHandType[] weaponHandType;

    PlayerController player;
    private void Awake()
    {
        index = 0;
        player = FindObjectOfType<PlayerController>();
    }

    public void BackToMainMenu()
    {
        index = 0;
        Close();
        
        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
        
    }

    private void Start()
    {
        imageWeapon.texture = weaponSprite[index].texture;
        nameWeapon.text = weaponSprite[index].name;
    }

    public void NextWeapon()
    {

        index++;
        if (index >= weaponSprite.Count)
            index = 0;
        imageWeapon.texture = weaponSprite[index].texture;
        nameWeapon.text = weaponSprite[index].name;
    }

    public void PrewWeapon()
    {
        index--;
        if (index < 0)
            index = weaponSprite.Count - 1;
        imageWeapon.texture = weaponSprite[index].texture;

        nameWeapon.text = weaponSprite[index].name;
        

    }

    public void Equip()
    {
        player.ChangeWeaponHand(weaponHandType[index]);
    }
}
