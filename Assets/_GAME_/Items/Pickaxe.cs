using System;
using System.Collections;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public float damageAmount = 5;
    public string animationClipName;
    public float delay;
    public AudioManager audioManager;

    //flag to block repeated attacks 
    private bool attackBlocked;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Swing()
    {
        if (attackBlocked) return;

        //make sword visable and colliable
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        //trigger animation 
        GetComponent<Animator>().Play(animationClipName);
        audioManager.PlaySFX(audioManager.stonebreak);

        StartCoroutine(DelaySwing());
    }

    private IEnumerator DelaySwing(){
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
        if (collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.stonebreak);

        }

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
