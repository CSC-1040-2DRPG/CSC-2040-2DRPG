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

   public void StartGameButton()
    {
        SceneManager.LoadScene(0); //Scene index
    }
    public void ExitGameButton()
    {
        Application.Quit(); //Closes application
    }

}
