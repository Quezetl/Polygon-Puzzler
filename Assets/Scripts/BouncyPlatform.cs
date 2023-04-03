using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public float bounceForce = 15;
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("BouncePadAnim");
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            float angle = transform.eulerAngles.z;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            playerRB.AddForce(rot * Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
