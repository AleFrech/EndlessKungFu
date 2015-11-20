using UnityEngine;
using System.Collections;

public class lvl : MonoBehaviour {

    public  AudioSource background_sound;
    public  AudioClip backgroundClip;

    // Use this for initialization
    void Start () {
        background_sound = gameObject.AddComponent<AudioSource>();
        backgroundClip = (AudioClip)Resources.Load("Sounds/Background_Music");
        background_sound.clip = backgroundClip;
    }
	
	// Update is called once per frame
	void Update () {
        if(!background_sound.isPlaying)
	         background_sound.Play();
	}
}
