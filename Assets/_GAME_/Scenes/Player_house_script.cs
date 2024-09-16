using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Player_house_script : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger entered");
            if(other.tag== "Player")
        {
            print("switching scene to " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }





    }




}
