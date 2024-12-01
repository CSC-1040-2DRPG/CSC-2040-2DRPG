using System;
using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damageAmount = 20;

    public string animationClipName;
    public float delay;

    //flag to block repeated attacks 
    private bool attackBlocked;

    public void Attack()
    {
        if (attackBlocked) return;

        //make sword visable and colliable
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        //trigger animation 
        GetComponent<Animator>().Play(animationClipName);
        
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack(){
        attackBlocked = true;
        //wait for delay before allowing player to attack again
        yield return new WaitForSeconds(delay);
        //make sword invisible and turn off collider
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        attackBlocked = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject;

            enemy.GetComponentInChildren<Enemy_health>().TakeDamage(damageAmount);
        }

        if (collision.gameObject.CompareTag("Spawner"))
        {
            GameObject Spawner = collision.gameObject;
            Spawner.GetComponentInChildren<Spawner_health>().TakeDamage(damageAmount);

        }

    }
}
