using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public ButtonPress buttonDetector;
    public bool vert = false;
    public float speed = 2f; 
    public float posChange = 3f;
    private bool isUnlocked = false;
    private Vector3 initialPosition;
    private Vector3 unlockedPosition;

    private void Start()
    {
        initialPosition = transform.position;
        if(vert)
            unlockedPosition = initialPosition + new Vector3(0f, posChange, 0f);
        else
            unlockedPosition = initialPosition + new Vector3(posChange, 0f, 0f);
    }

    private void Update()
    {
        if (buttonDetector.IsPressed() && !isUnlocked)
        {
            isUnlocked = true;
        }

        if (isUnlocked)
        {
            transform.position = Vector3.MoveTowards(transform.position, unlockedPosition, speed * Time.deltaTime);

            if (transform.position == unlockedPosition)
            {
                isUnlocked = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
        }
    }
}