using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerPositionHandler : MonoBehaviour, IDataPersistence
{
    public Vector3 lastKnownPosition;
    public static playerPositionHandler instance {get; private set;}
    //make sure there's only one player
    private void Awake() {
        if(instance != null){
            Debug.Log("Found more than one Player in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    private void Update(){
        if (transform == null | transform.position.x +transform.position.y != 0) return;
        lastKnownPosition.x = transform.position.x;
        lastKnownPosition.y = transform.position.y;
    }

    private void Start(){
        //using this method instead of loadData because loadData is called whenever a new scene is loaded.
        //that would teleport the player back a scene so instead the player is teleported only on start
        GameData data = DataPesistenceManager.instance.dataHandler.Load();
        if (data == null) return;

        SceneManager.LoadScene(data.playerSceneName, LoadSceneMode.Single); //set player scene
        this.transform.position = data.playerPosition; //set player position
    }

    //saving and loading of player data
    public void LoadData(GameData data){
        //will load players inventory later
    }

    public void SaveData(GameData data){
        Debug.Log("position save");
        data.playerSceneName = SceneManager.GetActiveScene().name; //store player scene
        data.playerPosition = lastKnownPosition; //store player position
    }
}
