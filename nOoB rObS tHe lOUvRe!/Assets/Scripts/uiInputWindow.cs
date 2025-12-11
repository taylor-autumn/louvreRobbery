using TMPro;
using UnityEngine;

public class uiInputWindow : MonoBehaviour
{
    [SerializeField] TMP_InputField passwordInput;
    [SerializeField] TMP_Text wifiStatusText;
    public bool connected=false;
    public taskManager managerRef;
    public Animator checkAnimator;

    public void checkPassword()
    {
        string input = passwordInput.text;

        if (!connected && input == "L0uVr3iSk3wL!")
        {
            wifiStatusText.text = "*Connected!*";
            wifiStatusText.color = Color.green;
            phoneShit.wifiConnected = true;
            connected = true;
            managerRef.completeTask(checkAnimator);
            print("connected");
        }
        else if (!connected)
        {
            wifiStatusText.text = "*Not Connected*";
            wifiStatusText.color = Color.red;
            print("not connected");
        }else if (connected)
        {
            wifiStatusText.text = "*Already Connected*";
            wifiStatusText.color = Color.green;
        }
    }


}
