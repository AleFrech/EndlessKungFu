using UnityEngine;
using System.Collections;

public class lvl : MonoBehaviour {

    public  AudioSource background_sound;
    public  AudioClip backgroundClip;
	public GameObject[] listBlocks;
	
	public GameObject Current;
	public GameObject Next;

    // Use this for initialization
    void Start () {
        background_sound = gameObject.AddComponent<AudioSource>();
        backgroundClip = (AudioClip)Resources.Load("Sounds/Background_Music");
        background_sound.clip = backgroundClip;

		Current = GameObject.Find (listBlocks [0].name);
		Current.transform.FindChild ("SpawnPointActivator").GetComponent<SpawnPointActivator> ().isnotStartPoint = false;

    }
	
	// Update is called once per frame
	void Update ()
	{
        if(!background_sound.isPlaying)
	         background_sound.Play();
	}

	public void SpawnNewBlock()
	{
		var blockToSpawn = Random.Range (0, listBlocks.Length-1);
		Next = (GameObject)Instantiate (listBlocks [blockToSpawn]);
		Next.transform.position = Current.transform.FindChild ("PointToSpawn").transform.position;
	}
}
