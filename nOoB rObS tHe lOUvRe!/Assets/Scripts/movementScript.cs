using UnityEngine;

//moved enemy code here too
//removed text for hurt cause eh
//moved hurtSound code here, changed enemy collision to a player collision. Makes more sense?
public class movementScript : MonoBehaviour
{
    public static movementScript _myPlayer;
    public float speed=3;
    public Camera myCam;
    public Animator guyAnimator;
    public GameObject notebook;

    public changePages changePgsRef;
    public clickButton clickRef;

    //public enum playerState
    //{
    //    ONPHONE,
    //    WALKING,
    //    INCONVO,
    //    DEADINSIDE
    //}
    //public playerState myState;

    //private void Awake()
    //{
    //    if(_myPlayer == null)
    //    { _myPlayer = this; }
    //}


    // Start is called before the first frame update
    void Start()
    {
        notebook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // STOP movement if in any of these modes
        if (changePgsRef.bookOpen || cafeWorkerClick.inCafeMode || clickButton.inInteractionMode || phoneShit.inPhoneMode)
        {

            return;
        }
        else
        {
            // ---------- Movement ----------
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
                guyAnimator.SetBool("up", true);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
                guyAnimator.SetBool("down", true);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                guyAnimator.SetBool("left", true);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                guyAnimator.SetBool("right", true);
            }

            // ---------- Key Up ----------
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                guyAnimator.SetBool("up", false);

            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                guyAnimator.SetBool("down", false);

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                guyAnimator.SetBool("left", false);

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                guyAnimator.SetBool("right", false);
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("toLobby"))
        {
            myCam.transform.position = new Vector3(0, 0, -10);
            if (transform.position.y < -5)
            {
                //print("just broke in");
                notebook.SetActive(true);
                transform.position = new Vector3(0, 0, 0);
            }
            if (transform.position.y > 5.49f)
            {
                //print("from cafe");
                transform.position = new Vector3(0, 2.74f, 0);
            }
            if (transform.position.x > 10)
            {
                //print("from jewels");
                transform.position = new Vector3(6.8f, 0, 0);
            }
            if (transform.position.x < -10)
            {
                //print("from paintings");
                transform.position = new Vector3(-6.8f, 0, 0);
            }

        }
        if (collision.CompareTag("toCafe"))
        {
            myCam.transform.position = new Vector3(0, 11, -10);
            transform.position = new Vector3(0, 8.2f, 0);
        }
        if (collision.CompareTag("toPaintings"))
        {
            myCam.transform.position = new Vector3(-20, 0, -10);
            transform.position = new Vector3(-13.5f, 0, 0);
        }
        if (collision.CompareTag("toJewels"))
        {
            myCam.transform.position = new Vector3(20, 0, -10);
            transform.position = new Vector3(13.5f, 0, 0);
        }
    }

}


