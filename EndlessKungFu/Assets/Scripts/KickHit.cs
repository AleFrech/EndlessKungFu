using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class KickHit : MonoBehaviour {

    private Player playerController;
    void Start()
    {
        GameObject playercontrollerObject = GameObject.FindWithTag("Player");
        if (playercontrollerObject != null)
        {
            playerController = playercontrollerObject.GetComponent<Player>();
        }
    }

    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag.Equals("Enemy") && !Player.isDead)
        {
            col.gameObject.GetComponent<Enemy1>().Die();
            playerController.AddScore(10);           
            PlayerPrefs.SetInt("TotalKick", PlayerPrefs.GetInt("TotalKick")+1);
            PlayerPrefs.SetInt("TotalKills", PlayerPrefs.GetInt("TotalKills") + 1);

        }
    }
}
