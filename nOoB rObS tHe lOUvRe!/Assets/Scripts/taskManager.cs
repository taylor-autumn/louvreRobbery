using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class taskManager : MonoBehaviour
{
    [Header("Original Code")]
    public string[] inventory;
    public clickButton[] allButtons;
    public cafeWorkerClick cafeRef;

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
    }
}
