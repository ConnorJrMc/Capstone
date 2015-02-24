using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class rope : MonoBehaviour {

	public int Score;
	public Vector3 point;
	public GameObject CurrentScore;
	public Vector3 startPos;
	public float speed;
	// Use this for initialization
	void Start () {
		Score = 0;
		point = new Vector3 (0, 2.5f, 0);
		startPos = transform.position;
		speed = 1;
	}
	
	// Update is called once per frame
	void Update () {

		//rotate around a point

		transform.RotateAround (point, new Vector3(1,0,0), 1);
		//upon a complete rotation
		if (transform.position == startPos) {
						Score++;
			speed  = speed + Score/10;
				}
		CurrentScore.GetComponent<Text> ().text = Score.ToString ();
	}
}
