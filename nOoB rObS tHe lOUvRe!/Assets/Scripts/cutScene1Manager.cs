using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cutScene1Manager : MonoBehaviour
{
    public bool inGameStart = true;
    public GameObject instructionSheet;
    public GameObject startingInteractBox;
    public taskManager managerRef;
    public changePages changesPgRef;
    public Animator interactAnimator;
    public bool canBeClicked = true;

    [Header("intro shit")]
    public GameObject notebook;
    public Button phone;
    public GameObject fadeScreen;
    public Animator fadeScreenAnimator;
    public Camera mainCam;
    public GameObject guy;
    public Animator fakeGuyAnimator;
    public bool inInstructions;
    public GameObject signs;

    [Header("Final Rob Shit")]
    public Button ringButton;
    public Button panel;
    public Button deathButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notebook.SetActive(false);
        ringButton.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        signs.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inGameStart)
        {
            startGame();
        }
        if (Input.GetKeyDown(KeyCode.Q) && inInstructions)
        {
            //starts game play
            instructionSheet.SetActive(false);
            startingInteractBox.SetActive(true);
            clickButton.inInteractionMode = false;
            inInstructions = false;
            managerRef.defaultGameMusic.Play();
           
        }

        if (managerRef.stolen)
        {
            ringButton.gameObject.SetActive(false);
        }

    }

    public void startGame()
    {
        canBeClicked = false; //spam protection
        StartCoroutine(managerRef.fadeAudio(managerRef.startingMusic, 0f, 1f));
        managerRef.resetGuyAnimations();
        clickButton.inInteractionMode = true;
        interactAnimator.SetBool("click", true); //clicks button
        StartCoroutine(startGameRoutine()); //wait coroutine for spam protection
        inGameStart = false;
    }

    public IEnumerator startGameRoutine()
    {
        yield return new WaitForSeconds(.5f);
        interactAnimator.SetBool("click", false);
        fadeScreen.SetActive(true);
        fadeScreenAnimator.SetBool("fade", true);
        yield return new WaitForSeconds(1f);
        signs.SetActive(false);
        managerRef.crashNoise.Play();
        yield return new WaitForSeconds(.5f);
        mainCam.transform.position = new Vector3(0, 0, -10);
        guy.transform.position=new Vector2 (0, -0.18f);

        SpriteRenderer guySprite = guy.GetComponent<SpriteRenderer>();
        guySprite.enabled = false;
    }

    public void deactivateFadeScreen()
    {
        fadeScreen.SetActive(false);
        fakeGuyAnimator.SetBool("breakIn", true);
    }

    //just to deactivate ik its inefficient suck my ass
    public void endFadeScreenFinal()
    {
        fadeScreen.SetActive(false);
    }

    public void landed()
    {
        notebook.SetActive(true);
        instructionSheet.SetActive(true);
        inInstructions = true;
        SpriteRenderer guySprite = guy.GetComponent<SpriteRenderer>();
        guySprite.enabled = true;
    }

    public void startFinal()
    {
        StartCoroutine(startFinalLevel());
    }

    public IEnumerator startFinalLevel()
    {
        StartCoroutine(managerRef.fadeAudio(managerRef.defaultGameMusic, 0f, 1.5f));
        yield return new WaitForSeconds(.5f);
        fadeScreen.SetActive(true);
        fadeScreenAnimator.SetBool("fadeFinal", true);
        yield return new WaitForSeconds(1.5f);
        managerRef.jewelAudio.Play();
        mainCam.transform.position = new Vector3(20, 0, -10);
        guy.transform.position = new Vector3(12f, 3.2f, 0);
        fadeScreenAnimator.SetBool("fadeFinal", false);
        Invoke(nameof(endFadeScreenFinal), 1f);
    }

    public IEnumerator startStealMode()
    {
        yield return new WaitForSeconds(.5f);
        fadeScreen.SetActive(true);
        fadeScreenAnimator.SetBool("fadeFinal", true);
        yield return new WaitForSeconds(1.5f);
        notebook.SetActive(false);
        phone.gameObject.SetActive(false);
        mainCam.transform.position = new Vector3(40, 0, -10);
        guy.SetActive(false);
        fadeScreenAnimator.SetBool("fadeFinal", false);
        Invoke(nameof(endFadeScreenFinal), 1f);
        ringButton.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        clickButton.inInteractionMode = false;
    }

    public IEnumerator openButtonMode()
    {
        StartCoroutine(managerRef.fadeAudio(managerRef.jewelAudio, 0f, 1.5f));
        clickButton.inInteractionMode = true;
        yield return new WaitForSeconds(.5f);
        fadeScreen.SetActive(true);
        fadeScreenAnimator.SetBool("fadeFinal", true);
        yield return new WaitForSeconds(1.5f);
        managerRef.clockAudio.Play();
        mainCam.transform.position = new Vector3(40, -11f, -10);
        fadeScreenAnimator.SetBool("fadeFinal", false);
        ringButton.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        deathButton.gameObject.SetActive(true);
        managerRef.timerActive = true;
        clickButton.inInteractionMode = false;
        Invoke(nameof(endFadeScreenFinal), 1f);
    }

    public IEnumerator win()
    {
        StartCoroutine(managerRef.fadeAudio(managerRef.clockAudio, 0f, 1.5f));
        yield return new WaitForSeconds(.5f);
        fadeScreen.SetActive(true);
        fadeScreenAnimator.SetBool("fadeFinal", true);
        yield return new WaitForSeconds(2f);
        goWinScene();
        print("going to win screen");
    }

    public IEnumerator lose()
    {
        StartCoroutine(managerRef.fadeAudio(managerRef.clockAudio, 0f, 1.5f));
        yield return new WaitForSeconds(.5f);
        fadeScreen.SetActive(true);
        fadeScreenAnimator.SetBool("fadeFinal", true);
        yield return new WaitForSeconds(2f);
        goLoseScene();
        print("going to lose screen");
    }

    public void goWinScene()
    {
        SceneManager.LoadScene("win");
    }

    public void goLoseScene()
    {
        SceneManager.LoadScene("lose");
    }

}
