using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    //saving and loading of player data
    public void LoadData(GameData data){
        this.transform.position = data.playerPosition; //set current position to position stored in data
    }

    public void SaveData(GameData data){
        data.playerPosition = this.transform.position; //store current position in data
    }
}
