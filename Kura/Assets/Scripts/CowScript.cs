using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    [SerializeField] AudioClip muuu;
    private AudioSource playerAudio;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {       
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAudio.PlayOneShot(muuu, 1);
        }
    }
}
