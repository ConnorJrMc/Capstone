using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour {
	public bool good;
	public float force;
	public int cloudID;
	public GameObject player;
	public Camera cam;

	public Texture goodTexture;
	public Texture badTexture;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera").camera;
		//the force the cloud applies to the player when hit
		if (good) {
						force = 5f;
					renderer.material.mainTexture = goodTexture;
			//GetComponentInChildren<TextMesh>().text = ;
				} else {
						force = 1;
					renderer.material.mainTexture = badTexture;
		//	GetComponentInChildren<TextMesh>().text = ;
				}
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
