using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Numerics;
using System.Globalization;
using System.Linq;

public class UserData : Singleton<UserData>
{
#if UNITY_EDITOR
    [Header(" ----Test Data----")]

    public bool IsTestCheckData = false;
#endif

    

    [Header("PlayerData")]
    public float playerSpeed;
    public float attackRange;

    [Header("----GameData----")]
    public int Level = 1;

    public int Cash;
    public bool removeAds = false;


    public bool musicIsOn = true;
    public bool vibrationIsOn = true;
    public bool fxIsOn = true;

    [Header("Hat")]
    public bool BunnyUnlocked = false;
    public bool HatUnlocked = false;
    public bool HornUnlocked = false;

    [Header("Weapon")]
    public bool AxeUnlocked = false;
    public bool KnifeUnlocked = false;
    public bool BoomerangUnlocked = false;

    [Header("Pant")]

    public bool OnionUnlocked = false;
    public bool PokemonUnlocked = false;
    public bool RainBowUnlocked = false;



    [Header("Curent")]

    public int CurentWeapon = 0;
    public int CurrentHat = 0;
    public int CurentPant = 0;


    public bool tutorialed = false;

    public string lastTimePlay;







    #region List

    /// <summary>
    ///  0 = lock , 1 = unlock , 2 = selected
    ///  luu mot danh sach gia tri, key la ten list, id la so thu tu, state la trang thai
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ID"></param>
    /// <param name="state"></param>
    public void SetDataState(string key, int ID, int state)
    {
        PlayerPrefs.SetInt(key + ID, state);
    }

    /// <summary>
    ///  0 = lock , 1 = unlock , 2 = selected
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ID"></param>
    /// <param name="state"></param>
    public int GetDataState(string key, int ID, int defaultID = 0)
    {
        return PlayerPrefs.GetInt(key + ID, defaultID);
    }

    /// <summary>
    ///  0 = lock , 1 = unlock , 2 = selected
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ID"></param>
    /// <param name="state"></param>
    public void SetDataState(string key, int ID, ref List<int> variable, int state)
    {
        variable[ID] = state;
        PlayerPrefs.SetInt(key + ID, state);
    }

    #endregion

    #region Save data

    /// <summary>
    /// Key_Name
    /// if(bool) true == 1
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetIntData(string key, ref int variable, int value)
    {
        variable = value;
        PlayerPrefs.SetInt(key, value);
    }

    public void SetIntData(string key, int value)
    {

        PlayerPrefs.SetInt(key, value);
    }
 

    public void SetBoolData(string key, bool value)
    {

        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public void SetFloatData(string key, float value)
    {
       
        PlayerPrefs.SetFloat(key, value);
    }

    public void SetStringData(string key, ref string variable, string value)
    {
        variable = value;
        PlayerPrefs.SetString(key, value);
    }

    #endregion

    //#region Class

    //public void SetClassData<T>(string key, T t) where T : class
    //{
    //    string s = JsonConvert.SerializeObject(t);
    //    PlayerPrefs.SetString(key, s);
    //}

    //public T GetClassData<T>(string key) where T : class
    //{
    //    string s = PlayerPrefs.GetString(key);
    //    return string.IsNullOrEmpty(s) ? null : JsonConvert.DeserializeObject<T>(s);
    //}

    //#endregion

    public void OnInitData()
    {
        //#if UNITY_EDITOR
        //        if (IsTestCheckData)
        //        {
        //            return;
        //        }
        //#endif

        playerSpeed = PlayerPrefs.GetFloat(Key_PlayerSpeed,5f);
        attackRange = PlayerPrefs.GetFloat(Key_AttackRange, 6f);

        Level = PlayerPrefs.GetInt(Key_Level, 1);
        Cash = PlayerPrefs.GetInt(Key_Cash);


        musicIsOn = PlayerPrefs.GetInt(Key_MusicIsOn, 1) == 1;
        vibrationIsOn = PlayerPrefs.GetInt(Key_VibrationIsOn, 1) == 1;
        fxIsOn = PlayerPrefs.GetInt(Key_FxIsOn, 1) == 1;
        removeAds = PlayerPrefs.GetInt(Key_RemoveAds, 0) == 1;
        tutorialed = PlayerPrefs.GetInt(Key_Tutorial, 0) == 1;
        lastTimePlay = PlayerPrefs.GetString(Key_Last_Time_Play, System.DateTime.Now.ToString(CultureInfo.InvariantCulture));


        BunnyUnlocked = UserData.Instance.GetDataState(Key_Hat, 0) == 1;
        HatUnlocked = UserData.Instance.GetDataState(Key_Hat, 1) == 1;
        HornUnlocked = UserData.Instance.GetDataState(Key_Hat, 2) == 1;

        AxeUnlocked = UserData.Instance.GetDataState(Key_Weapon, 0) == 1;
        KnifeUnlocked = UserData.Instance.GetDataState(Key_Weapon, 1) == 1;
        BoomerangUnlocked = UserData.Instance.GetDataState(Key_Weapon, 2) == 1;

        OnionUnlocked = UserData.Instance.GetDataState(Key_Pant, 0) == 1;
        PokemonUnlocked = UserData.Instance.GetDataState(Key_Pant, 1) == 1;
        RainBowUnlocked = UserData.Instance.GetDataState(Key_Pant, 2) == 1;


        CurentWeapon = PlayerPrefs.GetInt(Key_CurentWeapon, 0);
        CurrentHat = PlayerPrefs.GetInt(Key_CurrentHat, (int)PantType.GetValues(typeof(PantType)).Cast<PantType>().Last());
        CurentPant = PlayerPrefs.GetInt(Key_CurentPant, (int)PantType.GetValues(typeof(PantType)).Cast<PantType>().Last());

    }

    public void OnResetData()
    {
        PlayerPrefs.DeleteAll();
        OnInitData();
    }
    public const string Key_PlayerSpeed = "speed";
    public const string Key_AttackRange = "attackrange";

    public const string Key_Level = "Level";
    public const string Key_Cash = "Cash";


    public const string Key_CurentWeapon = "CurentWeapon";
    public const string Key_CurrentHat = "CurentHat";
    public const string Key_CurentPant = "CurentPant";




    public const string Key_Hat = "Hat";
    public const string Key_Pant = "Pant";
    public const string Key_Weapon = "Weapon";


    public const string Key_FxIsOn = "SoundIsOn";
    public const string Key_MusicIsOn = "MusicIsOn";
    public const string Key_VibrationIsOn = "VibrationIsOn";
    public const string Key_RemoveAds = "RemoveAds";
    public const string Key_Tutorial = "Tutorial";
    public const string Key_Last_Time_Play = "Key_Last_Time_Play";

    public const string Key_Slot_Type_ = "KeySlotType_";
    public const string Key_Slot_Level_ = "KeySlotLevel_";

    public const string Key_Max_Level_Melee_Unlock = "Key_Max_Level_Melee_Unlock";
    public const string Key_Max_Level_Range_Unlock = "Key_Max_Level_Range_Unlock";

    public const string Key_Melee_Have_Owned = "Key_Melee_Have_Owned";
    public const string Key_Range_Have_Owned = "Key_Range_Have_Owned";
}


