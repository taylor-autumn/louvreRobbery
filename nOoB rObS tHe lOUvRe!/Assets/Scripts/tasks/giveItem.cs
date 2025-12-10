using UnityEngine;

public class giveItem : MonoBehaviour
{
    [Header("Item")]
    public Animator itemAnimator;
    public GameObject item;

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
        //itemAnimator.SetBool("complete", true);
        Invoke(nameof(disableItem), 2.0f);
    }

    public void disableItem()
    {
        item.SetActive(false);
    }

    //this triggers as a event in the animation triggered above
    public void advanceCharacterAnim()
    {
        
        targetCharacterAnim.SetBool("complete", true);
        targetCharacterAnim2.SetBool("complete", true);
    }

}
