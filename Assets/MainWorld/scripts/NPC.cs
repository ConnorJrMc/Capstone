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
		col.size = new Vector3 (col.size.x*range,col.size.y,(col.size.z*range)*2);
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
		if (collision.tag == "Player") {
						interact = true;
						target = collision.transform.position;
						Debug.Log (collision.name);
				}

	}

	void OnTriggerExit(Collider collision)
	{
		interact = false;
	}

	public void facePlayer()
	{
		Vector3 temp = target;
		temp.y = transform.position.y;

		transform.LookAt (temp);

	}

	public void StartGame()
	{
		Application.LoadLevel (gameName);
	}

}
