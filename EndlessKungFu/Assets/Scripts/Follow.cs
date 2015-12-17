using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform target;
    void Start()
    {
   
    }

	void Update () {
		this.transform.position = new Vector3(target.transform.position.x,this.transform.position.y,this.transform.position.z);
	}
}
