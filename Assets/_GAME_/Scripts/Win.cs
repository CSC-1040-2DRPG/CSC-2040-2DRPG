using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    public string winScene = "Win";

    public void onWin()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            Destroy(player);
        }

        SceneManager.LoadScene(winScene);
        Debug.Log("onWin");
    }
}
