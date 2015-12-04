using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ButtonController : MonoBehaviour
{

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

    public void moverlef()
    {
        playerController.moveHorizontal(-10);
    }
    public void moverigth()
    {
        playerController.moveHorizontal(10);
    }

}