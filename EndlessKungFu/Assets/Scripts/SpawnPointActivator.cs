using UnityEngine;
using System.Collections;

public class SpawnPointActivator : MonoBehaviour {

	public lvl LevelManager;
	public bool Enabled;
	public bool isnotStartPoint;
	
	public GameObject[] SpawnPointList;
	void Start () {
		LevelManager = GameObject.Find ("Level").GetComponent<lvl> ();
		isnotStartPoint = true;
		Enabled = true;

		for (int i = 0; i< SpawnPointList.Length; i++) 
		{
			SpawnPointList[i].GetComponent<Spawner_Time>().enabled = true;
		}
	}
	
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.transform.tag == "Player" && isnotStartPoint && Enabled)
		{
			Debug.Log("Spawning Cunts");
		    LevelManager.DifficultyProgress += .5f;
		    LevelManager.CalculateDifficulty();
			Destroy(LevelManager.Current);
			LevelManager.Current = LevelManager.Next;
			Enabled = false;

		}
	}
}
