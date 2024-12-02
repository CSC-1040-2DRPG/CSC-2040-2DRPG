using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public int speed = 10;
    public float damage = 40f;
    public float ManaCost = 10f;
    public float lifetime = 1f;
    private Animator animator;
    public AudioManager audioManager;
    // Update is called once per frame

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // when spell is instiated mana gets updated & animation plays
        if (playerDataHandler.instance.GetComponentInChildren<Player_mana>().mana >= ManaCost)
        {
            playerDataHandler.instance.GetComponentInChildren<Player_mana>().mana -= ManaCost;
            animator = GetComponent<Animator>();
            audioManager.PlaySFX(audioManager.boomsound);

            if (animator != null)
            {
                animator.SetTrigger("fireball_anim");
            }
            Destroy(gameObject, .833333333f);
        }
    }
  

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            other.GetComponentInChildren<Enemy_health>().TakeDamage(damage);

            //destory spell after hitting
            Destroy(gameObject, .833333333f);
        }
    }
   

}
