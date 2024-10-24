using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject player;
   
    public int damage = 10;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        // Chase the player
            transform.position = Vector2.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, speed * Time.deltaTime);
    }
}
