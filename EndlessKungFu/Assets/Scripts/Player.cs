using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 10f;
	public bool Walking = false;
	private Rigidbody2D rb2d;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		anim.SetFloat ("speed", speed);
		anim.SetBool ("Walking", Walking);

		float move = Input.GetAxis("Horizontal");
		rb2d.velocity = new Vector2 (move * speed, rb2d.velocity.y);

		//rb2d.AddForce(Vector2.right*move*speed);
	}
}
