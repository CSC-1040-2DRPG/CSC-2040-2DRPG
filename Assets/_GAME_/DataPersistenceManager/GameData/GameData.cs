using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData {
    public String playerSceneName;
    public Vector3 playerPosition;
    public float playerSpeed;
    public float playerHealth;
    public float playerMana;
    public SerializableDictionary<String, bool> chestsOpen;
    public Inventory playerInventory;
    public GameData() {
        playerSceneName = "HomeTown";
        playerPosition = Vector3.zero;
        playerSpeed = 5f;

        playerHealth = 100f;
        playerMana = 100f;

        chestsOpen = new SerializableDictionary<String, bool>();
        playerInventory = new Inventory();
    }
}
