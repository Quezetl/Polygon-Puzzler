using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 5.0f;
    public bool vert = false;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance);
        if(vert)
            transform.position = startPos + Vector3.up * movement;
        else
            transform.position = startPos + Vector3.right * movement;
    }
}