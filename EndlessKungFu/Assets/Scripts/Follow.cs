using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform target;
  //  public Camera Cam1; // where you will set your default ( main ) camera
    void Start()
    {
  //     Cam1.aspect = (Screen.currentResolution.width / Screen.currentResolution.height); //so this would stretch the game scene in order to adjust it to the Device's screen }
    
    }
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(target.transform.position.x,this.transform.position.y,this.transform.position.z);
	}
}
