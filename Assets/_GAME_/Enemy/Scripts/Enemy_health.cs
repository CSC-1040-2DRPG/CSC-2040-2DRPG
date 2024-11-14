using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_health : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;




    void Start(){
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void TakeDamage(float playerDamage)
    {
        health = Mathf.Max(health - playerDamage, 0);
       
        healthSlider.value = health;

      
        Debug.Log("Health Updated: " + health);
        Debug.Log("Health Slider Updated: " + healthSlider.value);
    
    }


    public void HealHealth (float heal)
    {
        health = Mathf.Max(health + heal,0);
    }

 

    public void Update()
    {
       
        
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
            //Debug.Log("Health Slider Updated: " + healthSlider.value);

   
        }
    }
}


