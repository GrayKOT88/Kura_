using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseScript : MonoBehaviour
{
    [SerializeField] AudioClip frrr;
    private AudioSource playerAudio;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAudio.PlayOneShot(frrr, 1);
        }
    }
}
