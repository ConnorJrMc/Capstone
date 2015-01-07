using UnityEngine;
using System.Collections;

public class exit : MonoBehaviour {

	public string link;
	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider collision){
		Application.LoadLevel (link);
	}


}
