using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;

public class Player_house_script : MonoBehaviour
{
    [SerializeField] public String sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger entered");
        if(other.tag== "Player") {
            print("switching scene to " + sceneName);
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
