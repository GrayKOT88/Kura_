using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject chickPrefab;
    [SerializeField] GameObject foxPrefab;
    List<Transform> points = new List<Transform>();
    private int chickCount;
    private int waveNumber = 4;
    
    void Start()
    {
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }
        SpawnFox();
    }   
    void Update()
    {
        chickCount = FindObjectsOfType<Chick>().Length;
        if (chickCount == 0)
        {
            waveNumber++;
            SpawnChickWave(waveNumber);
        }
    }
    void SpawnChickWave(int chickToSpawn)
    {
        for(int i = 0; i < chickToSpawn; i++)
        {
            Instantiate(chickPrefab,(points[Random.Range(0, points.Count)].position), chickPrefab.transform.rotation);
        }
    }
    void SpawnFox()
    {
        Instantiate(foxPrefab, (points[Random.Range(0, points.Count)].position), foxPrefab.transform.rotation);
        if(Progress.Instance.PlayerInfo.saveChick >= 50) 
        {
            Instantiate(foxPrefab, (points[Random.Range(0, points.Count)].position), foxPrefab.transform.rotation);
        }
        if(Progress.Instance.PlayerInfo.saveChick >= 100) 
        {
            Instantiate(foxPrefab, (points[Random.Range(0, points.Count)].position), foxPrefab.transform.rotation);
        }
    }
}
