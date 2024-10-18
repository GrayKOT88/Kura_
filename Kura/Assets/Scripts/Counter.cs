using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using YG;
using YG.Utils.LB;

public class Counter : MonoBehaviour
{
    [SerializeField] GameObject Gold;
    [SerializeField] GameObject Silver;
    [SerializeField] GameObject Bronze;

    public TextMeshProUGUI CounterText;
    public TextMeshProUGUI CounterTextFox;
    public ParticleSystem explosionParticle;   
    [SerializeField] AudioClip pointSound;    
    private int Count;
    private int CountFox;
    AudioSource playerAudio;
    void Start()
    {
        Count = Progress.Instance.PlayerInfo.saveChick;
        CounterText.text = " " + Count;
        CountFox = Progress.Instance.PlayerInfo.eatenChick;
        CounterTextFox.text = " " + CountFox;        
        playerAudio = GetComponent<AudioSource>();
        Medal();
    }    
    public void UpdateScore(int scoreToAdd)
    {
        CountFox += scoreToAdd;
        CounterTextFox.text = " " + CountFox;
        Progress.Instance.PlayerInfo.eatenChick = CountFox;
        Progress.Instance.SaveData();
    }   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chick"))
        { 
            Count += 1;            
            CounterText.text = " " + Count;            
            playerAudio.PlayOneShot(pointSound, 1);
            Destroy(other.gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Progress.Instance.PlayerInfo.saveChick = Count;
            Medal();
            AddNewScores();
            Progress.Instance.SaveData();            
        }
    }
    public void AddNewScores()
    {
        if (Count > Progress.Instance.PlayerInfo.recordSaveChick)
        {
            Progress.Instance.PlayerInfo.recordSaveChick = Count;
            YandexGame.NewLeaderboardScores("saveChick", Count);
        }        
    }
    void Medal()
    {
        Gold.SetActive(false);
        Silver.SetActive(false);
        Bronze.SetActive(false);
        if (Progress.Instance.PlayerInfo.saveChick >= 20)
        {
            Bronze.SetActive(true);
        }
        if (Progress.Instance.PlayerInfo.saveChick >= 50)
        {
            Bronze.SetActive(false);
            Silver.SetActive(true);
        }
        if (Progress.Instance.PlayerInfo.saveChick >= 100)
        {
            Silver.SetActive(false);
            Gold.SetActive(true);
        }
    }
}
