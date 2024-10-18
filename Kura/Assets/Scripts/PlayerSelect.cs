using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    private GameObject[] characters;
    private int index;
    private void Start()
    {
        index = PlayerPrefs.GetInt("SelectPlayer");
        characters = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;            
        }
        foreach(GameObject go in characters)
        {
            go.SetActive(false);
        }
        if (characters[index])
        {
            characters[index].SetActive(true);
        }
    }
    public void SelectLeft()
    {
        characters[index].SetActive(false);
        index--;
        if (index < 1)
        {
            index = characters.Length - 1;
        }
        characters[index].SetActive(true);
    }
    public void SelectRight()
    {
        characters[index].SetActive(false);
        index++;
        if (index == characters.Length) 
        {
            index = 1;
        }
        characters[index].SetActive(true);
    }
    public void startScene()
    {
        PlayerPrefs.SetInt("SelectPlayer", index);
        SceneManager.LoadScene(1);
    }
}
