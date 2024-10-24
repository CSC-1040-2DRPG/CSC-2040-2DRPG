using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;
    

    void Start(){
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;

    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
       
        healthSlider.value = health;
       // Debug.Log("Health Updated: " + health);
      //  Debug.Log("Health Slider Updated: " + healthSlider.value);

    }


    public void HealHealth (float heal)
    {
        health = Mathf.Max(health + heal,0);
    }

    public void CheckDeath() 
    { 
        if(health == 0)
        {
           print("player died");
        }
    }

    public void Update()
    {
       CheckDeath();
        
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
            //Debug.Log("Health Slider Updated: " + healthSlider.value);
        }
    }

}

