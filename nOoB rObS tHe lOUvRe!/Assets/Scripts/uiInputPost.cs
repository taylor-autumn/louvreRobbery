using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class uiInputPost : MonoBehaviour
{

    [Header("Pre Posted Shit")]
    [SerializeField] TMP_InputField captionInput;

    [Header("Posted Shit")]
    public GameObject postedIGScreen;
    public Animator checkAnimator;
    public TMP_Text captionText;

    [Header("General Shit")]
    public bool posted = false;
    public phoneShit phoneRef;
    public taskManager managerRef;

    public void makePost()
    {
        string caption = captionInput.text;

        if (!posted)
        {
            if (caption.Length > 1)
            {
                posted = true;
                phoneRef.currentIGMode.SetActive(false); //sets old screen out
                postedIGScreen.SetActive(true); //sets new screen on
                phoneRef.ChangeIGMode(postedIGScreen.gameObject); //changes it so future will always be post screen
                managerRef.completeTask(checkAnimator); //completes task
                captionText.text = caption;

                if (caption.Length < 30)
                {
                    captionText.fontSize = 65;
                }
                else
                {
                    captionText.fontSize = 45;
                }
            }
            
        }
    }

}
