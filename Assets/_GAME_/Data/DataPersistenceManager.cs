using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPesistenceManager : MonoBehaviour
{
    private GameData gameData;
    private List<IDataPersistence> dataPersistencesObjects;
    public static DataPesistenceManager instance {get; private set;}

    private void Awake() {
        if(instance != null){
            Debug.LogError("Multiple Data Pesistence Managers found in this scene. This shouldn't happen");
        }
        instance = this;
    }

    private void Start(){
        this.dataPersistencesObjects = findAllDataPersistencesObjects();
        LoadGame();
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    //get all scripts that inherit IDataPersistence
    private List<IDataPersistence> findAllDataPersistencesObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>(); 

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void LoadGame(){
        // TODO - load data from file

        if(this.gameData == null) {
            Debug.Log("No save found, starting new game.");
            NewGame();
        }

        foreach (IDataPersistence dataObj in dataPersistencesObjects){
            dataObj.LoadData(gameData);
        }
    }

    public void SaveGame(){
        //

        //TODO - save data to file

    }

    public void OnApplicationQuit(){
        SaveGame();
    }
}
