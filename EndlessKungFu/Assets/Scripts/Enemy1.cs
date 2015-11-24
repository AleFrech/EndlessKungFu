using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start ()
	{
	    rb2d = gameObject.GetComponent<Rigidbody2D>();
	    anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{

        float move = 0.4f;
        rb2d.velocity = new Vector2(move * 1f, rb2d.velocity.y);

    }
}
