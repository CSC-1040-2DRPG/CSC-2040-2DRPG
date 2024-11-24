using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player_health : MonoBehaviour, IDataPersistence
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;
    private Animator animator;
    public bool isDead;
    public static Action OnPlayerDeath;
    public static Action OnEnemyDeath;


    void Start(){
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        isDead = false;
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

 private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);

        if (this.CompareTag("Player"))
        {
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke(); //? means it is not invoked if it is null 
        }
        else
        {
            OnEnemyDeath?.Invoke(); //Then it is an enemy -- then invoke
        }
    }



    public void Update()
    {
       
        
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
            //Debug.Log("Health Slider Updated: " + healthSlider.value);

   
        }
    }

    public void LoadData(GameData data){
        health = data.playerHealth;
    }

    public void SaveData(GameData data){
        data.playerHealth = health;
    }
}

