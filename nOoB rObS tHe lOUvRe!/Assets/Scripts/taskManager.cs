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

    [Header("Complete Stuff")]
    public Animator completeBox;
    public TMP_Text notifBoxText;

    [Header("Hidden Task Stuff")]
    public TMP_Text task8Guard;
    public TMP_Text task9Dance;
    public TMP_Text task10Steal;
    public Button task8Button;
    public Button task9Button;
    public Button task10Button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allButtons = Object.FindObjectsByType<clickButton>(FindObjectsInactive.Include, FindObjectsSortMode.None);
      
    }

    // Update is called once per frame
    void Update()
    {

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
        checkAnimator.SetBool("check", true);
        notifBox("Task Completed!");
        tasksCompleted += 1;

        if (tasksCompleted == 7)
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
        notifBox("Tasks unlocked!");
        revealFinalTasks();
    }

    public void revealFinalTasks()
    {
        //also set active security guards box here
        task8Guard.text = "- Romance the Security Guard";
        task9Dance.text = "- Dance in the Spotlight!";
        task10Steal.text = "- Don't fall to temptation";
        task8Button.gameObject.SetActive(true);
        task9Button.gameObject.SetActive(true);
        task10Button.gameObject.SetActive(true);
    }


}
