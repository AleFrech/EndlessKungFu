using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    public Button backButton;
    public Text Score1;
    public Text Score2;
    public Text Score3;
    // Use this for initialization
    void Start()
    {
        LoadScore();
    }

    void update()
    {
       
    }


    public void backToMenu()
    {
        Application.LoadLevel(0);
    }

    void LoadScore()
    {
        Score1.text = PlayerPrefs.GetInt("Score1").ToString();
        Score2.text = PlayerPrefs.GetInt("Score2").ToString();
        Score3.text = PlayerPrefs.GetInt("Score3").ToString();
    }
}
