using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spawner_Time : MonoBehaviour
{
    public GameObject LevelManager;
    public lvl LevelManagerScript;
    public GameObject[] objectToSpawn;
    public float TimeElapsed;
    public float TimeLimit;
    public float TimeLimitOffset = 0;
    public float TimeLimitOffsetRange = 0;
    public bool isTimer;
    public int whatObject = 0;
    public int whatObjectCorrespondant = 0;
    

    // Use this for initialization
    void Start()
    {
        TimeElapsed = 0;

        LevelManager = GameObject.Find("Level");
        LevelManagerScript = LevelManager.GetComponent<lvl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lvl.isPlayed)
            return;

        if (isTimer)
        {
            if (TimeElapsed >= (TimeLimit + TimeLimitOffset - LevelManagerScript.Difficulty))
            {
                Spawn();
                TimeLimitOffset = Random.Range(0, TimeLimitOffsetRange);
                TimeElapsed = 0;
            }

            
            TimeElapsed += Time.deltaTime;

        }
    }

    void Spawn()
    {
        var ObjectSpawned = (GameObject) Instantiate(objectToSpawn[whatObject]);
        whatObject = Random.Range(0, objectToSpawn.Length);
        Debug.Log(objectToSpawn.Length);
        ObjectSpawned.transform.position = this.transform.position;
        ObjectSpawned.transform.parent = LevelManager.transform;
    }
}
