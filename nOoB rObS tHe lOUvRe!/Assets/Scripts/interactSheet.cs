using UnityEngine;

public class interactSheet : MonoBehaviour
{

    public GameObject interactionBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionBox.SetActive(false);
        }
    }
}
