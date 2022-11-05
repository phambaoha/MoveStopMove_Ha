using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagers : Singleton<LevelManagers>
{
    [SerializeField]
    List<Level> levels = new List<Level>();

    Level curentLevel;
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(1);
        OnInit();
    }

    public void LoadLevel(int indexLevel)
    {
        if(curentLevel  != null )
        {
            Destroy(curentLevel.gameObject);

        }
        curentLevel = Instantiate(levels[indexLevel - 1]);
    }    

    public void OnInit()
    {

    }

    public void OnStart()
    {

    }

    public void OnFinish()
    {

    }
}
