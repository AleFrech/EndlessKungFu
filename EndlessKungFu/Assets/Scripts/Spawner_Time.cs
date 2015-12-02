using UnityEngine;
using System.Collections;

public class Spawner_Time : MonoBehaviour
{
    [SerializeField] public GameObject[] objectToSpawn;
    [SerializeField] public float TimeElapsed;
    [SerializeField] public float TimeLimit;
    [SerializeField] public float TimeElapsedForRefresh = 0;
    [SerializeField] public float TimeLimitForRefresh = 1;
    [SerializeField] public bool isRefreshed;
    [SerializeField] public bool isTimer;
    public int whatObject = 0;
    public int whatObjectCorrespondant = 0;

    // Use this for initialization
    void Start()
    {
        TimeElapsed = 0;
        TimeLimit = 10;
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
        //Pueden Modificar Esto para otras validaciones.
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
        }
    }

}
