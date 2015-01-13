using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour {
	public bool good;
	public float force;

	public GameObject player;
	public Camera cam;
	// Use this for initialization
	void Start () {
		good = true;
		//the force the cloud applies to the player when hit
		if (good)
						force = 5;
				else
						force = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > transform.position.y)
						GetComponent<BoxCollider> ().enabled = true;


					//if the cloud is below the screen destroy it
			Vector3 screenPos = cam.WorldToScreenPoint (transform.position);
		if (screenPos.y < -20)
						Destroy (gameObject);
	}
}
