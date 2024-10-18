using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using YG;

[System.Serializable]
public class PlayerInfo
{
    public int saveChick;
    public int eatenChick;
    public int recordSaveChick;
}
public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;
      
    public static Progress Instance;
    
    private void Start()
    {
        LoadData();       
    }
    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }   
    public void SaveData()
    {
        YandexGame.savesData.saveChick = PlayerInfo.saveChick;
        YandexGame.savesData.eatenChick = PlayerInfo.eatenChick;
        YandexGame.savesData.recordSaveChick = PlayerInfo.recordSaveChick;
        YandexGame.SaveProgress();       
    }
    public void LoadData()
    {
        PlayerInfo.saveChick = YandexGame.savesData.saveChick;
        PlayerInfo.eatenChick = YandexGame.savesData.eatenChick;
        PlayerInfo.recordSaveChick = YandexGame.savesData.recordSaveChick;
    }    
}
