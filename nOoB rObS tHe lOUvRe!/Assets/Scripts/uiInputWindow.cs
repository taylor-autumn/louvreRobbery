using TMPro;
using UnityEngine;

public class uiInputWindow : MonoBehaviour
{
    [SerializeField] TMP_InputField passwordInput;
    [SerializeField] TMP_Text wifiStatusText;
    public bool connected=false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkPassword()
    {
        string input = passwordInput.text;

        if (input == "L0uVr3iSk3wL!")
        {
            wifiStatusText.text = "*Connected!*";
            wifiStatusText.color = Color.green;
            phoneShit.wifiConnected = true;
            connected = true;
            print("connected");
        }
        else if (!connected)
        {
            wifiStatusText.text = "*Not Connected*";
            wifiStatusText.color = Color.red;
            print("not connected");
        }
    }


}
