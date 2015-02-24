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

	public float zPosition;
	// Use this for initialization
	void Start () {

		zPosition = 0.2f;
		control = GetComponent<CharacterController> ();
		height = 0;
		speed = 4;

		constantForce.force = (Vector3.up * -3);
	}
	
	// Update is called once per frame
	void Update () {

		//rigidbody.transform.position.Set (transform.position.x, transform.position.y, 0.2f);
				//adjust camera to follow the player
		Vector3 screenPos = cam.WorldToScreenPoint (transform.position);
		if (screenPos.y > 200) {
						cam.transform.position =  new Vector3(cam.transform.position.x,
													transform.position.y,
			                                 			cam.transform.position.z);
				}
		if (screenPos.y < -40) {
			//player has died
			//show score
			//show losing screen
			//load game menu
				Application.LoadLevel ("cloudMenu");
			int scoreTemp  =  PlayerPrefs.GetInt("score");
			scoreTemp++;
			PlayerPrefs.SetInt("score",scoreTemp);
				}
		//move left and right with gyroscope
		Vector3 Dir = Vector3.zero;
		Dir.x = Input.acceleration.y;
		Dir.y = 1;

		rigidbody.velocity.Scale (Dir);


		//update the score to display the highest hight acheived
		if (transform.position.y > height)
						height = transform.position.y;

		float temp = height * 10;
		int temp1 = (int)temp;
		score.GetComponent<Text> ().text = "Score:"+temp1.ToString ();


		//controls for pc
		if (Input.GetKey (KeyCode.RightArrow)) {
			rigidbody.AddForce (new Vector3(speed,0,0));

				}

		if(Input.GetKey (KeyCode.LeftArrow)){
			rigidbody.AddForce (new Vector3(-speed,0,0));
		}

		//gyroscope controls for android
		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		if (dir.sqrMagnitude > 1)
						dir.Normalize ();

		rigidbody.AddForce (dir * speed);

		//if the player hits the sides of the screen
		Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);

		Vector3 newPos;
		if (camPos.x <= -3) {
						newPos = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));
			newPos.y = transform.position.y;
			newPos.z = transform.position.z;
			transform.position = newPos;
				}
		if (camPos.x >= Screen.width + 3) {
						newPos = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0,0));
			newPos.y = transform.position.y;
			newPos.z = transform.position.z;
			transform.position = newPos;
				}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag != "Player") {
			//if player collides with a cloud, apply upwards force
			float temp = col.gameObject.GetComponent<cloud>().force;

			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;

			rigidbody.AddForce (new Vector3(0,1,0) * (temp * 50) , ForceMode.Acceleration);


		}
	}




}
