using UnityEngine;
using System.Collections;

public class ballon : MonoBehaviour {

	public bool good;
	public float points;
	public float speed;

	public float directionX;


	public Vector3 direction;
	public GameObject totalPoints;

	// Use this for initialization
	void Start () {
		if (good) {
						points = 1;
				}
		if (!good) {
						points = 1;
				}
		speed = Random.Range (1, 5);

		transform.position = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width/2, 0, 4));
		//constantForce.force = new Vector3  (directionX / 100,1,0);


		direction = new Vector3 (directionX / 100, 1, 0);
		totalPoints = GameObject.Find ("Text");
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate ((direction * speed) * Time.deltaTime);

		//if you click on a balllooon
		if (Input.GetMouseButton (0)) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider !=null && hit.collider.gameObject == gameObject )
			{
				Destroy(gameObject);
				if(good)
					totalPoints.GetComponent<balloonScore>().totalScore = totalPoints.GetComponent<balloonScore>().totalScore - 1;
			}
				
		}

		Vector3 worldPos = Camera.main.WorldToScreenPoint(transform.position);
		//if the balloon goes of the screen;
		if ((worldPos.y > Screen.height) || ( worldPos.x < 0) || (worldPos.x > Screen.width) ){
			if(good)
				totalPoints.GetComponent<balloonScore>().totalScore++;
			else
				totalPoints.GetComponent<balloonScore>().totalScore = totalPoints.GetComponent<balloonScore>().totalScore - 1;

			Destroy (gameObject);
		
		}

	}
}
