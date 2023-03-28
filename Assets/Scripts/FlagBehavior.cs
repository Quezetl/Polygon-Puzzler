using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched object.");
            Destroy(gameObject);
        }
    }
}
