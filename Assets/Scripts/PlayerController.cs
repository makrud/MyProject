using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float maxSpeed = 6.0F;
	public float jumpSpeed = 8.0F;

	public float floatHeight;
	public float liftForce;
	public float damping;
	/*
	//Variables for grounding system.
	public bool isGrounded;
	public Transform grounder;
	public float radius;
	public LayerMask ground;
	*/
	bool facingRight = true;
	float someScale;
	Animator anim;
	Rigidbody2D rgdBody;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		rgdBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame

	void FixedUpdate ()
	{
	
//		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//isGrounded = Physics2D.OverlapCircle (grounder.position, radius, ground); // checks if you are within 0.15 position in the Y of the ground
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rgdBody.velocity = new Vector2 (move * maxSpeed, rgdBody.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(hit.collider.tag == "Ground")
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 30), ForceMode2D.Impulse);
			} 

		}


	void Update ()
	{		

	}

	void Flip ()
	{

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
