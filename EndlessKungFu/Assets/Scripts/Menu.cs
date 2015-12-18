using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class Menu : MonoBehaviour
{

    public Button playButton;
    public Button exitButton;

    // Use this for initialization
    void Start ()
	{
	    playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();     
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

    public void viewStats()
    {
        Application.LoadLevel(4);
    }

    public void exitGame()
    {
        Application.Quit();
    }

  
}
