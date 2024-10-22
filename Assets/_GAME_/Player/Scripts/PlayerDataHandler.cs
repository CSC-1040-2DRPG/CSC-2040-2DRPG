using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDataHandler : MonoBehaviour, IDataPersistence
{
    public static playerDataHandler instance {get; private set;}
    public Inventory inventory;
    private void Awake() {
        if(instance != null){
            Debug.Log("Found more than one Player in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        inventory = new Inventory();
    }

    private void Start(){
        //using this method instead of loadData because loadData is called whenever a new scene is loaded.
        //that would teleport the player back a scene so instead the player is teleported only on start
        GameData data = DataPesistenceManager.instance.gameData;
        if (data == null) return;

        SceneManager.LoadScene(data.playerSceneName, LoadSceneMode.Single); //set player scene
        this.transform.position = data.playerPosition; //set player position
    }

    public void OnApplicationQuit(){
        GameData data = DataPesistenceManager.instance.gameData;

        data.playerSceneName = SceneManager.GetActiveScene().name; //store player scene
        data.playerPosition = transform.position; //store player position
    }

    //saving and loading of player data
    public void LoadData(GameData data){
        inventory = data.playerInventory;
    }

    public void SaveData(GameData data){
        data.playerInventory = inventory;
    }
}
