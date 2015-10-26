using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 3f;
	public bool lookingLeft = true;
	public bool walking = false;
	public bool attacking = false;
	private Rigidbody2D rb2d;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow) && lookingLeft) {
			lookingLeft = false;
		} else if (Input.GetKey (KeyCode.LeftArrow) && !lookingLeft) {
			lookingLeft = true;
		}

		if ((Input.GetKey (KeyCode.LeftArrow) && lookingLeft) || (Input.GetKey (KeyCode.RightArrow) && !lookingLeft)) {
			walking = true;
		} else{ walking = false;}

		attacking = (Input.GetKey (KeyCode.S));

		anim.SetBool ("Attacking", attacking);

		//Debug.Log (walking.ToString());
		anim.SetBool("LookingLeft", lookingLeft);
		anim.SetBool ("Walking", walking);
		//rb2d.AddForce(Vector2.right*move*speed);
	}

	void FixedUpdate(){
		float move = Input.GetAxis("Horizontal");
		rb2d.velocity = new Vector2 (move * speed, rb2d.velocity.y);
	}
}
