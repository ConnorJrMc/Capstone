using UnityEngine;
using System.Collections;

public class entrance : MonoBehaviour {

	public GameObject player;
	public GameObject Dpad;
	// Use this for initialization
	void Start () {
	
		Vector3 temp = transform.position;
		player.name = "ThePlayer";
		Instantiate (player, temp, Quaternion.identity);
		Dpad.GetComponent<dpad> ().GetPlayer ();

	}
}
