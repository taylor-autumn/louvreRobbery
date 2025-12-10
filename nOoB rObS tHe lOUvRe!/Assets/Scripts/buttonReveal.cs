using UnityEngine;

public class buttonReveal : MonoBehaviour
{
    public Animator targetAnimator;

    public void OnClick()
    {
        if (targetAnimator != null)
        {
            possessItem(targetAnimator);
        }
    }

    public void possessItem(Animator itemAnimator)
    {
        itemAnimator.SetBool("reveal", true);
    }
}
