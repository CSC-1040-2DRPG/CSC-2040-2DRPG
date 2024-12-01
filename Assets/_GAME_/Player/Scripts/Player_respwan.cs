using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_respwan : MonoBehaviour
{
 
    private Vector3 respawnPosition; 
    private float playerHealth;
    public Transform respawnPoint;
    private float playerMana;


    // activate checkpoint
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SavePlayerState(other);

        }
    }


    // save all player variables 
    void SavePlayerState(Collider2D playerCollider)

    {

        playerDataHandler.instance.GetComponent<Player_Controller>().SetLastBonfire(respawnPoint);
      
        playerHealth = 100f;
        playerMana = 100f; 
        Debug.Log("saved position "+ respawnPosition);

    }

 

    void RespawnPlayer()

    {

        if (playerDataHandler.instance.GetComponent<Player_Controller>().lastBonfire != null)
        {
            respawnPosition = playerDataHandler.instance.GetComponent<Player_Controller>().lastBonfire.position;

        }
        else
        {
            respawnPosition = new Vector3(1.0f, 1.0f, 0f);
        }
        
        playerDataHandler.instance.GetComponent<Player_Controller>().SetLastBonfire(respawnPoint);

        playerDataHandler.instance.transform.position = respawnPosition;

        playerDataHandler.instance.GetComponentInChildren<Player_health>().health = playerHealth;

        playerDataHandler.instance.GetComponentInChildren<Player_mana>().mana = playerMana;

        playerDataHandler.instance.GetComponentInChildren<Player_health>().isDead = false;

        playerDataHandler.instance.GetComponentInChildren<Player_Controller>().enabled = true;


    }





    // when player health is 0, respawn player
    void Update()
    {
       if (playerDataHandler.instance.GetComponentInChildren<Player_health>().health <= 0)
       {
           
            
                RespawnPlayer();
            
       }
    }
}
