using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData {
    public String playerSceneName;
    public Vector3 playerPosition;
    public float playerSpeed;
    public SerializableDictionary<String, bool> chestsOpen;
    public Inventory playerInventory;
    public GameData() {
        playerSceneName = "HomeTown";
        playerPosition = Vector3.zero;
        playerSpeed = 5f;

        chestsOpen = new SerializableDictionary<String, bool>();
        playerInventory = new Inventory();
    }
}
