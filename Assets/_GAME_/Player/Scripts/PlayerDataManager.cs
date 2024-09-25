using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    public static PlayerData instance {get; private set;}
    //make sure there's only one player
    private void Awake() {
        if(instance != null){
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("PDM Awoken");
    }

    //saving and loading of player data
    public void LoadData(GameData data){
        Debug.Log("PDM Data Loaded");
        SceneManager.LoadScene(data.playerSceneName, LoadSceneMode.Single);
        this.transform.position = data.playerPosition; //set current position to position stored in data
    }

    public void SaveData(GameData data){
        Debug.Log("PDM Data Saved");
        data.playerSceneName = SceneManager.GetActiveScene().name;
        data.playerPosition = this.transform.position; //store current position in data
    }
}
