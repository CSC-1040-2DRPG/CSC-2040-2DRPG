using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{

    public Slider healthSlider;
    public float maxhealth = 100f;
    public float health; 


    void Start ()
    {
        health = maxhealth; 
    }

    void update  ()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }
    }


   
    

}
