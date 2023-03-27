using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public float bounceForce = 15;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
