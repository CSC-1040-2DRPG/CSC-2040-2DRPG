using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Audio")]
    [SerializeField] private AudioClip dialogueTypingSoundClip;
    private AudioSource audioSource;


    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    private static DialogueManager instance;

    [SerializeField] private float dialogueCooldown = 0.5f; // Half a second cooldown
    private float cooldownTimer = 0f;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        //return right away if dialogue isnt playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        //handle continuing to the next line in the dialogue when submit is pressed
        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
            cooldownTimer = dialogueCooldown; //reset the cooldown
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    public delegate void DialogueEnd();

    private void ExitDialogueMode()
    {
        Debug.Log("Exiting Dialogue Mode"); // Debug this
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
        displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
        }
        else{

            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        //empty the dialogue text
        dialogueText.text = "";

        //display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            audioSource.PlayOneShot(dialogueTypingSoundClip);
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinueToNextLine = true;
    }
}
