using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, 1f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character

	public bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private bool m_wasCrouching = false;
	ContactFilter2D groundFilter;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		groundFilter.layerMask = m_WhatIsGround;
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		//m_Grounded = false;

		m_Grounded = GetComponent<Collider2D>().IsTouching(groundFilter);

	}


	public void Move(float move, bool crouch, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// // If the input is moving the player right and the player is facing left...
			// if (move > 0 && !m_FacingRight)
			// {
			// 	// ... flip the player.
			// 	Flip();
			// }
			// // Otherwise if the input is moving the player left and the player is facing right...
			// else if (move < 0 && m_FacingRight)
			// {
			// 	// ... flip the player.
			// 	Flip();
			// }
		}
		// // If the player should jump...
		// if (m_Grounded && jump)
		// {
		// 	// Add a vertical force to the player.
		// 	m_Grounded = false;
		// 	m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		// }
	}

	public void Jump(bool jump){
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	// private void Flip()
	// {
	// 	// Switch the way the player is labelled as facing.
	// 	m_FacingRight = !m_FacingRight;

	// 	// Multiply the player's x local scale by -1.
	// 	Vector3 theScale = transform.localScale;
	// 	theScale.x *= -1;
	// 	transform.localScale = theScale;
	// }
}
