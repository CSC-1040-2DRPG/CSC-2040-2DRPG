using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class BoulderTrigger : MonoBehaviour
{
    public GameObject bossPrefab; 
    public Transform spawnLocation; //where the boss spawns
    public GameObject boulder;
    public GameObject self;
    public float spawnDelay;


    private bool bossSpawned = false; //only spawns in oneboss

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boulder") && !bossSpawned)
        {
            Destroy(boulder);
            Destroy(self);
            SpawnBoss();

        }
    }



    private void SpawnBoss()
    {
        if (bossPrefab != null && spawnLocation != null)
        {
            Instantiate(bossPrefab, spawnLocation.position, spawnLocation.rotation);
            Debug.Log("Boss Spawned");
            bossSpawned = true; // only one boss spawns.
        }
    }
}
