using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    
    //provided player position accessors and mutators in case anyone finds them helpful
    public void setPlayerPosition(Vector3 pos){
        this.transform.position = pos;
    }

    public Vector3 getPlayerPosition(){
        return this.transform.position;
    }

    //saving and loading of player data
    public void LoadData(GameData data){
        setPlayerPosition(data.playerPosition); //set current position to position stored in data
    }

    public void SaveData(GameData data){
        data.playerPosition = getPlayerPosition(); //store current position in data
    }
}
