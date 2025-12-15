using UnityEngine;
using System.Collections;

public class danceParty : MonoBehaviour
{

    [Header("Other Shit")]
    public taskManager managerRef;
    public finalRobMode finalRef;
    public bool canTrigger = true;
    public bool danceFinished = false;
    public bool mustExitBeforeTrigger = false;
    

    [Header("Dance Party Shit")]
    public Animator discoBallAnimator;
    public Animator sparklesAnimator;
    public Animator guyAnimator;
    public Animator lightBeam1Anim;
    public Animator lightBeam2Anim;
    public Animator lightBeam3Anim;
    public AudioSource gangnamStyle;
    public Animator checkAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("lightBeam") && canTrigger && !mustExitBeforeTrigger)
        {
            print("in light beam");
            danceNow();
            mustExitBeforeTrigger = true;
        }
    }

    //wishlight item, fix this bug with staying in the same place sometimes breaks it and loops
    //still slight glitch with the collision if you stay in the same place for a while, maybe fix it by
    ///being able to tell if they moved with WASD and they set that can trigger is true again, only if time

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("lightBeam"))
        {
            if (danceFinished)
            {
                Invoke(nameof(resetCanTrigger), 1f);
                //resetCanTrigger();
            }

            mustExitBeforeTrigger = false; // leaves trigger area, meaning it can run
        }
    }

    public void resetCanTrigger()
    {
        canTrigger = true;
        danceFinished = false;
        //mustExitBeforeTrigger = true;
    }
    public void danceNow()
    {
        canTrigger = false;
        danceFinished = false;
        clickButton.inInteractionMode = true;
        StartCoroutine(guyDance());
        gangnamStyle.Play();
        if (!finalRef.danceTaskCompleted)
        {
            //first time dance stuff like completing the task
            print("first time dancing");
            finalRef.danceTaskCompleted = true;
            managerRef.completeTask(checkAnimator);
        }
        else
        {
            
        }
    }

    public IEnumerator guyDance()
    {
        managerRef.jewelAudio.Pause();
        managerRef.resetGuyAnimations();
        guyAnimator.SetBool("dance", true);
        lightBeam1Anim.SetBool("dance", true);
        lightBeam2Anim.SetBool("dance", true);
        lightBeam3Anim.SetBool("dance", true);
        sparklesAnimator.SetBool("dance", true);
        discoBallAnimator.SetBool("dance", true);
        yield return new WaitForSeconds(3.9f);
        managerRef.jewelAudio.UnPause();
        guyAnimator.SetBool("dance", false);
        lightBeam1Anim.SetBool("dance", false);
        sparklesAnimator.SetBool("dance", false);
        discoBallAnimator.SetBool("dance", false);
        lightBeam2Anim.SetBool("dance", false);
        lightBeam3Anim.SetBool("dance", false);
        clickButton.inInteractionMode = false;
        danceFinished = true;
    }


}
