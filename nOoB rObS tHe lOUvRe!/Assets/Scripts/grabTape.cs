using System.Collections;
using UnityEngine;

public class grabTape : MonoBehaviour
{

    public bool hasTape = false;
    public GameObject interactionCircle;
    public buttonReveal buttonRevealRef;
    public taskManager managerRef;
    public Animator tapeAnimator;
    public Animator tapePossession;
    public changePages changesPgRef;
    public Animator interactAnimator;
    public bool canBeClicked = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasTape && !phoneShit.inPhoneMode && !cafeWorkerClick.inCafeMode && !clickButton.inInteractionMode && !changesPgRef.bookOpen)
        {
            tapeShit();
            managerRef.notifBox("Tape Acquired!");
        }
    }

    public void tapeShit()
    {
        tapeAnimator.SetBool("take", true);
        managerRef.AddToInventory("tape");
        buttonRevealRef.possessItem(tapePossession);
        canBeClicked = false; //spam protection
        interactAnimator.SetBool("click", true); //clicks button
        hasTape = true;
        StartCoroutine(endFunction()); //wait coroutine for spam protection
    }
    public IEnumerator endFunction()
    {
        yield return new WaitForSeconds(.5f);
        interactAnimator.SetBool("click", false);
        interactionCircle.SetActive(false);
    }

}
