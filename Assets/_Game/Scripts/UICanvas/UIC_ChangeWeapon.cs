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
    public TextMeshProUGUI priceWeapon;

    [SerializeField]
    WeaponOnHandType[] weaponHandType;

    [SerializeField]
    Camera cameraRenderWeapon;

    [SerializeField]
    Image imageLock;



    [SerializeField]

    Button btnEquip;

    [SerializeField]

    Button btnBuy;



    public Transform CurrentWeapon = null;


    protected override void Awake()
    {
        base.Awake();


        index = 0;

        CurrentWeapon = Instantiate(weaponPrefab[index], new Vector3(cameraRenderWeapon.transform.position.x, cameraRenderWeapon.transform.position.y, cameraRenderWeapon.transform.localPosition.y + 1), Quaternion.identity);

        CurrentWeapon.SetParent(cameraRenderWeapon.transform);


        if (CurrentWeapon.GetComponent<WeaponRender>().unlocked)
        {

            EnableButtonEquip();
        }
        else
        {
            EnableButtonBuy();
        }


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



    }

    public void NextWeapon()
    {

        UserData.Instance.OnInitData();

        SoundManager.Instance.ClickButton();
        index++;

        if (index >= weaponPrefab.Count)
            index = 0;
        if (index < weaponPrefab.Count)
        {

            nameWeapon.text = weaponPrefab[index].name;
            priceWeapon.text = Cache.GetWeaponRender(weaponPrefab[index]).Price.ToString();


            Destroy(CurrentWeapon.gameObject);


            CurrentWeapon = Instantiate(weaponPrefab[index], new Vector3(cameraRenderWeapon.transform.position.x, cameraRenderWeapon.transform.position.y, cameraRenderWeapon.transform.localPosition.y + 1), cameraRenderWeapon.transform.localRotation);

            CurrentWeapon.SetParent(cameraRenderWeapon.transform);


            if (UserData.Instance.GetDataState(UserData.Key_Weapon, (int)Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType) == 1)
                Cache.GetWeaponRender(CurrentWeapon).unlocked = true;


        }

        if (Cache.GetWeaponRender(CurrentWeapon).unlocked)
        {
            EnableButtonEquip();

        }
        else
        {

            EnableButtonBuy();
        }


    }



    public void PrewWeapon()
    {
        UserData.Instance.OnInitData();

        SoundManager.Instance.ClickButton();

        index--;
        if (index < 0)
        {
            index = weaponPrefab.Count - 1;
        }
        if (index >= 0)
        {
            nameWeapon.text = weaponPrefab[index].name;

            priceWeapon.text = Cache.GetWeaponRender(weaponPrefab[index]).Price.ToString();



            Destroy(CurrentWeapon.gameObject);

            CurrentWeapon = Instantiate(weaponPrefab[index], new Vector3(cameraRenderWeapon.transform.position.x, cameraRenderWeapon.transform.position.y, cameraRenderWeapon.transform.localPosition.y + 1), cameraRenderWeapon.transform.localRotation);

            CurrentWeapon.SetParent(cameraRenderWeapon.transform);


            if (UserData.Instance.GetDataState(UserData.Key_Weapon, (int)Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType) == 1)
                Cache.GetWeaponRender(CurrentWeapon).unlocked = true;


     


        }

        // check da unlock hay chua
        if (CurrentWeapon.GetComponent<WeaponRender>().unlocked)
        {

            EnableButtonEquip();


        }
        else
        {
            EnableButtonBuy();


        }
    }

    public void Equip()
    {
        player.ChangeWeaponHand(Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType);

        UserData.Instance.SetIntData(UserData.Key_CurentWeapon, (int)Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType);


       

       // player.playerDataSO.RangeAttack = player.playerDataSO.defaultRangeAttack + Cache.GetWeaponRender(CurrentWeapon).upgradeRangeAttack;

       // player.PosUpCamera();

    }

    public void Buy()
    {

        if (player.GetCash() >= Cache.GetWeaponRender(CurrentWeapon).Price)
        {

            player.SetCash(-Cache.GetWeaponRender(CurrentWeapon).Price);


            player.SetTextCash(player.GetCash());


            UserData.Instance.SetIntData(UserData.Key_Cash, player.GetCash());


            Cache.GetWeaponRender(CurrentWeapon).unlocked = true;


            UserData.Instance.SetDataState(UserData.Key_Weapon, (int)Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType, 1);


        



            EnableButtonEquip();

        }



    }

    void EnableButtonBuy()
    {
        btnBuy.gameObject.SetActive(true);
        btnEquip.gameObject.SetActive(false);

        imageLock.enabled = true;
    }

    void EnableButtonEquip()
    {
        btnBuy.gameObject.SetActive(false);
        btnEquip.gameObject.SetActive(true);
        imageLock.enabled = false;
    }


}
