using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class crouchPunchHit : MonoBehaviour {

    // Use this for initialization
    private Player playerController;
    void Start()
    {
        GameObject playercontrollerObject = GameObject.FindWithTag("Player");

        if (playercontrollerObject != null)
        {
            playerController = playercontrollerObject.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D col)
    {

        if (col.transform.tag.Equals("Enemy") && !playerController.isDead)
        {

            col.gameObject.GetComponent<Enemy1>().Die();
            playerController.AddScore(20);

        }
    }
}
