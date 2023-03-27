using UnityEngine;

public class SquareGrow : MonoBehaviour
{
    public float growthRate = 0.1f; 
    private Vector3 initialScale; 

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 newScale = transform.localScale;
            newScale.y += growthRate * Time.deltaTime;
            transform.localScale = newScale;
        }
        else
        {
            transform.localScale = initialScale;
        }
    }
}