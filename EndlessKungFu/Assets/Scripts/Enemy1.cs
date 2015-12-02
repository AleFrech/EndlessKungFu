using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Animator anim;
    public float move = 0.4f;
    public bool facingLeft;

    // Use this for initialization
    void Start ()
	{
	    rb2d = gameObject.GetComponent<Rigidbody2D>();
	    anim = gameObject.GetComponent<Animator>();
        if (facingLeft)
        {
           anim.SetInteger("walkingAnimation", -1);
        }
        else
        {
            anim.SetInteger("walkingAnimation",1);
        }
	}
	
	// Update is called once per frame
	void Update ()
	{

        rb2d.velocity = new Vector2(move * 1f, rb2d.velocity.y);
    

    }


    public void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        rb2d.gravityScale = .2f;
        anim.SetBool("isDead",true);

        Destroy(gameObject,8);
    }
}
