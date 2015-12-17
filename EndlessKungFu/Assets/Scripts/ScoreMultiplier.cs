using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ScoreMultiplier : MonoBehaviour {
        private Player playerController;
        private Rigidbody2D rb2d;
        private Animator anim;
        public float move = 0.4f;
        public bool facingLeft;
      
    void Start()
          {
            
            GameObject playercontrollerObject = GameObject.FindWithTag("Player");

            if (playercontrollerObject != null)
            {
                    playerController = playercontrollerObject.GetComponent<Player>();
            }
            rb2d = gameObject.GetComponent<Rigidbody2D>();
            anim = gameObject.GetComponent<Animator>();
            if (facingLeft)
            {
                anim.SetInteger("walkingAnimation", -1);
            }
            else
            {
                anim.SetInteger("walkingAnimation", 1);
            }
        }
    
        void Update()
        {
            rb2d.velocity = new Vector2(move * 1f, rb2d.velocity.y);
            if (facingLeft)
            {
                anim.SetInteger("walkingAnimation", -1);
            }
            else
            {
                anim.SetInteger("walkingAnimation", 1);
            }
        }

        public void OnTriggerStay2D(Collider2D col)
        {
            if (col.transform.tag == "Player")
            {
                Destroy(gameObject);
            }
        }

    public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.tag == "SpawnPointActivator")
            {
                Destroy(gameObject);
            }
       }
    }
