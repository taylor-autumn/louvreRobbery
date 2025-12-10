using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class phoneShit : MonoBehaviour
{

    public GameObject homeScreen;
    public GameObject wifiScreen;
    //public GameObject IGScreenDraft;
    //public GameObject IGScreenDraftWPhoto;
    //public GameObject IGScreenPost;
    //public GameObject photosScreenEmpty;
    //public GameObject photosScreenFill;


    public GameObject currentIGMode;
    public GameObject currentPhotosMode;

    public static bool inPhoneMode = false;
    public TMP_Text closeText;

    public changePages changePgRef;

    [Header("WIFI")]
    public GameObject noWifiSymbol1;
    public GameObject noWifiSymbol2;
    public static bool wifiConnected = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inPhoneMode = false;
        homeScreen.SetActive(false);
        wifiScreen.SetActive(false);
        currentPhotosMode.SetActive(false);
        currentIGMode.SetActive(false);
        closeText.gameObject.SetActive(false);
        noWifiSymbol1.SetActive(false);
        noWifiSymbol2.SetActive(false);

        


    }

    // Update is called once per frame
    void Update()
    {
        if (inPhoneMode)
        {
            closeText.gameObject.SetActive(true);
        }
        else
        {
            closeText.gameObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Q) && inPhoneMode)
        {
            inPhoneMode = false;
            homeScreen.SetActive(false);
            wifiScreen.SetActive(false);
            changePgRef.greyBG.SetActive(false);
            currentIGMode.SetActive(false);
            currentPhotosMode.SetActive(false);
        }
    }

    public void goHomeScreen()
    {
        if (!clickButton.inInteractionMode && !cafeWorkerClick.inCafeMode && !changePgRef.bookOpen && !openWallPaper.inSheetMode)
        {
            inPhoneMode = true;
            changePgRef.greyBG.SetActive(true);
            homeScreen.SetActive(true);
            wifiScreen.SetActive(false);
            currentIGMode.SetActive(false);
            currentPhotosMode.SetActive(false);
            if (!wifiConnected)
            {
                noWifiSymbol1.SetActive(true);
                noWifiSymbol2.SetActive(true);
            }
            else
            {
                noWifiSymbol1.SetActive(false);
                noWifiSymbol2.SetActive(false);
            }
        }
        
    }

    public void openPhotos()
    {
        if (!wifiConnected)
        {
            print("not connected to wifi");
            //play buzz sound here
        }
        else
        {
            homeScreen.SetActive(false);
            wifiScreen.SetActive(false);
            currentIGMode.SetActive(false);
            currentPhotosMode.SetActive(true);
        }

    }

    public void openIG()
    {
        if (!wifiConnected)
        {
            print("not connected to wifi");
            //play buzz sound here
        }
        else
        {
            homeScreen.SetActive(false);
            wifiScreen.SetActive(false);
            currentIGMode.SetActive(true);
            currentPhotosMode.SetActive(false);
        }
    }

    public void openWifi()
    {
        homeScreen.SetActive(false);
        wifiScreen.SetActive(true);
        currentIGMode.SetActive(false);
        currentPhotosMode.SetActive(false);
    }

    public void ChangeIGMode(GameObject newMode)
    {
        currentIGMode = newMode;
    }

    public void changePhotoMode(GameObject newMode)
    {
        currentPhotosMode = newMode;
    }

}
