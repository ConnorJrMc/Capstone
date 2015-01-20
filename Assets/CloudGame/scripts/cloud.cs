using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour {
	public bool good;
	public float force;
	public int cloudID;
	public GameObject player;
	public Camera cam;
	// Use this for initialization
	void Start () {
		good = true;
		cam = GameObject.Find ("Main Camera").camera;
		//the force the cloud applies to the player when hit
		if (good)
						force = 5;
				else
						force = 1;
	}
	
	// Update is called once per frame
	void Update () {

		//if player is above the cloud, turn on the collider
		if (player.transform.position.y > transform.position.y) {;
						GetComponent<BoxCollider> ().enabled = true;
		}

		//if player is below the cloud, turn off the collider
		if (player.transform.position.y < transform.position.y)
			GetComponent<BoxCollider>().enabled  = false;
					//if the cloud is below the screen destroy it


		//if cloud is below the screen, destroy the cloud
		Vector3 screenPos = cam.WorldToScreenPoint (transform.position);
		if (screenPos.y < -20) {
						Destroy (gameObject);
						cam.GetComponent<cloudGame> ().clouds.RemoveAt (cloudID);
				}
	}
}
