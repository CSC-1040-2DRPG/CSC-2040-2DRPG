using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int totalEnemies; // set to toal number of enemies in the scene
    public GameObject door;


    public int enemiesKilled;


    private void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Total Enemies: " + totalEnemies);
    }


    public void EnemyKilled() // when an enemy is killed
    {
        enemiesKilled++;
        if (enemiesKilled >= totalEnemies) // if all enemies are killed
        {
            if (door != null)
            {
                Debug.Log("Door destroyed!");
                Destroy(door);
            }
        }

    }


    private void Update()
    {
        Debug.Log("Enemies Killed: " + enemiesKilled);

    }
}