using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{


    public int damage = 10;
    public float speed;
    public Enemy_health health;
    public int rewardAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInChildren<Enemy_health>();
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


    public void Squaredeath(float health)
    {
        if (health == 0)
        {

            Destroy(gameObject);
            print("enemy has died.");
            MoneyManager.Instance.AddMoney(rewardAmount); //add money to player
        }
    }


    // Update is called once per frame
    void Update()
    {
        //If health is 0, remove the square
        Squaredeath(health.GetEnemyHealth());

        // Chase the player
        if (GameObject.FindWithTag("Player") != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, speed * Time.deltaTime);

        }
    }
}
