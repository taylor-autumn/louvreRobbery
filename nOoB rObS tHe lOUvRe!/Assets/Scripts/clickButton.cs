using System.Collections;
using TMPro;
using UnityEngine;

public class clickButton : MonoBehaviour
{

    [Header("Task Status")]
    public string requiredItem;
    public bool taskCompleted = false;
    public taskManager managerRef;
    public string taskPrize;
    public Animator prizePossessionAnimator;

    [Header("For the Notebook")]
    public Animator checkAnimator;
    //prob make a reference to the prizes animator so that it will be given to the guy

    [Header("Mouse Shit")]
    public GameObject mouse;
    public Animator mouseAnimator;

    [Header("General")]
    public bool canBeClicked = true;
    public Animator interactAnimator;
    public GameObject godBox;
    public Animator godBoxAnimator;
    public TMP_Text characterName;
    public TMP_Text taskLine;
    public movementScript moveRef;
    public int bgSortingLayer;
    public giveItem giveItemRef;
    public changePages changePgRef;
    public GameObject menu;
    public buttonReveal buttonRevealRef;

    [Header("Conversation Info")]
    public string NPCname;
    public string[] texts;
    public int currentIndex;
    public bool firstInteraction = true;
    public bool postTask = false;
    public Animator guyAnimator;
    

    [Header("In Interaction")]
    public static bool inInteractionMode = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        godBox.SetActive(false);
        menu.SetActive(false);
        currentIndex = 0;
        firstInteraction = true;
    }

    // Update is called once per frame
    void Update()
    {
        //switch(movementScript._myPlayer.myState)
        //{
        //    case movementScript.playerState.ONPHONE:
        //        break;

        //}


        if (gameObject.activeSelf && canBeClicked==true && Input.GetKeyDown(KeyCode.E) && !phoneShit.inPhoneMode && !cafeWorkerClick.inCafeMode && !inInteractionMode && !changePgRef.bookOpen)
        {
            click();
        }

        //if (!changePgRef.bookOpen)
        //{
        //    //NOTE FOR LATER, THIS DOESNT WORK, NOT A PRIORITY< it gets set active and the sorting order changes but for some reason it just doesnt show
        //    changePgRef.greyBG.SetActive(cafeWorkerClick.inCafeMode);
        //    moveRef.greyNonUIBG.SetActive(inInteractionMode);
        //    SpriteRenderer spriteRenderer = moveRef.greyNonUIBG.gameObject.GetComponent<SpriteRenderer>();
        //    spriteRenderer.sortingOrder = bgSortingLayer;
        //}

        //if (CompareTag("cafeButton"))
        //{
        //    menu.SetActive(cafeWorkerClick.inCafeMode);
        //}

    }

    public void click()
    {
        inInteractionMode = true;
        characterName.text = NPCname;

        managerRef.resetGuyAnimations();

        if (gameObject.CompareTag("mouseButton"))
        {
            mouse.SetActive(true);
            mouseAnimator.SetBool("out", true);
        }


        //if its the first interaction w this button, it should say the first line
        if (firstInteraction && !gameObject.CompareTag("securityButton"))
        {
            currentIndex = 0;
            taskLine.text = texts[currentIndex];
            firstInteraction=false;
        }
        else
        {
            if (!taskCompleted && !string.IsNullOrEmpty(requiredItem))
            {
                if (managerRef.checkInventory(requiredItem))
                {
                    //task completed line
                    taskCompleted = true;
                    currentIndex = 2;
                    taskLine.text = texts[currentIndex];
                    managerRef.completeTask(checkAnimator);
                    if (!gameObject.CompareTag("securityButton")) //doesn't add anything since there is no prize for security button
                    {
                        buttonRevealRef.possessItem(prizePossessionAnimator); //adds the item to the possessions UI tab
                    }
                    
                    if (gameObject.CompareTag("mouseButton"))
                    {
                        StartCoroutine(giveItems());
                    }

                    if (gameObject.CompareTag("phoneButton") || gameObject.CompareTag("securityButton"))
                    {
                        giveItemRef.completeAnimation();
                        giveItemRef.giveItem2();
                    }
                    
                }
                else
                {
                    //hint line
                    currentIndex = 1;
                    taskLine.text = texts[currentIndex];
                }
            }
            if (postTask)
            {
                currentIndex = 3;
                taskLine.text = texts[currentIndex];
            }
        
        }
        

        canBeClicked = false; //spam protection
        interactAnimator.SetBool("click", true); //clicks button
        godBox.SetActive(true); //sets god box active
        godBoxAnimator.SetBool("fadeIn", true); //fades in god box
        StartCoroutine(spamProtection()); //wait coroutine for spam protection
        //taskLine.gameObject.SendMessage("CheckText", taskLine.text); 
    }

    //public void nextText()
    //{
    //    currentIndex++;
    //    if (currentIndex >= texts.Length) { currentIndex = texts.Length - 1; }
    //}

    public IEnumerator spamProtection()
    {
        yield return new WaitForSeconds(.5f);
        interactAnimator.SetBool("click", false);
    }

    public IEnumerator giveItems()
    {
        yield return new WaitForSeconds(1f);
        giveItemRef.giveItem2();
        managerRef.AddToInventory("rose");
        yield return new WaitForSeconds(1f);
        giveItemRef.completeAnimation();
        yield return new WaitForSeconds(1f);
    }




}



