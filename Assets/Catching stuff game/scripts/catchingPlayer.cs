using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class catchingPlayer : MonoBehaviour {
	
	public float movementSpeed;
	public Vector3 targetPosition;
	public Vector3 direction;
	public float distance;

	public GameObject points;
	public float health;
	public float score;
	// Use this for initialization
	void Start () {
		direction = new Vector3 (0, 0, 0);
		score = 0;
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
		points.GetComponent<Text> ().text = score.ToString ();

		if (Input.GetMouseButton (0)) {
			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit))
			{
				targetPosition = hit.point;
				targetPosition.y = transform.position.y;
				targetPosition.z =transform.position.z;
			}
				}

		//target.transform.position = targetPosition;
		//

		distance = targetPosition.x - transform.position.x;
		//transform.LookAt (targetPosition);
		if (distance > 1) {
						direction.x = 1;

				}
		else if (distance < -1) {
			direction.x = -1;
				}

		if (distance <1 && distance > -1 ){
			direction = new Vector3(0,0,0);
				}
		transform.Translate (direction * movementSpeed * Time.deltaTime);


		if (health <= 0) {
			//you lose
				}
	}
}
