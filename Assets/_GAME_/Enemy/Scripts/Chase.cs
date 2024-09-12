using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float speed;

    private void onTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            speed = +1;
            print("You touched me!");
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }



}
