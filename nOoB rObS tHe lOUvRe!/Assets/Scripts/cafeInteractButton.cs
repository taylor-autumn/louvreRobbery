using System.Collections;
using UnityEngine;

public class cafeInteractButton : MonoBehaviour
{
    public GameObject interactionBox;
    public clickButton clickRef;
    public cafeWorkerClick cafeRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && clickRef.godBox.activeSelf)
        {
            clickRef.godBoxAnimator.SetBool("fadeIn", false);
            cafeWorkerClick.inCafeMode = false;
            StartCoroutine(delayBoxInactive());

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
        cafeRef.canBeClicked = true;
    }
}