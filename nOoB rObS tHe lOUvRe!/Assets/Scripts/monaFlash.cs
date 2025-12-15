using UnityEngine;

public class monaFlash : MonoBehaviour
{

    public GameObject flash;
    public GameObject guy;
    public GameObject tapedBanana;
    public taskManager managerRef;


    //private void OnEnable()
    //{
    //    flash.SetActive(true);
    //    flash.transform.position = guy.transform.position;
    //    flashAnimator = GetComponent<Animator>();
    //    flashAnimator.SetBool("flash", true);
    //    Invoke(nameof(disableFlash), 2f);
    //}

    public void enableFlash()
    {
        flash.SetActive(true);
        managerRef.flashSound.Play();
        flash.transform.position = guy.transform.position;
        Invoke(nameof(disableFlash), .7f);
        //play sound
    }

    public void playFlashSound()
    {
        managerRef.flashSound.Play();
    }

    public void disableFlash()
    {
        flash.SetActive(false);
    }

    public void enableTapedBanana()
    {
        tapedBanana.SetActive(true);
    }

}
