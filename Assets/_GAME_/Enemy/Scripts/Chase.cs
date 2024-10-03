using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject player;
    private Player_health p1Health;  // Reference to the Player_health component
    public int damage = 10;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Player_health component from the player GameObject
        p1Health = player.GetComponentInChildren<Player_health>();
    }

    // Detect collision with player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("You have touched me!");

            // Get the current health, subtract damage, and update health
            float newHealth = p1Health.health - damage;

            // Ensure the health doesn't drop below zero
            p1Health.health = Mathf.Max(newHealth, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Chase the player
        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, speed * Time.deltaTime);    }
}
