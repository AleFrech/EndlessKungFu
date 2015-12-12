using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour {
    public Button backButton;
    public Text TotalKills;
    public Text TotalPunch;
    public Text TotalKick;
    // Use this for initialization
    void Start () {
	    LoadStats();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void backToMenu()
    {
        Application.LoadLevel(0);
    }

    void LoadStats()
    {
        TotalKick.text = PlayerPrefs.GetInt("TotalKick").ToString();
        TotalKills.text = PlayerPrefs.GetInt("TotalKills").ToString();
        TotalPunch.text = PlayerPrefs.GetInt("TotalPunch").ToString();
    }

}
