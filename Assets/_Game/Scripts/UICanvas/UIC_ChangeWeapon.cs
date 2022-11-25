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
    List<Transform> weaponPrefab;
    int index = 0;

    [SerializeField]
    RenderTexture renderWeapon;
    public TextMeshProUGUI nameWeapon;

    [SerializeField]
    WeaponOnHandType[] weaponHandType;

    [SerializeField]
    Camera cameraRender;


    PlayerController player;
    private void Awake()
    {
  

        index = 0;
        player = FindObjectOfType<PlayerController>();
        Instantiate(weaponPrefab[index], new Vector3(cameraRender.transform.position.x,cameraRender.transform.position.y,cameraRender.transform.localPosition.y +1 ), cameraRender.transform.localRotation).SetParent(cameraRender.transform);
    }

    public void BackToMainMenu()
    {
        SoundManager.Instance.ClickButton();
        index = 0;
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
        
    }

    private void Update()
    {
        imageWeapon.texture = renderWeapon;
        nameWeapon.text = weaponPrefab[index].name;
    }

    public void NextWeapon()
    {
        SoundManager.Instance.ClickButton();
        index++;
        
        if (index >= weaponPrefab.Count)
                index = 0;    
        if ( index < weaponPrefab.Count)
        {
            Destroy(cameraRender.transform.GetChild(0).gameObject);
            Instantiate(weaponPrefab[index], new Vector3(cameraRender.transform.position.x, cameraRender.transform.position.y, cameraRender.transform.localPosition.y + 1), cameraRender.transform.localRotation).SetParent(cameraRender.transform);
        }




    }

    public void PrewWeapon()
    {
        SoundManager.Instance.ClickButton();

        index--;
        if (index < 0)
        {
            index = weaponPrefab.Count - 1;
        }
        if ( index >= 0 )
        { 
            Destroy(cameraRender.transform.GetChild(0).gameObject);
            Instantiate(weaponPrefab[index], new Vector3(cameraRender.transform.position.x, cameraRender.transform.position.y, cameraRender.transform.localPosition.y + 1), cameraRender.transform.localRotation).SetParent(cameraRender.transform);

        }
    }

    public void Equip()
    {
        SoundManager.Instance.ClickButton();
        player.ChangeWeaponHand(weaponHandType[index]);
    }
}
