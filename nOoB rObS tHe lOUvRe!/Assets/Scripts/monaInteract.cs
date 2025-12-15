using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class monaInteract : MonoBehaviour
{
    [Header("Task Status")]
    public bool taskCompleted = false;
    public Animator checkAnimator;

    [Header("Phone Screens")]
    public GameObject igPhotoDraft;
    public GameObject photoFilled;

    [Header("Guy Animator")]
    public Animator guyAnimator;

    [Header("Banana Stuff")]
    public GameObject banana;
    public GameObject tape;

    [Header("General")]
    public taskManager managerRef;
    public bool canBeClicked = true;
    public Animator interactAnimator;
    public GameObject godBox;
    public Animator godBoxAnimator;
    public TMP_Text characterName;
    public TMP_Text taskLine;
    public movementScript moveRef;
    public changePages changePgRef;
    public phoneShit phoneRef;

    [Header("Conversation Info")]
    public string NPCname;
    public string[] texts;
    public int currentIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        godBox.SetActive(false);
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.activeSelf && !godBox.activeSelf && canBeClicked == true && Input.GetKeyDown(KeyCode.E) && !phoneShit.inPhoneMode && !cafeWorkerClick.inCafeMode && !clickButton.inInteractionMode && !changePgRef.bookOpen)
        {
            click();
        }

    }

    public void click()
    {
        characterName.text = NPCname;
        clickButton.inInteractionMode = true;

        if (gameObject.CompareTag("monaButton"))
        {
            managerRef.resetGuyAnimations();


            if (!managerRef.checkInventory("phone"))
            {
                currentIndex = 0;
                taskLine.text = texts[currentIndex];
                repetitiveShit();

            }
            else
            {
                if (!taskCompleted)
                {
                    if (managerRef.checkInventory("phone"))
                    {
                        //task completed line
                        taskCompleted = true;
                        canBeClicked = false; //spam protection
                        interactAnimator.SetBool("click", true); //clicks button
                        StartCoroutine(spamProtection()); //wait coroutine for spam protection

                        StartCoroutine(selfieAnim());
                        phoneRef.ChangeIGMode(igPhotoDraft);
                        phoneRef.changePhotoMode(photoFilled);

                    }
                }
                else if (taskCompleted)
                {
                    currentIndex = 2;
                    taskLine.text = texts[currentIndex];
                    repetitiveShit();
                }
            }
        }
        else if (gameObject.CompareTag("bananaButton"))
        {
            managerRef.resetGuyAnimations();

            if (!managerRef.checkInventory("banana") && !managerRef.checkInventory("tape"))
            {
                currentIndex = 0;
                taskLine.text = texts[currentIndex];
                repetitiveShit();
            }
            else
            {
                if (!taskCompleted)
                {
                    if (managerRef.checkInventory("banana") && managerRef.checkInventory("tape"))
                    {
                        //task completed line
                        taskCompleted = true;
                        canBeClicked = false; //spam protection
                        interactAnimator.SetBool("click", true); //clicks button
                        StartCoroutine(spamProtection()); //wait coroutine for spam protection
                        banana.SetActive(true);
                        tape.SetActive(true);
                        StartCoroutine(bananaAnim());

                    }
                    else
                    {
                        currentIndex = 0;
                        taskLine.text = texts[currentIndex];
                        repetitiveShit();
                    }
                }
                else if (taskCompleted)
                {
                    currentIndex = 2;
                    taskLine.text = texts[currentIndex];
                    repetitiveShit();
                }
            }
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

    public IEnumerator selfieAnim()
    {
        yield return new WaitForSeconds(.3f);
        guyAnimator.SetBool("selfie", true);
        yield return new WaitForSeconds(2f);
        currentIndex = 1; //change text
        taskLine.text = texts[currentIndex]; //change text
        managerRef.completeTask(checkAnimator); //completes the text
        godBox.SetActive(true); //sets god box active
        godBoxAnimator.SetBool("fadeIn", true); //fades in god box
        guyAnimator.SetBool("selfie", false); //change 
    }

    public IEnumerator bananaAnim()
    {
        yield return new WaitForSeconds(2f);
        banana.SetActive(false);
        tape.SetActive(false);
        currentIndex = 1; //change text
        taskLine.text = texts[currentIndex]; //change text
        managerRef.completeTask(checkAnimator); //completes the text
        godBox.SetActive(true); //sets god box active
        godBoxAnimator.SetBool("fadeIn", true); //fades in god box
    }

}



