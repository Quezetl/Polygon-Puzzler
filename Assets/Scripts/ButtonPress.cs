using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Animator anim;
    public bool isPressed = false;

    public bool IsPressed()
    {
        return isPressed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPressed = false;
        }
    }

    private void Update()
    {
        anim.SetBool("IsPressed", isPressed);
    }
}