using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    public string winScene = "Win";

    public void onWin()
    {
        SceneManager.LoadScene(winScene);
        Debug.Log("onWin");
    }
}
