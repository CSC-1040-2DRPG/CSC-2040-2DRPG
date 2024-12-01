using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public int speed = 10;
    public float damage = 40f;
    public float ManaCost = 10f;

    private Animator animator;
    // Update is called once per frame


    void Start()
    {
        // when spell is instiated mana gets updated & animation plays
        if (playerDataHandler.instance.GetComponentInChildren<Player_mana>().mana >= ManaCost)
        {
            playerDataHandler.instance.GetComponentInChildren<Player_mana>().mana -= ManaCost;
            animator = GetComponent<Animator>();

            if (animator != null)
            {
                animator.SetTrigger("fireball_anim");
            }
            Destroy(gameObject, lifetime);
        }
    }
  

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            other.GetComponent<Enemy_health>().TakeDamage(damage);

            //destory spell after hitting
            Destroy(gameObject);
        }
    }
   

}
