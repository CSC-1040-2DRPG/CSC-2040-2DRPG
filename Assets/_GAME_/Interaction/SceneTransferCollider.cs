using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    [SerializeField] public String sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger entered");
        if(other.tag== "Player") {
            print("switching scene to " + sceneName);
                DataPesistenceManager.instance.SaveGame();
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
