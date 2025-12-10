using UnityEngine;
using UnityEngine.UI;

public class changeShopImage : MonoBehaviour
{

    public Button[] shopButtons;
    public int currentButton = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //itemButton.image.sprite = shopImages[currentItem];
        foreach (Button item in shopButtons)
        {
            item.gameObject.SetActive(false);
        }
        shopButtons[currentButton].gameObject.SetActive(true);
    }

    public void nextButton()
    {
        if (currentButton < shopButtons.Length - 1)
        {
            currentButton += 1;
            shopButtons[currentButton - 1].gameObject.SetActive(false);
        }
        else
        {
            currentButton = 0;
            shopButtons[3].gameObject.SetActive(false);
        }
        
        shopButtons[currentButton].gameObject.SetActive(true);

    }
}
