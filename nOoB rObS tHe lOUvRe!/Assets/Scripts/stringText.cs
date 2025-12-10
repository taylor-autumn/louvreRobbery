using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class stringText : MonoBehaviour
{
    // Dialougue variables
    public TextMeshProUGUI textComponent;
    public clickButton clickRef;
    public string[] lines;
    private int index;
    public float textSpeed=0.03f;
    // finish dialougue variables

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialougue();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void StartDialougue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        //else
        //{ //finish dialougue
        //    gameObject.SetActive(false);
        //}
    }

    public void CheckText(string text)
    {
        //code that checks the sent text against current text
        Debug.Log("called CheckText");
        if (textComponent.text == text)
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }    

}