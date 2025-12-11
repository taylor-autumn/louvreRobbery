using System.Collections;
using TMPro;
using UnityEngine;

public class openWallPaper : MonoBehaviour
{

    public int whichPaper;

    public GameObject redHerring1;
    public GameObject redHerring2;
    public GameObject wifiPaper;
    public GameObject TBDSign;
    public TMP_Text closeText;
    public changePages changesPgRef;
    public Animator guyAnimator;

    public Animator interactAnimator;
    public bool canBeClicked = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closePage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !phoneShit.inPhoneMode && !cafeWorkerClick.inCafeMode && !clickButton.inInteractionMode && !changesPgRef.bookOpen)
        {
            openPaper(whichPaper);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            closePage();
        }
    }

    public void openPaper(int whichOne)
    {
        guyAnimator.SetBool("down", false);
        guyAnimator.SetBool("up", false);
        guyAnimator.SetBool("left", false);
        guyAnimator.SetBool("right", false);

        closeText.gameObject.SetActive(true);
        if (whichOne == 1)
        {
            redHerring1.SetActive(true);
            redHerring2.SetActive(false);
            wifiPaper.SetActive(false);
            TBDSign.SetActive(false);
            closeText.color = Color.black;
            clickButton.inInteractionMode = true;

        }
        else if (whichOne == 2)
        {
            redHerring2.SetActive(true);
            redHerring1.SetActive(false);
            wifiPaper.SetActive(false);
            TBDSign.SetActive(false);
            closeText.color = Color.black;
            clickButton.inInteractionMode = true;
        }
        else if (whichOne == 3)
        {
            redHerring1.SetActive(false);
            redHerring2.SetActive(false);
            wifiPaper.SetActive(false);
            TBDSign.SetActive(true);
            closeText.color = Color.white;
            clickButton.inInteractionMode = true;
        }
        else
        {
            wifiPaper.SetActive(true);
            redHerring2.SetActive(false);
            redHerring1.SetActive(false);
            TBDSign.SetActive(false);
            closeText.color = Color.black;
            clickButton.inInteractionMode = true;
        }

        canBeClicked = false; //spam protection
        interactAnimator.SetBool("click", true); //clicks button
        StartCoroutine(spamProtection()); //wait coroutine for spam protection
    }

    public void closePage()
    {
        redHerring1.SetActive(false);
        redHerring2.SetActive(false);
        wifiPaper.SetActive(false);
        TBDSign.SetActive(false);
        closeText.gameObject.SetActive(false);
        clickButton.inInteractionMode = false;
    }

    public IEnumerator spamProtection()
    {
        yield return new WaitForSeconds(.5f);
        interactAnimator.SetBool("click", false);
    }

}
