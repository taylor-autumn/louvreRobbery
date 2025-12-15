using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class taskManager : MonoBehaviour
{
    [Header("inventory shit")]
    public string[] inventory;
    public clickButton[] allButtons;

    [Header("General Shit")]
    public int tasksCompleted = 0;
    public cafeWorkerClick cafeRef;
    public Animator securityAnimator;
    public Animator guyAnimator;

    [Header("Complete Stuff")]
    public Animator completeBox;
    public TMP_Text notifBoxText;

    [Header("Final Level Stuff")]
    public GameObject currentLobbyImage;
    public GameObject unlockedLobbyImage;

    [Header("Hidden Task Stuff")]
    public TMP_Text task7Mouse;
    public TMP_Text task8Guard;
    public TMP_Text task9Dance;
    public TMP_Text task10Steal;
    public Button task7Button;
    public Button task8Button;
    public Button task9Button;
    public Button task10Button;
    public GameObject mouseInteract;
    public GameObject securityInteract;

    [Header("Final Rob Stuff")]
    public GameObject ringPop;
    public Animator ringAnimator;
    public Animator panelAnimator;
    public TMP_Text robbingText;
    public cutScene1Manager cutRef;
    public bool stolen = false;

    [Header("Timer Shit")]
    public TMP_Text timerText;
    public float totalTime = 15f;
    private float currentTime;
    public bool timerActive = false;

    [Header("Music Shit")]
    public AudioSource startingMusic;
    public AudioSource crashNoise;
    public AudioSource defaultGameMusic;
    public AudioSource jewelAudio;
    public AudioSource clockAudio;
    public AudioSource taskCompleteSound;
    public AudioSource notifSound;
    public AudioSource flashSound;
    public AudioSource oofSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingMusic.Play();
        allButtons = Object.FindObjectsByType<clickButton>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        mouseInteract.SetActive(false);
        securityInteract.SetActive(false);
        ringPop.SetActive(false);
        currentTime = totalTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            startCountdown();
        }
    }

    public void AddToInventory(string item)
    {
        //if breaks change inventory.length back to for (int i = 0; i < allButtons.Length; i++)
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                if (cafeWorkerClick.inCafeMode)
                {
                    cafeRef.taskLine.text = "I already gave you a " + item + " broski.";
                }
                //item already in inventory no Dupes
                return;
            }
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == "")
            {
                inventory[i] = item;
                if (cafeWorkerClick.inCafeMode)
                {
                    notifSound.Play();
                    notifBox(item + " aquired!");
                    cafeRef.taskLine.text = "You want that? Alright here's a " + item + " dude.";
                }

                return;
            }
        }
    }

    //public void iterateText(string NPCname)
    //{
    //    //this function should happen when the task is completed, and also mark off text
    //    //signaling that the task has been completed, maybe a notification if I get time

    //    foreach (clickButton button in allButtons)
    //    {
    //        if (button.NPCname == NPCname)
    //        {
    //            button.nextText();
    //        }
    //    }
    //}

    public bool checkInventory(string item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                return true;
            }
        }
        return false;
    }

    public void completeTask(Animator checkAnimator)
    {
        taskCompleteSound.Play();
        checkAnimator.SetBool("check", true);
        notifBox("Task Completed!");
        tasksCompleted += 1;

        if (tasksCompleted == 6)
        {
            StartCoroutine(announceHiddenTasks());
        }
    }

    public void notifBox(string fillText)
    {
        completeBox.SetBool("complete", true);
        notifBoxText.text=fillText;
        StartCoroutine(setBoolInactive());
    }
    public IEnumerator setBoolInactive()
    {
        yield return new WaitForSeconds(2f);
        completeBox.SetBool("complete", false);
    }

    public IEnumerator announceHiddenTasks()
    {
        yield return new WaitForSeconds(4f);
        notifSound.Play();
        notifBox("Tasks unlocked!");
        revealMoreTasks();
    }

    public void revealMoreTasks()
    {
        task7Mouse.text = "- Feed Lord Nibbleton";
        task8Guard.text = "- Romance the Security Guard";
        task7Button.gameObject.SetActive(true);
        task8Button.gameObject.SetActive(true);
        mouseInteract.SetActive(true);
        securityInteract.SetActive(true);
    }

    public void revealFinalTask()
    {
        task10Steal.text = "- Don't fall to temptation";
        task10Button.gameObject.SetActive(true);
        task9Dance.text = "- Dance in the Spotlight!";
        task9Button.gameObject.SetActive(true);
    }

    public void completeSecurity()
    {
        securityAnimator.SetBool("complete", true);
        securityInteract.SetActive(false);
        currentLobbyImage.SetActive(false);
        unlockedLobbyImage.SetActive(true);
        notifBox("Final Tasks Open!"); 
        notifSound.Play();
        revealFinalTask();
        Invoke(nameof(announceOpenRoom), 4f);
    }

    public void announceOpenRoom()
    {
        notifBox("Final Room Opened!");
        notifSound.Play();
    }

    public void resetGuyAnimations()
    {
        guyAnimator.SetBool("down", false);
        guyAnimator.SetBool("up", false);
        guyAnimator.SetBool("left", false);
        guyAnimator.SetBool("right", false);
    }


    //ring button shit end mode
    public void stealRing()
    {
        ringPop.SetActive(true);
        ringAnimator.SetBool("steal", true);
        panelAnimator.SetBool("steal", true);
        Invoke(nameof(enablePanel), 2f);

    }

    public void enablePanel()
    {
        stolen = true;
        robbingText.text = "Huh? What's that panel? Click it to find out...";

    }

    public void openPanel()
    {
        if (stolen)
        {
            print("stealing lol");
            StartCoroutine(cutRef.openButtonMode());

        }
    }

    public void startCountdown()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            displayTime(currentTime);
        }
        else
        {
            timerActive = false;
            currentTime = 0;
            displayTime(0);
            print("WIN");
            StartCoroutine(cutRef.win());
        }
    }

    public void displayTime(float timeToDisplay)
    {
        // Ensure time is not negative for display purposes
        if (timeToDisplay < 0) timeToDisplay = 0;

        // Format the time as minutes and seconds
        string minutes = Mathf.FloorToInt(timeToDisplay / 60).ToString("00");
        string seconds = Mathf.FloorToInt(timeToDisplay % 60).ToString("00");
        timerText.text = string.Format("{0}", seconds);
    }

    public void pressDeathButton()
    {
        print("DEATH");
        timerActive = false;
        oofSound.Play();
        StartCoroutine(cutRef.lose());
    }


    public IEnumerator fadeAudio(AudioSource audioSource, float targetVolume, float duration)
    {
        float startVolume = audioSource.volume;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, timer / duration);
            yield return null;
        }
        audioSource.volume = targetVolume;
        if (targetVolume == 0f) audioSource.Stop();
    }

}
