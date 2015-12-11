using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public lvl LevelManager;
	public bool Enabled;
	// Use this for initialization
	void Start () 
	{
		LevelManager = GameObject.Find ("Level").GetComponent<lvl> ();
		Enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("WHAT");
        if (col.transform.tag == "Player" && Enabled)
        {
            Debug.Log("Spawning Bitches");
            LevelManager.SpawnNewBlock();
            Enabled = false;
        }
    }
}
