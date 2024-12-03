using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Text ScoreValueText; //How many enemies have been killed

    private int score = 0;

   
  

    private void OnDestroy()
    {
      
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); //Returns to main menu
    }

 
   

}
