using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerinRange;
    private void Awake()
    {
        playerinRange = false;
        visualCue.SetActive(false);
    }
    
    private void Update()
    {
        if (playerinRange)
        {
            visualCue.SetActive(true);
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
    if (collider.gameObject.tag == "Player")
        {
            playerinRange = false;
        }
    }
}
