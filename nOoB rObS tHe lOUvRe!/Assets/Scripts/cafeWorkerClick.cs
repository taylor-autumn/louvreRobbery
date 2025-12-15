using System.Collections;
using TMPro;
using UnityEngine;

public class cafeWorkerClick : MonoBehaviour
{
    
    [Header("General")]
    public bool canBeClicked = true;
    public taskManager managerRef;
    public Animator interactAnimator;
    public GameObject godBox;
    public Animator godBoxAnimator;
    public movementScript moveRef;
    public changePages changePgRef;
    public GameObject menu;
    public Animator guyAnimator;

    [Header("Conversation Info")]
    public TMP_Text characterName;
    public TMP_Text taskLine;
    public string cafeLine;
    public string NPCname;

    public static bool inCafeMode = false;

    [Header("Check/Complete Task Notebook")]
    public Animator checkAnimator;
    public bool ringPopAchieved = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ringPopAchieved)
        {
            if (managerRef.checkInventory("ring pop"))
            {
                managerRef.completeTask(checkAnimator);
                ringPopAchieved = true;
            }
        }


        if (gameObject.activeSelf && canBeClicked == true && Input.GetKeyDown(KeyCode.E) && !phoneShit.inPhoneMode && !clickButton.inInteractionMode && !changePgRef.bookOpen)
        {
            click();
        }

        if (!changePgRef.bookOpen)
        {
            changePgRef.greyBG.SetActive(inCafeMode);
        }

        if (CompareTag("cafeButton"))
        {
            menu.SetActive(inCafeMode);
        }

    }

    public void click()
    {
        characterName.text = NPCname;
        taskLine.text = cafeLine;

        managerRef.resetGuyAnimations();

        canBeClicked = false; //spam protection
        interactAnimator.SetBool("click", true); //clicks button
        godBox.SetActive(true); //sets god box active
        godBoxAnimator.SetBool("fadeIn", true); //fades in god box
        StartCoroutine(spamProtection()); //wait coroutine for spam protection

        if (CompareTag("cafeButton"))
        {
            inCafeMode = true;
        }
    }

    public IEnumerator spamProtection()
    {
        yield return new WaitForSeconds(.5f);
        interactAnimator.SetBool("click", false);
    }

}




