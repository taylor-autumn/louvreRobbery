using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class changePages : MonoBehaviour
{
    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;
    public hintButton hintButtonRef;
    public taskManager managerRef;

    //actual images
    public GameObject page1;
    public GameObject page2;
    public GameObject inventory;
    public GameObject greyBG;
    public GameObject items;

    [Header("Items Code")]
    public List<GameObject> itemObjects;

    [Header("Tasks Code")]
    public List<GameObject> pg1checks;
    public GameObject checks1;
    public List<GameObject> pg2checks;
    public GameObject checks2;

    //open or not bool
    public bool bookOpen = false;

    public void Start()

    {
        page1.SetActive(false);
        page2.SetActive(false);
        greyBG.SetActive(false);
        inventory.SetActive(false);
        items.SetActive(true);
        checks1.SetActive(true);
        checks2.SetActive(true);
        turnOffImages();
        turnOff2Checks();
        turnOff1Checks();

    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (bookOpen)
            {
                page1.SetActive(false);
                page2.SetActive(false);
                greyBG.SetActive(false);
                inventory.SetActive(false);
                hintButtonRef.hintBox.SetActive(false);
                bookOpen = false;
                turnOffImages();
                turnOff2Checks();
                turnOff1Checks();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(eventSystem);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.CompareTag("notebook")&& !cafeWorkerClick.inCafeMode && !clickButton.inInteractionMode && !phoneShit.inPhoneMode)
                {
                    if (!bookOpen)
                    {
                        managerRef.resetGuyAnimations();
                        page1.SetActive(true);
                        page2.SetActive(false);
                        inventory.SetActive(false);
                        greyBG.SetActive(true);
                        bookOpen = true;
                        turnOffImages();
                        turnOn1Checks();
                        turnOff2Checks();
                    }
                }
                    
                if (result.gameObject.CompareTag("pg1"))
                {
                    page1.SetActive(true);
                    page2.SetActive(false);
                    inventory.SetActive(false);
                    turnOffImages();
                    turnOff2Checks();
                    turnOn1Checks();

                }  

                if (result.gameObject.CompareTag("pg2"))
                {
                    page2.SetActive(true);
                    page1.SetActive(false);
                    inventory.SetActive(false);
                    turnOffImages();
                    turnOff1Checks();
                    turnOn2Checks();

                }
                if (result.gameObject.CompareTag("inventory"))
                {
                    inventory.SetActive(true);
                    page2.SetActive(false);
                    page1.SetActive(false);
                    turnOnImages();
                    turnOff2Checks();
                    turnOff1Checks();


                }

            }
        }

    }


    public void turnOnImages()
    {
        foreach (GameObject item in itemObjects)
        {
            
            Image itemImage = item.GetComponent<Image>();
            itemImage.enabled = true;
        }

    }

    public void turnOffImages()
    {
        foreach (GameObject item in itemObjects)
        {
            Image itemImage = item.GetComponent<Image>();
            itemImage.enabled = false;
        }

    }

    public void turnOn1Checks()
    {
        foreach (GameObject item in pg1checks)
        {
            Image itemImage = item.GetComponent<Image>();
            itemImage.enabled = true;
        }
    }

    public void turnOff1Checks()
    {
        foreach (GameObject item in pg1checks)
        {
            Image itemImage = item.GetComponent<Image>();
            itemImage.enabled = false;
        }
    }

    public void turnOn2Checks()
    {
        foreach (GameObject item in pg2checks)
        {
            Image itemImage = item.GetComponent<Image>();
            itemImage.enabled = true;
        }
    }

    public void turnOff2Checks()
    {
        foreach (GameObject item in pg2checks)
        {
            Image itemImage = item.GetComponent<Image>();
            itemImage.enabled = false;
        }
    }

}
