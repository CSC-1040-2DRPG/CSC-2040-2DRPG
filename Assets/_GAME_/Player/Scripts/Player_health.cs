using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    public Slider healthSlider;
    public float maxhealth = 100f;
    public float health;

    void Start()
    {
        health = maxhealth;
    }

    

    public void SetHealth(float newHealth)
    {
        health = newHealth;
        print("Updating!");
    }
void Update()
    {
        //health = health -0.001f;
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
    }

}

