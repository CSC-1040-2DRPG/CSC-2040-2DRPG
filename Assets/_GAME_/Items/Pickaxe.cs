using System;
using System.Collections;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public string animationClipName;
    public float delay;

    //flag to block repeated attacks 
    private bool attackBlocked;

    public void Swing()
    {
        if (attackBlocked) return;

        //make sword visable and colliable
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        //trigger animation 
        GetComponent<Animator>().Play(animationClipName);
        
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

    }
}
