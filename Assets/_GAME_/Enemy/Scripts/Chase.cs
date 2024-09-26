using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            //when the square touches the player, this code runs
            speed += 0;
            print("You touched me!");

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, speed * Time.deltaTime);
        
    }
}