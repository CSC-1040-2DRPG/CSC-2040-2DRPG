using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
public class DataPesistenceManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool disableSaving;
    [SerializeField] private bool disableLoading;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private FileDataHandler dataHandler;
    private List<IDataPersistence> dataPersistenceObjects;
    public static DataPesistenceManager instance {get; private set;}

    private void Awake() {
        if(instance != null){
            Debug.LogError("Multiple Data Pesistence Managers found in this scene. This shouldn't happen");
        }
        instance = this;
    }

    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = findAlldataPersistenceObjects();
        LoadGame();
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    //get all scripts that inherit IDataPersistence
    private List<IDataPersistence> findAlldataPersistenceObjects(){
        return new List<IDataPersistence>(FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>());
    }

    public void LoadGame(){  
        if(disableLoading) return;      
        //get data from file
        this.gameData = dataHandler.Load();

        //start new game if no data
        if(this.gameData == null) {
            Debug.Log("No save found, starting new game.");
            NewGame();
        }

        //send data to all scripts inheriting IDataPersistence
        foreach (IDataPersistence dataObj in dataPersistenceObjects){
            dataObj.LoadData(gameData);
        }
    }

    public void SaveGame(){
        if(disableSaving) return;

        //get data to be saved from all scripts inheriting IDataPersistence
        foreach (IDataPersistence dataObj in dataPersistenceObjects) 
        {
            dataObj.SaveData(gameData);
        }

        //save data to file
        dataHandler.Save(gameData);
    }

    public void OnApplicationQuit(){
        SaveGame();
    }
}
