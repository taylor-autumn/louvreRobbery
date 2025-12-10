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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionBox.SetActive(false);
        phoneButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)&& clickRef.godBox.activeSelf)
        {
            clickRef.godBoxAnimator.SetBool("fadeIn", false);
            cafeWorkerClick.inCafeMode = false;
            clickButton.inInteractionMode = false;
            StartCoroutine(delayBoxInactive());
            if (clickRef.firstInteraction)
            {
                clickRef.firstInteraction = false;
            }
            if (clickRef.taskCompleted)
            {
                clickRef.postTask = true;
            }
            
            clickButton phoneButtonScript = phoneInteractButton.GetComponent<clickButton>();
            if (phoneButtonScript.taskCompleted)
            {
                managerRef.AddToInventory(phoneButtonScript.taskPrize);
                phoneButton.SetActive(true);
                //here I would reference the prizes animator and give it to the guy
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
        yield return new WaitForSeconds(1f);
        clickRef.godBox.SetActive(false);
        clickRef.canBeClicked = true;
    }

}
