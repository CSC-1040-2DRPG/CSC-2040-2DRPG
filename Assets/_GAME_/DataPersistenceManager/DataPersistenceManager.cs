using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;
public class DataPesistenceManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool disableSaving;
    [SerializeField] private bool disableLoading;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    public GameData gameData;
    public FileDataHandler dataHandler;
    private List<IDataPersistence> dataPersistenceObjects;
    public static DataPesistenceManager instance {get; private set;}

    private void Awake() {
        if(instance != null){
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    // private void Start(){
    //     this.dataPersistenceObjects = FindAllDataPersistenceObjects();
    //     LoadGame();
    // }

    //get all scripts that inherit IDataPersistence
    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        Debug.Log("Data Persistant objects aquired");
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){    
        if(disableLoading) {
            NewGame();
            return;
        }   

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
        Debug.Log("Game Loaded!");
    }

    public void SaveGame(){
        if(disableSaving) return;

        if (this.gameData == null) 
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }

        //get data to be saved from all scripts inheriting IDataPersistence
        foreach (IDataPersistence dataObj in dataPersistenceObjects) 
        {
            if(dataObj == null) {
                Debug.LogWarning(dataObj + " is null! make sure it doesn't get removed before saving");
                break;
            }
            Debug.Log(dataObj + " data saved");
            dataObj.SaveData(gameData);
        }

        //save data to file
        dataHandler.Save(gameData);

        Debug.Log("Game Saved!");
    }

    public void OnApplicationQuit(){
        Debug.Log("Application Quit 1");
        SaveGame();
        Debug.Log("Application Quit 2");
    }
}
