using UnityEngine;
using System.Collections;

public class lvl : MonoBehaviour {

    public  AudioSource background_sound;
    public  AudioClip backgroundClip;
	public GameObject[] listBlocks;
	public GameObject Current;
	public GameObject Next;
    public AudioSource BackgroundSoundAudioSource;
    public AudioClip BackgroundClip;
    public static bool isPlayed = false;
    public float DifficultyProgress;
    public int Difficulty;

    
    // Use this for initialization
    void Start()
    {
        isPlayed=false;
        BackgroundSoundAudioSource = gameObject.AddComponent<AudioSource>();
        BackgroundClip = (AudioClip)Resources.Load("Sounds/Game_Start");
        BackgroundSoundAudioSource.clip = BackgroundClip;
        BackgroundSoundAudioSource.Play();
        background_sound = gameObject.AddComponent<AudioSource>();
        backgroundClip = (AudioClip)Resources.Load("Sounds/Background_Music");
        Invoke("Startlvl",5.0f);
       
    }

    void Startlvl()
    {
      
        Current = GameObject.Find(listBlocks[0].name);
        background_sound.clip = backgroundClip;
        Current.transform.FindChild("SpawnPointActivator").GetComponent<SpawnPointActivator>().isnotStartPoint = false;
        isPlayed = true;

    }


	// Update is called once per frame
	void Update ()
	{
        if(!background_sound.isPlaying)
	         background_sound.Play();
	}

    public void CalculateDifficulty()
    {
        if (DifficultyProgress > 0 && DifficultyProgress%2 == 0)
        {
            DifficultyProgress = 0;
            Difficulty += 1;
        }
    }

	public void SpawnNewBlock()
	{
		var blockToSpawn = Random.Range (0, listBlocks.Length-1);
		Next = (GameObject)Instantiate (listBlocks [blockToSpawn]);
		Next.transform.position = Current.transform.FindChild ("PointToSpawn").transform.position;
	}
}
