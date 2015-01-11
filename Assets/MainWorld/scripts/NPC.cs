using UnityEngine;
using System.Collections;

public class NPC : character {

	//boolean for whether the ai is interacting with the player or not
	public bool interact;
	public float range;
	public Vector3 target;
	public GameObject playGame;

	public string gameName;
	// Use this for initialization
	void Start ()
		{
		base.Start ();
		BoxCollider col = GetComponent<BoxCollider> ();
		col.size = new Vector3 (range,transform.localScale.y, range);
		interact = false;
		target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

		//if dealing with the player
		if (interact) {

			//face the player
			facePlayer ();
			playGame.SetActive (true);
				}

		//else perform some other action
		else if (!interact) {
			playGame.SetActive (false);

			//do regular animation

				}
	}
	

	void OnTriggerEnter(Collider collision)
	{
		Debug.Log ("hi");
		if (collision.tag == "Player") {
						interact = true;
						target = collision.transform.position;
						Debug.Log (collision.name);
				}

	}

	void OnTriggerExit(Collider collision)
	{
		Debug.Log ("bye");
		interact = false;
	}

	public void facePlayer()
	{
		float tempX = transform.position.x - target.x;
		float tempZ = transform.position.z - target.z;

		float radians = Mathf.Atan2 (tempX, tempZ);
		float angle = radians * 180 / Mathf.PI - 90;

		transform.eulerAngles = new Vector3 (transform.rotation.x,angle, transform.rotation.z);

	}

	public void StartGame()
	{
		Application.LoadLevel (gameName);
	}

}
