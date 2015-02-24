using UnityEngine;
using System.Collections;

public class JumpPlayer : MonoBehaviour {

	public float jump;
	public bool isJumping;
	// Use this for initialization
	void Start () {

		isJumping = false;
		jump = 4;
		constantForce.force = new Vector3(0,-14.0f,0);
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

	void OnTriggerEnter(Collider col)
	{
				//if player gets hit by the rope, end the game
				//if player hits the landing collider
				if (col.name == "landing") {
						isJumping = false;
				}

				if (col.name == "rope") {
						//you hit the rope and lose
					Debug.Log ("you lost");
					//Application.LoadLevel ("jumpRopeMenu");
				}
		}
	
}
