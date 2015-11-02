using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour {
	
        public float speed = 1f;
        public bool lookingLeft = true;
        public bool walking = false;
        public bool attacking = false;
        public bool crouching = false;
        public bool kicking = false;
        public bool jumping = false;
        public float base_y = 0.0f;
        public float jump_velocity = 0.0f;

        private Rigidbody2D rb2d;
        private Animator anim;
        // Use this for initialization
        void Start () {
      
            rb2d = gameObject.GetComponent<Rigidbody2D> ();
            anim = gameObject.GetComponent<Animator> ();
            base_y = rb2d.position.y;

        }
	
        // Update is called once per frame
        void Update () {
            crouching = (Input.GetKey(KeyCode.DownArrow));
            kicking = (Input.GetKey(KeyCode.A));
            jumping = (Input.GetKey(KeyCode.UpArrow));



            if (Input.GetKey (KeyCode.RightArrow) && lookingLeft) {
                lookingLeft = false;
            } else if (Input.GetKey (KeyCode.LeftArrow) && !lookingLeft) {
                lookingLeft = true;
            }
        
            if (((Input.GetKey (KeyCode.LeftArrow) && lookingLeft) || (Input.GetKey (KeyCode.RightArrow) && !lookingLeft))&&!crouching) {
                walking = true;
            } else{ walking = false;}



            if (Input.GetKey(KeyCode.UpArrow))
            {
                jumping = true;
                rb2d.velocity = new Vector2(0, 2f);
            }

            //if ((lookingLeft && Input.GetKeyUp(KeyCode.LeftArrow)) || (!lookingLeft && Input.GetKeyUp(KeyCode.RightArrow)))
            //{
            //    walking = false;
            //}
      
            attacking = (Input.GetKey (KeyCode.S));

            anim.SetBool ("Attacking", attacking);
            anim.SetBool("Crouching",crouching);
            anim.SetBool("Kicking", kicking);
            anim.SetBool("Jumping",jumping);


            //Debug.Log (walking.ToString());
            anim.SetBool("LookingLeft", lookingLeft);
            anim.SetBool ("Walking", walking);
            //rb2d.AddForce(Vector2.right*move*speed);
        }

        void FixedUpdate(){
            if (walking)
            {
                float move = Input.GetAxis("Horizontal")/2;
                rb2d.velocity = new Vector2(move*speed, rb2d.velocity.y);
            }
        }
    }
}
