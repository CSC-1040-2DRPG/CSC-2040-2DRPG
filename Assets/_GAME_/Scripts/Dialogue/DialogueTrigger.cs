using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private bool dialogueStarted = false;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);

    }

    private void Update()
    {
        if (playerInRange && !dialogueStarted)
        {
            visualCue.SetActive(!DialogueManager.GetInstance().dialogueIsPlaying);

            if (!DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.Space))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                dialogueStarted = true;
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    // Reset when dialogue ends
    private void OnEnable()
    {
        DialogueManager.OnDialogueEnd += ResetDialogueTrigger;
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueEnd -= ResetDialogueTrigger;
    }

    private void ResetDialogueTrigger()
    {
        dialogueStarted = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }
    }
}