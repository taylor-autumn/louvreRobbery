using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class finalRobMode : MonoBehaviour
{
    [Header("Task Status")]
    public bool danceTaskCompleted = false;
    public bool taskCompleted = false;
    public bool taskFailed = false;
    public Animator checkAnimator;
    public Animator ringPossessionAnimator;
    public buttonReveal buttonRef;

    [Header("General")]
    public bool canBeClicked = true;
    public Animator interactAnimator;
    public GameObject finalInteractionBox;
    public GameObject godBox;
    public Animator godBoxAnimator;

    [Header("Script References")]
    public taskManager managerRef;
    public movementScript moveRef;
    public changePages changePgRef;
    public phoneShit phoneRef;
    public cutScene1Manager cutRef;

    [Header("Conversation Info")]
    public string NPCname;
    public string hastyText;
    public TMP_Text characterName;
    public TMP_Text taskLine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        godBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.activeSelf && canBeClicked == true && Input.GetKeyDown(KeyCode.E) && !phoneShit.inPhoneMode && !cafeWorkerClick.inCafeMode && !clickButton.inInteractionMode && !changePgRef.bookOpen)
        {
            click();
        }

    }

    public void click()
    {
        characterName.text = NPCname;
        managerRef.resetGuyAnimations();
        clickButton.inInteractionMode = true;

        if (!danceTaskCompleted)
        {

            taskLine.text = hastyText;
            repetitiveShit();

        }
        else
        {
            canBeClicked = false;
            interactAnimator.SetBool("click", true); //clicks button
            StartCoroutine(spamProtection()); //wait coroutine for spam protection
            finalInteractionBox.SetActive(true); //keeps it on so it remains active in the final scene
            print("going to final rob mode");
            StartCoroutine(cutRef.startStealMode());
        }
    }

    public void repetitiveShit()
    {
        canBeClicked = false; //spam protection
        interactAnimator.SetBool("click", true); //clicks button
        godBox.SetActive(true); //sets god box active
        godBoxAnimator.SetBool("fadeIn", true); //fades in god box
        StartCoroutine(spamProtection()); //wait coroutine for spam protection
    }

    public IEnumerator spamProtection()
    {
        yield return new WaitForSeconds(.5f);
        interactAnimator.SetBool("click", false);
        canBeClicked = true;
    }
}
