using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class Menu : MonoBehaviour
{

    public Button playButton;
    public Button exitButton;
    public AudioSource background_sound;
    public AudioClip backgroundClip;

    // Use this for initialization
    void Start ()
	{
	    playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        background_sound = gameObject.AddComponent<AudioSource>();
        backgroundClip = (AudioClip)Resources.Load("Sounds/Game_Start");
        background_sound.clip = backgroundClip;
    }

    void update()
    {

    }


    public void playGame()
    {
        //background_sound.Play();
        Application.LoadLevel(1);
    }

    public void viewScores()
    {
        Application.LoadLevel(2);
    }

    public void exitGame()
    {
        Application.Quit();
    }

  
}
