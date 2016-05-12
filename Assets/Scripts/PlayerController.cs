using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	public float jumpForce;
	private Rigidbody2D myRigidbody;
	public bool grounded;
	public LayerMask whatIsGround;
	private Collider2D myCollider;
	private Animator myAnimator;
	public float lockPos = 0;
	public float jumpTime;
	private float jumpTimeCounter;
	public GameManager theGameManager;



	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;

	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);
		if (grounded) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);	
			}
		}
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;

			}
		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
		}
		if (grounded) {
			jumpTimeCounter = jumpTime;
		}
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "killbox") {
			theGameManager.RestartGame ();
		}
	}
}
