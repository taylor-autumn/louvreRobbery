using UnityEngine;

public class giveItem : MonoBehaviour
{
    [Header("Item")]
    public GameObject item;
    public GameObject item2;

    [Header("Character targets")]
    public Animator targetCharacterAnim;
    public Animator targetCharacterAnim2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void completeAnimation()
    {
        item.SetActive(true);
        Invoke(nameof(disableItem), 2.0f);
    }

    public void giveItem2()
    {
        item2.SetActive(true);
        Invoke(nameof(disableItem2), 2.0f);
    }

    public void disableItem()
    {
        item.SetActive(false);
    }
    public void disableItem2()
    {
        item2.SetActive(false);
    }

    //this triggers as a event in the animation triggered above
    public void advanceCharacterAnim()
    {
        targetCharacterAnim.SetBool("complete", true);
        targetCharacterAnim2.SetBool("complete", true);
    }

}
