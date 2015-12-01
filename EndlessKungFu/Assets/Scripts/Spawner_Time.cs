using UnityEngine;
using System.Collections;

public class Spawner_Time : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn;
    [SerializeField] public float TimeElapsed;
    [SerializeField] public float TimeLimit;
    [SerializeField] public bool isTimer;

	// Use this for initialization
	void Start ()
	{
	    TimeElapsed = 0;
	    TimeLimit = 10;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (isTimer)
	    {
	        if (TimeElapsed >= TimeLimit)
	        {
	            Spawn();
	            TimeElapsed = 0;
	        }
	        TimeElapsed += Time.deltaTime;
	    }
    }

    void Spawn()
    {
        //Pueden Modificar Esto para otras validaciones.
        var ObjectSpawned =(GameObject)Instantiate(objectToSpawn);
		ObjectSpawned.transform.position = this.transform.position;
		ObjectSpawned.transform.parent = this.transform;
    }
}
