using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    private Canvas Scene;
    public Text ScoreText;
    // Use this for initialization
    void Start ()
    {
        ScoreText.text = Score.score.ToString();

    }
	
	// Update is called once per frame
	void Update () {
    }


    public void backToMenu()
    {
        Application.LoadLevel(0);
    }

    public void enterScore()
    {
        Debug.Log("Yes");
    }

}
