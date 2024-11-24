using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private TextConsoleSimulator ScoreValueText; //How many enemies have been killed

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
       //OnPlayerDeath += ActivateGameObject;
        //Health.OnEnemyDeath += CountScpre;
        //this.gameObject.SetActivate(false);
    }

    private void OnDestroy()
    {
        //Health.OnPlayerDeath -= ActivateGameObject;
        //Health.OnEnemyDeath -= CountScore;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(4); //Returns to main menu
    }

    private void CountScore()
    {
        score++;
    }
   
    private void ActivateGameObject()
    {
       // this.ActivateGameObject(true);
        //ScoreValueText.text = score.ToString(); //sets text of UI to the value of Score
    }

}
