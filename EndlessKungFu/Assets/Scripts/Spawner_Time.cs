using UnityEngine;
using System.Collections;

public class Spawner_Time : MonoBehaviour
{
    public GameObject[] objectToSpawn;
    public float TimeElapsed;
    public float TimeLimit;
    public float TimeElapsedForRefresh = 0;
    public float TimeLimitForRefresh = 1;
    public bool isRefreshed;
    public bool isTimer;
    //public bool canSpawn = true;
    public int whatObject = 0;
    public int whatObjectCorrespondant = 0;

    // Use this for initialization
    void Start()
    {
        TimeElapsed = 0;
        isRefreshed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
            if (TimeElapsed >= TimeLimit)
            {
                Spawn();
                TimeElapsed = 0;
            }
            TimeElapsed += Time.deltaTime;


            if (!isRefreshed)
            {
                TimeElapsedForRefresh += Time.deltaTime;
            }
            if (TimeElapsedForRefresh >= TimeLimitForRefresh)
            {
                isRefreshed = true;
                TimeElapsedForRefresh = 0;
            }
        }
    }

    void Spawn()
    {
        var ObjectSpawned = (GameObject) Instantiate(objectToSpawn[whatObject]);
        ObjectSpawned.transform.position = this.transform.position;
        ObjectSpawned.transform.parent = this.transform;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player" && isRefreshed)
        {
            int x = whatObject;
            whatObject = whatObjectCorrespondant;
            whatObjectCorrespondant = x;
            isRefreshed = false;
            //canSpawn = true;
        }
    }


    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.transform.tag == "Player")
    //    {
    //        canSpawn = false;
    //    }
    //}

}
