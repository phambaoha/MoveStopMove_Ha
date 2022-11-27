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

    [SerializeField]
     WeaponOnHandType currentWeaponOnHandType;

    Transform CurrentWeapon = null;


    private void Awake()
    {

        player = FindObjectOfType<PlayerController>();

        index = 0;


        CurrentWeapon = Instantiate(weaponPrefab[index], new Vector3(cameraRenderWeapon.transform.position.x, cameraRenderWeapon.transform.position.y, cameraRenderWeapon.transform.localPosition.y + 1), cameraRenderWeapon.transform.localRotation);

        CurrentWeapon.SetParent(cameraRenderWeapon.transform);

        currentWeaponOnHandType = Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType;

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


           



            currentWeaponOnHandType = Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType;

            if (currentWeaponOnHandType == WeaponOnHandType.Knife)
            {
                Cache.GetWeaponRender(CurrentWeapon).unlocked = UserData.Instance.KnifeUnlocked;
            }
            if (currentWeaponOnHandType == WeaponOnHandType.Boomerang)
            {
                Cache.GetWeaponRender(CurrentWeapon).unlocked = UserData.Instance.BoomerangUnlocked;
            }
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

            currentWeaponOnHandType = Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType;

          

            if (currentWeaponOnHandType == WeaponOnHandType.Knife)
            {
                Cache.GetWeaponRender(CurrentWeapon).unlocked = UserData.Instance.KnifeUnlocked;
            }
            if (currentWeaponOnHandType == WeaponOnHandType.Boomerang)
            {
                Cache.GetWeaponRender(CurrentWeapon).unlocked = UserData.Instance.BoomerangUnlocked;
            }


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
        player.ChangeWeaponHand(currentWeaponOnHandType);
     
    }

    public void Buy()
    {
            
        if(player.GetCash() >= Cache.GetWeaponRender(CurrentWeapon).Price)
        {

            Cache.GetWeaponRender(CurrentWeapon).unlocked = true;
       
            if (Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType == WeaponOnHandType.Knife )
            {
                UserData.Instance.SetBoolData(UserData.Key_KnifeUnlock, true);
            }

            if(Cache.GetWeaponRender(CurrentWeapon).weaponOnHandType == WeaponOnHandType.Boomerang)
            {
                UserData.Instance.SetBoolData(UserData.Key_BoomerangUnlock, true);
            }


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
