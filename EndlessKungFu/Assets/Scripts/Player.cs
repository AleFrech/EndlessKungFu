using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public bool isDead;
        public bool canBeKilled = true;
        public bool deathAnimPlayed=false;
        public bool facingLeft = true;
        public float moveForce = 5f;
        public float maxSpeed = 3f;
        public float jumpForce = 150f;
        public bool walking = false;
        public bool attacking = false;
        public bool crouching = false;
        public bool kicking = false;
        public bool jumping = false;
        private Animator anim;
        public AudioSource kick_sound;
        public AudioSource punch_sound;
        public Transform groundCheck;
        public Transform headCheck;
        private bool grounded = false;
        private Rigidbody2D rb2d;
        public Animator player_Animation;
        public LayerMask mask;
        public float deathTime;
        public int score = 0;
        [SerializeField] public Text WOT;

        // Use this for initialization
        void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            player_Animation = GetComponent<Animator>();
            punch_sound = gameObject.AddComponent<AudioSource>();
            anim = gameObject.GetComponent<Animator>();
            var punchClip = (AudioClip) Resources.Load("Sounds/Punch Effect");
            punch_sound.clip = punchClip;
            kick_sound = gameObject.AddComponent<AudioSource>();
            var kickClip = (AudioClip) Resources.Load("Sounds/Kick Effect");
            kick_sound.clip = kickClip;
        }

        // Update is called once per frame
        void Update()
        {
            grounded = Physics2D.Linecast(transform.position, groundCheck.position, mask);
            if (isDead || !deathAnimPlayed)
            {
                anim.SetBool("isDead", isDead);
                deathAnimPlayed = true;
            }
            if (isDead)
            {
                deathTime+= Time.deltaTime;
            }
            if (deathTime >=2)
            {
                EndGame();
            }

        }

        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Jump");
            float c = Input.GetAxis("Crouch");
            float punch = Input.GetAxis("Fire1");
            float kick = Input.GetAxis("Kick");
            if (punch > 0)
                attacking = true;
            else
                attacking = false;
            if (kick > 0)
                kicking = true;
            else
                kicking = false;

            if (h*rb2d.velocity.x < maxSpeed)
                rb2d.AddForce(Vector2.right*h*moveForce);
            if (c > 0)
                crouching = true;
            else
                crouching = false;
            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            {
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x)*maxSpeed, rb2d.velocity.y);
            }
            if (h != 0)
            {
                walking = true;
            }
            else
            {
                walking = false;
            }

            if (v > 0 && grounded && rb2d.velocity.y == 0)
            {
                jumping = true;
                rb2d.AddForce(new Vector2(0, jumpForce));
            }
            else
                jumping = false;

            anim.SetBool("Attacking", attacking);
            anim.SetBool("Crouching", crouching);
            anim.SetBool("Kicking", kicking);
            anim.SetBool("Jumping", jumping);
            anim.SetBool("Walking", walking);

            if (h < 0 && !facingLeft)
                Flip();
            else if (h > 0 && facingLeft)
                Flip();

        }

        void Flip()
        {
            facingLeft = !facingLeft;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        void OnTriggerStay2D(Collider2D col)
        {
            if ((col.transform.tag == "Enemy") && (attacking || kicking))
            {
                col.gameObject.GetComponent<Enemy1>().Die();
                if (kicking)
                {
                    AddScore(10);
                }
                if (attacking)
                {
                    AddScore(20);
                }
            }
        }

        void AddScore(int x)
        {
            score += x;
            WOT.text = score.ToString();
        }

        void PunchEffect()
        {
            punch_sound.Play();
        }

        void KickEffect()
        {
            kick_sound.Play();
        }

        public void Kill()
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().isKinematic = true;
            foreach (var x in GetComponents<BoxCollider2D>())
            {
                x.enabled = false;
            }
            if (canBeKilled)
            {
                isDead = true;
                canBeKilled = false;
            }
        }

        void EndGame()
        {
            Application.LoadLevel(0);
        }
}
}
