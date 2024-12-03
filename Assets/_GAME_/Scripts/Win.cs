using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    public string winScene = "Win";

    public void onWin()
    {
        DestroyAllDontDestroyOnLoadObjects();

        SceneManager.LoadScene(winScene);
        Debug.Log("onWin");
    }

    public void DestroyAllDontDestroyOnLoadObjects()
    {

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        foreach (var root in go.scene.GetRootGameObjects())
            Destroy(root);

    }
}
