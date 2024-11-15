using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{


    public int damage = 10;
    public float speed;
    public Spawner_health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInChildren<Spawner_health>();
    }

    // Detect collision with player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameObject player = collision.gameObject;
            
            // call to TakeDamage function -> inside Player_health script 
            player.GetComponentInChildren<Player_health>().TakeDamage(damage);
        }
    }


    public void Spawnerdeath(float health)
    {
        if (health == 0)
        {

            Destroy(gameObject);
            print("Spawner has died.");
        }
    }


    // Update is called once per frame
    void Update()
    {
        //If health is 0, remove the square
        Spawnerdeath(health.GetEnemyHealth());

    }
}
