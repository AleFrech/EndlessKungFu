using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{

    // Use this for initialization
    private Player playerController;
    public EventTrigger trigger;
    public static bool walkLeft;
    public static bool walkright;
    public static bool crouch;
    public static bool punch;
    public static bool kick;
    public float timeWalkleft;
    public float timeWalkright;
    public float timecrouching;
    public float timepunching;
    public float timekicking;
    void Start()
    {
        trigger = GetComponent<EventTrigger>();
        GameObject playercontrollerObject = GameObject.FindWithTag("Player");

        if (playercontrollerObject != null)
        {
            playerController = playercontrollerObject.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (walkLeft)
        {
            timeWalkleft += Time.deltaTime;
            playerController.Move(-1);
        }
        if (walkright)
        {
            timeWalkright += Time.deltaTime;
            playerController.Move(1);
        }
        if (crouch)
        {
            timecrouching += Time.deltaTime;
            playerController.Crouch(1);
        }
        if (punch)
        {
            timepunching += Time.deltaTime;
            playerController.Punch(1);
        }
        if (kick)
        {
            timekicking += Time.deltaTime;
            playerController.Kick(1);
        }

    }

    public void Moveleft()
    {
        walkLeft = true;
        
    }

    public void StopLeft()
    {
        walkLeft = false;
        timeWalkleft = 0;
    }
    public void Moveright()
    {
        walkright = true;
    }
    public void StopRight()
    {
        walkright = false;
        timeWalkright = 0;
    }

    public void Jump()
    {
        playerController.Jump(1);
    }

    public void Crouch()
    {
        crouch = true;
    }

    public void StopCrouch()
    {
        crouch = false;
        timecrouching = 0;
    }

    public void Punch()
    {
        punch = true;
    }

    public void StopPunch()
    {
        punch = false;
        timepunching = 0;
    }
    public void Kick()
    {
        kick = true;
   
    }
    public void StopKick()
    {
        kick = false;
        timekicking = 0;

    }

}