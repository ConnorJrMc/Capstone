using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public Vector3 direction;
	public float height;
	// Use this for initialization
	void Start () {
		height = 0;
	}
	
	// Update is called once per frame
	void Update () {


		//move left and right with gyroscope

		//update the score to display the highest hight acheived
		if (transform.position.y > height)
						height = transform.position.y;
	}

	void OnCollisionEnter(Collision col)
	{
		//if player collides with a cloud, apply upwards force
		Vector3 forceVec = -rigidbody.velocity.normalized * 4;
		rigidbody.AddForce (forceVec, ForceMode.Acceleration);
	}


}
