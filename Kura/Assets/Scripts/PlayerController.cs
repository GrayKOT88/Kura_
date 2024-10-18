using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator playerAnim;
    [SerializeField] GameObject gameOverImege;
    [SerializeField] GameObject buttonPause;
    [SerializeField] AudioClip kura;
    public ParticleSystem explosionParticle;
    private float oldMousePositionX;
    private float eulerY;
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBarScript healthBar;
    public bool gameOver = false;
    private AudioSource playerAudio;
    void Start()
    {
        currentHealth = maxHealth;      
        healthBar.SetHealth(currentHealth);
        playerAudio = GetComponent<AudioSource>();
    }    
    void Update()
    {
        Movement();
        if(transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldMousePositionX = Input.mousePosition.x;            
        }
        if (Input.GetMouseButton(0) && !gameOver)
        {
            //transform.position += transform.forward * Time.deltaTime * speed;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            float deltaX = Input.mousePosition.x - oldMousePositionX;
            oldMousePositionX = Input.mousePosition.x;
            eulerY += deltaX;
            transform.eulerAngles = new Vector3(0, eulerY, 0);
            playerAnim.SetFloat("Speed_f", 1);
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            playerAnim.SetFloat("Speed_f", 0);           
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        playerAudio.PlayOneShot(kura,1);
        if(currentHealth <= 0)
        {
            gameOver = true;
            gameOverImege.gameObject.SetActive(true);
            buttonPause.gameObject.SetActive(false);
            //YandexGame.ResetSaveProgress(); // сбрасывает ВСЕ сохранения
            //YandexGame.SaveProgress();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            TakeDamage(1);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }    
}
