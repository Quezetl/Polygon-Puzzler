using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravityScale = 1f;
    public float maxVelocity = 10f;
    public float slopeForce = 10f;
    public float slopeForceRayLength = 1f;

    private Rigidbody2D rb;
    private CircleCollider2D cc;

    private bool isGrounded;
    private bool isOnSlope;
    private Vector2 slopeNormalPerp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float slopeModifier = 1f;

        if (isOnSlope)
        {
            slopeModifier = slopeForce / slopeNormalPerp.magnitude;
        }

        rb.AddForce(Vector2.right * moveInput * moveSpeed * slopeModifier);

        float velocityX = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        rb.velocity = new Vector2(velocityX, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.contactCount > 0 && other.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }

        CheckSlopeCollision(other);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.contactCount > 0 && other.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }

        CheckSlopeCollision(other);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.contactCount > 0 && other.contacts[0].normal.y > 0.5f)
        {
            isGrounded = false;
        }
    }

    void CheckSlopeCollision(Collision2D other)
    {
        for (int i = 0; i < other.contactCount; i++)
        {
            Vector2 contact = other.contacts[i].point;
            float angle = Vector2.Angle(other.contacts[i].normal, Vector2.up);

            if (angle > 0 && angle < 90)
            {
                isOnSlope = true;
                slopeNormalPerp = Vector2.Perpendicular(other.contacts[i].normal).normalized;

                Debug.DrawRay(contact, slopeNormalPerp, Color.green);
                Debug.DrawRay(contact, other.contacts[i].normal, Color.red);
            }
        }
    }
}