using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class interactButtons : MonoBehaviour
{

    public GameObject interactionBox;
    public clickButton clickRef;
    public GameObject phoneInteractButton;
    public GameObject phoneButton;
    public taskManager managerRef;
    public Animator mouseAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionBox.SetActive(false);
        if (!interactionBox.CompareTag("mouseButton") && !interactionBox.CompareTag("securityButton"))
        {
            phoneButton.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //note for the future, there is a bug here where it is possible the player spams two buttons fast
        //and bc of the spammming, it just shuts off the god box and bc its not active like in the condition
        //u get stuck. This can be fixed by making sure u cant spam one box after another but I don't have time rn lol

        if (Input.GetKeyDown(KeyCode.Q) && clickRef.godBox.activeSelf)
        {
            clickRef.godBoxAnimator.SetBool("fadeIn", false);
            cafeWorkerClick.inCafeMode = false;
            clickButton.inInteractionMode = false;
            StartCoroutine(delayBoxInactive());
            if (clickRef.taskCompleted)
            {
                clickRef.postTask = true;
            }
            
            if (interactionBox.CompareTag("phoneButton"))
            {
                clickButton phoneButtonScript = phoneInteractButton.GetComponent<clickButton>();
                if (phoneButtonScript.taskCompleted)
                {
                    managerRef.AddToInventory(phoneButtonScript.taskPrize);
                    phoneButton.SetActive(true);
                }
            }
            if (interactionBox.CompareTag("mouseButton"))
            {
                mouseAnimator.SetBool("out", false);
            }
            if (interactionBox.CompareTag("securityButton"))
            {
                clickButton securityButtonScript = interactionBox.GetComponent<clickButton>();
                if (securityButtonScript.taskCompleted)
                {
                    managerRef.completeSecurity();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionBox.SetActive(false);
        }
    }

    public IEnumerator delayBoxInactive()
    {
        yield return new WaitForSeconds(.3f);
        clickRef.godBox.SetActive(false);
        clickRef.canBeClicked = true;
    }

}
