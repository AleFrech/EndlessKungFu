using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    public Button nextButton;
    public Button backButton;

    // Use this for initialization
    void Start()
    {
        nextButton = nextButton.GetComponent<Button>();
        backButton = backButton.GetComponent<Button>();
    }

    void update()
    {

    }


    public void backToMenu()
    {
        Application.LoadLevel(0);
    }

    public void nextPages()
    {
        Debug.Log("Yes");
    }
}
