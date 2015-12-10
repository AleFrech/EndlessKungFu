using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Enemy1 : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Animator anim;
    public float move = 0.4f;
    public bool facingLeft;
    public int x_;
    public float timewithin;
    public bool isAttacking;
    public float attackTime;
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
        anim.SetBool("isAttacking",isAttacking);
        rb2d.velocity = new Vector2(move * 1f, rb2d.velocity.y);
	    if (attackTime > .30)
	    {
	        isAttacking = false;
	    }
	    if (isAttacking)
	    {
	        attackTime += Time.deltaTime;
	    }

    }

    public void Die()
    {
        anim.SetBool("isDead", true);

        foreach (var x in GetComponents<BoxCollider2D>())
        {
            x.enabled = false;
        }

        move = -move;      
        rb2d.AddForce(new Vector2(0,10));
        Destroy(gameObject,8);
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            timewithin += Time.deltaTime;
            if (timewithin>0.1)
            {
                isAttacking = true;
                col.transform.gameObject.GetComponent<Player>().Kill();
            }
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            timewithin = 0;
        }
    }
}
