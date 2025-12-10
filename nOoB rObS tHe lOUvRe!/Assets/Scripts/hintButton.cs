using System.Collections;
using TMPro;
using UnityEngine;

public class hintButton : MonoBehaviour
{

    public Animator hintBoxAnim;
    public GameObject hintBox;
    public TMP_Text hintText;
    public bool hintVisible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hintBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && hintVisible)
        {
            hintBoxAnim.SetBool("fadeIn", false);
            hintVisible = false;
        }
    }

    public void getHint(string hint)
    {
        hintVisible = true;
        hintBox.SetActive(true);
        hintBoxAnim.SetBool("fadeIn", true);
        hintText.text = hint;
    }

    public IEnumerator setBoxInactive()
    {
        yield return new WaitForSeconds(2f);
        hintBox.SetActive(false);
    }


}
