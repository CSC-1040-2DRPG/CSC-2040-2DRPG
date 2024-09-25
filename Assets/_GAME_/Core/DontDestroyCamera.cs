using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyCamera : MonoBehaviour
{
    public static DontDestroyCamera instance {get; private set;}
    private void Awake() {
        if(instance != null){
            Debug.Log("Found more than one Camera in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
}
