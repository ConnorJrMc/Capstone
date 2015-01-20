using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {
	public Vector3 direction;
	public float height;
	public GameObject score;
	public Camera cam;
	public float speed;

	protected CharacterController control;
	// Use this for initialization
	void Start () {

		control = GetComponent<CharacterController> ();
		height = 0;
		speed = 4;
	}
	
	// Update is called once per frame
	void Update () {
				//adjust camera to follow the player
		Vector3 screenPos = cam.WorldToScreenPoint (transform.position);
		if (screenPos.y > 300) {
						cam.transform.position =  new Vector3(cam.transform.position.x,
														transform.position.y,
			                                 			cam.transform.position.z);
				}
		//move left and right with gyroscope
		Vector3 Dir = Vector3.zero;
		Dir.x = Input.acceleration.x;
		Dir.y = 1;

		rigidbody.velocity.Scale (Dir);


		//update the score to display the highest hight acheived
		if (transform.position.y > height)
						height = transform.position.y;

		score.GetComponent<Text> ().text = height.ToString ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag != "Player") {
			//if player collides with a cloud, apply upwards force
			float temp = col.gameObject.GetComponent<cloud>().force;

			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.AddForce (transform.up * (temp * 100) , ForceMode.Acceleration);
		}
	}




}
