using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //When we die, time scale to 0 so time stops

    }

    public void ContinueGameButton()
    {
        SceneManager.LoadScene("HomeTown", LoadSceneMode.Single);
    }

    public void NewGameButton()
    {
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveWithoutCheckingPersistenceObjects();
        SceneManager.LoadScene("HomeTown", LoadSceneMode.Single);
    }

    public void ExitGameButton()
    {
        Application.Quit(); //Closes application
    }

}
