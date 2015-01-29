using UnityEngine;
using System.Collections;

public class JumpPlayer : MonoBehaviour {

	public float jump;
	public bool isJumping;
	// Use this for initialization
	void Start () {

		isJumping = false;
		jump = 7;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetMouseButtonDown (0)) && (!isJumping)){
			//player jumps 
			isJumping = true;
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.AddForce(transform.up*(jump * 100),ForceMode.Acceleration);
				}

	}

	void OnCollisionTrigger(Collision col)
	{
				//if player gets hit by the rope, end the game

				//if player hits the landing collider
				if (col.gameObject.name == "landing") {
						Debug.Log ("landing");
						isJumping = false;
				}
		}
	
}
