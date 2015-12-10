using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    private Player playerController;
    private Canvas Scene;
    public Text ScoreText;
    public static int score;
    void Start ()
    {

        ScoreText.text = score.ToString();
        SaveScore(score);

    }
	void Update ()
    {

    }
    public void backToMenu()
    {
        Application.LoadLevel(0);
    }
    void SaveScore(int newScore)
    {
        var score1 = PlayerPrefs.GetInt("Score1");
        var score2 = PlayerPrefs.GetInt("Score2");
        var score3 = PlayerPrefs.GetInt("Score3");

        if (newScore > score1)
        {
            PlayerPrefs.SetInt("Score3", score2);
            PlayerPrefs.SetInt("Score2", score1);
            PlayerPrefs.SetInt("Score1", newScore);
            return;

        }
        if (newScore > score2)
        {
            PlayerPrefs.SetInt("Score3", score2);
            PlayerPrefs.SetInt("Score2", newScore);
            return;

        }
        if (newScore > score3)
        {
            PlayerPrefs.SetInt("Score3", newScore);
            return;
        }
    }
}
